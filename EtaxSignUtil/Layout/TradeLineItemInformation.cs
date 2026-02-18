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
using System.Security;

namespace EtaxSignUtil.Layout
{
    public class TradeLineItemInformation : TaxFileLayout
    {
        [Required()]
        [StringLength(1)]
        [Description("ประเภทรายการ[DATA_TYPE]")]
        public virtual string DATA_TYPE { get; set; }


        [Required()]
        [StringLength(35)]
        [Description("ลำดับรายการ[LINE_ID]")]
        public virtual string LINE_ID { get; set; }


        [StringLength(35)]
        [Description("รหัสสินค้า[PRODUCT_ID]")]
        public virtual string PRODUCT_ID { get; set; }


        [Required()]
        [StringLength(256)]
        [Description("ชื่อสินค้า[PRODUCT_NAME]")]
        public virtual string PRODUCT_NAME { get; set; }


        [StringLength(256)]
        [Description("รายละเอียดสินค้า[PRODUCT_DESC]")]
        public virtual string PRODUCT_DESC { get; set; }


        [StringLength(35)]
        [Description("ครั้งที่ผลิต[PRODUCT_BATCH_ID]")]
        public virtual string PRODUCT_BATCH_ID { get; set; }


        [StringLength(19)]
        [Description("วันหมดอายุ[PRODUCT_EXPIRE_DTM]")]
        public virtual string PRODUCT_EXPIRE_DTM { get; set; }


        [StringLength(35)]
        [Description("รหัสหมวดหมู่สินค้า[PRODUCT_CLASS_CODE]")]
        public virtual string PRODUCT_CLASS_CODE { get; set; }


        [StringLength(256)]
        [Description("ชื่อหมวดหมู่สินค้า[PRODUCT_CLASS_NAME]")]
        public virtual string PRODUCT_CLASS_NAME { get; set; }

        [StringLength(3)]
        [Description("รหัสประเทศกำเนิด[PRODUCT_ORIGIN_COUNTRY_ID]")]
        public virtual string PRODUCT_ORIGIN_COUNTRY_ID { get; set; }

        [Required()]
        [StringLength(16)]
        [Description("ราคาต่อหน่วย[PRODUCT_CHARGE_AMOUNT]")]
        public virtual string PRODUCT_CHARGE_AMOUNT { get; set; }


        [Required()]
        [StringLength(3)]
        [Description("รหัสสกุลเงิน (ราคาต่อหน่วย)[PRODUCT_CHARGE_CURRENCY_CODE]")]
        public virtual string PRODUCT_CHARGE_CURRENCY_CODE { get; set; }


        [StringLength(5)]
        [Description("ตัวบอกส่วนลดหรือค่าธรรมเนียม[PRODUCT_ALLOWANCE_CHARGE_IND]")]
        public virtual string PRODUCT_ALLOWANCE_CHARGE_IND { get; set; }


        [StringLength(16)]
        [Description("มูลค่าส่วนลดหรือค่าธรรมเนียม[PRODUCT_ALLOWANCE_ACTUAL_AMOUNT]")]
        public virtual string PRODUCT_ALLOWANCE_ACTUAL_AMOUNT { get; set; }


        [StringLength(3)]
        [Description("รหัสสกุลเงิน (มูลค่าส่วนลดหรือค่าธรรมเนียม)[PRODUCT_ALLOWANCE_ACTUAL_CURRENCY_CODE]")]
        public virtual string PRODUCT_ALLOWANCE_ACTUAL_CURRENCY_CODE { get; set; }


        [StringLength(16)]
        [Description("รหัสเหตุผลในการคิดส่วนลดหรือค่าธรรมเนียม[PRODUCT_ALLOWANCE_REASON_CODE]")]
        public virtual string PRODUCT_ALLOWANCE_REASON_CODE { get; set; }


        [StringLength(256)]
        [Description("เหตุผลในการคิดสวนลดหรือค่าธรรมเนียม[PRODUCT_ALLOWANCE_REASON]")]
        public virtual string PRODUCT_ALLOWANCE_REASON { get; set; }


