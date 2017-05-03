using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HW.Entity
{
    [XmlRoot(ElementName = "Request")]
    public class SetMappingInfo
    {
        [XmlElement(ElementName = "HeaderInfo")]
        public HeaderInfoRequest HeaderInfo { get; set; }

        public SetMappingInfoRequest SetMappingInfoRequest { get; set; }
    }


    [Serializable]
    public class SetMappingInfoRequest
    {
        /// <summary>
        /// 品牌名字(单体酒店)
        /// </summary>
        public string HotelGroupBrand { set; get; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string SupplierID { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Brand { set; get; }

        /// <summary>
        /// Ctrip酒店编号
        /// </summary>
        public string Hotel { set; get; }

        /// <summary>
        /// Ctrip房型编号
        /// </summary>
        public string Room { set; get; }

        /// <summary>
        /// Ctrip母酒店编号
        /// </summary>
        public string MasterHotel { set; get; }

        /// <summary>
        /// Ctrip母房型编号
        /// </summary>
        public string MasterRoom { set; get; }

        /// <summary>
        /// Ctrip 房价代码
        /// </summary>
        public string RatePlanCode { set; get; }

        /// <summary>
        /// 房型静态信息
        /// </summary>
        public BasicRoomInfo BasicRoomInfo { set; get; }

        /// <summary>
        /// 合作方酒店房型代码
        /// </summary>
        public string HotelGroupRoomTypeCode { set; get; }

        /// <summary>
        /// 接口房型名称
        /// </summary>
        public string HotelGroupRoomName { set; get; }

        /// <summary>
        /// 合作方酒店代码
        /// </summary>
        public string HotelGroupHotelCode { set; get; }

        /// <summary>
        /// 合作方房价代码
        /// </summary>
        public string HotelGroupRatePlanCode { set; get; }

        /// <summary>
        /// 支付类型，PP 预付，FG 现付， PKG包价
        /// </summary>
        public string BalanceType { set; get; }

        /// <summary>
        /// Mapping类型，0代表自Mapping，1代表互相Mapping
        /// </summary>
        public int MappingType { set; get; }

        /// <summary>
        /// 设置类型，-1代表删除，0代表修改，1代表新增
        /// </summary>
        public int SetType { set; get; }

        /// <summary>
        /// ebk hotelcompany
        /// </summary>        
        public string EBKHotelCompany { set; get; }
    }


    public class BasicRoomInfo
    {

        /// <summary>
        /// 基础房型名称
        /// </summary>
        public string RoomName { get; set; }


        /// <summary>
        /// 基础房型英文名称
        /// </summary>
        public string RoomEnglishName { get; set; }


        /// <summary>
        /// 房型描述
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// 房型英文描述信息,
        /// </summary>
        public string DescriptionIntl { get; set; }


        /// <summary>
        /// 标准房型
        /// </summary>
        public int RoomTypeStd { get; set; }

        /// <summary>
        /// 入住人数
        /// </summary>
        public int Person { get; set; }


        /// <summary>
        /// 房间数量
        /// </summary>
        public int RoomQuantity { get; set; }


        /// <summary>
        /// 能否加床
        /// </summary>
        public string AddBed { get; set; }


        /// <summary>
        /// 加床费用
        /// </summary>
        public decimal AddBedFee { get; set; }


        /// <summary>
        /// 面积
        /// </summary>
        public string AreaRange { get; set; }



        /// <summary>
        /// 是否有单人床
        /// </summary>
        public bool HasSingleBed { get; set; }



        /// <summary>
        /// 单人床宽度
        /// </summary>
        public decimal SingleBedWidth { get; set; }


        /// <summary>
        /// 是否有大床
        /// </summary>
        public bool HasKingBed { get; set; }


        /// <summary>
        /// 大床宽度
        /// </summary>
        public decimal KingBedWidth { get; set; }

        /// <summary>
        /// 是否有双床
        /// </summary>
        public bool HasTwinBed { get; set; }

        /// <summary>
        /// 双床宽度
        /// </summary>
        public decimal TwinBedWidth { get; set; }


        /// <summary>
        /// 宽带资费
        /// </summary>
        public string BroadnetFeeDetail { get; set; }


        /// <summary>
        /// 入住儿童数
        /// </summary>
        public int Children { get; set; }


        /// <summary>
        /// 币种
        /// </summary>
        public string Currency { get; set; }


        /// <summary>
        /// 楼层
        /// </summary>
        public string FloorRange { get; set; }



        /// <summary>
        /// 是否有宽带
        /// </summary>
        public bool HasBroadnet { get; set; }


        /// <summary>
        /// 该房型有无烟房
        /// </summary>
        public bool HasNonSmokeRoom { get; set; }


        /// <summary>
        /// 可安排无烟楼层
        /// </summary>
        public bool HasRoomInNonSmokeArea { get; set; }



        /// <summary>
        /// 该房可无烟处理
        /// </summary>
        public bool HasSmokeCleanRoom { get; set; }

        /// <summary>
        /// 无法安排无烟
        /// </summary>
        public bool NoNonSmokeRoom { get; set; }


        /// <summary>
        /// 不可吸烟
        /// </summary>
        public bool NotAllowSmoking { get; set; }


        /// <summary>
        /// 是否有窗
        /// </summary>
        public int HasWindow { get; set; }


        /// <summary>
        /// 是否有有线宽带
        /// </summary>
        public bool HasWiredBroadnet { get; set; }

        /// <summary>
        /// 是否有无线宽带
        /// </summary>
        public bool HasWirelessBroadnet { get; set; }

        /// <summary>
        /// 房型卖点
        /// </summary>
        public string SellingPoint { get; set; }


        /// <summary>
        /// 有线宽带收费情况
        /// </summary>
        public int WiredBroadnetFee { get; set; }


        /// <summary>
        /// 全部房间还是部分房间有线宽带
        /// </summary>
        public int WiredBroadnetRoom { get; set; }


        /// <summary>
        /// 无线宽带收费情况
        /// </summary>
        public int WirelessBroadnetFee { get; set; }


        /// <summary>
        /// 部分房间有还是全部房间无线宽带
        /// </summary>
        public int WirelessBroadnetRoom { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BedInfo[] BedInfoList { get; set; }

    }


    public class BedInfo
    {
        /// <summary>
        /// 父床型
        /// </summary>
        public int ParentBedType { get; set; }

        /// <summary>
        /// 子床型
        /// </summary>
        public int ChildBedType { get; set; }

        /// <summary>
        /// 床数BedCount
        /// </summary>
        public int BedCount { get; set; }

        /// <summary>
        /// BedWidth床宽(米)
        /// </summary>
        public decimal BedWidth { get; set; }

    }

}
