using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class EmailURIUniversalCommunication
    {
        [XmlElement("URIID", Namespace = Namespace.ram)]
        public string URIID { get; set; }
    }

}
