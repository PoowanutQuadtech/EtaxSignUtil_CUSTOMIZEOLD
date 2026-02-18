using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class ApplicableHeaderTradeAgreement
    {
        [XmlElement("SellerTradeParty", Namespace = Namespace.ram)]
        public SellerTradeParty SellerTradeParty { get; set; }

        [XmlElement("BuyerTradeParty", Namespace = Namespace.ram)]
        public BuyerTradeParty BuyerTradeParty { get; set; }

        [XmlElement("BuyerOrderReferencedDocument", Namespace = Namespace.ram)]
        public BuyerOrderReferencedDocument BuyerOrderReferencedDocument { get; set; }
        
        public ApplicableHeaderTradeAgreement()
        {
            this.SellerTradeParty = new SellerTradeParty();
            this.BuyerTradeParty = new BuyerTradeParty();
            this.BuyerOrderReferencedDocument = new BuyerOrderReferencedDocument();
        }
    }

}