        [StringLength(10)]
        [Description("จำนวนสินค้า[PRODUCT_QUANTITY]")]
        public virtual string PRODUCT_QUANTITY { get; set; }


        [StringLength(3)]
        [Description("รหัสหน่วยสินค้า[PRODUCT_UNIT_CODE]")]
        public virtual string PRODUCT_UNIT_CODE { get; set; }


        [StringLength(5)]
        [Description("ขนาดบรรจุต่อหน่วยขาย[PRODUCT_QUANTITY_PER_UNIT]")]
        public virtual string PRODUCT_QUANTITY_PER_UNIT { get; set; }


        [Required()]
        [StringLength(3)]
        [Description("รหัสประเภทภาษี[LINE_TAX_TYPE_CODE]")]
        public virtual string LINE_TAX_TYPE_CODE { get; set; }


        [Required()]
        [StringLength(5)]
        [Description("อัตราภาษี[LINE_TAX_CAL_RATE]")]
        public virtual string LINE_TAX_CAL_RATE { get; set; }


        [Required()]
        [StringLength(16)]
        [Description("มูลค่าสินค้า/บริการ (ไม่รวมภาษีมูลค่าเพิ่ม[LINE_BASIS_AMOUNT]")]
        public virtual string LINE_BASIS_AMOUNT { get; set; }


        [Required()]
        [StringLength(3)]
        [Description("รหัสสกุลเงิน (มูลค่าสินค้า/บริการ)[LINE_BASIS_CURRENCY_CODE]")]
        public virtual string LINE_BASIS_CURRENCY_CODE { get; set; }


        [Required()]
        [StringLength(16)]
        [Description("มูลค่าภาษีมูลค่าเพิ่ม[LINE_TAX_CAL_AMOUNT]")]
        public virtual string LINE_TAX_CAL_AMOUNT { get; set; }


        [Required()]
        [StringLength(3)]
        [Description("รหัสสกุลเงิน (มูลค่าภาษีมูลค่าเพิ่ม)[LINE_TAX_CAL_CURRENCY_CODE]")]
        public virtual string LINE_TAX_CAL_CURRENCY_CODE { get; set; }


        [StringLength(5)]
        [Description("ตัวบอกส่วนลดหรือค่าธรรมเนียม[LINE_ALLOWANCE_CHARGE_IND]")]
        public virtual string LINE_ALLOWANCE_CHARGE_IND { get; set; }

        [StringLength(2)]
        [Description("ประเภทส่วนลด[LINE_ALLOWANCE_TYPE_CODE")]
        public virtual string LINE_ALLOWANCE_TYPE_CODE { get; set; }


        [StringLength(16)]
        [Description("มูลค่าส่วนลดหรือค่าธรรมเนียม[LINE_ALLOWANCE_ACTUAL_AMOUNT]")]
        public virtual string LINE_ALLOWANCE_ACTUAL_AMOUNT { get; set; }


        [StringLength(3)]
        [Description("มูลค่าส่วนลดหรือค่าธรรมเนียม[LINE_ALLOWANCE_ACTUAL_CURRENCY_CODE]")]
        public virtual string LINE_ALLOWANCE_ACTUAL_CURRENCY_CODE { get; set; }


        [StringLength(16)]
        [Description("รหัสเหตุผลในการคิดส่วนลดหรือค่าธรรมเนียม[LINE_ALLOWANCE_REASON_CODE]")]
        public virtual string LINE_ALLOWANCE_REASON_CODE { get; set; }


        [StringLength(256)]
        [Description("เหตุผลในการคิดสวนลดหรือค่าธรรมเนียม[LINE_ALLOWANCE_REASON]")]
        public virtual string LINE_ALLOWANCE_REASON { get; set; }


        [StringLength(16)]
        [Description("ภาษีมูลค่าเพิ่ม[LINE_TAX_TOTAL_AMOUNT]")]
        public virtual string LINE_TAX_TOTAL_AMOUNT { get; set; }


