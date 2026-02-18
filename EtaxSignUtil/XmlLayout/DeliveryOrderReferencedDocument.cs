using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class DeliveryOrderReferencedDocument
    {
        [XmlElement("IssuerAssignedID", Namespace = Namespace.ram)]
        public string IssuerAssignedID { get; set; }
    }

}
