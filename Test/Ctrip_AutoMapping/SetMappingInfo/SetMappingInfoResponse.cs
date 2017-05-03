using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HW.Entity
{
     [Serializable]
    [XmlRoot(ElementName = "RequestResponse")]
    public class SetMapping
    {

        [XmlElement(ElementName = "RequestResult")]
        public SetMappingRequestResult SetMappingRequestResult { get; set; }

    }

     [Serializable]
    public class SetMappingRequestResult
    {
        public string Message { get; set; }
        public int ResultCode { get; set; }

       [XmlElement(ElementName = "Response")]
        public SetMappingResponse Response { get; set; }
    }
     [Serializable]
     public class SetMappingResponse
     {
         public HeaderInfo HeaderInfo { get; set; }

         public SetMappingInfoResponse SetMappingInfoResponse { get; set; }
     }

     [Serializable]
     public class SetMappingInfoResponse
     {
         /// <summary>
         /// 处理结果，True代表处理成功，False表示处理失败
         /// </summary>
         public string Result { get; set; }

     }
}
