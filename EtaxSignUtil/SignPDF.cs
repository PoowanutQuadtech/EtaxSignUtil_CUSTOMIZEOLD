using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text.pdf.security;
using iTextSharp.text.pdf;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using iTextSharp.text;
using iTextSharp.awt.geom;
using System.Security;
using System.Net;
using System.Threading;
using System.Data;
using DBUtil;
using ModuleUtil;
using System.Text.RegularExpressions;
using UtilityHelper;

namespace EtaxSignUtil
{
    public class SignPDF
    {
        private DBUtil.DBSimple DBSimple { get; set; }
        private QEB.Center CenterInfo { get; set; }
        private DataTable TBAPIService { get; set; }
        private DataTable TBAPIServiceInfo { get; set; }
        private string ServiceName => "Etax";
        private bool UseAPI { get; set; } = false;
        public SignPDF(DBUtil.DBSimple dBSimple, QEB.Center center)
        {
            this.DBSimple = dBSimple;
            this.CenterInfo = center;
            this.InitTable();
        }
        private void InitTable()
        {
            DataSet QEBds = new DataSet();
            TableDefCreateStore TBStore = new TableDefCreateStore();
            TBStore.Add(new TableCreatedDef("APIService", new string[] { }, true, false));
            TBStore.Add(new TableCreatedDef("APIServiceInfo", new string[] { }, true, false));
            this.DBSimple.CreateArrayDataTable(QEBds, ref TBStore);

            this.TBAPIService = QEBds.Tables["APIService"];
            this.TBAPIServiceInfo = QEBds.Tables["APIServiceInfo"];
            if (this.TBAPIService != null && this.TBAPIServiceInfo != null)
            {
                string Query = $"SELECT * FROM APIService WHERE Service = '{ServiceName}' AND UseValue = 1";
                this.DBSimple.FillData(this.TBAPIService, Query);
                string QueryInfo = $"SELECT * FROM APIServiceInfo WHERE Service = '{ServiceName}' AND UseValue = 1";
                this.DBSimple.FillData(this.TBAPIServiceInfo, QueryInfo);
                if (this.TBAPIService.Rows.Count > 0)
                {
                    this.UseAPI = true;

                    DataRow rowService = this.TBAPIService.Rows[0];
                    string URL = ReceiveValue.StringReceive("URL", rowService);
                    if (URL.Contains("$servername"))
                    {
                        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Server001.cfg");
                        try
                        {
                            string fileContents = File.ReadAllText(filePath);
                            string pattern = @"URLBASE=(.*?)$";
                            Match match = Regex.Match(fileContents, pattern, RegexOptions.Multiline);

                            if (match.Success)
                            {
                                string urlBase = match.Groups[1].Value;
                                urlBase = urlBase.Replace("http://", "");
                                urlBase = urlBase.Replace("https://", "");
                                urlBase = urlBase.Replace("\r", "");
                                urlBase = urlBase.Replace("\n", "");
                                string[] list = urlBase.Split(new string[] { "\\", ":", "/" }, StringSplitOptions.RemoveEmptyEntries);
                                if (list.Length > 0)
                                {
                                    string ip = list[0];

                                    URL = URL.Replace("$servername", ip);
                                    rowService.BeginEdit();
                                    rowService["URL"] = URL;
                                    rowService.EndEdit();
                                }
                            }
                        }
                        catch { }
                    }
                }
            }
        }
        public int SignWithCert(bool UseEtax, TokenInfo token, string CompanyName, DateTime DateSign, string filepath, string filetemp, float x, float y, float width, float height, bool IsTestSign, ref string ErrMsg)
        {
            int TransErr = 0;
            try
            {
                X509Certificate2 cert = null;
                if (IsTestSign)
                    TransErr += this.GetCertTest(ref cert, ref ErrMsg);
                else
                    TransErr += this.GetCert(token, ref cert, ref ErrMsg);
                if (TransErr == 0)
                {
                    byte[] result = null;
                    System.Drawing.Bitmap bitmap = Properties.Resources.etax_new;
                    if (bitmap != null)
                    {
                        MemoryStream stream = new MemoryStream();
                        bitmap.Save(stream, bitmap.RawFormat);
                        result = stream.ToArray();
                    }
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(result);
                    image.SetAbsolutePosition(0, 0);

                    int errFont = 0;
                    Font font = UtilityClass.GetThaiFont();
                  
              
                    font.Size = 10;

                    System.util.RectangleJ recJ = new System.util.RectangleJ(x, y, width, height);
                    iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(recJ);
                   
                    StringBuilder Layer2Text = new StringBuilder();
                    Layer2Text.Append("Digitally Signed by ");
                    Layer2Text.Append(CompanyName).Append('\n');
                    Layer2Text.Append("Date: ").Append(DateSign.ToString("dd-MM-yyyy HH:mm:ss zzz"));
                    string valueText = Layer2Text.ToString();
                   

                    PdfReader pdfReader = new PdfReader(filetemp);
                    FileStream signedPdf = new FileStream(filepath, FileMode.Create);
                    PdfStamper pdfStamper = PdfStamper.CreateSignature(pdfReader, signedPdf, '\0');
                    PdfSignatureAppearance appearance = pdfStamper.SignatureAppearance;
                    appearance.Acro6Layers = true;
                    appearance.SignDate = DateSign;
                    appearance.Reason = "";
                    appearance.Location = "";
                    appearance.SetVisibleSignature(rec, pdfReader.NumberOfPages, "Signature");

                    float size = font.Size;
                    float MARGIN = 2;
                    Rectangle dataRect = new Rectangle(
                            MARGIN,
                            MARGIN,
                            appearance.Rect.Width - MARGIN,
                            appearance.Rect.Height - MARGIN);
                    if (size <= 0)
                    {
                        Rectangle sr = new Rectangle(dataRect.Width, dataRect.Height);
                        size = ColumnText.FitText(font, valueText, sr, 12, appearance.RunDirection);
                    }

                    PdfTemplate layer2 = appearance.GetLayer(2);
                    if (UseEtax)
                    {
                        ColumnText ct = new ColumnText(layer2);
                        ct.RunDirection = PdfWriter.RUN_DIRECTION_LTR;
                        Chunk chunkImage = new Chunk(image, 0, 0, true);
                        ct.SetSimpleColumn(new Phrase(chunkImage), dataRect.Left, dataRect.Bottom, dataRect.Right, dataRect.Top, size, Element.ALIGN_LEFT);
                        ct.Go();
                    }
                    ColumnText ct2 = new ColumnText(layer2);
                    ct2.RunDirection = PdfWriter.RUN_DIRECTION_LTR;
                    ct2.SetSimpleColumn(new Phrase(valueText.ToString(), font), dataRect.Left + 40, dataRect.Bottom, dataRect.Right, dataRect.Top - 5, size, Element.ALIGN_LEFT);
                    ct2.Go();

                   

                    Org.BouncyCastle.X509.X509CertificateParser cp = new Org.BouncyCastle.X509.X509CertificateParser();
                    Org.BouncyCastle.X509.X509Certificate[] chain = new Org.BouncyCastle.X509.X509Certificate[] { cp.ReadCertificate(cert.RawData) };
                    IExternalSignature externalSignature = new X509Certificate2Signature(cert, "SHA-1");
                    MakeSignature.SignDetached(appearance, externalSignature, chain, null, null, null, 0, CryptoStandard.CMS);
                    
                    
                }
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                if (ex.InnerException != null)
                {
                    ErrMsg += Environment.NewLine;
                    ErrMsg += ex.InnerException.Message;
                }
                ErrMsg += Environment.NewLine;
                ErrMsg += ex.StackTrace;
                TransErr++;
            }
            return TransErr;
        }
   
