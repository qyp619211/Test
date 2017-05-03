using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUnZipString
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // this.richTextBox2.Text = GUnZipString(this.richTextBox1.Text);
            var txt = GUnZipString(this.richTextBox1.Text);


               int i = txt.IndexOf("<SoapContent>")+13;
            int j = txt.IndexOf("</SoapContent>");
            string str = txt.Substring(i, j - i);

            this.richTextBox2.Text = GUnZipString(str);


            
        }
        public static string GUnZipString(string toDecompress)
        {
            if (!string.IsNullOrEmpty(toDecompress))
            {
                byte[] toDecompressBuffer = Convert.FromBase64String(toDecompress);

                using (MemoryStream decompressedStream = new MemoryStream())
                {
                    int len = BitConverter.ToInt32(toDecompressBuffer, 0);
                    decompressedStream.Write(toDecompressBuffer, 4, toDecompressBuffer.Length - 4);

                    byte[] outBuffer = new byte[len];

                    decompressedStream.Position = 0;
                    using (GZipStream gzip = new GZipStream(decompressedStream, CompressionMode.Decompress))
                    {
                        gzip.Read(outBuffer, 0, outBuffer.Length);
                    }

                    return Encoding.UTF8.GetString(outBuffer);
                }
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
