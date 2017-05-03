using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebTest.Controllers
{
    public class ExportController : Controller
    {
        //
        // GET: /Export/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult test()
        {
            return View();
        }
        public ActionResult ExportExcel()
        {
            var actionResult = default(ContentResult);

            //actionResult = Json();
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("用户名", typeof(string));
            dtResult.Columns.Add("借款编号", typeof(string));
            dtResult.Columns.Add("标题", typeof(string));
            dtResult.Columns.Add("标的类型", typeof(string));
            dtResult.Columns.Add("标的用途", typeof(string));
            dtResult.Columns.Add("借入金额", typeof(string));
            dtResult.Columns.Add("年利率", typeof(string));
            dtResult.Columns.Add("应付利息", typeof(string));
            dtResult.Columns.Add("借款期数", typeof(string));
            dtResult.Columns.Add("创建时间", typeof(string));
            dtResult.Columns.Add("状态", typeof(string));
            dtResult.Columns.Add("城市", typeof(string));

            for (int i = 0; i < 100; i++)
            {
                DataRow dr = dtResult.NewRow();
                dr["用户名"] = i.ToString();
                dr["借款编号"] = i.ToString();
                dr["标题"] = i.ToString();
                dr["标的类型"] = i.ToString();
                dr["标的用途"] = i.ToString();
                dr["借入金额"] = i.ToString();
                dr["年利率"] = i.ToString();
                dr["应付利息"] = i.ToString();
                dr["借款期数"] = i.ToString();
                dr["创建时间"] = i.ToString();
                dr["状态"] = i.ToString();
                dr["城市"] = i.ToString();
                dtResult.Rows.Add(dr);
                
            }
            DataTable2Excel(dtResult, "InvestmentExcel.xls");
            return actionResult;
        }


        public static string BuildExportHTML(System.Data.DataTable dt)
        {
            string result = string.Empty;
            int readCnt = dt.Rows.Count;
            int colCount = dt.Columns.Count;
            int pagerecords = 50000;
            result = "<?xml version=\"1.0\" encoding=\"gb2312\"?>";
            result += "<?mso-application progid=\"Excel.Sheet\"?>";
            result += "<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\" ";
            result += "xmlns:o=\"urn:schemas-microsoft-com:office:office\" ";
            result += "xmlns:x=\"urn:schemas-microsoft-com:office:excel\" ";
            result += "xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\" ";
            result += "xmlns:html=\"http://www.w3.org/TR/REC-html40\"> ";
            string strTitleRow = "";
            //设置每行的标题行
            strTitleRow = "<Row ss:AutoFitHeight='0'>";
            for (int j = 0; j < colCount; j++)
            {
                var tempColName = dt.Columns[j].ColumnName;
                if (tempColName.IndexOf("@@@@@@@@@@@@") >= 0)   //把"@@@@@@@@@@@@"作为分隔符号 前面为显示内容，后面为主键id。
                {
                    tempColName = tempColName.Split(new string[] { "@@@@@@@@@@@@" }, StringSplitOptions.None)[0];
                }

                strTitleRow += "<Cell><Data ss:Type=\"String\">" + tempColName + "</Data></Cell>";
            }
            strTitleRow += "</Row>";
            StringBuilder strRows = new StringBuilder();
            //在变长的字符操作方面stringbuilder的效率比string高得多
            int page = 1;    //分成的sheet数
            int cnt = 1;        //输入的记录数
            int sheetcolnum = 0;        //每个sheet的行数，其实就等于cnt+1
            for (int i = 0; i < readCnt; i++)
            {
                strRows.Append("<Row ss:AutoFitHeight=\"0\">");
                for (int j = 0; j < colCount; j++)
                {
                    if (dt.Columns[j].DataType.Name == "DateTime" || dt.Columns[j].DataType.Name == "SmallDateTime")
                    {
                        if (dt.Rows[i][j].ToString() != string.Empty)
                        {
                            strRows.Append("<Cell><Data ss:Type=\"String\">" + Convert.ToDateTime(dt.Rows[i][j].ToString()).ToShortDateString() + "</Data></Cell>");
                        }
                        else
                            strRows.Append("<Cell><Data ss:Type=\"String\"></Data></Cell>");
                    }
                    //alter by taomin 2012-11-13 新增decimal类型数据的处理方式 避免decimal类型数据导入EXCEL是未被转化为数字型，不利于在excel中进行统计计算
                    else if (dt.Columns[j].DataType.Name == "Int32" || dt.Columns[j].DataType.Name == "Int64" || dt.Columns[j].DataType.Name.ToLower() == "decimal")
                    {
                        strRows.Append("<Cell><Data ss:Type= \"Number\">" + dt.Rows[i][j].ToString().Trim() + "</Data></Cell>");
                    }
                    else
                    {

                        strRows.Append("<Cell><Data ss:Type=\"String\">" + dt.Rows[i][j].ToString().Trim() + "</Data></Cell>");
                    }
                }
                strRows.Append("</Row>");
                cnt++;
                //到设定行数时，要输出一页，防止office打不开，同时要注意string和stringbuilder的长度限制
                if (cnt >= pagerecords + 1)
                {
                    sheetcolnum = cnt + 1;
                    result += "<Worksheet ss:Name=\"Sheet" + page.ToString() + "\"><Table ss:ExpandedColumnCount=\"" + colCount.ToString() + "\" ss:ExpandedRowCount=\"" + sheetcolnum.ToString() + "\" x:FullColumns=\"1\" x:FullRows=\"1\" ss:DefaultColumnWidth=\"104\" ss:DefaultRowHeight=\"13.5\">" + strTitleRow.ToString() + strRows.ToString() + "</Table></Worksheet>";
                    strRows.Remove(0, strRows.Length);
                    cnt = 1;                     //下一个sheet重新计数
                    page++;
                }
            }
            sheetcolnum = cnt + 1;
            result = result + "<Worksheet ss:Name='Sheet" + page.ToString() + "'><Table ss:ExpandedColumnCount='" + colCount.ToString() + "' ss:ExpandedRowCount='" + sheetcolnum.ToString() + "' x:FullColumns='1' x:FullRows='1' ss:DefaultColumnWidth='104' ss:DefaultRowHeight='13.5'>" + strTitleRow.ToString() + strRows.ToString() + "</Table></Worksheet></Workbook>";
            return result;
        }

        /// <summary>
        /// 导出Excel
        /// 例子 Controller里面调用 ExcelExportProvider.DataTable2Excel(dt, "ClickExcel.xls");
        /// </summary>
        public static void DataTable2Excel(DataTable dt, string fileName)
        {
            string outputFileName = null;
            HttpContext curContext = System.Web.HttpContext.Current;
            string browser = curContext.Request.UserAgent.ToUpper();
            if (browser.Contains("FIREFOX") == true)
            {
                outputFileName = "\"" + fileName + "\"";
            }
            else
            {
                outputFileName = HttpUtility.UrlEncode(fileName);
            }
            curContext.Response.ContentType = "application/ms-excel";
            curContext.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            curContext.Response.AppendHeader("Content-Disposition", ("attachment;filename=" + outputFileName));
            curContext.Response.Charset = "";
            curContext.Response.Write(BuildExportHTML(dt));
            curContext.Response.Flush();
            curContext.Response.End();
        }

    }
}
