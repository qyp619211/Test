using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using En = HW.Entity;
using Svc_WebService;
using System.IO;

namespace Ctrip_AutoMapping
{
    public partial class GetHotelInfo : UserControl
    {
        public GetHotelInfo()
        {
            InitializeComponent();
            this.text_brand.Enabled = true;
            this.text_supplierid.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_brand.Checked)
            {
                this.text_brand.Enabled = true;
                this.text_supplierid.Enabled = false;
                this.text_supplierid.Text = "";
            }
          
        }

        private void radio_supplierid_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_supplierid.Checked)
            {
                this.text_brand.Enabled = false;
                this.text_supplierid.Enabled = true;
                this.text_brand.Text = "";
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var service = new CommonReceiveService();
                //En.OTAHotelInfoResponse response = new En.OTAHotelInfoResponse();
                //var resquest = new En.OTAGetHotelInfoRequest();
                //resquest.GetHotelInfoRequest = new En.GetHotelInfoRequest();

                //if (this.radio_brand.Checked) resquest.GetHotelInfoRequest.Brand = this.text_brand.Text;
                //if (this.radio_supplierid.Checked) resquest.GetHotelInfoRequest.SupplierID = this.text_supplierid.Text;

                //resquest.HeaderInfo = Common.GetHeaderInfoRequest("GetHotelInfo", "1.3", this.text_userid.Text, this.text_username.Text, this.text_password.Text);
                //resquest.GetHotelInfoRequest.CurrentPage = this.text_currentpage.Text;
                //var xmlResquest = XmlUtil.XmlSerialize(resquest, Encoding.UTF8);
                if (!string.IsNullOrEmpty(this.richTextBox1.Text))
                {
                    var xmlResponse = service.AdapterRequest(this.richTextBox1.Text);
                    this.richText_response.Text = Common.FormatXml(xmlResponse);
                }
                else
                {
                    MessageBox.Show("请生成请求！");
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("异常："+e1.ToString());
            }
        }

        private void richText_response_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                ((RichTextBox)sender).SelectAll();
            }  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var service = new CommonReceiveService();
                En.OTAHotelInfoResponse response = new En.OTAHotelInfoResponse();
                var resquest = new En.OTAGetHotelInfoRequest();
                resquest.GetHotelInfoRequest = new En.GetHotelInfoRequest();

                if (this.radio_brand.Checked) resquest.GetHotelInfoRequest.Brand = this.text_brand.Text;
                if (this.radio_supplierid.Checked) resquest.GetHotelInfoRequest.SupplierID = this.text_supplierid.Text;

                resquest.HeaderInfo = Common.GetHeaderInfoRequest("GetHotelInfo", "1.3", this.text_userid.Text, this.text_username.Text, this.text_password.Text);
                resquest.GetHotelInfoRequest.CurrentPage = this.text_currentpage.Text;
                var xmlResquest = XmlUtil.XmlSerialize(resquest, Encoding.UTF8);

               // var xmlResponse = service.AdapterRequest(xmlResquest);
                this.richTextBox1.Text = Common.FormatXml(xmlResquest);
            }
            catch (Exception e1)
            {
                MessageBox.Show("异常：" + e1.ToString());
            }
        }
        /// <summary>
        /// 配置HeaderInfo信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="setMappingInfo"></param>
        /// <returns></returns>
      

    }
}
