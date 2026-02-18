using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class IncludedNote
    {
        [XmlElement("Subject", Namespace = Namespace.ram)]
        public string Subject { get; set; }

        [XmlElement("Content", Namespace = Namespace.ram)]
        public string Content { get; set; }
    }
}
