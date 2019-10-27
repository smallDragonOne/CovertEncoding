using System;
using System.IO;
using System.Windows.Forms;

namespace encodingCovert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.textBox2.Text = "UTF-8";
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

            if (string.IsNullOrWhiteSpace(this.textBox2.Text))
            {
                this.textBox2.Text = "UTF-8";
            }

            FileEncoding.StartConvert(sourcePath,isFile,this.textBox2.Text);
            MessageBox.Show("转换成功");
        }
    }
}
