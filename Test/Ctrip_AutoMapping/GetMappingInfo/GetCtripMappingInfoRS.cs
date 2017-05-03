using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using En = HW.Entity;

namespace HW.Entity
{
    [Serializable]
    [XmlRoot(ElementName = "RequestResponse")]
    public class GetCtripMappingInfoRS
    {
        [XmlElement(ElementName = "RequestResult")]
        public MappingRequestResult RequestResult { get; set; }
    }
    [Serializable]
    public class MappingRequestResult
    {
        public string Message { get; set; }
        public int ResultCode { get; set; }

        [XmlElement(ElementName = "Response")]
        public MappingResponse Response { get; set; }
    }

    [Serializable]
    public class MappingResponse
    {
        public HeaderInfo HeaderInfo { get; set; }

        [XmlElement(ElementName = "GetMappingInfoResponseList")]
        public En.GetMappingInfoResponseList GetMappingInfoResponseList { get; set; }
    }
}
