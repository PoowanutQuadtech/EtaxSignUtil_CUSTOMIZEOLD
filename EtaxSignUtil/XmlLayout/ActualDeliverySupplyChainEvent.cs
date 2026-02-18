using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class ActualDeliverySupplyChainEvent
    {
        [XmlElement("OccurrenceDateTime", Namespace = Namespace.ram)]
        public string OccurrenceDateTime { get; set; }
    }

}
