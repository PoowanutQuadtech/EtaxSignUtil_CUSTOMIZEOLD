using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class SpecifiedTradeSettlementHeaderMonetarySummation
    {
        [XmlElement("LineTotalAmount", Namespace = Namespace.ram)]
        public Amount LineTotalAmount { get; set; }

        [XmlElement("AllowanceTotalAmount", Namespace = Namespace.ram)]
        public Amount AllowanceTotalAmount { get; set; }

        [XmlElement("TaxBasisTotalAmount", Namespace = Namespace.ram)]
        public Amount TaxBasisTotalAmount { get; set; }

        [XmlElement("TaxTotalAmount", Namespace = Namespace.ram)]
        public Amount TaxTotalAmount { get; set; }

        [XmlElement("GrandTotalAmount", Namespace = Namespace.ram)]
        public Amount GrandTotalAmount { get; set; }

        public SpecifiedTradeSettlementHeaderMonetarySummation()
        {
            this.LineTotalAmount = new Amount();
            this.AllowanceTotalAmount = new Amount();
            this.TaxBasisTotalAmount = new Amount();
            this.TaxTotalAmount = new Amount();
            this.GrandTotalAmount = new Amount();
        }
    }

}
