using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EtaxSignUtil
{
    public static class ResourceLoader
    {
        public static byte[] LoadEmbeddedResource(string resourceName)
        {
            string resourceNameFull = $"EtaxSignUtil.{resourceName}";
            // ใช้ Assembly ที่กำลังรันโปรแกรมอยู่เพื่อหา Resource
            var assembly = Assembly.GetExecutingAssembly();

            // สร้าง Stream เพื่อดึงข้อมูลไฟล์จาก Resource
            using (Stream stream = assembly.GetManifestResourceStream(resourceNameFull))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException("Resource not found: " + resourceNameFull);
                }

                // อ่านข้อมูลไฟล์เป็น Byte Array
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    byte[] buffer = new byte[81920]; // ขนาด buffer สามารถปรับได้
                    int bytesRead;
                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        memoryStream.Write(buffer, 0, bytesRead);
                    }
                    return memoryStream.ToArray();
                }
            }
        }

        public static List<string> lstPathTempFile = new List<string>();
        public static int CreatedEmbeddedResourceToTempPath(string resourceName,ref string pathFile)
        {
            int err = 0;
            byte[] FileBytes = LoadEmbeddedResource(resourceName);
            if (FileBytes == null || FileBytes.Length == 0) return ++err;

            // สร้างชื่อไฟล์ชั่วคราว
            string fileName = $"{Path.GetFileNameWithoutExtension(resourceName)}_{Guid.NewGuid()}{Path.GetExtension(resourceName)}";
            string tempPath = Path.Combine(Path.GetTempPath(), fileName);

            // กันเหนียวด้วยการเรียก GetUniqueFileName ถ้าชื่อดันไปซ้ำ
            tempPath = UtilityClass.GetUniqueFileName(tempPath);

            File.WriteAllBytes(tempPath, FileBytes);
            pathFile = tempPath;
            lstPathTempFile.Add(tempPath);
            return err;
        }

 


        public static void DeleteFileTempPath()
        {
            try
            {
                foreach (string tempFilePath in lstPathTempFile)
                {
                    if (File.Exists(tempFilePath))
                    {
                        File.Delete(tempFilePath);
                    }
                }
                lstPathTempFile.Clear();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
