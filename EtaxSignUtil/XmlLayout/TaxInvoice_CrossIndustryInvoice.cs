using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace XmlLayout
{
    [XmlRoot("TaxInvoice_CrossIndustryInvoice", Namespace = Namespace.rsm)]
    public class TaxInvoice_CrossIndustryInvoice
    {
        [XmlElement("ExchangedDocumentContext", Namespace = Namespace.rsm)]
        public ExchangedDocumentContext ExchangedDocumentContext { get; set; }

        [XmlElement("ExchangedDocument", Namespace = Namespace.rsm)]
        public ExchangedDocument ExchangedDocument { get; set; }

        [XmlElement("SupplyChainTradeTransaction", Namespace = Namespace.rsm)]
        public SupplyChainTradeTransaction SupplyChainTradeTransaction { get; set; }

        public TaxInvoice_CrossIndustryInvoice()
        {
            this.ExchangedDocumentContext = new ExchangedDocumentContext();
            this.ExchangedDocument = new ExchangedDocument();
            this.SupplyChainTradeTransaction = new SupplyChainTradeTransaction();
        }
    }
}
