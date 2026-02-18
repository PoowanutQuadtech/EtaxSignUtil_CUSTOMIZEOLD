using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class Amount
    {
         [XmlAttribute]
        public string currencyID { get; set; }

         [XmlText]
         public string value;
    }
}
