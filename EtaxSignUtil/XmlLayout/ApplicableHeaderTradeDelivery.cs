using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class ApplicableHeaderTradeDelivery
    {
        [XmlElement("ActualDeliverySupplyChainEvent", Namespace = Namespace.ram)]
        public ActualDeliverySupplyChainEvent ActualDeliverySupplyChainEvent { get; set; }

        public ApplicableHeaderTradeDelivery()
        {
            this.ActualDeliverySupplyChainEvent = new ActualDeliverySupplyChainEvent();
        }
    }

}
