using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class SpecifiedTaxRegistration
    {
        [XmlElement("ID", Namespace = Namespace.ram)]
        public ID ID { get; set; }

        public SpecifiedTaxRegistration()
        {
            this.ID = new ID();
            this.ID.schemeID = "TXID";
        }
    }
}
