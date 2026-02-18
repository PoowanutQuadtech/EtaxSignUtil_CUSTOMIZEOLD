using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class BuyerTradeParty
    {
        [XmlElement("ID", Namespace = Namespace.ram)]
        public string ID { get; set; }

        [XmlElement("Name", Namespace = Namespace.ram)]
        public string Name { get; set; }

        [XmlElement("SpecifiedTaxRegistration", Namespace = Namespace.ram)]
        public SpecifiedTaxRegistration SpecifiedTaxRegistration { get; set; }

        [XmlElement("DefinedTradeContact", Namespace = Namespace.ram)]
        public DefinedTradeContact DefinedTradeContact { get; set; }

        [XmlElement("PostalTradeAddress", Namespace = Namespace.ram)]
        public PostalTradeAddress PostalTradeAddress { get; set; }

        public BuyerTradeParty()
        {
            this.SpecifiedTaxRegistration = new SpecifiedTaxRegistration();
            this.DefinedTradeContact = new DefinedTradeContact();
            this.PostalTradeAddress = new PostalTradeAddress();
        }
    }

}
