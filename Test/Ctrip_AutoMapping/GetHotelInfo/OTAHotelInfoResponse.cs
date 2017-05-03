using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HW.Entity
{
    [XmlRoot(ElementName = "RequestResponse")]
    public class OTAHotelInfoResponse
    {
        public RequestResult RequestResult { get; set; }
    }
  
    public class RequestResult
    {
        public string Message { get; set; }
        public int ResultCode { get; set; }

        public Response Response { get; set; }
    }

    public class Response
    {
       // public string ResultCode { get; set; }
        public HeaderInfo HeaderInfo { get; set; }
        public GetHotelInfoResponse GetHotelInfoResponse { get; set; }
    }
    public class HeaderInfo { }

    public class GetHotelInfoResponse
    {
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// 酒店总数量
        /// </summary>
        public int TotalNum { get; set; }

        private List<HotelList> hotelList { get; set; }
        /// <summary>
        /// 酒店信息    
       [XmlElement(ElementName = "HotelList")]
        public List<HotelList> HotelList
        {
            get { return hotelList; }
            set { hotelList = value; }
        }
    
    }

    public class HotelList
    {
        /// <summary>
        /// Ctrip 酒店编码
        /// </summary>
        public int Hotel { get; set; }
        /// <summary>
        /// Ctrip 酒店名称
        /// </summary>
        public string HotelName { get; set; }
        /// <summary>
        /// 国家名
        /// </summary>
        public string CountryName { get; set; }
        /// <summary>
        ///  城市名
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        ///  酒店地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        ///  酒店电话
        /// </summary>
        public string Telephone { get; set; }

    }


}
