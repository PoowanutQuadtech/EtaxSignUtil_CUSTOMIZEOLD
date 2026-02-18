using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class SpecifiedLineTradeSettlement
    {
        [XmlElement("ApplicableTradeTax", Namespace = Namespace.ram)]
        public ApplicableTradeTax ApplicableTradeTax { get; set; }

        [XmlElement("SpecifiedTradeAllowanceCharge", Namespace = Namespace.ram)]
        public SpecifiedTradeAllowanceCharge SpecifiedTradeAllowanceCharge { get; set; }

        [XmlElement("SpecifiedTradeSettlementLineMonetarySummation", Namespace = Namespace.ram)]
        public SpecifiedTradeSettlementLineMonetarySummation SpecifiedTradeSettlementLineMonetarySummation { get; set; }

        public SpecifiedLineTradeSettlement()
        {
            this.ApplicableTradeTax = new ApplicableTradeTax();
            this.SpecifiedTradeAllowanceCharge = new SpecifiedTradeAllowanceCharge();
            this.SpecifiedTradeSettlementLineMonetarySummation = new SpecifiedTradeSettlementLineMonetarySummation();
        }
    }

}
