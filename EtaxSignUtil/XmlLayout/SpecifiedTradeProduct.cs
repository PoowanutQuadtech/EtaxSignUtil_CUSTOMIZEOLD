using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class SpecifiedTradeProduct
    {
        [XmlElement("ID", Namespace = Namespace.ram)]
        public ID ID { get; set; }

        [XmlElement("Name", Namespace = Namespace.ram)]
        public string Name { get; set; }

        [XmlElement("InformationNote", Namespace = Namespace.ram)]
        public IncludedNote[] InformationNote { get; set; }

        public SpecifiedTradeProduct()
        {
            this.ID = new ID();
        }
    }

}
