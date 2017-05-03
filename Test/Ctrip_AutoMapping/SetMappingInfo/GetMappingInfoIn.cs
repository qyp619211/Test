using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Entity
{
    public class GetMappingInfoIn
    {
     

        public string HotelGroupCode { set; get; }


        public string EBKID { set; get; }

        //public string SubHotel { get; set; }

        public string Channel { get; set; }

        //public List<GetMappingInfoEntity> MappingInfoEntitys { get; set; }
        public GetMappingInfoEntity MappingInfoEntitys { get; set; }
    }
}
