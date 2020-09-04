using System;
using System.Collections.Generic;
using System.Xml.Serialization;


namespace BE
{
    [Serializable]

    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}