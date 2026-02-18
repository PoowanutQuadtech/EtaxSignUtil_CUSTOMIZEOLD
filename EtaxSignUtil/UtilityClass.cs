using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace EtaxSignUtil
{
    public static class UtilityClass
    {
        public static Font GetThaiFont()
        {
            // เตรียม path ฟอนต์ใน Windows
            string windowsFontDir = Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "Fonts");
            string pathPSK = Path.Combine(windowsFontDir, "THSarabunPSK.ttf");
            string pathSarabun = Path.Combine(windowsFontDir, "THSarabun.ttf");

            // ฟังก์ชันเล็กๆ ไว้ใช้โหลดฟอนต์
            Font tryRegisterFont(string fontFile, string fontName)
            {
                if (!File.Exists(fontFile)) return null;
                FontFactory.Register(fontFile);
                var f = FontFactory.GetFont(fontName, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                return (f == null || f.Familyname.ToLower() == "unknown") ? null : f;
            }

            // 1) ลองใช้ THSarabunPSK ก่อน
            Font font = tryRegisterFont(pathPSK, "TH SarabunPSK");

            // 2) ถ้ายังไม่ได้ผล ลอง THSarabun ต่อ
            if (font == null)
                font = tryRegisterFont(pathSarabun, "TH Sarabun");

            // 3) ถ้ายังไม่เจออีก ก็โหลดจาก embedded resource
            if (font == null)
            {
                // สร้างชื่อไฟล์ชั่วคราวที่ไม่ซ้ำ
                string tempPath = Path.Combine(Path.GetTempPath(), "THSarabun.ttf");
                tempPath = GetUniqueFileName(tempPath);

                // สร้างไฟล์ฟอนต์ชั่วคราว
                if (ResourceLoader.CreatedEmbeddedResourceToTempPath("THSarabun.ttf", ref tempPath) == 0)
                {
                    var baseFont = BaseFont.CreateFont(tempPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                  
                    font = new Font(baseFont, 12);
                }
            }

            // 4) กันเหนียว ถ้าโหลดฟอนต์ไม่ได้จริงๆ ให้ใช้ฟอนต์ default
            return font ?? new Font(Font.FontFamily.HELVETICA,12);
        }

        public static Font OldGetThaiFont(ref int TransErr,ref string ErrMsg)
        {
            Font font = null;
            int errFont = 0;
            // ลองลงทะเบียนฟอนต์ TH SarabunPSK จากไฟล์
            string fontPathPSK = Environment.GetEnvironmentVariable("SystemRoot") + "\\Fonts\\THSarabunPSK.ttf";
            if (File.Exists(fontPathPSK))
            {
                // ลงทะเบียนฟอนต์โดยใช้เส้นทางไฟล์
                FontFactory.Register(fontPathPSK);
                font = FontFactory.GetFont("TH SarabunPSK", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                if (font == null ||
                font.Familyname.ToLower() == "unknown")
                {
                    // กรณีที่ฟอนต์ยังไม่ถูกโหลด
                    ++errFont;
                }
            }

            if (!File.Exists(fontPathPSK) ||
                errFont > 0)
            {
                // ลองลงทะเบียนฟอนต์ TH Sarabun จากไฟล์
                string fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "\\Fonts\\THSarabun.ttf";
                if (File.Exists(fontPath))
                {
                    // ลงทะเบียนฟอนต์โดยใช้เส้นทางไฟล์
                    FontFactory.Register(fontPath);
                    font = FontFactory.GetFont("TH Sarabun", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    if (font == null ||
                         font.Familyname.ToLower() == "unknown")
                    {
                        ++errFont;
                    }
                }
                else
                {
                    try
                    {
                        BaseFont baseFontPSK = BaseFont.CreateFont("THSarabun", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        font = new Font(baseFontPSK, 12); // กำหนดขนาดฟอนต์ตามที่ต้องการ

                        if (font == null)
                        {
                            ++errFont;
                        }
                    }
                    catch (Exception ex)
                    {
                        fontPathPSK = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "THSarabun.ttf");
                        if (File.Exists(fontPathPSK))
                        {
                            BaseFont baseFontPSK = BaseFont.CreateFont(fontPathPSK, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                            font = new Font(baseFontPSK, 12); // กำหนดขนาดฟอนต์ตามที่แม่ต้องการ
                        }
                        else
                        {
                            ++errFont;
                        }
                    }
                }
            }

            if (errFont != 0)
            {
                errFont = 0;
                errFont = ResourceLoader.CreatedEmbeddedResourceToTempPath("THSarabun.ttf", ref fontPathPSK);
                if (errFont == 0)
                {
                    BaseFont baseFontPSK = BaseFont.CreateFont(fontPathPSK, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    font = new Font(baseFontPSK, 12); // กำหนดขนาดฟอนต์ตามที่แม่ต้องการ
                }
            }



            if (errFont > 0 ||
                font == null ||
                font.Familyname.ToLower() == "unknown")
            {
                ErrMsg = "ไม่พบ Font TH SarabunPSK";
                ++TransErr;
            }
            return font;
        }

        public static void SetupLookupEdit(DataView vt, string StrCode, string StrDesc, DevExpress.XtraEditors.LookUpEdit C)
        {
            C.Properties.DataSource = vt;
            C.Properties.DisplayMember = StrDesc;
            C.Properties.ValueMember = StrCode;
            C.Properties.DropDownRows = vt.Count;
            C.Properties.PopupSizeable = false;
            C.Properties.ShowHeader = false;
            C.Properties.PopupWidth = C.Width;
            C.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            C.Properties.PopupFormMinSize = new System.Drawing.Size(10, 10);
        }

        public static string GetUniqueFileName(string originalPath)
        {
            if (!File.Exists(originalPath))
                return originalPath;

            string dir = Path.GetDirectoryName(originalPath);
            string name = Path.GetFileNameWithoutExtension(originalPath);
            string ext = Path.GetExtension(originalPath);

            int i = 1;
            string newPath;
            do
            {
                newPath = Path.Combine(dir, $"{name}({i++}){ext}");
            }
            while (File.Exists(newPath));

            return newPath;
        }
    }
}
