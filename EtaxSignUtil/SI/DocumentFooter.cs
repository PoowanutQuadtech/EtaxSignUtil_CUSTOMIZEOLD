using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EtaxSignUtil.SI
{
    public class DocumentFooter : EtaxSignUtil.Layout.DocumentFooter
    {
        [Required()]
        [StringLength(844)]
        [Description("เงื่อนไขการชำระเงิน (วัน)[TERM_PAYMENT]")]
        public virtual string TERM_PAYMENT { get; set; }

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
            , DateTime PAYMENT_DUE_DTM
            , int TERM_PAYMENT
            , double PRODUCT_DISCOUNT_AMOUNT) :
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
             , PAYMENT_TYPE_CODE
             , PAYMENT_DESCRIPTION
             , PAYMENT_DUE_DTM
             , PRODUCT_DISCOUNT_AMOUNT
             , null)
        {
            this.TERM_PAYMENT = this.ConvertDouble2Digit(TERM_PAYMENT);
        }
    }
}
