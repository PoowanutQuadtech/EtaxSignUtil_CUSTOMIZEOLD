using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class ExchangedDocumentContext
    {
        [XmlElement("GuidelineSpecifiedDocumentContextParameter", Namespace = Namespace.ram)]
        public GuidelineSpecifiedDocumentContextParameter GuidelineSpecifiedDocumentContextParameter { get; set; }

        public ExchangedDocumentContext()
        {
            this.GuidelineSpecifiedDocumentContextParameter = new GuidelineSpecifiedDocumentContextParameter();
        }
    }
}
