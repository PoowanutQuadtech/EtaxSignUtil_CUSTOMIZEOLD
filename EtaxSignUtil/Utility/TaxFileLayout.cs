using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using DBUtil;
using System.Data;
using ModuleUtil;
using System.Reflection;
using System.Collections;

namespace EtaxSignUtil
{
    public class TaxFileLayout
    {
        protected List<string> ErrMsg { get; set; }
        private string Result { get; set; }
        private int? MaximumLength_BUILDING_NO { get; set; }
        private int? MaximumLength_BUILDING_NAME { get; set; }
        public TaxFileLayout()
        {
            this.ErrMsg = new List<string>();
            this.Result = "";

            this.MaximumLength_BUILDING_NO = this.GetMaximumLength("BUYER_BUILDING_NO");
            this.MaximumLength_BUILDING_NAME = this.GetMaximumLength("BUYER_BUILDING_NAME");
        }
        private int? GetMaximumLength(string PropertyName)
        {
            int? MaximumLength = null;
            if (!String.IsNullOrEmpty(PropertyName))
            {
                var propertyInfo = typeof(Layout.BuyerInformation).GetProperty(PropertyName);
                var attribute = propertyInfo.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true);
                object[] customAttributes = propertyInfo.GetCustomAttributes(typeof(ValidationAttribute), true);
                foreach (var customAttribute in customAttributes)
                {
                    var validationAttribute = (ValidationAttribute)customAttribute;
                    var stringAtt = ((System.ComponentModel.DataAnnotations.StringLengthAttribute)(validationAttribute));
                    MaximumLength = stringAtt.MaximumLength;
                    break;
                }
            }
            return MaximumLength;
        }
        public virtual bool Validate()
        {
            this.ErrMsg = EtaxSignUtil.Validator.Validate(this);
            return this.ErrMsg.Count == 0 ? true : false;
        }
        public string GetErrorMessage()
        {
            string ErrMsg = string.Empty;
            foreach (var item in this.ErrMsg)
            {
                if (ErrMsg != "")
                    ErrMsg += Environment.NewLine;
                ErrMsg += item;
            }
            return ErrMsg;
        }
        public string ConvertISODateTime(DateTime date)
        {
            return String.Format("{0}-{1:MM}-{1:dd}T{1:HH:mm:ss}", date.Year, date);
        }
        protected string ConvertDouble2Digit(double value)
        {
            return value.ToString("0.00");
        }
        protected string ConvertInt(int value)
        {
            return value.ToString();
        }
        protected string ConvertBoolean(bool value)
        {
            return value ? "true" : "false";
        }
        protected string GetTextFileFormat()
        {
            this.Result = "";
            if (this.ErrMsg.Count == 0)
            {
                PropertyInfo[] listProperty = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                foreach (var property in listProperty)
                {
                    var value = property.GetValue(this, null);
                    if (this.Result != "")
                        this.Result += ",";
                    if (value == null)
                        this.Result += String.Format(@"""{0}""", string.Empty);
                    else
                        this.Result += String.Format(@"""{0}""", value.ToString().Replace("\r\n", " "));
                }
            }
            return this.Result;
        }
        public string GetStringXML(string value, bool IsDash = true)
        {
            value = value.Replace(Environment.NewLine, " ").Trim();
            value = value.Replace("&", "&amp;").Trim();
            value = value.Replace("<", "&lt;").Trim();
            value = value.Replace(">", "&gt;").Trim();
            value = value.Replace("'", "&apos;").Trim();
            value = value.Replace("\"", "&quot;").Trim();
            if (IsDash)
                return value == "" ? "-" : value;
            else
                return value;
        }
        protected string Get_BUILDING_NO(string address)
        {
            string address_old = address;
            string value = "";
            address = address.Replace("บ้าน", "").Trim();
            address = address.Replace("เลขที่", "").Trim();
            address = address.Replace(", ", ",").Trim();
            address = address.Replace(" ,", ",").Trim();
            string[] ListValue = address.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (ListValue.Length > 0)
            {
                value = ListValue[0].Trim();
                string specialChar = @"0123456789/-,๑๒๓๔๕๖๗๘๙ข";
                foreach (var item in value)
                {
                    if (!specialChar.Contains(item))
                    {
                        value = "";
                        break;
                    }
                }
                if (value == "" && address.Contains("นิคมอุตสาหกรรม") && ListValue.Length > 1)
                {
                    value = ListValue[1].Trim();
                    foreach (var item in value)
                    {
                        if (!specialChar.Contains(item))
                        {
                            value = "";
                            break;
                        }
                    }
                }
            }
            if (String.IsNullOrEmpty(value))
            {
                address = address_old;
                int index = address.IndexOf("เลขที่");
                int indexRoomNo = address.IndexOf("ห้องเลขที่");
                if (indexRoomNo != -1)
                    index = address.IndexOf("เลขที่", indexRoomNo + ("ห้องเลขที่").Length);

                int index_to = address.Length;
                if (index >= 0)
                {
                    int indexMooban = address.IndexOf("หมู่บ้าน");
                    if (indexMooban > index && indexMooban < index_to)
                        index_to = indexMooban;

                    int indexMoo = address.IndexOf("หมู่ที่");
                    if (indexMoo == -1)
                        indexMoo = address.IndexOf("หมู่");
                    if (indexMoo > index && indexMoo < index_to)
                        index_to = indexMoo;

                    int indexSoi = address.IndexOf("ซอย");
                    if (indexSoi == -1)
                        indexSoi = address.IndexOf("ซ.");
                    if (indexSoi > index && indexSoi < index_to)
                        index_to = indexSoi;

                    int indexStreet = address.IndexOf("ถนน");
                    if (indexStreet == -1)
                        indexStreet = address.IndexOf("ถ.");
                    if (indexStreet > index && indexStreet < index_to)
                        index_to = indexStreet;

                    index_to = index_to - index;
                    value = address.Substring(index, index_to).Trim();
                }
            }
            if (this.MaximumLength_BUILDING_NO.HasValue)
            {
                if (value.Length > MaximumLength_BUILDING_NO.Value)
                    value = value.Substring(0, MaximumLength_BUILDING_NO.Value);
            }
            return value;
        }
        protected string Get_BUILDING_NAME(string address)
        {
            string value = "";
            int index = address.IndexOf("อาคาร");
            int index_to = address.Length;
            if (index >= 0)
            {
                int indexMooban = address.IndexOf("หมู่บ้าน");
                if (indexMooban > index && indexMooban < index_to)
                    index_to = indexMooban;

                int indexBuildingNo = address.IndexOf("เลขที่");
                int indexRoomNo = address.IndexOf("ห้องเลขที่");
                if (indexRoomNo != -1)
                    indexBuildingNo = address.IndexOf("เลขที่", indexRoomNo + ("ห้องเลขที่").Length);

                if (indexBuildingNo > index && indexBuildingNo < index_to)
                    index_to = indexBuildingNo;

                int indexMoo = address.IndexOf("หมู่ที่");
                if (indexMoo == -1)
                    indexMoo = address.IndexOf("หมู่");
                if (indexMoo > index && indexMoo < index_to)
                    index_to = indexMoo;

                int indexSoi = address.IndexOf("ซอย");
                if (indexSoi == -1)
                    indexSoi = address.IndexOf("ซ.");
                if (indexSoi > index && indexSoi < index_to)
                    index_to = indexSoi;

                int indexStreet = address.IndexOf("ถนน");
                if (indexStreet == -1)
                    indexStreet = address.IndexOf("ถ.");
                if (indexStreet > index && indexStreet < index_to)
                    index_to = indexStreet;

                index_to = index_to - index;
                value = address.Substring(index, index_to).Trim();
            }
            if (value == "")
            {
                string[] ListValue = address.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in ListValue)
                {
                    if (item.Contains("นิคมอุตสาหกรรม"))
                    {
                        value = item;
                        break;
                    }
                }
            }
            if (this.MaximumLength_BUILDING_NAME.HasValue)
            {
                if (value.Length > MaximumLength_BUILDING_NAME.Value)
                    value = value.Substring(0, MaximumLength_BUILDING_NAME.Value);
            }
            return value;
        }
        protected string Get_ADDRESS_LINE3(string address)
        {
            string value = "";
            int index = address.IndexOf("ซอย");
            int index_to = address.Length;
            if (index >= 0)
            {
                int indexMooban = address.IndexOf("หมู่บ้าน");
                if (indexMooban > index && indexMooban < index_to)
                    index_to = indexMooban;

                int indexBuildingNo = address.IndexOf("เลขที่");
                int indexRoomNo = address.IndexOf("ห้องเลขที่");
                if (indexRoomNo != -1)
                    indexBuildingNo = address.IndexOf("เลขที่", indexRoomNo + ("ห้องเลขที่").Length);
                if (indexBuildingNo > index && indexBuildingNo < index_to)
                    index_to = indexBuildingNo;

                int indexMoo = address.IndexOf("หมู่ที่");
                if (indexMoo == -1)
                    indexMoo = address.IndexOf("หมู่");
                if (indexMoo > index && indexMoo < index_to)
                    index_to = indexMoo;

                int indexStreet = address.IndexOf("ถนน");
                if (indexStreet == -1)
                    indexStreet = address.IndexOf("ถ.");
                if (indexStreet > index && indexStreet < index_to)
                    index_to = indexStreet;

                index_to = index_to - index;
                value = address.Substring(index, index_to).Trim();
            }
            return value;
        }
        protected string Get_ADDRESS_LINE4(string address)
        {
            string value = "";
            int index = address.IndexOf("หมู่บ้าน");
            int index_to = address.Length;
            if (index >= 0)
            {
                int indexBuildingNo = address.IndexOf("เลขที่");
                int indexRoomNo = address.IndexOf("ห้องเลขที่");
                if (indexRoomNo != -1)
                    indexBuildingNo = address.IndexOf("เลขที่", indexRoomNo + ("ห้องเลขที่").Length);
                if (indexBuildingNo > index && indexBuildingNo < index_to)
                    index_to = indexBuildingNo;

                int indexMoo = address.IndexOf("หมู่ที่");
                if (indexMoo == -1)
                    indexMoo = address.IndexOf("หมู่");
                if (indexMoo > index && indexMoo < index_to)
                    index_to = indexMoo;

                int indexSoi = address.IndexOf("ซอย");
                if (indexSoi == -1)
                    indexSoi = address.IndexOf("ซ.");
                if (indexSoi > index && indexSoi < index_to)
                    index_to = indexSoi;

                int indexStreet = address.IndexOf("ถนน");
                if (indexStreet == -1)
                    indexStreet = address.IndexOf("ถ.");
                if (indexStreet > index && indexStreet < index_to)
                    index_to = indexStreet;

                index_to = index_to - index;
                value = address.Substring(index, index_to).Trim();
            }
            return value;
        }
        protected string Get_ADDRESS_LINE5(string address)
        {
            string value = "";
            int index = address.IndexOf("หมู่ที่");
            if (index == -1)
                index = address.IndexOf("หมู่");

            int index_to = address.Length;
            if (index >= 0)
            {
                int indexMooban = address.IndexOf("หมู่บ้าน");
                if (indexMooban > index && indexMooban < index_to)
                    index_to = indexMooban;

                int indexBuildingNo = address.IndexOf("เลขที่");
                int indexRoomNo = address.IndexOf("ห้องเลขที่");
                if (indexRoomNo != -1)
                    indexBuildingNo = address.IndexOf("เลขที่", indexRoomNo + ("ห้องเลขที่").Length);
                if (indexBuildingNo > index && indexBuildingNo < index_to)
                    index_to = indexBuildingNo;

                int indexSoi = address.IndexOf("ซอย");
                if (indexSoi == -1)
                    indexSoi = address.IndexOf("ซ.");
                if (indexSoi > index && indexSoi < index_to)
                    index_to = indexSoi;

                int indexStreet = address.IndexOf("ถนน");
                if (indexStreet == -1)
                    indexStreet = address.IndexOf("ถ.");
                if (indexStreet > index && indexStreet < index_to)
                    index_to = indexStreet;

                index_to = index_to - index;
                value = address.Substring(index, index_to).Trim();
            }
            return value;
        }
        protected string Get_STREET_NAME(string address)
        {
            string value = "";
            int index = address.IndexOf("ถนน");
            if (index == -1)
                index = address.IndexOf("ถ.");

            int index_to = address.Length;
            if (index >= 0)
            {
                int indexMooban = address.IndexOf("หมู่บ้าน");
                if (indexMooban > index && indexMooban < index_to)
                    index_to = indexMooban;

                int indexBuildingNo = address.IndexOf("เลขที่");
                int indexRoomNo = address.IndexOf("ห้องเลขที่");
                if (indexRoomNo != -1)
                    indexBuildingNo = address.IndexOf("เลขที่", indexRoomNo + ("ห้องเลขที่").Length);
                if (indexBuildingNo > index && indexBuildingNo < index_to)
                    index_to = indexBuildingNo;

                int indexMoo = address.IndexOf("หมู่ที่");
                if (indexMoo == -1)
                    indexMoo = address.IndexOf("หมู่");
                if (indexMoo > index && indexMoo < index_to)
                    index_to = indexMoo;

                int indexSoi = address.IndexOf("ซอย");
                if (indexSoi == -1)
                    indexSoi = address.IndexOf("ซ.");
                if (indexSoi > index && indexSoi < index_to)
                    index_to = indexSoi;

                int indexStreet = address.IndexOf("ถนน");
                if (indexStreet == -1)
                    indexStreet = address.IndexOf("ถ.");
                if (indexStreet > index && indexStreet < index_to)
                    index_to = indexStreet;

                index_to = index_to - index;
                value = address.Substring(index, index_to).Trim();
            }
            return value;
        }
    }
}  
