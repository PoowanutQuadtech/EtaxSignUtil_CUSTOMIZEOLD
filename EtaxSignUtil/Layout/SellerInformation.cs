using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using DBUtil;
using System.Data;
using ModuleUtil;
using System.Reflection;
using System.ComponentModel;

namespace EtaxSignUtil.Layout
{
    public class SellerInformation : TaxFileLayout
    {
        [Required()]
        [StringLength(256)]
        [Description("ชื่อผู้ขาย[SELLER_NAME]")]
        public virtual string SELLER_NAME { get; private set; }

        [StringLength(35)]
        [Description("รหัสผู้ขาย[SELLER_ID]")]
        public virtual string SELLER_TAX_ID { get; private set; }

        [Required()]
        [StringLength(35)]
        [Description("เลขประจำตัวผู้เสียภาษีอากร[SELLER_TAX_ID]")]
        public virtual string SELLER_BRANCH_ID { get; private set; }

        [StringLength(70)]
        [Description("บ้านเลขที่[SELLER_BUILDING_NO]")]
        public virtual string SELLER_BUILDING_NO { get; private set; }

        [StringLength(70)]
        [Description("ชื่ออาคาร[SELLER_BUILDING_NAME]")]
        public virtual string SELLER_BUILDING_NAME { get; private set; }

        [StringLength(256)]
        [Description("ที่อยู่บรรทัดที่ 1[SELLER_ADDRESS_LINE1]")]
        public virtual string SELLER_ADDRESS_LINE1 { get; private set; }

        [StringLength(256)]
        [Description("ที่อยู่บรรทัดที่ 2[SELLER_ADDRESS_LINE2]")]
        public virtual string SELLER_ADDRESS_LINE2 { get; private set; }

        [StringLength(70)]
        [Description("ซอย[SELLER_ADDRESS_LINE3]")]
        public virtual string SELLER_ADDRESS_LINE3 { get; private set; }

        [StringLength(70)]
        [Description("หมู่บ้าน[SELLER_ADDRESS_LINE4]")]
        public virtual string SELLER_ADDRESS_LINE4 { get; private set; }
        [StringLength(70)]
        [Description("หมู่ที่[SELLER_ADDRESS_LINE5]")]
        public virtual string SELLER_ADDRESS_LINE5 { get; private set; }

        [StringLength(70)]
        [Description("ถนน[SELLER_STREET_NAME]")]
        public virtual string SELLER_STREET_NAME { get; private set; }

        [StringLength(70)]
        [Description("รหัสตำบล[SELLER_CITY_SUB_DIV_ID]")]
        public virtual string SELLER_CITY_SUB_DIV_ID { get; private set; }

        [StringLength(70)]
        [Description("ชื่อตำบล[SELLER_CITY_SUB_DIV_NAME]")]
        public virtual string SELLER_CITY_SUB_DIV_NAME { get; private set; }

        [StringLength(70)]
        [Description("รหัสอำเภอ[SELLER_CITY_ID]")]
        public virtual string SELLER_CITY_ID { get; private set; }

        [StringLength(70)]
        [Description("ชื่ออำเภอ[SELLER_CITY_NAME]")]
        public virtual string SELLER_CITY_NAME { get; private set; }

        [StringLength(70)]
        [Description("รหัสจังหวัด[SELLER_COUNTRY_SUB_DIV_ID]")]
        public virtual string SELLER_COUNTRY_SUB_DIV_ID { get; private set; }


        [StringLength(70)]
        [Description("ชื่อจังหวัด[SELLER_COUNTRY_SUB_DIV_NAME]")]
        public virtual string SELLER_COUNTRY_SUB_DIV_NAME { get; private set; }

        [Required()]
        [StringLength(3)]
        [Description("รหัสประเทศ[SELLER_COUNTRY_ID]")]
        public virtual string SELLER_COUNTRY_ID { get; private set; }

        [StringLength(16)]
        [Description("รหัสไปรษณีย์[SELLER_POST_CODE]")]
        public virtual string SELLER_POST_CODE { get; private set; }

