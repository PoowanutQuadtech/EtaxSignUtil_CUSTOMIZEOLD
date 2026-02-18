using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class GuidelineSpecifiedDocumentContextParameter
    {
        [XmlElement("ID", Namespace = Namespace.ram)]
        public ID ID { get; set; }

        public GuidelineSpecifiedDocumentContextParameter()
        {
            this.ID = new ID();
            this.ID.schemeAgencyID = "1";
            this.ID.schemeVersionID = "v2.0";
            this.ID.value = "1";
        }
    }
}