        private SecureString GetSecurePin(string PinCode)
        {
            SecureString pwd = new SecureString();
            foreach (var c in PinCode.ToCharArray()) pwd.AppendChar(c);
            return pwd;
        }


        private int GetCert(TokenInfo token, ref X509Certificate2 cert, ref string ErrMsg)
        {
            int TransErr = 0;

            string ProviderName = token.NET_ProviderName;
            string ProviderName2 = token.NET_ProviderName2;
            string PinCode = token.Password;
            bool CanAccess = true;

            if (!string.IsNullOrEmpty(PinCode))
            {
                try
                {
                    SecureString pwd = GetSecurePin(PinCode);
                    CspParameters csp = new CspParameters(1,
                                                          ProviderName,
                                                          EtaxSignUtil.Value.Variable.KeyContainerName,
                                                          new System.Security.AccessControl.CryptoKeySecurity(),
                                                          pwd);
                    using (RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider(csp)) { }
                }
                catch
                {
                    CanAccess = false;
                }
            }

            X509Store storeCert = new X509Store(StoreLocation.CurrentUser);
            storeCert.Open(OpenFlags.ReadOnly);

            foreach (X509Certificate2 cert2 in storeCert.Certificates)
            {
                if (!cert2.HasPrivateKey) continue;

                try
                {
                    AsymmetricAlgorithm privateKey = null;

                    try
                    {
                        privateKey = cert2.PrivateKey;
                    }
                    catch (Exception exKey)
                    {
                        ErrMsg = "ไม่สามารถเข้าถึง PrivateKey ของ Certificate ได้: " +
                                 exKey.Message + Environment.NewLine + exKey.StackTrace;
                        return ++TransErr;
                    }

                    var rsa = privateKey as RSACryptoServiceProvider;
                    if (rsa == null)
                    {
                        ErrMsg = "พบ Certificate แต่ไม่สามารถใช้งานได้ (ไม่ใช่ CSP หรือ cast ไม่ได้)";
                        return ++TransErr;
                    }

                    string provider = rsa.CspKeyContainerInfo.ProviderName;

                    if (rsa.CspKeyContainerInfo.HardwareDevice &&
                        (provider == ProviderName || provider == ProviderName2))
                    {
                        string key = rsa.CspKeyContainerInfo.KeyContainerName;
                        cert = cert2;
                        if (EtaxSignUtil.Value.Variable.KeyContainerName != key)
                            EtaxSignUtil.Value.Variable.KeyContainerName = key;

                        ErrMsg = "พบ Certificate ที่ใช้งานได้ - ProviderName: " + provider;
                        return TransErr;
                    }
                    else
                    {
                        ErrMsg = "พบ Certificate ที่ไม่ตรงกับ ProviderName ที่ตั้งไว้" + Environment.NewLine +
                                 "Provider จริงคือ: " + provider + Environment.NewLine +
                                 "กรุณาตรวจสอบค่าที่ตั้งในระบบให้ตรงกับนี้";
                    }
                }
                catch (Exception ex)
                {
                    ErrMsg = "เกิดข้อผิดพลาดระหว่างตรวจสอบ Certificate:" + Environment.NewLine +
                             ex.Message + Environment.NewLine +
                             (ex.InnerException != null ? ex.InnerException.Message + Environment.NewLine : "") +
                             ex.StackTrace;
                    return ++TransErr;
                }
            }

            if (!CanAccess)
            {
                try
                {
                    CspParameters csp = new CspParameters(1, ProviderName);
                    using (RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider(csp)) { }
                }
                catch (Exception ex)
                {
                    ErrMsg = "ไม่สามารถเข้าถึง Token ได้: " + ex.Message;
                    return ++TransErr;
                }
            }

            if (cert == null)
            {
                ErrMsg = "ไม่พบ Certificate ที่ใช้งานได้ในเครื่อง" + Environment.NewLine +
                         "กรุณาตรวจสอบว่า Token ได้ถูกเสียบ และมีใบรับรองอยู่ใน Certificate Store";
                return ++TransErr;
            }

            return TransErr;
        }