        public SellerInformation(string SELLER_NAME
            , string SELLER_TAX_ID
            , string SELLER_HEADQUATER_OR_BRANCH
            , string SELLER_ADDRESS
            , int SELLER_KWAENGTAMBON_CODE
            , string SELLER_KWAENGTAMBON_NAME
            , int SELLER_AMPORCITY_CODE
            , string SELLER_AMPORCITY_NAME
            , int SELLER_PROVINCE_CODE
            , string SELLER_PROVINCE_NAME
            , bool SELLER_KWAENGKHET_TRUEFALSE
            , string SELLER_COUNTRY_ID
            , string SELLER_POST_CODE)
        {
            string SELLER_BRANCH_ID = "";
            if (SELLER_HEADQUATER_OR_BRANCH == "H" || SELLER_HEADQUATER_OR_BRANCH == "" )
                SELLER_BRANCH_ID = "00000";
            string BUILDING_NO = "";
            string BUILDING_NAME = "";
            string ADDRESS_LINE1 = "";
            string ADDRESS_LINE2 = "";
            string ADDRESS_LINE3 = "";
            string ADDRESS_LINE4 = "";
            string ADDRESS_LINE5 = "";
            string STREET_NAME = "";
            string CITY_SUB_DIV_ID = "";
            string CITY_SUB_DIV_NAME = "";
            string CITY_ID = "";
            string CITY_NAME = "";
            string COUNTRY_SUB_DIV_ID = "";
            string COUNTRY_SUB_DIV_NAME = "";

            SELLER_COUNTRY_ID = SELLER_COUNTRY_ID.ToUpper();
            if (SELLER_COUNTRY_ID == "")
                SELLER_COUNTRY_ID = "TH";
            if (SELLER_COUNTRY_ID != "TH")
            {
                ADDRESS_LINE1 = SELLER_ADDRESS;
                SELLER_KWAENGTAMBON_NAME = "";
                SELLER_AMPORCITY_NAME = "";
                SELLER_PROVINCE_NAME = "";
                SELLER_POST_CODE = "";
            }
            else
            {
                if (SELLER_PROVINCE_CODE > 0 && SELLER_AMPORCITY_CODE > 0 && SELLER_KWAENGTAMBON_CODE > 0)
                {
                    BUILDING_NO = this.Get_BUILDING_NO(SELLER_ADDRESS);
                    BUILDING_NAME = this.Get_BUILDING_NAME(SELLER_ADDRESS);
                    ADDRESS_LINE3 = this.Get_ADDRESS_LINE3(SELLER_ADDRESS);
                    ADDRESS_LINE4 = this.Get_ADDRESS_LINE4(SELLER_ADDRESS);
                    ADDRESS_LINE5 = this.Get_ADDRESS_LINE5(SELLER_ADDRESS);
                    STREET_NAME = this.Get_STREET_NAME(SELLER_ADDRESS);

                    COUNTRY_SUB_DIV_ID = SELLER_PROVINCE_CODE.ToString("00");
                    COUNTRY_SUB_DIV_NAME = SELLER_PROVINCE_NAME;

                    CITY_ID = COUNTRY_SUB_DIV_ID + SELLER_AMPORCITY_CODE.ToString("00");
                    CITY_NAME = SELLER_AMPORCITY_NAME;

                    CITY_SUB_DIV_ID = CITY_ID + SELLER_KWAENGTAMBON_CODE.ToString("00");
                    CITY_SUB_DIV_NAME = SELLER_KWAENGTAMBON_NAME;
                }
                else
                {
                    ADDRESS_LINE1 = SELLER_ADDRESS;
                    if (SELLER_KWAENGTAMBON_NAME != "")
                        ADDRESS_LINE2 = String.Format(SELLER_KWAENGKHET_TRUEFALSE ? "แขวง{0}" : "ต.{0}", SELLER_KWAENGTAMBON_NAME);
                    if (SELLER_AMPORCITY_NAME != "")
                    {
                        if (ADDRESS_LINE2 != "")
                            ADDRESS_LINE2 += " ";
                        ADDRESS_LINE2 += String.Format(SELLER_KWAENGKHET_TRUEFALSE ? "เขต{0}" : "อ.{0}", SELLER_AMPORCITY_NAME);
                    }
                    if (SELLER_PROVINCE_NAME != "")
                    {
                        if (ADDRESS_LINE2 != "")
                            ADDRESS_LINE2 += " ";
                        ADDRESS_LINE2 += String.Format(SELLER_KWAENGKHET_TRUEFALSE ? "{0}" : "จ.{0}", SELLER_PROVINCE_NAME);
                    }
                }
            }
            this.SELLER_NAME = SELLER_NAME;
            this.SELLER_TAX_ID = SELLER_TAX_ID;
            this.SELLER_BRANCH_ID = SELLER_BRANCH_ID;
            this.SELLER_BUILDING_NO = BUILDING_NO;
            this.SELLER_BUILDING_NAME = BUILDING_NAME;
            this.SELLER_ADDRESS_LINE3 = ADDRESS_LINE3;
            this.SELLER_ADDRESS_LINE4 = ADDRESS_LINE4;
            this.SELLER_ADDRESS_LINE5 = ADDRESS_LINE5;
            this.SELLER_STREET_NAME = STREET_NAME;
            this.SELLER_ADDRESS_LINE1 = ADDRESS_LINE1;
            this.SELLER_ADDRESS_LINE2 = ADDRESS_LINE2;
            this.SELLER_CITY_SUB_DIV_ID = CITY_SUB_DIV_ID;
            this.SELLER_CITY_SUB_DIV_NAME = CITY_SUB_DIV_NAME;
            this.SELLER_CITY_ID = CITY_ID;
            this.SELLER_CITY_NAME = CITY_NAME;
            this.SELLER_COUNTRY_SUB_DIV_ID = COUNTRY_SUB_DIV_ID;
            this.SELLER_COUNTRY_SUB_DIV_NAME = COUNTRY_SUB_DIV_NAME;
            this.SELLER_COUNTRY_ID = SELLER_COUNTRY_ID;
            this.SELLER_POST_CODE = SELLER_POST_CODE;
        }
    }
}