        [StringLength(3)]
        [Description("รหัสสกุลเงิน (ภาษีมูลค่าเพิ่ม)[LINE_TAX_TOTAL_CURRENCY_CODE]")]
        public virtual string LINE_TAX_TOTAL_CURRENCY_CODE { get; set; }


        [Required()]
        [StringLength(16)]
        [Description("จำนวนเงินรวมก่อนภาษี[LINE_NET_TOTAL_AMOUNT]")]
        public virtual string LINE_NET_TOTAL_AMOUNT { get; set; }


        [Required()]
        [StringLength(3)]
        [Description("รหัสสกุลเงิน (จำนวนเงินรวมก่อนภาษี)[LINE_NET_TOTAL_CURRENCY_CODE]")]
        public virtual string LINE_NET_TOTAL_CURRENCY_CODE { get; set; }


        [Required()]
        [StringLength(16)]
        [Description("จำนวนเงินรวม[LINE_NET_INCLUDE_TAX_TOTAL_AMOUNT]")]
        public virtual string LINE_NET_INCLUDE_TAX_TOTAL_AMOUNT { get; set; }


        [Required()]
        [StringLength(3)]
        [Description("รหัสสกุลเงิน (จำนวนเงินรวม)[LINE_NET_INCLUDE_TAX_TOTAL_CURRENCY_CODE]")]
        public virtual string LINE_NET_INCLUDE_TAX_TOTAL_CURRENCY_CODE { get; set; }


        [StringLength(500)]
        [Description("หมายเหตุท้ายสินค้า[PRODUCT_REMARK]")]
        public virtual string PRODUCT_REMARK { get; set; }

        [StringLength(1)]
        [Description("ประเภทรายการ[PRODUCT_TRANSACTIONTYPE]")]
        public virtual string PRODUCT_TRANSACTIONTYPE { get; set; }


        [StringLength(35)]
        [Description("เลขที่เอกสารอ้างอิง[ADDITIONAL_REF_ASSIGN_ID]")]
        public virtual string ADDITIONAL_REF_ASSIGN_ID { get; set; }

