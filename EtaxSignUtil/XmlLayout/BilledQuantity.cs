using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class BilledQuantity
    {
         [XmlAttribute]
        public string unitCode { get; set; }

         [XmlText]
         public string value;
    }
}
