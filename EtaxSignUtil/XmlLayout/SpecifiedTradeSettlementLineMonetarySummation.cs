using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class SpecifiedTradeSettlementLineMonetarySummation
    {
        [XmlElement("TaxTotalAmount", Namespace = Namespace.ram)]
        public Amount TaxTotalAmount { get; set; }

        [XmlElement("NetLineTotalAmount", Namespace = Namespace.ram)]
        public Amount NetLineTotalAmount { get; set; }

        [XmlElement("NetIncludingTaxesLineTotalAmount", Namespace = Namespace.ram)]
        public Amount NetIncludingTaxesLineTotalAmount { get; set; }

        public SpecifiedTradeSettlementLineMonetarySummation()
        {
            this.TaxTotalAmount = new Amount();
            this.NetLineTotalAmount = new Amount();
            this.NetIncludingTaxesLineTotalAmount = new Amount();
        }
    }

}
