using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;

namespace 获取交换机的mac地址表
{
    public partial class Form1 : Form
    {
        private string host = "172.16.0.1";

        private int port = 22;

        private string uid = "juloong";

        private string pwd = "Netengineer@123";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectionInfo connection = new ConnectionInfo(host, 22, uid, new PasswordAuthenticationMethod(uid, pwd), new privte); ;

            connection.Timeout = TimeSpan.FromSeconds(30);

            SshClient client = new SshClient(connection);

            try
            {
                client.Connect();
            }
            catch (Exception ec)
            {
                MessageBox.Show("出错信息：" + ec.Message);
            }

            if (client.IsConnected)

            {
                try
                {
                    var cmd = client.CreateCommand(@"dis mac-address");
                    var mess = cmd.Execute();
                    textBox1.Text = mess.ToString();
                }
                catch (Exception ee)
                {
                    MessageBox.Show("执行命令错误：" + ee.Message);
                }
            }
        }
    }
}
