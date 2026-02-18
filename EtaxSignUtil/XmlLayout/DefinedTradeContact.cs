using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XmlLayout;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class DefinedTradeContact
    {
        [XmlElement("EmailURIUniversalCommunication", Namespace = Namespace.ram)]
        public EmailURIUniversalCommunication EmailURIUniversalCommunication { get; set; }

        public DefinedTradeContact()
        {
            this.EmailURIUniversalCommunication = new EmailURIUniversalCommunication();
        }
    }

}
