using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class SpecifiedLineTradeAgreement
    {
        [XmlElement("GrossPriceProductTradePrice", Namespace = Namespace.ram)]
        public GrossPriceProductTradePrice GrossPriceProductTradePrice { get; set; }

        public SpecifiedLineTradeAgreement()
        {
            this.GrossPriceProductTradePrice = new GrossPriceProductTradePrice();
        }
    }

}