        //private int GetCert(TokenInfo token, ref X509Certificate2 cert, ref string ErrMsg)
        //{
        //    int TransErr = 0;

        //    string ProviderName = token.NET_ProviderName;
        //    string ProviderName2 = token.NET_ProviderName2;
        //    string PinCode = token.Password;
        //    bool CanAccess = true;
        //    if (PinCode != "")
        //    {
        //        //if pin code is set then no windows form will popup to ask it
        //        SecureString pwd = GetSecurePin(PinCode);
        //        CspParameters csp = new CspParameters(1,
        //                                                ProviderName,
        //                                                EtaxSignUtil.Value.Variable.KeyContainerName,
        //                                                new System.Security.AccessControl.CryptoKeySecurity(),
        //                                                pwd);
        //        try
        //        {
        //            RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider(csp);
        //            // the pin code will be cached for next access to the smart card
        //        }
        //        catch
        //        {
        //            CanAccess = false;
        //        }
        //    }

        //    X509Store storeCert = new X509Store(StoreLocation.CurrentUser);
        //    storeCert.Open(OpenFlags.ReadOnly);
        //    foreach (X509Certificate2 cert2 in storeCert.Certificates)
        //    {
        //        if (cert2.HasPrivateKey)
        //        {
        //            RSACryptoServiceProvider rsa = null;
        //            try
        //            {
        //                rsa = (RSACryptoServiceProvider)cert2.PrivateKey;
        //            }
        //            catch { }
        //            if (rsa == null)
        //                continue;
        //            if (rsa.CspKeyContainerInfo.HardwareDevice)
        //            {
        //                if (rsa.CspKeyContainerInfo.ProviderName == ProviderName || rsa.CspKeyContainerInfo.ProviderName == ProviderName2)
        //                {
        //                    string key = rsa.CspKeyContainerInfo.KeyContainerName;
        //                    cert = cert2;
        //                    if (EtaxSignUtil.Value.Variable.KeyContainerName != key)
        //                        EtaxSignUtil.Value.Variable.KeyContainerName = key;
        //                    return TransErr;
        //                }
        //            }
        //        }
        //    }