        public TradeLineItemInformation(int LINE_ID
            , string PRODUCT_ID
            , string PRODUCT_NAME
            , double PRODUCT_QUANTITY
            , string PRODUCT_UNIT_CODE
            , string PRODUCT_CURRENCY_CODE
            , bool PRODUCT_INCLUDE_VAT
            , double LINE_TAX_RATE
            , double PRODUCT_UNIT_PRICE
            , double PRODUCT_TOTAL_AMOUNT
            , double PRODUCT_TOTAL_AMOUNT_AFTER_DISCOUNT
            , string PRODUCT_REMARK
            , CalculateItem CAL
            , bool LAST_DETAIS)
        {
            double PRODUCT_DISCOUNT = Math.Round(PRODUCT_TOTAL_AMOUNT - PRODUCT_TOTAL_AMOUNT_AFTER_DISCOUNT, 2);
            double LINE_BASIS_AMOUNT;
            double LINE_TAX_AMOUNT;
            double LINE_NET_INCLUDE_TAX_TOTAL_AMOUNT;
            if (LAST_DETAIS)
            {
                if (CAL.Total_Discount == 0)
                {
                    LINE_BASIS_AMOUNT = CAL.Remain_BeforeVAT;
                    LINE_NET_INCLUDE_TAX_TOTAL_AMOUNT = CAL.Remain_AfterVAT;
                    LINE_TAX_AMOUNT = Math.Round(LINE_NET_INCLUDE_TAX_TOTAL_AMOUNT - LINE_BASIS_AMOUNT, 2);
                }
                else
                {
                    LINE_BASIS_AMOUNT = CAL.Remain_BeforeVAT;
                    LINE_TAX_AMOUNT = Math.Round(LINE_BASIS_AMOUNT * LINE_TAX_RATE / 100, 2);
                    LINE_NET_INCLUDE_TAX_TOTAL_AMOUNT = Math.Round(LINE_BASIS_AMOUNT + LINE_TAX_AMOUNT, 2);
                }
            }
            else
            {
                if (PRODUCT_INCLUDE_VAT)
                {
                    if (CAL.Remain_Discount == 0)
                    {
                        LINE_NET_INCLUDE_TAX_TOTAL_AMOUNT = Math.Round(PRODUCT_TOTAL_AMOUNT_AFTER_DISCOUNT, 2);
                        LINE_BASIS_AMOUNT = Math.Round(PRODUCT_TOTAL_AMOUNT_AFTER_DISCOUNT / (1 + (LINE_TAX_RATE / 100)), 2);
                        LINE_TAX_AMOUNT = Math.Round(LINE_NET_INCLUDE_TAX_TOTAL_AMOUNT - LINE_BASIS_AMOUNT, 2);
                    }
                    else
                    {
                        double cal_AfterDiscount = PRODUCT_TOTAL_AMOUNT_AFTER_DISCOUNT;
                        if (CAL.Total_ItemIncludeVAT != 0)
                        {
                            cal_AfterDiscount = (CAL.Total_AfterVAT / CAL.Total_ItemIncludeVAT) * PRODUCT_TOTAL_AMOUNT_AFTER_DISCOUNT;
                            cal_AfterDiscount = Math.Round(cal_AfterDiscount, 2);
                        }

                        double Diff_Discount = PRODUCT_TOTAL_AMOUNT_AFTER_DISCOUNT - cal_AfterDiscount;
                        Diff_Discount = Math.Round(Diff_Discount, 2);

                        LINE_BASIS_AMOUNT = Math.Round((PRODUCT_TOTAL_AMOUNT_AFTER_DISCOUNT - Diff_Discount) / (1 + (LINE_TAX_RATE / 100)), 2);
                        LINE_BASIS_AMOUNT += Diff_Discount;
                        LINE_BASIS_AMOUNT = Math.Round(LINE_BASIS_AMOUNT, 2);

                        LINE_TAX_AMOUNT = Math.Round(LINE_BASIS_AMOUNT * LINE_TAX_RATE / 100, 2);
                        LINE_NET_INCLUDE_TAX_TOTAL_AMOUNT = Math.Round(LINE_BASIS_AMOUNT + LINE_TAX_AMOUNT, 2);

                        CAL.Remain_Discount -= Diff_Discount;
                        CAL.Remain_Discount = Math.Round(CAL.Remain_Discount, 2);
                    }
                }
                else
                {
                    LINE_BASIS_AMOUNT = PRODUCT_TOTAL_AMOUNT_AFTER_DISCOUNT;
                    LINE_TAX_AMOUNT = Math.Round(PRODUCT_TOTAL_AMOUNT_AFTER_DISCOUNT * LINE_TAX_RATE / 100, 2);
                    LINE_NET_INCLUDE_TAX_TOTAL_AMOUNT = Math.Round(LINE_BASIS_AMOUNT + LINE_TAX_AMOUNT, 2);
                }
                CAL.Remain_BeforeVAT -= LINE_BASIS_AMOUNT;
                CAL.Remain_AfterVAT -= LINE_NET_INCLUDE_TAX_TOTAL_AMOUNT;
            }
            if (LINE_BASIS_AMOUNT < 0)
                LINE_BASIS_AMOUNT = 0;
            if (LINE_TAX_AMOUNT < 0)
                LINE_TAX_AMOUNT = 0;
            if (LINE_NET_INCLUDE_TAX_TOTAL_AMOUNT < 0)
                LINE_NET_INCLUDE_TAX_TOTAL_AMOUNT = 0;

            this.DATA_TYPE = "L";
            this.LINE_ALLOWANCE_TYPE_CODE = "95";
            this.LINE_ID = this.ConvertInt(LINE_ID);
            this.PRODUCT_ID = PRODUCT_ID;
            this.PRODUCT_NAME = SecurityElement.Escape(PRODUCT_NAME);
            this.PRODUCT_CHARGE_AMOUNT = this.ConvertDouble2Digit(PRODUCT_UNIT_PRICE);
            this.PRODUCT_CHARGE_CURRENCY_CODE = PRODUCT_CURRENCY_CODE;
            this.PRODUCT_ALLOWANCE_CHARGE_IND = PRODUCT_DISCOUNT > 0 ? this.ConvertBoolean(true) : this.ConvertBoolean(false);
            this.PRODUCT_ALLOWANCE_ACTUAL_AMOUNT = this.ConvertDouble2Digit(PRODUCT_DISCOUNT);
            this.PRODUCT_ALLOWANCE_ACTUAL_CURRENCY_CODE = PRODUCT_CURRENCY_CODE;
            this.PRODUCT_QUANTITY = this.ConvertDouble2Digit(PRODUCT_QUANTITY);
            this.PRODUCT_UNIT_CODE = PRODUCT_UNIT_CODE.Length > 3 ? PRODUCT_UNIT_CODE.Substring(0, 3) : PRODUCT_UNIT_CODE;

            this.LINE_TAX_TYPE_CODE = LINE_TAX_RATE == 0 ? "FRE" : "VAT";
            this.LINE_TAX_CAL_RATE = this.ConvertDouble2Digit(LINE_TAX_RATE);

            this.LINE_BASIS_AMOUNT = this.ConvertDouble2Digit(LINE_BASIS_AMOUNT);
            this.LINE_BASIS_CURRENCY_CODE = PRODUCT_CURRENCY_CODE;

            this.LINE_TAX_CAL_AMOUNT = this.ConvertDouble2Digit(LINE_TAX_AMOUNT);
            this.LINE_TAX_CAL_CURRENCY_CODE = PRODUCT_CURRENCY_CODE;

            this.LINE_ALLOWANCE_CHARGE_IND = PRODUCT_DISCOUNT > 0 ? this.ConvertBoolean(true) : this.ConvertBoolean(false);
            this.LINE_ALLOWANCE_ACTUAL_AMOUNT = this.ConvertDouble2Digit(PRODUCT_DISCOUNT);
            this.LINE_ALLOWANCE_ACTUAL_CURRENCY_CODE = PRODUCT_CURRENCY_CODE;

            this.LINE_TAX_TOTAL_AMOUNT = this.ConvertDouble2Digit(LINE_TAX_AMOUNT);
            this.LINE_TAX_TOTAL_CURRENCY_CODE = PRODUCT_CURRENCY_CODE;

            this.LINE_NET_TOTAL_AMOUNT = this.ConvertDouble2Digit(LINE_BASIS_AMOUNT);
            this.LINE_NET_TOTAL_CURRENCY_CODE = PRODUCT_CURRENCY_CODE;

            this.LINE_NET_INCLUDE_TAX_TOTAL_AMOUNT = this.ConvertDouble2Digit(LINE_NET_INCLUDE_TAX_TOTAL_AMOUNT);
            this.LINE_NET_INCLUDE_TAX_TOTAL_CURRENCY_CODE = PRODUCT_CURRENCY_CODE;

            this.PRODUCT_REMARK = PRODUCT_REMARK;
        }

