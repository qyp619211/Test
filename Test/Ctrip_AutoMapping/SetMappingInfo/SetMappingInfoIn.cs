using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Entity
{
    public class SetMappingInfoIn
    {
        private int _ota_SubRoomTypeID;
        public int OTA_SubRoomTypeID
        {
            set { _ota_SubRoomTypeID = value; }
            get { return _ota_SubRoomTypeID; }
        }

        private int _pms_Product_InfoID;
        public int PMS_Product_InfoID
        {
            set { _pms_Product_InfoID = value; }
            get { return _pms_Product_InfoID; }
        }
        private int _setType;
        public int SetType
        {
            set { _setType = value; }
            get { return _setType; }
        }
        private string _ver;
        public string Ver
        {
            set { _ver = value; }
            get { return _ver; }
        }
    }
}
