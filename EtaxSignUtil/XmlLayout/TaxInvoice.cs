using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace XmlLayout
{
    [XmlRoot("TaxInvoice", Namespace = Namespace.rsm)]
    public class TaxInvoice
    {
        [XmlElement("TaxInvoice_CrossIndustryInvoice", Namespace = Namespace.rsm)]
        public TaxInvoice_CrossIndustryInvoice[] TaxInvoice_CrossIndustryInvoice { get; set; }
    }
}
