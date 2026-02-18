using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class IncludedSupplyChainTradeLineItem
    {
        [XmlElement("AssociatedDocumentLineDocument", Namespace = Namespace.ram)]
        public AssociatedDocumentLineDocument AssociatedDocumentLineDocument { get; set; }

        [XmlElement("SpecifiedTradeProduct", Namespace = Namespace.ram)]
        public SpecifiedTradeProduct SpecifiedTradeProduct { get; set; }

        [XmlElement("SpecifiedLineTradeAgreement", Namespace = Namespace.ram)]
        public SpecifiedLineTradeAgreement SpecifiedLineTradeAgreement { get; set; }

        [XmlElement("SpecifiedLineTradeDelivery", Namespace = Namespace.ram)]
        public SpecifiedLineTradeDelivery SpecifiedLineTradeDelivery { get; set; }

        [XmlElement("SpecifiedLineTradeSettlement", Namespace = Namespace.ram)]
        public SpecifiedLineTradeSettlement SpecifiedLineTradeSettlement { get; set; }


        public IncludedSupplyChainTradeLineItem()
        {
            this.AssociatedDocumentLineDocument = new AssociatedDocumentLineDocument();
            this.SpecifiedTradeProduct = new SpecifiedTradeProduct();
            this.SpecifiedLineTradeAgreement = new SpecifiedLineTradeAgreement();
            this.SpecifiedLineTradeDelivery = new SpecifiedLineTradeDelivery();
            this.SpecifiedLineTradeSettlement = new SpecifiedLineTradeSettlement();
        }
    }

}
