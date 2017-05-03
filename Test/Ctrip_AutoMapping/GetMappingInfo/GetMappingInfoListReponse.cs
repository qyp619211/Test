using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
namespace HW.Entity
{

    
    //[Serializable]
    ////[XmlRoot(ElementName = "RequestResponse")]
    //public class MappingInfoListReponse
    //{
    //    [XmlElement(ElementName = "RequestResult")]
    //    public MappingRequestResult RequestResult { get; set; }
    //}
    //[Serializable]
    //public class MappingRequestResult
    //{

    //    public string Message { get; set; }
    //    public int ResultCode { get; set; }

    //    [XmlElement(ElementName = "Response")]
    //    public MappingResponse Response { get; set; }
    
    //}

    //[Serializable]
    //public class MappingResponse
    //{
    //    public HeaderInfo HeaderInfo { get; set; }

    //     [XmlElement(ElementName = "GetMappingInfoResponseList")]
    //    public GetMappingInfoListReponse GetMappingInfoResponseList { get; set; }
    //}
   

    [Serializable]
    public class GetMappingInfoResponseList
    {
        /// <summary>
        /// 供应商编码
        /// </summary>
        public int? SupplierID { get; set; }

            /// <summary>
        /// 供应商名字
        /// </summary>
        public string SupplierName { get; set; }


        [XmlElement(ElementName = "HotelResponseItem")]
        public List<HotelResponseEntity> HotelResponseItem { get; set; }
    }


    [Serializable]
    public class HotelResponseEntity
    {

        public MasterHotelEntity MasterHotel { get; set; }
    }

    [Serializable]
    public class MasterHotelEntity 
    {
        /// <summary>
        /// 母酒店id
        /// </summary>
        public int Hotel { get; set; }

        /// <summary>
        /// 酒店名称
        /// </summary>
        public string HotelName { get; set; }

        /// <summary>
        /// 城市代码
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 母房型列表
        /// </summary>
        /// 
        [XmlElement(ElementName = "RoomResponseItem")]
        public MasterRoomEntity[] RoomResponseItem { get; set; }

        /// <summary>
        /// 子酒店信息
        /// </summary>
        public ChildHotelEntity ChildHotel { get; set; }

    }

    [Serializable]
    public class MasterRoomEntity
    {

        public int MasterRoom { get; set; }

        public string RoomName { get; set; }
        /// <summary>
        /// 入住人数
        /// </summary>
        public string Person { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// 宽带信息
        /// </summary>
        public string Broadnet { get; set; }
        /// <summary>
        /// 是否有窗（有窗，无窗，部分有窗）
        /// </summary>
        public string HasWindow { get; set; }
        /// <summary>
        /// 加床信息
        /// </summary>
        public decimal? AddBedFee { get; set; }
    }

    [Serializable]
    public class ChildHotelEntity
    {
        public int Hotel { get; set; }
        /// <summary>
        /// 集团品牌
        /// </summary>
        public string HotelGroupBrand { get; set; }
        /// <summary>
        /// 是否打开（T/F）
        /// </summary>
        public string IsOpen { get; set; }

        [XmlElement(ElementName = "RoomResponseItem")]
        public List<HotelRoomEntity> RoomResponseItem { get; set; }

    }

    [Serializable]
    public class HotelRoomEntity
    {
        /// <summary>
        /// 母房型名称
        /// </summary>
        public int MasterRoom { get; set; }

        /// <summary>
        /// 房型id
        /// </summary>
        public int Room { get; set; }

        /// <summary>
        /// 房型名字
        /// </summary>
        public string RoomName { get; set; }


        /// <summary>
        /// 早餐数
        /// </summary>
        public int Breakfast { get; set; }

        /// <summary>
        /// 是否双人床：T：是 F：否
        /// </summary>
        public string TwinBed { get; set; }

        /// <summary>
        /// 是否大床：T：是 F：否
        /// </summary>
        public string KingSize { get; set; }

        /// <summary>
        /// 入住人数
        /// </summary>
        public int Person { get; set; }

        /// <summary>
        /// 是否可加床：T:可加 F：不可加
        /// </summary>
        public string AllowAddBed { get; set; }

        /// <summary>
        /// 支付类型：PP 预付， FG 现付， PKG包价
        /// </summary>
        public string BalanceType { get; set; }

        /// <summary>
        /// 房价代码
        /// </summary>
        public string RatePlanCode { get; set; }


        /// <summary>
        /// 接口方酒店代码
        /// </summary>
        public string HotelGroupHotelCode { get; set; }

        /// <summary>
        /// 接口方酒店代码
        /// </summary>
        public string HotelGroupRoomTypeCode { get; set; }


        /// <summary>
        /// 接口方集团名称
        /// </summary>
        public string HotelGroupRoomName { get; set; }


        /// <summary>
        /// 接口方品牌代码
        /// </summary>
        public string HotelGroupBrand { get; set; }


        /// <summary>
        /// 接口方房价代码
        /// </summary>
        public string HotelGroupRatePlanCode { get; set; }

    }

   
}
