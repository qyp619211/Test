using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
namespace HW.Entity
{
    [Serializable]
    [XmlRoot(ElementName = "Request")]
    public class GetMappingInfoRequest
    {
        [XmlElement(ElementName = "HeaderInfo")]
        public HeaderInfoRequest HeaderInfo { get; set; }

        [XmlElement(ElementName = "GetMappingInfoRequestList")]
        public GetMappingInfoListRequest GetMappingInfoListRequest { get; set; }
    }

    [Serializable]
    public class GetMappingInfoListRequest
    {
        /// <summary>
        /// UnMapping表示获取未对接的信息，Mapping表示获取指定信息
        /// </summary>
        public string GetMappingInfoType { set; get; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string SupplierID { set; get; }
      
        /// <summary>
        /// 集团编号
        /// </summary>
        public string Brand { set; get; }

        /// <summary>
        /// 酒店自己的酒店Code
        /// </summary>
        public string HotelGroupHotelCode { set; get; }

        /// <summary>
        /// 酒店自己的房型Code
        /// </summary>
        public string HotelGroupRoomTypeCode { set; get; }

        /// <summary>
        /// 酒店自己的房价代码
        /// </summary>
        public string HotelGroupRatePlanCode { set; get; }

        /// <summary>
        /// 请求明细
        /// </summary>        
        [XmlElement("GetMappingInfoRequest")]
        public List<GetMappingInfoEntity> GetMappingInfoRequest { set; get; }
    }


    [Serializable]
    public class GetMappingInfoEntity
    {
        public string Hotel { set; get; }
    }
}
