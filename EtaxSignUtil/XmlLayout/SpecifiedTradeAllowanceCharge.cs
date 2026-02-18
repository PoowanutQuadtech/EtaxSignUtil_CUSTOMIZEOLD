using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class SpecifiedTradeAllowanceCharge
    {
        [XmlElement("ChargeIndicator", Namespace = Namespace.ram)]
        public string ChargeIndicator { get; set; }

        [XmlElement("ActualAmount", Namespace = Namespace.ram)]
        public Amount ActualAmount { get; set; }

        [XmlElement("TypeCode", Namespace = Namespace.ram)]
        public string TypeCode { get; set; }

        public SpecifiedTradeAllowanceCharge()
        {
            this.ActualAmount = new Amount();
        }
    }

}
