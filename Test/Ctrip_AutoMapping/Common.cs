using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using En = HW.Entity;

namespace Ctrip_AutoMapping
{
    public  class Common
    {
        public static En.HeaderInfoRequest GetHeaderInfoRequest(string name, string version, string userid, string userName, string password)
        {
            En.HeaderInfoRequest headerInfoRequest = new En.HeaderInfoRequest()
            {
                AsyncRequest = "false",
                RequestorId = "Ctrip.com",
                Authentication = new En.Authentication() { UserName = userName, Password = password },
                RequestType = new En.RequestType() { Name = name, Version = version },
                TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                UserID = userid
            };
            return headerInfoRequest;
        }
        public static string FormatXml(string sUnformattedXml)
        {
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(sUnformattedXml);
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            XmlTextWriter xtw = null;
            try
            {
                xtw = new XmlTextWriter(sw);
                xtw.Formatting = Formatting.Indented;
                xtw.Indentation = 1;
                xtw.IndentChar = '\t';
                xd.WriteTo(xtw);
            }
            finally
            {
                if (xtw != null)
                    xtw.Close();
            }
            return sb.ToString();
        }
    }
}
