using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BE
{
    [Serializable]

    public class Address
    {
        public string Street { get; set; }
        public string Building { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}