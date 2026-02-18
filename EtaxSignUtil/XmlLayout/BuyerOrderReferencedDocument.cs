using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class BuyerOrderReferencedDocument
    {
        [XmlElement("IssuerAssignedID", Namespace = Namespace.ram)]
        public string IssuerAssignedID { get; set; }

        [XmlElement("IssuerAssignedID2", Namespace = Namespace.ram)]
        public string IssuerAssignedID2 { get; set; }
    }

}
