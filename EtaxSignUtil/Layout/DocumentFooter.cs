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
    public class DocumentFooter : TaxFileLayout
    {

        [Required()]
        [StringLength(1)]
        [Description("ประเภทรายการ[DATA_TYPE]")]
        public virtual string DATA_TYPE { get; set; }


        [Required()]
        [StringLength(5)]
        [Description("จำนวนรายการสินค้า[LINE_TOTAL_COUNT]")]
        public virtual string LINE_TOTAL_COUNT { get; set; }


        [StringLength(19)]
        [Description("วันเวลานัดส่งสินค้า[DELIVERY_OCCUR_DTM]")]
        public virtual string DELIVERY_OCCUR_DTM { get; set; }


        [StringLength(3)]
        [Description("รหัสสกุลเงินตรา[INVOICE_CURRENCY_CODE]")]
        public virtual string INVOICE_CURRENCY_CODE { get; set; }


        [Required()]
        [StringLength(3)]
        [Description("รหัสประเภทภาษี[TAX_TYPE_CODE]")]
        public virtual string TAX_TYPE_CODE { get; set; }


        [Required()]
        [StringLength(5)]
        [Description("อัตราภาษี[TAX_CAL_RATE]")]
        public virtual string TAX_CAL_RATE { get; set; }


        [Required()]
        [StringLength(16)]
        [Description("มูลค่าสินค้า/บริการ (ไม่รวมภาษีมูลค่าเพิ่ม)[BASIS_AMOUNT]")]
        public virtual string BASIS_AMOUNT { get; set; }


        [Required()]
        [StringLength(3)]
        [Description("มูลค่าสินค้า/บริการ (ไม่รวมภาษีมูลค่าเพิ่ม)[BASIS_CURRENCY_CODE]")]
        public virtual string BASIS_CURRENCY_CODE { get; set; }


        [Required()]
        [StringLength(16)]
        [Description("มูลค่าภาษีมูลค่าเพิ่ม[TAX_CAL_AMOUNT]")]
        public virtual string TAX_CAL_AMOUNT { get; set; }


        [Required()]
        [StringLength(3)]
        [Description("มูลค่าภาษีมูลค่าเพิ่ม[TAX_CAL_CURRENCY_CODE]")]
        public virtual string TAX_CAL_CURRENCY_CODE { get; set; }


        [StringLength(5)]
        [Description("ตัวบอกส่วนลดหรือค่าธรรมเนียม[ALLOWANCE_CHARGE_IND]")]
        public virtual string ALLOWANCE_CHARGE_IND { get; set; }


        [StringLength(16)]
        [Description("มูลค่าส่วนลดหรือค่าธรรมเนียม[ALLOWANCE_ACTUAL_AMOUNT]")]
        public virtual string ALLOWANCE_ACTUAL_AMOUNT { get; set; }


        [StringLength(3)]
        [Description("มูลค่าส่วนลดหรือค่าธรรมเนียม[ALLOWANCE_ACTUAL_CURRENCY_CODE]")]
        public virtual string ALLOWANCE_ACTUAL_CURRENCY_CODE { get; set; }


        [StringLength(16)]
        [Description("รหัสเหตุผลในการคิดส่วนลดหรือค่าธรรมเนียม[ALLOWANCE_REASON_CODE]")]
        public virtual string ALLOWANCE_REASON_CODE { get; set; }


        [StringLength(256)]
        [Description("เหตุผลในการคิดสวนลดหรือค่าธรรมเนียม[ALLOWANCE_REASON]")]
        public virtual string ALLOWANCE_REASON { get; set; }


        [StringLength(16)]
        [Description("รหัสประเภทส่วนลดหรือค่าธรรมเนียม[PAYMENT_TYPE_CODE]")]
        public virtual string PAYMENT_TYPE_CODE { get; set; }


        [StringLength(256)]
        [Description("รายละเอียดเงื่อนไขการชำระเงิน[PAYMENT_DESCRIPTION]")]
        public virtual string PAYMENT_DESCRIPTION { get; set; }


        [StringLength(19)]
        [Description("วันครบกำหนดชำระเงิน[PAYMENT_DUE_DTM]")]
        public virtual string PAYMENT_DUE_DTM { get; set; }


        //[StringLength(16)]
        //[Description("รวมมูลค่าตามเอกสารเดิม[ORIGINAL_TOTAL_AMOUNT]")]
        //public virtual string ORIGINAL_TOTAL_AMOUNT { get; set; }


        //[StringLength(3)]
        //[Description("รวมมูลค่าตามเอกสารเดิม[ORIGINAL_TOTAL_CURRENCY_CODE]")]
        //public virtual string ORIGINAL_TOTAL_CURRENCY_CODE { get; set; }


        [Required()]
        [StringLength(16)]
        [Description("รวมมูลค่าตามรายการ/มูลค่าที่ถูกต้อง[LINE_TOTAL_AMOUNT]")]
        public virtual string LINE_TOTAL_AMOUNT { get; set; }


        [Required()]
        [StringLength(3)]
        [Description("รวมมูลค่าตามรายการ/มูลค่าที่ถูกต้อง[LINE_TOTAL_CURRENCY_CODE]")]
        public virtual string LINE_TOTAL_CURRENCY_CODE { get; set; }


        //[StringLength(16)]
        //[Description("มูลค่าผลต่าง[ADJUSTED_INFORMATION_AMOUNT]")]
        //public virtual string ADJUSTED_INFORMATION_AMOUNT { get; set; }


        //[StringLength(3)]
        //[Description("มูลค่าผลต่าง[ADJUSTED_INFORMATION_CURRENCY_CODE]")]
        //public virtual string ADJUSTED_INFORMATION_CURRENCY_CODE { get; set; }


        [StringLength(16)]
        [Description("ส่วนลดทั้งหมด[ALLOWANCE_TOTAL_AMOUNT]")]
        public virtual string ALLOWANCE_TOTAL_AMOUNT { get; set; }


        [StringLength(3)]
        [Description("ส่วนลดทั้งหมด[ALLOWANCE_TOTAL_CURRENCY_CODE]")]
        public virtual string ALLOWANCE_TOTAL_CURRENCY_CODE { get; set; }


        [StringLength(16)]
        [Description("ค่าธรรมเนียมทั้งหมด[CHARGE_TOTAL_AMOUNT]")]
        public virtual string CHARGE_TOTAL_AMOUNT { get; set; }


        [StringLength(3)]
        [Description("ค่าธรรมเนียมทั้งหมด[CHARGE_TOTAL_CURRENCY_CODE]")]
        public virtual string CHARGE_TOTAL_CURRENCY_CODE { get; set; }


        [Required()]
        [StringLength(16)]
        [Description("มูลค่าที่นำมาคิดภาษีมูลค่าเพิ่ม[TAX_BASIS_TOTAL_AMOUNT]")]
        public virtual string TAX_BASIS_TOTAL_AMOUNT { get; set; }


        [Required()]
        [StringLength(3)]
        [Description("มูลค่าที่นำมาคิดภาษีมูลค่าเพิ่ม[TAX_BASIS_TOTAL_CURRENCY_CODE]")]
        public virtual string TAX_BASIS_TOTAL_CURRENCY_CODE { get; set; }


        [Required()]
        [StringLength(16)]
        [Description("จำนวนภาษีมูลค่าเพิ่ม[TAX_TOTAL_AMOUNT]")]
        public virtual string TAX_TOTAL_AMOUNT { get; set; }


        [Required()]
        [StringLength(3)]
        [Description("จำนวนภาษีมูลค่าเพิ่ม[TAX_TOTAL_CURRENCY_CODE]")]
        public virtual string TAX_TOTAL_CURRENCY_CODE { get; set; }


        [Required()]
        [StringLength(16)]
        [Description("จำนวนเงินรวม (รวมภาษีมูลค่าเพิ่ม)[GRAND_TOTAL_AMOUNT]")]
        public virtual string GRAND_TOTAL_AMOUNT { get; set; }


        [Required()]
        [StringLength(3)]
        [Description("จำนวนเงินรวม (รวมภาษีมูลค่าเพิ่ม)[GRAND_TOTAL_CURRENCY_CODE]")]
        public virtual string GRAND_TOTAL_CURRENCY_CODE { get; set; }


        //[Required()]
        //[StringLength(844)]
        //[Description("เงื่อนไขการชำระเงิน (วัน)[TERM_PAYMENT]")]
        //public virtual string TERM_PAYMENT { get; set; }

        public DocumentFooter(int LINE_TOTAL_COUNT
            , DateTime DELIVERY_OCCUR_DTM
            , string INVOICE_CURRENCY_CODE
            , bool INVOICE_INCLUDE_VAT
            , double INVOICE_TOTAL_AMOUNT
            , double DISCOUNT_AMOUNT
            , double INVOICE_TOTAL_AMOUNT_AFTER_DISCOUNT
            , double TAX_RATE
            , double TAX_AMOUNT
            , double INVOICE_TOTAL_AMOUNT_AFTER_TAX
            , string PAYMENT_TYPE_CODE
            , string PAYMENT_DESCRIPTION
            , DateTime? PAYMENT_DUE_DTM
            , double PRODUCT_DISCOUNT_AMOUNT
            , double? LINE_TOTAL_AMOUNT)
        {
            this.DATA_TYPE = "F";
            this.LINE_TOTAL_COUNT = this.ConvertInt(LINE_TOTAL_COUNT);
            this.DELIVERY_OCCUR_DTM = this.ConvertISODateTime(DELIVERY_OCCUR_DTM);
            this.INVOICE_CURRENCY_CODE = INVOICE_CURRENCY_CODE;
            this.TAX_TYPE_CODE = TAX_RATE == 0 ? "FRE" : "VAT";
            this.TAX_CAL_RATE = this.ConvertDouble2Digit(TAX_RATE);

            if (LINE_TOTAL_AMOUNT.HasValue)
                this.LINE_TOTAL_AMOUNT = this.ConvertDouble2Digit(LINE_TOTAL_AMOUNT.Value);
            else
                this.LINE_TOTAL_AMOUNT = this.ConvertDouble2Digit(INVOICE_TOTAL_AMOUNT_AFTER_DISCOUNT + DISCOUNT_AMOUNT);
            this.LINE_TOTAL_CURRENCY_CODE = INVOICE_CURRENCY_CODE;

            this.BASIS_AMOUNT = this.ConvertDouble2Digit(INVOICE_TOTAL_AMOUNT_AFTER_DISCOUNT);
            this.BASIS_CURRENCY_CODE = INVOICE_CURRENCY_CODE;

            this.TAX_CAL_AMOUNT = this.ConvertDouble2Digit(TAX_AMOUNT);
            this.TAX_CAL_CURRENCY_CODE = INVOICE_CURRENCY_CODE;

            this.ALLOWANCE_CHARGE_IND = DISCOUNT_AMOUNT > 0 ? this.ConvertBoolean(true) : this.ConvertBoolean(false);
            this.ALLOWANCE_ACTUAL_AMOUNT = this.ConvertDouble2Digit(DISCOUNT_AMOUNT);
            this.ALLOWANCE_ACTUAL_CURRENCY_CODE = INVOICE_CURRENCY_CODE;

            if (!String.IsNullOrEmpty(PAYMENT_TYPE_CODE))
            {
                this.PAYMENT_TYPE_CODE = paymentTypeCodeClass.GetPaymentTypeCode(PAYMENT_TYPE_CODE);
            }
            if (!String.IsNullOrEmpty(PAYMENT_DESCRIPTION))
                this.PAYMENT_DESCRIPTION = PAYMENT_DESCRIPTION;
            if (PAYMENT_DUE_DTM.HasValue)
                this.PAYMENT_DUE_DTM = this.ConvertISODateTime(PAYMENT_DUE_DTM.Value);

            this.TAX_BASIS_TOTAL_AMOUNT = this.ConvertDouble2Digit(INVOICE_TOTAL_AMOUNT_AFTER_DISCOUNT);
            this.TAX_BASIS_TOTAL_CURRENCY_CODE = INVOICE_CURRENCY_CODE;

            this.TAX_TOTAL_AMOUNT = this.ConvertDouble2Digit(TAX_AMOUNT);
            this.TAX_TOTAL_CURRENCY_CODE = INVOICE_CURRENCY_CODE;

            this.GRAND_TOTAL_AMOUNT = this.ConvertDouble2Digit(INVOICE_TOTAL_AMOUNT_AFTER_TAX);
            this.GRAND_TOTAL_CURRENCY_CODE = INVOICE_CURRENCY_CODE;

            this.ALLOWANCE_TOTAL_AMOUNT = this.ConvertDouble2Digit(DISCOUNT_AMOUNT + PRODUCT_DISCOUNT_AMOUNT);
            this.ALLOWANCE_TOTAL_CURRENCY_CODE = INVOICE_CURRENCY_CODE;
        }



        public DocumentFooter(int LINE_TOTAL_COUNT
             , DateTime DELIVERY_OCCUR_DTM
             , string INVOICE_CURRENCY_CODE
             , bool INVOICE_INCLUDE_VAT
             , double INVOICE_TOTAL_AMOUNT
             , double DISCOUNT_AMOUNT
             , double INVOICE_TOTAL_AMOUNT_AFTER_DISCOUNT
             , double TAX_RATE
             , double TAX_AMOUNT
             , double INVOICE_TOTAL_AMOUNT_AFTER_TAX
             , double PRODUCT_DISCOUNT_AMOUNT
             , double? LINE_TOTAL_AMOUNT) : 
            this(LINE_TOTAL_COUNT
            , DELIVERY_OCCUR_DTM
            , INVOICE_CURRENCY_CODE
            , INVOICE_INCLUDE_VAT
            , INVOICE_TOTAL_AMOUNT
            , DISCOUNT_AMOUNT
            , INVOICE_TOTAL_AMOUNT_AFTER_DISCOUNT
            , TAX_RATE
            , TAX_AMOUNT
            , INVOICE_TOTAL_AMOUNT_AFTER_TAX
            , ""
            , ""
            , null
            , PRODUCT_DISCOUNT_AMOUNT
            , LINE_TOTAL_AMOUNT)
        {

        }

        public DocumentFooter(int LINE_TOTAL_COUNT
             , string INVOICE_CURRENCY_CODE
             , double INVOICE_TOTAL_AMOUNT_AFTER_TAX)
        {
            this.DATA_TYPE = "F";
            this.LINE_TOTAL_COUNT = this.ConvertInt(LINE_TOTAL_COUNT);
            this.INVOICE_CURRENCY_CODE = INVOICE_CURRENCY_CODE;
            this.TAX_TOTAL_CURRENCY_CODE = INVOICE_CURRENCY_CODE;
            this.GRAND_TOTAL_AMOUNT = this.ConvertDouble2Digit(INVOICE_TOTAL_AMOUNT_AFTER_TAX);
            this.GRAND_TOTAL_CURRENCY_CODE = INVOICE_CURRENCY_CODE;
        }
    }
}
