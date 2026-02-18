using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class ApplicableTradeTax
    {
        [XmlElement("TypeCode", Namespace = Namespace.ram)]
        public string TypeCode { get; set; }

        [XmlElement("CalculatedRate", Namespace = Namespace.ram)]
        public string CalculatedRate { get; set; }

        [XmlElement("BasisAmount", Namespace = Namespace.ram)]
        public Amount BasisAmount { get; set; }

        [XmlElement("CalculatedAmount", Namespace = Namespace.ram)]
        public Amount CalculatedAmount { get; set; }

        public ApplicableTradeTax()
        {
            this.BasisAmount = new Amount();
            this.CalculatedAmount = new Amount();
        }
    }

}