        public TradeLineItemInformation(int LINE_ID
            , string TRANSACTION_TYPE
            , string PRODUCT_ID
            , string PRODUCT_NAME
            , double PRODUCT_QUANTITY
            , string PRODUCT_UNIT_CODE
            , string ADDITIONAL_REF_ASSIGN_ID
            , string PRODUCT_CURRENCY_CODE
            , bool PRODUCT_INCLUDE_VAT
            , double LINE_TAX_RATE
            , double PRODUCT_UNIT_PRICE
            , double PRODUCT_TOTAL_AMOUNT
            , double PRODUCT_TOTAL_AMOUNT_AFTER_DISCOUNT
            , string PRODUCT_REMARK
            , CalculateItem CAL
            , bool LAST_DETAIS
           ) :
            this(LINE_ID
             , PRODUCT_ID
             , PRODUCT_NAME
             , PRODUCT_QUANTITY
             , PRODUCT_UNIT_CODE
             , PRODUCT_CURRENCY_CODE
             , PRODUCT_INCLUDE_VAT
             , LINE_TAX_RATE
             , PRODUCT_UNIT_PRICE
             , PRODUCT_TOTAL_AMOUNT
             , PRODUCT_TOTAL_AMOUNT_AFTER_DISCOUNT
             , PRODUCT_REMARK
             , CAL
             , LAST_DETAIS)
        {
            this.PRODUCT_TRANSACTIONTYPE = TRANSACTION_TYPE;
            this.ADDITIONAL_REF_ASSIGN_ID = ADDITIONAL_REF_ASSIGN_ID;
        }

