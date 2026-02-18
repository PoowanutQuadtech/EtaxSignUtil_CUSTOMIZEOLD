using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class TypeCode
    {
         [XmlAttribute]
        public string listAgencyID { get; set; }

         [XmlAttribute]
         public string listID { get; set; }

         [XmlAttribute]
         public string listVersionID { get; set; }

         [XmlText]
         public string value;

         public TypeCode()
         {
             this.listID = "1001_ThaiDocumentNameCodeInvoice";
             this.listAgencyID = "RD/ETDA";
             this.listVersionID = "15A";
         }
    }
}
