using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace XmlLayout
{
    public class PostalTradeAddress
    {
        [XmlElement("PostcodeCode", Namespace = Namespace.ram)]
        public string PostcodeCode { get; set; }

        [XmlElement("BuildingName", Namespace = Namespace.ram)]
        public string BuildingName { get; set; }

        [XmlElement("LineOne", Namespace = Namespace.ram)]
        public string LineOne { get; set; }

        [XmlElement("LineTwo", Namespace = Namespace.ram)]
        public string LineTwo { get; set; }

        [XmlElement("LineThree", Namespace = Namespace.ram)]
        public string LineThree { get; set; }

        [XmlElement("LineFour", Namespace = Namespace.ram)]
        public string LineFour { get; set; }

        [XmlElement("LineFive", Namespace = Namespace.ram)]
        public string LineFive { get; set; }

        [XmlElement("StreetName", Namespace = Namespace.ram)]
        public string StreetName { get; set; }

        [XmlElement("CityName", Namespace = Namespace.ram)]
        public string CityName { get; set; }

        [XmlElement("CitySubDivisionName", Namespace = Namespace.ram)]
        public string CitySubDivisionName { get; set; }

        [XmlElement("CountryID", Namespace = Namespace.ram)]
        public string CountryID { get; set; }

        [XmlElement("CountrySubDivisionID", Namespace = Namespace.ram)]
        public string CountrySubDivisionID { get; set; }

        [XmlElement("BuildingNumber", Namespace = Namespace.ram)]
        public string BuildingNumber { get; set; }
    }
}
