using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NNDD.Entities
{
    public class LoginData
    {
        [XmlRoot(ElementName = "nicovideo_user_response")]
        public class Nicovideo_user_response
        {
            [XmlElement(ElementName = "session_key")]
            public string Session_key { get; set; }
            [XmlElement(ElementName = "expire")]
            public string Expire { get; set; }
            [XmlElement(ElementName = "user_id")]
            public string User_id { get; set; }
            [XmlAttribute(AttributeName = "status")]
            public string Status { get; set; }
        }
    }
}
