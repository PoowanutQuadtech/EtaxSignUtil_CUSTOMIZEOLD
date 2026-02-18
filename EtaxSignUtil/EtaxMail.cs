using DBUtil;
using MessageUtil;
using ModuleUtil;
using QEB;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using Outlook = Microsoft.Office.Interop.Outlook;
namespace EtaxSignUtil
{
    public class EtaxMail
    {
        private Center QEBCenterInfo { get; set; }
        private DBSimple DBSimpleObj { get; set; }
        private string QERPPath { get; set; }
        private string EmailSubject { get; set; } = "";
        private string EmailBody { get; set; } = "";
        private string EmailUsername { get; set; } = "";
        private string EmailPassword { get; set; } = "";
        private string SMTP { get; set; } = "";
        private int PORT { get; set; } = 25;
        private bool EnableSSL { get; set; } = false;
        public bool UseEtaxSendmail { get; set; } = false;
        public bool InitDataYesNo { get; set; } = false;
        public EtaxMail(Center QEBCenterInfo, DBSimple DBSimpleObj)
        {
            this.QEBCenterInfo = QEBCenterInfo;
            this.DBSimpleObj = DBSimpleObj;
            this.QERPPath = AppDomain.CurrentDomain.BaseDirectory;
        }
        public void InitData()
        {
            DataTable TBMail = new DataTable();
            string Query = $@"SELECT F.*
, E.EmailUsername
, E.EmailPassword
, E.SMTP
, E.PORT
, E.EnableSSL
, CASE WHEN C.Value = 'Y' THEN CAST(1 as bit) ELSE CAST(0 as bit) END AS UseEtaxSendmail
FROM QERP.dbo.CompanyComunicateUserByFunction F
LEFT JOIN QERP.dbo.CompanyComunicateUserEmail E
ON E.QERP_Username = 'ETAX'
AND E.CompanyCode = F.CompanyCode
LEFT JOIN QERP.dbo.CompanyConfig C
ON C.CompanyCode = F.CompanyCode
AND C.ConfigCode = 'UseEtaxSendmail'
WHERE F.CompanyCode = DB_NAME()
AND F.ModuleCode = 'SITI'
AND F.FunctionCode = 'ETAX'";
            this.DBSimpleObj.FillData(TBMail, Query);
            if (TBMail.Rows.Count > 0)
            {
                this.EmailSubject = ReceiveValue.StringReceive("EmailSubject", TBMail.Rows[0]);
                this.EmailBody = ReceiveValue.StringReceive("EmailBody", TBMail.Rows[0]);
                this.EmailUsername = ReceiveValue.StringReceive("EmailUsername", TBMail.Rows[0]);
                this.EmailPassword = ReceiveValue.StringReceive("EmailPassword", TBMail.Rows[0]);
                this.SMTP = ReceiveValue.StringReceive("SMTP", TBMail.Rows[0]);
                this.PORT = ReceiveValue.IntReceive("PORT", TBMail.Rows[0], 25);
                this.EnableSSL = ReceiveValue.BoolReceive("EnableSSL", TBMail.Rows[0], false);
                this.UseEtaxSendmail = ReceiveValue.BoolReceive("UseEtaxSendmail", TBMail.Rows[0], false);
                this.InitDataYesNo = true;
            }
        }
        public void SendMail(DataRow rowHeader)
        {
            if (rowHeader == null)
                return;
            if (!InitDataYesNo)
                this.InitData();
            string DocumentModuleCode = ReceiveValue.StringReceive("DocumentModuleCode", rowHeader);
            string DocumentTypeCode = ReceiveValue.StringReceive("DocumentTypeCode", rowHeader);
            long RunNo = ReceiveValue.LongReceive("RunNo", rowHeader, -1);
            if (DocumentModuleCode == "SITI" || DocumentModuleCode == "SIDO")
            {
                string CustomerCode = ReceiveValue.StringReceive("CustomerCode", rowHeader);
                string DocNo = ReceiveValue.StringReceive("InvoiceNo", rowHeader);
                DataTable TBPDF = new DataTable();
                string Query = $@"SELECT TOP 1 F.FileData
FROM FileDoc F
WHERE F.RefTableHeaderDetails = 'ETAX_PDF'
AND F.DocumentModuleCode = '{DocumentModuleCode}'
AND F.DocumentTypeCode = '{DocumentTypeCode}'
AND F.RunNo = {RunNo}
ORDER BY F.LastUpdated";
                int ErrCode = 0;
                string ErrMsg = "";
                int TransErr = this.DBSimpleObj.FillData(TBPDF, Query, ref ErrCode, ref ErrMsg);
                if (TransErr != 0)
                {
                    MyMessageBox.Show($"ผิดพลาดการ Select Etax PDF : {ErrMsg}");
                    return;
                }
                if (TBPDF.Rows.Count == 0)
                {
                    MyMessageBox.Show($"ไม่พบเอกสาร Etax PDF เลขที่เอกสาร : {DocNo}");
                    return;
                }

                DataTable TBEmail = new DataTable();
                string QueryEmail = $@"SELECT Email
FROM TransactionContactOfMaster
WHERE RecStatus = 0
AND NodeType = 'C' 
AND ISNULL(Email,'') <> ''
AND Code = '{CustomerCode}'
AND UseEtax = 1
GROUP BY Email";
                TransErr = this.DBSimpleObj.FillData(TBEmail, QueryEmail, ref ErrCode, ref ErrMsg);
                if (TransErr != 0)
                {
                    MyMessageBox.Show($"ผิดพลาดการ Select Customer {CustomerCode} : {ErrMsg}");
                    return;
                }
                if (TBEmail.Rows.Count == 0)
                {
                    MyMessageBox.Show($"ไม่พบ Email ผู้ติดต่อของลูกค้า : {CustomerCode}");
                    return;
                }

                DataRow rowPDF = TBPDF.Rows[0];
                byte[] FileData = (byte[])rowPDF["FileData"];
                if (FileData.Length == 0)
                {
                    MyMessageBox.Show($"ไม่พบเอกสาร Etax PDF เลขที่เอกสาร : {DocNo}");
                    return;
                }
                string fileName = DocNo.Replace("/", "-");
                string folder = Path.Combine(this.QERPPath, "ETAX");
                string filepath = Path.Combine(folder, $"{fileName}.pdf");
                this.CreateFile(folder, filepath, FileData);

                string[] listEmail = TBEmail.AsEnumerable().Select(x => x.Field<string>("Email")).ToArray();
                string SendTo = String.Join(";", listEmail);
                string Subject = this.EmailSubject.Replace("$DocNo", DocNo);
                string Body = this.EmailBody.Replace("$DocNo", DocNo);
                this.OpenOutlookAndAttachFile(SendTo, Subject, Body, filepath);
            }
            else
            {
                throw new NotImplementedException($"DocumentModuleCode : {DocumentModuleCode} Not Implement");
            }
        }
        private void CreateFile(string folder, string filepath, byte[] FileData)
        {
            try
            {
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            try
            {
                if (File.Exists(filepath))
                    File.Delete(filepath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            try
            {
                File.WriteAllBytes(filepath, FileData);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        private void OpenOutlookAndAttachFile(string SendTo, string Subject, string Body, string filePath)
        {
            try
            {
                // Create an instance of Outlook Application
                Outlook.Application outlookApp = new Outlook.Application();

                // Create a new mail item
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);

                //Set the subject and body of the email(optional)
                mailItem.To = SendTo;
                mailItem.Subject = Subject;
                if (Body.Contains("<html>"))
                    mailItem.HTMLBody = Body;
                else
                    mailItem.Body = Body;
                // Attach the file
                if (!String.IsNullOrEmpty(filePath) && File.Exists(filePath))
                    mailItem.Attachments.Add(filePath);

                //Display the email
                mailItem.Display(false); // Set to true to display the email modally

                //Release the Outlook COM objects
                Marshal.ReleaseComObject(mailItem);
                Marshal.ReleaseComObject(outlookApp);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);

                MyExceptionMessageBox.Show(ex.Message, ex.StackTrace);
            }
        }
        public int AutoSendMail(string DocumentModuleCode, string DocNo ,string CustomerCode, string filepath, ref string ErrMsg, ref Exception ErrException)
        {
            int TransErr = 0;
            if (!InitDataYesNo)
                this.InitData();
            if (!this.UseEtaxSendmail)
                return TransErr;
            if (DocumentModuleCode == "SITI" || DocumentModuleCode == "SIDO")
            {
                DataTable TBEmail = new DataTable();
                string QueryEmail = $@"SELECT Email
FROM TransactionContactOfMaster
WHERE RecStatus = 0
AND NodeType = 'C' 
AND ISNULL(Email,'') <> ''
AND Code = '{CustomerCode}'
AND UseEtax = 1
GROUP BY Email";
                int ErrCode = 0;
                TransErr = this.DBSimpleObj.FillData(TBEmail, QueryEmail, ref ErrCode, ref ErrMsg);
                if (TransErr != 0)
                {
                    ErrMsg = $"ผิดพลาดการ Select Customer {CustomerCode} : {ErrMsg}";
                    return ++TransErr;
                }
                if (TBEmail.Rows.Count == 0)
                {
                    ErrMsg = $"ไม่พบ Email ผู้ติดต่อของลูกค้า : {CustomerCode}";
                    return ++TransErr;
                }
                List<string> ListEmail = new List<string>();
                foreach (DataRow rowEmail in TBEmail.Rows)
                {
                    string[] Emails = ReceiveValue.StringReceive("Email", rowEmail).Split(new string[] { "/", ";", ",", ":" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string email in Emails)
                    {
                        string data = email.Trim();
                        if (!ListEmail.Contains(data))
                        {
                            if (IsValidEmail(data))
                            {
                                ListEmail.Add(data);
                            }
                            else
                            {
                                ErrMsg = $"Email : {data} ของผู้ติดต่อของลูกค้า : {CustomerCode} Format ไม่ถูกต้อง";
                                return ++TransErr;
                            }
                        }

                    }
                    
                }
                string Subject = this.EmailSubject.Replace("$DocNo", DocNo);
                string Body = this.EmailBody.Replace("$DocNo", DocNo);
                // Create a new SmtpClient instance.
                SmtpClient smtpClient = new SmtpClient(this.SMTP);
                smtpClient.Port = this.PORT; // Use the appropriate SMTP port for your server.

                // Set your credentials for SMTP authentication.
                smtpClient.Credentials = new NetworkCredential(this.EmailUsername, this.EmailPassword);

                // Create a new MailMessage instance.
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(this.EmailUsername, "e-Tax Invoice");
                foreach (var email in ListEmail)
                    mailMessage.To.Add(email);
                mailMessage.Subject = Subject;           
                mailMessage.Body = Body;
                mailMessage.IsBodyHtml = true;
                if (!String.IsNullOrEmpty(filepath) && File.Exists(filepath))
                {
                    Attachment attachment = new Attachment(filepath, MediaTypeNames.Application.Octet);
                    mailMessage.Attachments.Add(attachment);
                }
                try
                {
                    // Send the email.
                    smtpClient.Send(mailMessage);
                }
                catch (SmtpFailedRecipientsException ex)
                {
                    // Handle specific exception for failed recipients
                    ErrException = ex;
                    ErrMsg = "Failed to deliver email to one or more recipients: " + ex.Message;
                    foreach (SmtpFailedRecipientException innerEx in ex.InnerExceptions)
                    {
                        ErrMsg += $"Recipient: {innerEx.FailedRecipient}, Status: {innerEx.StatusCode}, Error: {innerEx.Message}\n";
                    }
                    Console.WriteLine(ErrMsg);
                    return ++TransErr;
                }
                catch (SmtpException ex)
                {
                    // Handle general SMTP exceptions
                    ErrException = ex;
                    ErrMsg = "SMTP error occurred: " + ex.Message;
                    Console.WriteLine(ErrMsg);
                    return ++TransErr;
                }
                catch (Exception ex)
                {
                    ErrException = ex;
                    Console.WriteLine("Error sending email: " + ex.Message);
                    ErrMsg = ex.Message;
                    return ++TransErr;
                }
                return TransErr;
            }
            return TransErr;
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";
            // Use the Regex class to check if the email matches the pattern
            return Regex.IsMatch(email, pattern);
        }
    }
}
