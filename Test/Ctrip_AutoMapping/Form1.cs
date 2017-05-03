using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ctrip_AutoMapping
{
    public partial class Form1 : Form
    {
        public GetMapping getmapping;
        public SetMapping setmapping;
        public GetHotelInfo getHotel;

        public Form1()
        {
            InitializeComponent();
            getmapping = new GetMapping();
            setmapping = new SetMapping();
            getHotel = new GetHotelInfo();
            getmapping.Show();
            this.panel1.Controls.Add(getmapping);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getmapping.Show();
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(getmapping);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setmapping.Show();
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(setmapping);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getHotel.Show();
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(getHotel);
        }
    }
}
