using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class SupplyChainTradeTransaction
    {
        [XmlElement("ApplicableHeaderTradeAgreement", Namespace = Namespace.ram)]
        public ApplicableHeaderTradeAgreement ApplicableHeaderTradeAgreement { get; set; }

        [XmlElement("ApplicableHeaderTradeDelivery", Namespace = Namespace.ram)]
        public ApplicableHeaderTradeDelivery ApplicableHeaderTradeDelivery { get; set; }

        [XmlElement("ApplicableHeaderTradeSettlement", Namespace = Namespace.ram)]
        public ApplicableHeaderTradeSettlement ApplicableHeaderTradeSettlement { get; set; }

        [XmlElement("IncludedSupplyChainTradeLineItem", Namespace = Namespace.ram)]
        public IncludedSupplyChainTradeLineItem[] IncludedSupplyChainTradeLineItem { get; set; }

        public SupplyChainTradeTransaction()
        {
            this.ApplicableHeaderTradeAgreement = new ApplicableHeaderTradeAgreement();
            this.ApplicableHeaderTradeDelivery = new ApplicableHeaderTradeDelivery();
            this.ApplicableHeaderTradeSettlement = new ApplicableHeaderTradeSettlement();
        }
    }

}
