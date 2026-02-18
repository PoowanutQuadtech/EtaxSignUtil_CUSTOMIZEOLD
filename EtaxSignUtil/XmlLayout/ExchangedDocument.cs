using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class ExchangedDocument
    {
        [XmlElement("ID", Namespace = Namespace.ram)]
        public string ID  { get; set; }

        [XmlElement("Name", Namespace = Namespace.ram)]
        public string Name { get; set; }

        [XmlElement("TypeCode", Namespace = Namespace.ram)]
        public TypeCode TypeCode { get; set; }

        [XmlElement("IssueDateTime", Namespace = Namespace.ram)]
        public string IssueDateTime { get; set; }

        [XmlElement("CreationDateTime", Namespace = Namespace.ram)]
        public string CreationDateTime { get; set; }

        [XmlElement("IncludedNote", Namespace = Namespace.ram)]
        public IncludedNote[] IncludedNote { get; set; }

        public ExchangedDocument()
        {
            this.TypeCode = new TypeCode();
        }

    }

}
