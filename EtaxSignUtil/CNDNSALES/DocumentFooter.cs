using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EtaxSignUtil.CNDNSALES
{

    public class DocumentFooter : EtaxSignUtil.Layout.DocumentFooter
    {
        [Required()]
        [StringLength(16)]
        [Description("รวมมูลค่าตามเอกสารเดิม[ORIGINAL_TOTAL_AMOUNT]")]
        public virtual string ORIGINAL_TOTAL_AMOUNT { get; set; }


        [Required()]
        [StringLength(3)]
        [Description("รวมมูลค่าตามเอกสารเดิม[ORIGINAL_TOTAL_CURRENCY_CODE]")]
        public virtual string ORIGINAL_TOTAL_CURRENCY_CODE { get; set; }


        [Required()]
        [StringLength(16)]
        [Description("มูลค่าผลต่าง[ADJUSTED_INFORMATION_AMOUNT]")]
        public virtual string ADJUSTED_INFORMATION_AMOUNT { get; set; }


        [Required()]
        [StringLength(3)]
        [Description("มูลค่าผลต่าง[ADJUSTED_INFORMATION_CURRENCY_CODE]")]
        public virtual string ADJUSTED_INFORMATION_CURRENCY_CODE { get; set; }

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
            , double ORIGINAL_TOTAL_AMOUNT
            , double LINE_TOTAL_AMOUNT
            , double ADJUSTED_INFORMATION_AMOUNT) :
            base(LINE_TOTAL_COUNT
            , DELIVERY_OCCUR_DTM
            , INVOICE_CURRENCY_CODE
            , INVOICE_INCLUDE_VAT
            , INVOICE_TOTAL_AMOUNT
            , DISCOUNT_AMOUNT
            , INVOICE_TOTAL_AMOUNT_AFTER_DISCOUNT
            , TAX_RATE
            , TAX_AMOUNT
            , INVOICE_TOTAL_AMOUNT_AFTER_TAX
            , 0
            , LINE_TOTAL_AMOUNT)
        {
            this.ORIGINAL_TOTAL_AMOUNT = this.ConvertDouble2Digit(ORIGINAL_TOTAL_AMOUNT);
            this.ORIGINAL_TOTAL_CURRENCY_CODE = INVOICE_CURRENCY_CODE;

            this.ADJUSTED_INFORMATION_AMOUNT = this.ConvertDouble2Digit(ADJUSTED_INFORMATION_AMOUNT);
            this.ADJUSTED_INFORMATION_CURRENCY_CODE = INVOICE_CURRENCY_CODE;
        }
    }
}
