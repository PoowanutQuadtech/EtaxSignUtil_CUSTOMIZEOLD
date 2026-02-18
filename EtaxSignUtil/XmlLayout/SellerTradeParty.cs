using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class SellerTradeParty
    {
        [XmlElement("Name", Namespace = Namespace.ram)]
        public string Name { get; set; }

        [XmlElement("SpecifiedTaxRegistration", Namespace = Namespace.ram)]
        public SpecifiedTaxRegistration SpecifiedTaxRegistration { get; set; }

        [XmlElement("PostalTradeAddress", Namespace = Namespace.ram)]
        public PostalTradeAddress PostalTradeAddress { get; set; }

        public SellerTradeParty()
        {
            this.SpecifiedTaxRegistration = new SpecifiedTaxRegistration();
            this.PostalTradeAddress = new PostalTradeAddress();
        }
    }

}
