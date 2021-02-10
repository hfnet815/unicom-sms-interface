using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 联通短信发送接口
{
    public class StatusReprot
    {
        public string taskID { get; set; }
        public string vaa35 { get; set; }
        public string smsStatus { get; set; }
        public string smsreceivetime { get; set; }
    }

    public class ReturnSms
    {
        public string taskID { get; set; }
        public string Returnid { get; set; }
        public string vaa35 { get; set; }
        public string content { get; set; }
        public string contentreceivetime { get; set; }
    }

    internal class OutPatient
    {
        // private string vac01 { get; set; }

        // string VAA05 { get; set; }
        public string vaa35 { get; set; }

        public string returnStatus { get; set; }
        public string taskID { get; set; }
    }
}