        //    if (!CanAccess)
        //    {
        //        CspParameters csp = new CspParameters(1, ProviderName);
        //        try
        //        {
        //            RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider(csp);
        //        }
        //        catch (Exception ex)
        //        {
        //            ErrMsg = String.Format("Crypto error: {0}", ex.Message);
        //            return ++TransErr;
        //        }
        //    }
        //    X509Store store = new X509Store(StoreLocation.CurrentUser);
        //    store.Open(OpenFlags.ReadOnly);
        //    foreach (X509Certificate2 cert2 in store.Certificates)
        //    {
        //        if (cert2.HasPrivateKey)
        //        {
        //            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)cert2.PrivateKey;
        //            if (rsa == null) continue;
        //            if (rsa.CspKeyContainerInfo.HardwareDevice)
        //            {
        //                if (rsa.CspKeyContainerInfo.ProviderName == ProviderName || rsa.CspKeyContainerInfo.ProviderName == ProviderName2)
        //                {
        //                    string key = rsa.CspKeyContainerInfo.KeyContainerName;
        //                    cert = cert2;
        //                    if (EtaxSignUtil.Value.Variable.KeyContainerName != key)
        //                        EtaxSignUtil.Value.Variable.KeyContainerName = key;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    if (cert == null)
        //    {
        //        ErrMsg = "Certificate not found";
        //        return ++TransErr;
        //    }
        //    return TransErr;
        //}
        private int GetCertTest(ref X509Certificate2 cert, ref string ErrMsg)
        {
            int TransErr = 0;
            var testcertByte = ResourceLoader.LoadEmbeddedResource("testcert.pfx");
            cert = new X509Certificate2(testcertByte, "1234",
                                 X509KeyStorageFlags.MachineKeySet
                               | X509KeyStorageFlags.PersistKeySet
                               | X509KeyStorageFlags.Exportable);
            if (cert == null)
            {
                ErrMsg = "Certificate not found";
                return ++TransErr;
            }
            return TransErr;
        }
        public int GenPDF3A(string pdfFilePath, string xmlFilePath, string FileName, string DocumentType, ref string ErrMsg, ref Exception exception)
        {
            int TransErr = 0;
            string TempErrMsg = "";
            Exception TempException = null;
            try
            {
                if (!this.UseAPI)
                    return TransErr;
                string ActionName = "GeneratePdf";
                DataRow rowService = this.TBAPIService.Rows[0];
                DataRow rowServiceInfo = this.TBAPIServiceInfo.AsEnumerable().FirstOrDefault(x => x.Field<string>("ActionName") == ActionName && x.Field<bool>("UseValue") == true);
                if (rowServiceInfo == null)
                    return TransErr;
                // Create a ManualResetEvent to wait for the response.
                ManualResetEvent waitHandle = new ManualResetEvent(false);

                string URL = ReceiveValue.StringReceive("URL", rowService);
                string token = ReceiveValue.StringReceive("Token", rowService);
                string request_uri = $"{URL}{ActionName}";
                var request = (HttpWebRequest)WebRequest.Create(request_uri);
                request.Method = "POST";
                request.Headers.Add("Authorization", "Bearer " + token);

                // Load PDF content from file
                byte[] pdfBytes = File.ReadAllBytes(pdfFilePath);
                byte[] xmlBytes = File.ReadAllBytes(xmlFilePath);

                // Convert content to base64
                string base64PdfData = Convert.ToBase64String(pdfBytes);
                string base64XmlData = Convert.ToBase64String(xmlBytes);

                // Create a JSON payload
                string jsonPayload = string.Format("{{\"PdfBase64\": \"{0}\", \"XmlBase64\": \"{1}\", \"DocumentType\": \"{2}\"  }}", base64PdfData, base64XmlData, DocumentType);
                byte[] jsonDataBytes = Encoding.UTF8.GetBytes(jsonPayload);
                request.ContentLength = jsonDataBytes.Length;
                request.ContentType = "application/json";
                // Write the JSON data to the request stream
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(jsonDataBytes, 0, jsonDataBytes.Length);
                }
                // Start the asynchronous request.
                request.BeginGetResponse(result =>
                {
                    try
                    {
                        // End the asynchronous request and get the response
                        HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);

                        // Read the response content
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            using (Stream responseStream = response.GetResponseStream())
                            {
                                StreamReader reader = new StreamReader(responseStream);
                                string responseJson = reader.ReadToEnd();
                            }
                        }
                        else
                        {
                            using (Stream responseStream = response.GetResponseStream())
                            {
                                using (MemoryStream memoryStream = new MemoryStream())
                                {
                                    byte[] buffer = new byte[4096];
                                    int bytesRead;

                                    while ((bytesRead = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        memoryStream.Write(buffer, 0, bytesRead);
                                    }

                                    // Now, 'memoryStream' contains the response content as a byte array
                                    byte[] pdfContent = memoryStream.ToArray();

                                    // Save the PDF content to a local file
                                    File.WriteAllBytes(FileName, pdfContent);

                                    Console.WriteLine($"PDF saved to: {FileName}");
                                }
                            }
                        }

                        response.Close();

                        // Set the ManualResetEvent to signal completion.
                        waitHandle.Set();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("WebException occurred: " + ex.Message);
                        // Set the ManualResetEvent to signal completion even in case of an error.
                        waitHandle.Set();

                        TransErr++;
                        TempErrMsg = ex.Message;
                        TempException = ex;
                    }
                }, null);

                // Wait for the asynchronous operation to complete.
                waitHandle.WaitOne();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during the request
                Console.WriteLine("An exception occurred: " + ex.Message);

                TransErr++;
                TempErrMsg = ex.Message;
                TempException = ex;
            }
            ErrMsg = TempErrMsg;
            if (TempException != null)
                exception = TempException;

            return TransErr;
        }
    }
}
