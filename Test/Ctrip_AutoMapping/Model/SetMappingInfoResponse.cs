using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Ctrip_AutoMapping.Model
{
    [Serializable]
    [XmlRoot(ElementName = "RequestResponse")]
    public class SetMappingInfoResponse
    {
        public RequestResult RequestResult { get; set; }
    }
    [Serializable]
    public class RequestResult
    {
        public string Message { get; set; }
        public string ResultCode { get; set; }
        public Response Response  { get; set; }

    }
     [Serializable]                     
    public class Response
    {
         public HeaderInfo HeaderInfo { get; set; }
         public SetMappingInfoReponse SetMappingInfoReponse { get; set; }

    }
    [Serializable] 
    public class HeaderInfo { }
    [Serializable] 
    public class SetMappingInfoReponse 
    {
        public string Result { get; set; }
    }
}