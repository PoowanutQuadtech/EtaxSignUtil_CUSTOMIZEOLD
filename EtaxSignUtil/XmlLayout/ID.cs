using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class ID
    {
         [XmlAttribute]
        public string schemeAgencyID { get; set; }

         [XmlAttribute]
        public string schemeVersionID { get; set; }

         [XmlAttribute]
         public string schemeID { get; set; }

         [XmlAttribute]
         public string transactionType { get; set; }

         [XmlText]
         public string value;
    }
}
