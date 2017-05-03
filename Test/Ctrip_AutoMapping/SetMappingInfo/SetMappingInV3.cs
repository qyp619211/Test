using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Entity
{
    public class SetMappingInV3
    {
        private List<SetMappingNewInItem> setMappingNewInItems;
        public List<SetMappingNewInItem> SetMappingNewInItems
        {
            set { setMappingNewInItems = value; }
            get { return setMappingNewInItems; }
        }

        /// <summary>
        /// 集团代码
        /// </summary>
        private string brand;
        public string Brand
        {
            set { brand = value; }
            get { return brand; }
        }
        /// <summary>
        /// 供应商代码
        /// </summary>
        private string supplierID;
        public string SupplierID
        {
            set { supplierID = value; }
            get { return supplierID; }
        }
        /// <summary>
        /// 单体酒店路由名称
        /// </summary>
        private string hotelGroupBrand;
        public string HotelGroupBrand
        {
            set { hotelGroupBrand = value; }
            get { return hotelGroupBrand; }
        }
    }

    public class SetMappingNewInItem
    {
        /// <summary>
        /// pms酒店代码
        /// </summary>
        private string hotelGroupHotelCode;
        public string HotelGroupHotelCode
        {
            set { hotelGroupHotelCode = value; }
            get { return hotelGroupHotelCode; }
        }
        /// <summary>
        /// pms房型代码
        /// </summary>
        private string hotelGroupRoomTypeCode;
        public string HotelGroupRoomTypeCode
        {
            set { hotelGroupRoomTypeCode = value; }
            get { return hotelGroupRoomTypeCode; }
        }
        /// <summary>
        /// pms房型代码
        /// </summary>
        private string hotelGroupRatePlanCode;
        public string HotelGroupRatePlanCode
        {
            set { hotelGroupRatePlanCode = value; }
            get { return hotelGroupRatePlanCode; }
        }
        /// <summary>
        /// pms房型名称
        /// </summary>
        private string hotelGroupRoomName;
        public string HotelGroupRoomName
        {
            set { hotelGroupRoomName = value; }
            get { return hotelGroupRoomName; }
        }
        /// <summary>
        /// 支付类型，PP 预付，FG 现付， PKG包价
        /// </summary>
        private string balanceType;
        public string BalanceType
        {
            set { balanceType = value; }
            get { return balanceType; }
        }
        /// <summary>
        /// ota酒店代码
        /// </summary>
        private string hotel;
        public string Hotel
        {
            set { hotel = value; }
            get { return hotel; }
        }
        /// <summary>
        /// ota母酒店id
        /// </summary>
        private string masterHotel;
        public string MasterHotel
        {
            set { masterHotel = value; }
            get { return masterHotel; }
        }
        /// <summary>
        /// ota母房型id
        /// </summary>
        private string masterRoom;
        public string MasterRoom
        {
            set { masterRoom = value; }
            get { return masterRoom; }
        }
        /// <summary>
        /// ota子房型id
        /// </summary>
        private int? room;
        public int? Room
        {
            set { room = value; }
            get { return room; }
        }
        /// <summary>
        /// ota价格代码
        /// </summary>
        private string ratePlanCode;
        public string RatePlanCode
        {
            set { ratePlanCode = value; }
            get { return ratePlanCode; }
        }
        /// <summary>
        /// Mapping类型，0代表自Mapping，1代表互相Mapping 
        /// </summary>
        private string mappingType;
        public string MappingType
        {
            set { mappingType = value; }
            get { return mappingType; }
        }
        /// <summary>
        /// -1代表房型删除Mapping关系；0代表修改；1代表新增 
        /// </summary>
        private string setType;
        public string SetType
        {
            set { setType = value; }
            get { return setType; }
        }

    }
}
