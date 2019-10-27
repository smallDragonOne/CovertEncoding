using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace encodingCovert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

            FileEncoding.StartConvert(sourcePath,isFile);
            MessageBox.Show("转换成功");
        }
    }
}