        public TradeLineItemInformation(int LINE_ID
            , string PRODUCT_NAME
            , double PRODUCT_QUANTITY
            , string PRODUCT_UNIT_CODE
            , string PRODUCT_CURRENCY_CODE
            , double PRODUCT_TOTAL_AMOUNT_AFTER_DISCOUNT)
        {
            if (PRODUCT_TOTAL_AMOUNT_AFTER_DISCOUNT < 0)
            {
                double PRODUCT_DISCOUNT = Math.Abs(PRODUCT_TOTAL_AMOUNT_AFTER_DISCOUNT);
                this.LINE_ALLOWANCE_TYPE_CODE = "95";
                this.LINE_ALLOWANCE_CHARGE_IND = PRODUCT_DISCOUNT > 0 ? this.ConvertBoolean(true) : this.ConvertBoolean(false);
                this.LINE_ALLOWANCE_ACTUAL_AMOUNT = this.ConvertDouble2Digit(PRODUCT_DISCOUNT);
                this.LINE_ALLOWANCE_ACTUAL_CURRENCY_CODE = PRODUCT_CURRENCY_CODE;

                PRODUCT_TOTAL_AMOUNT_AFTER_DISCOUNT = 0;
            }
            this.DATA_TYPE = "L";
            this.LINE_ID = this.ConvertInt(LINE_ID);
            this.PRODUCT_NAME = SecurityElement.Escape(PRODUCT_NAME);
            this.PRODUCT_CHARGE_AMOUNT = this.ConvertDouble2Digit(PRODUCT_TOTAL_AMOUNT_AFTER_DISCOUNT);
            this.PRODUCT_CHARGE_CURRENCY_CODE = PRODUCT_CURRENCY_CODE;
            this.PRODUCT_QUANTITY = this.ConvertDouble2Digit(PRODUCT_QUANTITY);
            this.PRODUCT_UNIT_CODE = PRODUCT_UNIT_CODE.Length > 3 ? PRODUCT_UNIT_CODE.Substring(0, 3) : PRODUCT_UNIT_CODE;
            this.LINE_BASIS_CURRENCY_CODE = PRODUCT_CURRENCY_CODE;
            this.LINE_NET_INCLUDE_TAX_TOTAL_AMOUNT = this.ConvertDouble2Digit(PRODUCT_TOTAL_AMOUNT_AFTER_DISCOUNT);
            this.LINE_NET_INCLUDE_TAX_TOTAL_CURRENCY_CODE = PRODUCT_CURRENCY_CODE;
        }

