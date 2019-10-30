using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace encodingCovert
{
    public partial class Form1 : Form
    {
        private string OutEncording { get; set; }
        private string InEncording { get; set; }
        public Form1()
        {
            InitializeComponent();
            //this.textBox2.Text = "UTF-8";
            var list = Encoding.GetEncodings().Select(item=>item.Name).ToList();
            list.Insert(0, "utf-8-bom");
            this.comboBox1.DataSource = list;
            //OutEncording = this.comboBox1.SelectedText;

            var inlist = new List<string> { "gb2312", "utf-8", "utf-8-bom" };
            this.comboBox2.DataSource = inlist;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            
            var sourcePath = this.textBox1.Text;

            if (string.IsNullOrWhiteSpace(sourcePath))
            {
                MessageBox.Show("路径不能为空");
                return;
            }

            var isFile = false;
            var isPathEnable = false;
            if (Directory.Exists(sourcePath))
            {
                isPathEnable = true;
            }
            else if (File.Exists(sourcePath))
            {
                isPathEnable = true;
                isFile = true;
            }

            if (!isPathEnable)
            {
                MessageBox.Show("当前路径不符合要求");
                return;
            }


            FileEncoding.StartConvert(sourcePath,isFile,OutEncording,InEncording);
            MessageBox.Show("转换成功");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.OutEncording = this.comboBox1.Text;
            //MessageBox.Show(this.comboBox1.Text);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InEncording = this.comboBox2.Text;
        }
    }
}
