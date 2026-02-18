using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class SpecifiedTradePaymentTerms
    {
        [XmlElement("Description", Namespace = Namespace.ram)]
        public string Description { get; set; }

        [XmlElement("DueDateDateTime", Namespace = Namespace.ram)]
        public string DueDateDateTime { get; set; }

        [XmlElement("TypeCode", Namespace = Namespace.ram)]
        public string TypeCode { get; set; }
    }

}