        public TradeLineItemInformation(int LINE_ID
          , string PRODUCT_ID
          , string PRODUCT_NAME
          , double PRODUCT_QUANTITY
          , string PRODUCT_UNIT_CODE
          , string PRODUCT_CURRENCY_CODE
          , bool PRODUCT_INCLUDE_VAT
          , double LINE_TAX_RATE
          , double PRODUCT_TOTAL_AMOUNT_AFTER_DISCOUNT
          , string PRODUCT_REMARK)
        {
            double PRODUCT_DISCOUNT = Math.Abs(PRODUCT_TOTAL_AMOUNT_AFTER_DISCOUNT);
            double LINE_BASIS_AMOUNT = 0;
            double LINE_TAX_AMOUNT = 0;
            double LINE_NET_INCLUDE_TAX_TOTAL_AMOUNT = 0;
            double PRODUCT_UNIT_PRICE = 0;

            this.DATA_TYPE = "L";
            this.LINE_ALLOWANCE_TYPE_CODE = "65";
            this.LINE_ID = this.ConvertInt(LINE_ID);
            this.PRODUCT_ID = PRODUCT_ID;
            this.PRODUCT_NAME = SecurityElement.Escape(PRODUCT_NAME);
            this.PRODUCT_CHARGE_AMOUNT = this.ConvertDouble2Digit(PRODUCT_UNIT_PRICE);
            this.PRODUCT_CHARGE_CURRENCY_CODE = PRODUCT_CURRENCY_CODE;
            this.PRODUCT_ALLOWANCE_CHARGE_IND = PRODUCT_DISCOUNT > 0 ? this.ConvertBoolean(true) : this.ConvertBoolean(false);
            this.PRODUCT_ALLOWANCE_ACTUAL_AMOUNT = this.ConvertDouble2Digit(PRODUCT_DISCOUNT);
            this.PRODUCT_ALLOWANCE_ACTUAL_CURRENCY_CODE = PRODUCT_CURRENCY_CODE;
            this.PRODUCT_QUANTITY = this.ConvertDouble2Digit(PRODUCT_QUANTITY);
            this.PRODUCT_UNIT_CODE = PRODUCT_UNIT_CODE.Length > 3 ? PRODUCT_UNIT_CODE.Substring(0, 3) : PRODUCT_UNIT_CODE;
            this.LINE_TAX_TYPE_CODE = LINE_TAX_RATE == 0 ? "FRE" : "VAT";
            this.LINE_TAX_CAL_RATE = this.ConvertDouble2Digit(LINE_TAX_RATE);
            this.LINE_BASIS_AMOUNT = this.ConvertDouble2Digit(LINE_BASIS_AMOUNT);

            this.LINE_BASIS_CURRENCY_CODE = PRODUCT_CURRENCY_CODE;
            this.LINE_TAX_CAL_AMOUNT = this.ConvertDouble2Digit(LINE_TAX_AMOUNT);
            this.LINE_TAX_CAL_CURRENCY_CODE = PRODUCT_CURRENCY_CODE;
            this.LINE_ALLOWANCE_CHARGE_IND = PRODUCT_DISCOUNT > 0 ? this.ConvertBoolean(true) : this.ConvertBoolean(false);
            this.LINE_ALLOWANCE_ACTUAL_AMOUNT = this.ConvertDouble2Digit(PRODUCT_DISCOUNT);
            this.LINE_ALLOWANCE_ACTUAL_CURRENCY_CODE = PRODUCT_CURRENCY_CODE;
            this.LINE_TAX_TOTAL_AMOUNT = this.ConvertDouble2Digit(LINE_TAX_AMOUNT);
            this.LINE_TAX_TOTAL_CURRENCY_CODE = PRODUCT_CURRENCY_CODE;
            this.LINE_NET_TOTAL_AMOUNT = this.ConvertDouble2Digit(LINE_BASIS_AMOUNT);
            this.LINE_NET_TOTAL_CURRENCY_CODE = PRODUCT_CURRENCY_CODE;

            this.LINE_NET_INCLUDE_TAX_TOTAL_AMOUNT = this.ConvertDouble2Digit(LINE_NET_INCLUDE_TAX_TOTAL_AMOUNT);
            this.LINE_NET_INCLUDE_TAX_TOTAL_CURRENCY_CODE = PRODUCT_CURRENCY_CODE;
            this.PRODUCT_REMARK = PRODUCT_REMARK;
        }
    }
}
