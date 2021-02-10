using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 联通短信发送接口
{
    internal class writelog
    {
        public void writelog3(string msg)
        {
            string path = Application.StartupPath + "\\data_log\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            StreamWriter stream = new StreamWriter(path, true, Encoding.Default);
            stream.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + msg);
            stream.Close();
        }
    }
}
