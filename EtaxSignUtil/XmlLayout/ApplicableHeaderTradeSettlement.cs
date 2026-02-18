using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class ApplicableHeaderTradeSettlement
    {
        [XmlElement("InvoiceCurrencyCode", Namespace = Namespace.ram)]
        public string InvoiceCurrencyCode { get; set; }

        [XmlElement("ApplicableTradeTax", Namespace = Namespace.ram)]
        public ApplicableTradeTax ApplicableTradeTax { get; set; }

        [XmlElement("SpecifiedTradeAllowanceCharge", Namespace = Namespace.ram)]
        public SpecifiedTradeAllowanceCharge SpecifiedTradeAllowanceCharge { get; set; }

        [XmlElement("SpecifiedTradePaymentTerms", Namespace = Namespace.ram)]
        public SpecifiedTradePaymentTerms SpecifiedTradePaymentTerms { get; set; }

        [XmlElement("SpecifiedTradeSettlementHeaderMonetarySummation", Namespace = Namespace.ram)]
        public SpecifiedTradeSettlementHeaderMonetarySummation SpecifiedTradeSettlementHeaderMonetarySummation { get; set; }

        public ApplicableHeaderTradeSettlement()
        {
            this.ApplicableTradeTax = new ApplicableTradeTax();
            this.SpecifiedTradeAllowanceCharge = new SpecifiedTradeAllowanceCharge();
            this.SpecifiedTradePaymentTerms = new SpecifiedTradePaymentTerms();
            this.SpecifiedTradeSettlementHeaderMonetarySummation = new SpecifiedTradeSettlementHeaderMonetarySummation();
        }
    }

}
