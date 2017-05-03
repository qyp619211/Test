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
using System.IO;
using En = HW.Entity;
using Svc_WebService;

namespace Ctrip_AutoMapping
{
    public partial class SetMapping : UserControl
    {
        public SetMapping()
        {
            InitializeComponent();
            this.text_brand.Enabled = false;
            this.text_supplierid.Enabled = false;
            this.text_hotelgroupbrand.Enabled = true;
            this.text_masterhotel.Enabled = false;
            this.text_masterroom.Enabled = false;
            this.text_rateplancode.Enabled = false;
            this.text_room.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var service = new CommonReceiveService();
            //En.SetMappingInfo setMappingInfo = new En.SetMappingInfo();
            //setMappingInfo.SetMappingInfoRequest = new En.SetMappingInfoRequest();
            //Model.SetMappingInfoResponse response = new Model.SetMappingInfoResponse();

            //setMappingInfo.SetMappingInfoRequest = new En.SetMappingInfoRequest()
            //{
            //    Hotel = this.text_hotel.Text,
            //    Room = this.text_room.Text,
            //    HotelGroupRoomTypeCode = this.text_hotelgrouproomtypecode.Text,
            //    HotelGroupHotelCode = this.text_hotelgrouphotelcode.Text,
            //    HotelGroupRatePlanCode = this.text_hotelgrouprateplancode.Text,
            //    HotelGroupRoomName = this.text_hotelgrouproomname.Text,
            //    BalanceType = this.radio_fg.Checked==true?"FG":"PP",
            //    MappingType = 1,
            //    SetType = this.radio_delete.Checked==true?-1:1
            //};
            //if (this.radio_singel.Checked) { setMappingInfo.SetMappingInfoRequest.HotelGroupBrand = this.text_hotelgroupbrand.Text; }
            //if (this.radio_supplierld.Checked) { setMappingInfo.SetMappingInfoRequest.SupplierID = this.text_supplierid.Text; }
            //if (this.radio_brand.Checked) { setMappingInfo.SetMappingInfoRequest.Brand = this.text_brand.Text; }
            //setMappingInfo.HeaderInfo = Common.GetHeaderInfoRequest("SetMappingInfo", "1.3", this.text_userid.Text, this.text_username.Text, this.text_password.Text);
            //var xmlResquest = XmlUtil.XmlSerialize(setMappingInfo, Encoding.UTF8);

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

        private void richText_response_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                ((RichTextBox)sender).SelectAll();
            }  
        }

        private void radio_singel_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_singel.Checked)
            {
                this.text_brand.Enabled = false;
                this.text_supplierid.Enabled = false;
                this.text_hotelgroupbrand.Enabled = true;
                this.text_brand.Text = "";
                this.text_supplierid.Text = "";
            }
        }

        private void radio_brand_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_brand.Checked)
            {
                this.text_brand.Enabled = true;
                this.text_supplierid.Enabled = false;
                this.text_hotelgroupbrand.Enabled = false;
                this.text_hotelgroupbrand.Text = "";
                this.text_supplierid.Text = "";
            }
        }

        private void radio_supplierld_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_supplierld.Checked)
            {
                this.text_brand.Enabled = false;
                this.text_supplierid.Enabled = true;
                this.text_hotelgroupbrand.Enabled = false;
                this.text_hotelgroupbrand.Text = "";
                this.text_brand.Text = "";
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                ((RichTextBox)sender).SelectAll();
            }  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            En.SetMappingInfo setMappingInfo = new En.SetMappingInfo();
            setMappingInfo.SetMappingInfoRequest = new En.SetMappingInfoRequest();
            Model.SetMappingInfoResponse response = new Model.SetMappingInfoResponse();

            if (this.radio_createroomid.Checked)
            {
                setMappingInfo.SetMappingInfoRequest = new En.SetMappingInfoRequest()
                {
                    Hotel = this.text_hotel.Text,
                    MasterHotel=this.text_masterhotel.Text,
                    MasterRoom=this.text_masterroom.Text,
                    RatePlanCode=this.text_rateplancode.Text,
                    HotelGroupRoomTypeCode = this.text_hotelgrouproomtypecode.Text,
                    HotelGroupHotelCode = this.text_hotelgrouphotelcode.Text,
                    HotelGroupRatePlanCode = this.text_hotelgrouprateplancode.Text,
                    HotelGroupRoomName = this.text_hotelgrouproomname.Text,
                    BalanceType = this.radio_fg.Checked == true ? "FG" : "PP",
                    MappingType = 1,
                    SetType = this.radio_delete.Checked == true ? -1 : 1
                };

            }
            else
            {
                setMappingInfo.SetMappingInfoRequest = new En.SetMappingInfoRequest()
                {
                    Hotel = this.text_hotel.Text,
                    Room = this.text_room.Text,
                    HotelGroupRoomTypeCode = this.text_hotelgrouproomtypecode.Text,
                    HotelGroupHotelCode = this.text_hotelgrouphotelcode.Text,
                    HotelGroupRatePlanCode = this.text_hotelgrouprateplancode.Text,
                    HotelGroupRoomName = this.text_hotelgrouproomname.Text,
                    BalanceType = this.radio_fg.Checked == true ? "FG" : "PP",
                    MappingType = 1,
                    SetType = this.radio_delete.Checked == true ? -1 : 1
                };
            
            }

        
            if (this.radio_singel.Checked) { setMappingInfo.SetMappingInfoRequest.HotelGroupBrand = this.text_hotelgroupbrand.Text; }
            if (this.radio_supplierld.Checked) { setMappingInfo.SetMappingInfoRequest.SupplierID = this.text_supplierid.Text; }
            if (this.radio_brand.Checked) { setMappingInfo.SetMappingInfoRequest.Brand = this.text_brand.Text; }
           


            setMappingInfo.HeaderInfo = Common.GetHeaderInfoRequest("SetMappingInfo", "1.3", this.text_userid.Text, this.text_username.Text, this.text_password.Text);
            var xmlResquest = XmlUtil.XmlSerialize(setMappingInfo, Encoding.UTF8);
            //var xmlResponse = service.AdapterRequest(xmlResquest);
            this.richTextBox1.Text = Common.FormatXml(xmlResquest);

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_setmapping.Checked)
            {
                this.text_masterhotel.Enabled = false;
                this.text_masterroom.Enabled = false;
                this.text_rateplancode.Enabled = false;
                this.text_room.Enabled = true;
            
            }
        }

        private void radio_createroomid_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_createroomid.Checked)
            {
                this.text_masterhotel.Enabled = true;
                this.text_masterroom.Enabled = true;
                this.text_rateplancode.Enabled = true;
                this.text_room.Enabled = false;
            }
        }
    }
}
