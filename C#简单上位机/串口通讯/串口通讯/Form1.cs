using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 串口通讯
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 99; i++)
            {
                /*string str= i.ToString("x").ToUpper();//i的数值转换成16进制，ToUpper()大写
                if (str.Length == 1)//String 类的Length 属性能够获取字符串的长度
                    str = "0" + str;//在str前面加一个0
                comboBox1.Items.Add("0x" + str);*/
                comboBox1.Items.Add(i);
            }
            //comboBox1.Text = "0x00";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = comboBox1.Text;
            string convertdata = data;//.Substring(0,1);
            byte[] buffer = new byte[1];//数据一个字节就够用了
            buffer[0] = Convert.ToByte(convertdata, 16);//将字符串转化为byte型变量（byte相当于单片机中的unsigned char（0-255））
            try//防止出错
            {
                serialPort1.Open();
                serialPort1.Write(buffer, 0, 1);
                serialPort1.Close();
            }
            catch
            {//如果出错就执行此块代码
                if (serialPort1.IsOpen)
                    serialPort1.Close();//如果是写数据时出错，此时窗口状态为开，就应关闭串口，防止下次不能使用，串口是不能重复打开和关闭的
                MessageBox.Show("端口错误", "错误");
            }
        }
    }
}
