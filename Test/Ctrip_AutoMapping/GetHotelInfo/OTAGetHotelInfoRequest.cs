using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HW.Entity
{
     [XmlRoot(ElementName = "Request")]
    public  class OTAGetHotelInfoRequest
    {
         [XmlElement(ElementName = "HeaderInfo")]
         public HeaderInfoRequest HeaderInfo { get; set; }

         public GetHotelInfoRequest GetHotelInfoRequest { get; set; }
    }
    
     public class HeaderInfoRequest 
     {
         public Authentication Authentication ;

         public RequestType RequestType;

         [XmlAttribute("UserID")]
         public string UserID
         {
             get;
             set;
         }
         [XmlAttribute("RequestorId")]
         public string RequestorId
         {
             get;
             set;
         }
         [XmlAttribute("AsyncRequest")]
         public string AsyncRequest
         {
             get;
             set;
         }
         [XmlAttribute("TimeStamp")]
         public string TimeStamp
         {
             get;
             set;
         }
     }

     public class Authentication 
     {
         [XmlAttribute("UserName")]
         public string UserName
         {
             get;
             set;
         }
         [XmlAttribute("Password")]
         public string Password
         {
             get;
             set;
         }
     }

     public class RequestType
     {
         [XmlAttribute("Name")]
         public string Name
         {
             get;
             set;
         }
          [XmlAttribute("Version")]
         public string Version
         {
             get;
             set;
         }
     
     }

     public class GetHotelInfoRequest
     {
         /// <summary>
         /// 供应商编号
         /// </summary>
         public string SupplierID { set; get; }


         public string Brand { set; get; }


         public string EBKID { set; get; }

         public string CurrentPage { get; set; }
     }
    

}
