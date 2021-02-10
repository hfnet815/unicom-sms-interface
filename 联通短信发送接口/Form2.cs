using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 联通短信发送接口
{
    public partial class PwdCheck : Form
    {
        public PwdCheck()
        {
            InitializeComponent();
        }


       bool checkpwd()
        {
            bool b=false;
            if (passwordtext.Text.Length >0)
            {
                string p = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                if (p.Equals(passwordtext.Text.Trim())) { b = true; }


            }
            return b;

        }

        public delegate  void changetext(bool b);
        public event changetext cs;

        private void bt_pwdOk_Click(object sender, EventArgs e)
        {
            if (checkpwd())
            {
                cs(true);
                this.Hide();
                this.Dispose();

                
            }
        }

        private void bt_pwdCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
