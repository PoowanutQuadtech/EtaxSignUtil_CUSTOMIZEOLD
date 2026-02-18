using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class SpecifiedLineTradeDelivery
    {
        [XmlElement("BilledQuantity", Namespace = Namespace.ram)]
        public BilledQuantity BilledQuantity { get; set; }


        [XmlElement("DeliveryOrderReferencedDocument", Namespace = Namespace.ram)]
        public DeliveryOrderReferencedDocument DeliveryOrderReferencedDocument { get; set; }

        public SpecifiedLineTradeDelivery()
        {
            this.BilledQuantity = new BilledQuantity();
            this.DeliveryOrderReferencedDocument = new DeliveryOrderReferencedDocument();
        }
    }

}
