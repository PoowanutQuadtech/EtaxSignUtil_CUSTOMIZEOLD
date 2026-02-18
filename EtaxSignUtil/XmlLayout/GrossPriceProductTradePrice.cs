using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class GrossPriceProductTradePrice
    {
        [XmlElement("ChargeAmount", Namespace = Namespace.ram)]
        public Amount ChargeAmount { get; set; }

        public GrossPriceProductTradePrice()
        {
            this.ChargeAmount = new Amount();
        }
    }

}
