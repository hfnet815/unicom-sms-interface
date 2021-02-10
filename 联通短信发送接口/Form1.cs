using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace 联通短信发送接口
{
    public partial class 联通短信发送接口 : Form
    {
        private static readonly HttpClient client = new HttpClient();

        private readonly Sunisoft.IrisSkin.SkinEngine skin = new Sunisoft.IrisSkin.SkinEngine();

        private readonly SqlHelper sql = new SqlHelper();

        private System.Timers.Timer GetTimer;

        private string url = @"http://27.221.101.37:81/sms.aspx?";
   

        public 联通短信发送接口()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            textBox2.Enabled = false;

            skin.SkinFile = Application.StartupPath + @"\office2007.ssk";

            GetSmsdata();
            //TimeGetResultData();
        }

        /// <summary>
        /// 写获取数据，post 消息日志
        /// </summary>
        /// <param name="msg"></param>
        public void Writelog(string msg)
        {
            SmsData.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  " + msg + "\r\n" + SmsData.Text;

            string path = Application.StartupPath + "\\data_log\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            StreamWriter stream = new StreamWriter(path, true, Encoding.Default);
            stream.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + msg);
            stream.Close();
        }

        /// <summary>
        /// 获取短信回执日志
        /// </summary>
        /// <param name="msg"></param>
        public void Writelog2(string msg)
        {
            SmsSendText.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  " + msg + "\r\n" + SmsSendText.Text;

            string path = Application.StartupPath + "\\sms_log\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            StreamWriter stream = new StreamWriter(path, true, Encoding.Default);
            stream.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + msg);
            stream.Close();
        }

        /// <summary>
        /// 数据获取计时器
        /// </summary>
        public void GetSmsdata()
        {
            GetTimer = new System.Timers.Timer(3600000)
            {
                AutoReset = true,
                Enabled = true
            };
            GetTimer.Start();
            GetTimer.Elapsed += new System.Timers.ElapsedEventHandler(Getdata);
        }





        /// <summary>
        /// 获取发送短信的回执
        /// </summary>
        /// <returns></returns>

        private string GetSendSmsResult(string s)
        {
            string ss;

            string para = @"action=report&account=rcrmyy&password=d19bja0m1@&taskid=" + s;
            byte[] data = Encoding.UTF8.GetBytes(para);
            ss = DoPostRequest(url, data);
            Writelog2("获取短信发送状态的参数：" + url + para);
            return ss;
        }

        private string GetContent(string taskid)
        {
            string ss;

            string para = @"action=getmo&account=rcrmyy&password=d19bja0m1@&taskid=" + taskid;
            byte[] data = Encoding.UTF8.GetBytes(para);
            ss = DoPostRequest(url, data);
            Writelog2("获取短信反馈内容的参数：" + url + para);
            return ss;
        }

        /// <summary>
        /// 批量自动获取更新 发送标志，最终集成语句
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Getdata(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (SmsData.Text.Length > 4000)
            {
                SmsData.Clear();
            }

            if (SmsSendText.Text.Length > 4000)
            {
                SmsData.Clear();
            }

            if (DateTime.Now.Hour == 17)
            {
                button1_Click(null, null);
            }

            if (DateTime.Now.Hour == 18)
            {
                button2_Click(null, null);
            }

            if (DateTime.Now.Hour == 20)
            {
                button3_Click(null, null);
            }
        }

        /// <summary>
        /// 手动测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button1_Click(object sender, EventArgs e)
        {


            url = @"http://27.221.101.37:81/sms.aspx?";

            string msg;
            if (textBox2.Text.Length == 0)
            {
                msg = @"尊敬的患者您好！感谢选择荣成市人民医院就诊，为给您提供更优质的医疗服务，请对本次诊疗服务（就诊环境、就医过程、服务态度等）进行评价：满意，请短信回复  “1”；不满意，请短信回复“0”，或简要说明原因（30字以内），我们会及时落实、改进。祝您身体健康，生活愉快！";
            }
            else
            {
                msg = textBox2.Text.ToString();
            }



            List<string> usernumber = null;
            try
            {
                usernumber = sql.Getvaa35();
            }
            catch (Exception EE)
            {
                Writelog("获取号码异常" + EE.Message);
            }

            string postdata;

            while (usernumber.Count > 0)
            {
                List<string> vs;

                if (usernumber.Count > 200)
                {
                    vs = usernumber.Take(200).ToList();
                }
                else
                {
                    vs = usernumber.ToList();
                }

                string sc = string.Empty;

                foreach (string sd in vs) { sc += sd + ","; }

                sc = sc.Substring(0, sc.Length - 1);

                postdata = @"action=send&account=rcrmyy&password=d19bja0m1@&mobile=" + sc +
                @"&content=" + msg;

                Writelog("提交psot参数：" + url + postdata);

                byte[] data = Encoding.UTF8.GetBytes(postdata.ToString());

                string ss;
                string message;
                string task;
                string status;

                try
                {
                    ss = DoPostRequest(url, data);
                    ss.Replace(" ", "");
                    ss.Replace("<", "&lt");
                    ss.Replace(">", "&gt");
                    status = DealwithXML(ss, "returnstatus");
                    message = DealwithXML(ss, "message");
                    task = DealwithXML(ss, "taskid");

                    Writelog("短信发送状态：任务状态：" + status + "消息状态：" + message + " 任务批次ID:" + task);
                }
                catch (Exception ee)
                {
                    Writelog("发送请求异常：" + ee.Message);

                    break;
                }

                try
                {
                    int i = sql.updateReturntaskid(sc, task);
                    Writelog("更新数据" + i + "条");
                }
                catch (Exception dd)
                {
                    Writelog("更新结果标志异常：" + dd.Message);

                    break;
                }

                if (vs.Count >= 200)
                {
                    usernumber.RemoveRange(0, 200);
                }
                else
                {
                    usernumber.Clear();
                }
            }
        }

        /// <summary>
        /// 手动获取结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            List<string> taskid;
            taskid = sql.Gettaskid();

            foreach (string si in taskid)
            {
                string xml = string.Empty;
                List<StatusReprot> SR = null;
                try
                {
                    xml = GetSendSmsResult(si);
                    Writelog2("获取到的结果：" + xml);

                    try
                    {
                        SR = reportxml(xml, "statusbox", si);

                        if (SR.Count() > 0)
                        {
                            try
                            {
                                sql.updatereportstatus(SR);

                                Writelog2("更新数据库成功");
                            }
                            catch (Exception D)
                            {
                                Writelog2("更新数据库错误：" + D.Message);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Writelog2("解析返回结果错误：" + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    Writelog2("获取返回信息错误：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 发送数据函数
        /// </summary>

        private string DoPostRequest(string urlstring, byte[] content)
        {
            HttpWebRequest Request;
            HttpWebResponse Response;
            string Resutl = String.Empty;
            try
            {
                Request = (HttpWebRequest)WebRequest.Create(urlstring);

                Request.Method = "POST";
                Request.ContentType = "application/x-www-form-urlencoded";
                Request.ContentLength = content.Length;
                Stream stream = Request.GetRequestStream();

                stream.Write(content, 0, content.Length);
                stream.Close();
            }
            catch (System.Exception E)
            {
                Writelog("故障：" + E.Message);
                return Resutl;
            }

            try
            {
                Response = (HttpWebResponse)Request.GetResponse();
                StreamReader reader = new StreamReader(Response.GetResponseStream(), Encoding.UTF8);
                Resutl = reader.ReadToEnd();
                reader.Close();
                Response.Close();
            }
            catch (System.Exception E)
            {
                Writelog("获取相应失败：" + E.Message);
            }

            return Resutl;
        }

        private string DealwithXML(string xml, string mark)
        {
            XElement xe = XElement.Parse(xml);
            IEnumerable<XElement> xes = from ele in xe.Elements(mark)
                                        select ele;

            string result = string.Empty;
            foreach (string s in xes.ToList())
            {
                result += s;
            }

            return result;
        }

        private List<StatusReprot> reportxml(string xml, string mark, string taskid)
        {
            XElement xe = XElement.Parse(xml);
            IEnumerable<XElement> xes = from ele in xe.Elements(mark)
                                        select ele;

            List<StatusReprot> result = new List<StatusReprot>();

            if (xes.Count() > 0)
            {
                foreach (var s in xes)
                {
                    StatusReprot sr = new StatusReprot();
                    sr.taskID = taskid;
                    sr.vaa35 = s.Element("mobile").Value.ToString();
                    sr.smsStatus = s.Element("status").Value.ToString();
                    sr.smsreceivetime = s.Element("receivetime").Value.ToString();

                    result.Add(sr);
                }
            }
            return result;
        }

        private List<ReturnSms> Rs(string xml, string mark, string taskid)
        {
            XElement xe = XElement.Parse(xml);
            IEnumerable<XElement> xes = from ele in xe.Elements(mark)
                                        select ele;

            List<ReturnSms> result = new List<ReturnSms>();

            Writelog("元素数量：" + xes.Count().ToString());

            if (xes.Count() > 0)
            {
                foreach (var s in xes)
                {
                    ReturnSms sr = new ReturnSms();

                    sr.taskID = taskid;
                    sr.Returnid = s.Element("id").Value.ToString();
                    sr.vaa35 = s.Element("mobile").Value.ToString();
                    sr.content = s.Element("content").Value.ToString();
                    sr.contentreceivetime = s.Element("receivetime").Value.ToString();

                    result.Add(sr);
                }
            }
            return result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> taskid;
            taskid = sql.Gettaskid();
            foreach (string st in taskid)
            {
                string xml = string.Empty;
                List<ReturnSms> returnSms = null;
                try
                {
                    xml = GetContent(st);
                    Writelog2("获取到上行信息：" + xml);
                    try
                    {
                        returnSms = Rs(xml, "callbox", st);

                        if (returnSms.Count() > 0)
                        {
                            try
                            {
                                sql.updateContent(returnSms);
                                Writelog2("更新数据库成功");
                            }
                            catch (Exception EX)
                            {
                                Writelog2("上行内容更新数据库异常：" + EX.Message);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Writelog2("解析上行内容结果异常：" + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    Writelog2("获取上行内容异常：" + ex.Message);
                }
            }
        }

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    StreamReader SR = new StreamReader(@"C:\16.txt", Encoding.UTF8);
        //    String SS = SR.ReadToEnd();

        // Writelog2(SS);

        // List<ReturnSms> rs = new List<ReturnSms>(); try { rs = Rs(SS, "callbox",
        // "2011110906348998"); } catch (Exception ex) { Writelog2("解析上行内容结果异常：" + ex.Message); }

        // Writelog("获取到记录：" + rs.Count().ToString());

        //    if (rs.Count() > 0)
        //    {
        //        try
        //        {
        //            sql.updateContent(rs);
        //            Writelog2("更新数据库成功");
        //        }
        //        catch (Exception EX)
        //        {
        //            Writelog2("上行内容更新数据库异常：" + EX.Message);
        //        }
        //    }
        //}

        private void button8_Click(object sender, EventArgs e)
        {
            StreamReader SR = new StreamReader(@"C:\Users\jl\15.txt", Encoding.Default);
            String SS = SR.ReadToEnd();

            Writelog2(SS);

            List<ReturnSms> rs = new List<ReturnSms>();
            try
            {
                rs = Rs(SS, "callbox", "2011110906348998");
            }
            catch (Exception ex)
            {
                Writelog2("解析上行内容结果异常：" + ex.Message);
            }

            Writelog("获取到记录：" + rs.Count().ToString());

            if (rs.Count() > 0)
            {
                try
                {
                    sql.updateContent(rs);
                    Writelog2("更新数据库成功");
                }
                catch (Exception EX)
                {
                    Writelog2("上行内容更新数据库异常：" + EX.Message);
                }
            }
        }

        /////以下为手动处理正式数据代码/////

        //手动发送短信按钮
        private void button5_Click(object sender, EventArgs e)
        {
            if (SmsData.Text.Length > 4000)
            {
                SmsData.Clear();
            }
            if (SmsSendText.Text.Length > 4000)
            {
                SmsSendText.Clear();
            }

            string begintime = dateTimePicker1.Value.ToString();

            string endtime = dateTimePicker2.Value.ToString();

            url = @"http://27.221.101.37:81/sms.aspx?";

            string msg = @"尊敬的患者您好！感谢选择荣成市人民医院就诊，为给您提供更优质的医疗服务，请对本次诊疗服务（就诊环境、就医过程、服务态度等）进行评价：满意，请短信回复  “1”；不满意，请回短信简要说明（30字以内），我们会及时落实、改进。祝您身体健康，生活愉快！";

            List<string> usernumber = null;
            try
            {
                usernumber = sql.ManualGetvaa35(begintime, endtime);

                string postdata;

                while (usernumber.Count > 0)
                {
                    List<string> vs;

                    if (usernumber.Count > 200)
                    {
                        vs = usernumber.Take(200).ToList();
                    }
                    else
                    {
                        vs = usernumber.ToList();
                    }

                    string sc = string.Empty;

                    foreach (string sd in vs) { sc += sd + ","; }

                    sc = sc.Substring(0, sc.Length - 1);

                    postdata = @"action=send&account=rcrmyy&password=d19bja0m1@&mobile=" + sc +
                    @"&content=" + msg;

                    Writelog("提交psot参数：" + url + postdata);

                    byte[] data = Encoding.UTF8.GetBytes(postdata.ToString());

                    string ss;
                    string message;
                    string task;
                    string status;

                    try
                    {
                        ss = DoPostRequest(url, data);
                        ss.Replace(" ", "");
                        ss.Replace("<", "&lt");
                        ss.Replace(">", "&gt");
                        status = DealwithXML(ss, "returnstatus");
                        message = DealwithXML(ss, "message");
                        task = DealwithXML(ss, "taskid");

                        Writelog("短信发送状态：任务状态：" + status + "消息状态：" + message + " 任务批次ID:" + task);
                    }
                    catch (Exception ee)
                    {
                        Writelog("发送请求异常：" + ee.Message);

                        break;
                    }

                    try
                    {
                        int i = sql.ManualUpdateReturnTaskid(sc, task, begintime, endtime);
                        Writelog("更新数据" + i + "条");
                    }
                    catch (Exception dd)
                    {
                        Writelog("更新结果标志异常：" + dd.Message);

                        break;
                    }

                    if (vs.Count >= 200)
                    {
                        usernumber.RemoveRange(0, 200);
                    }
                    else
                    {
                        usernumber.Clear();
                    }
                }
            }
            catch (Exception EE)
            {
                Writelog("获取号码异常" + EE.Message);
            }
        }

        //手动获取状态
        private void button6_Click(object sender, EventArgs e)
        {
            string begintime = dateTimePicker1.Value.ToString();

            string endtime = dateTimePicker2.Value.ToString();

            List<string> taskid;

            taskid = sql.Gettaskid();

            taskid = sql.ManualGetTaskId(begintime, endtime);

            foreach (string si in taskid)
            {
                string xml = string.Empty;
                List<StatusReprot> SR = null;
                try
                {
                    xml = GetSendSmsResult(si);

                    Writelog2("获取到的结果：" + xml);

                    try
                    {
                        SR = reportxml(xml, "statusbox", si);

                        if (SR.Count() > 0)
                        {
                            try
                            {
                                sql.ManualUpdateReprotStatus(SR, begintime, endtime);
                                Writelog2("更新数据库成功");
                            }
                            catch (Exception D)
                            {
                                Writelog2("更新数据库错误：" + D.Message);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Writelog2("解析返回结果错误：" + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    Writelog2("获取返回信息错误：" + ex.Message);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string begintime = dateTimePicker1.Value.ToString();

            string endtime = dateTimePicker2.Value.ToString();

            if (SmsSendText.TextLength > 4000)
            {
                SmsSendText.Clear();
            }

            List<string> taskid;

            taskid = sql.ManualGetTaskId(begintime, endtime);

            foreach (string st in taskid)
            {
                string xml = string.Empty;
                List<ReturnSms> returnSms = null;
                try
                {
                    xml = GetContent(st);
                    Writelog2("获取到上行信息：" + xml);
                    try
                    {
                        returnSms = Rs(xml, "callbox", st);

                        if (returnSms.Count() > 0)
                        {
                            try
                            {
                                sql.updateContent(returnSms);
                                Writelog2("更新数据库成功");
                            }
                            catch (Exception EX)
                            {
                                Writelog2("上行内容更新数据库异常：" + EX.Message);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Writelog2("解析上行内容结果异常：" + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    Writelog2("获取上行内容异常：" + ex.Message);
                }
            }
        }



        #region 手动测试发送内容，状态及反馈


        string manaulTaskid = string.Empty;
        private void Sendmessage()
        {
            tb_info.Text = String.Empty;
            tb_feedbackinfo.Text = String.Empty;
            tb_manaulSendState.Text = String.Empty;


            string msg;
            if (textBox2.Text.Length == 0)
            {
                msg = @"尊敬的患者您好！感谢选择荣成市人民医院就诊，为给您提供更优质的医疗服务，请对本次诊疗服务（就诊环境、就医过程、服务态度等）进行评价：满意，请短信回复  “1”；不满意，请短信回复“0”，或简要说明原因（30字以内），我们会及时落实、改进。祝您身体健康，生活愉快！";
            }
            else
            {
                msg = textBox2.Text.ToString();
            }

            if (tb_manaulPhonenumber.Text.Length != 0)
            {



              string  postdata = @"action=send&account=rcrmyy&password=d19bja0m1@&mobile=" + tb_manaulPhonenumber.Text.Trim() +
                @"&content=" + msg;

                tb_info.AppendText("提交psot参数：" + url + postdata);

                byte[] data = Encoding.UTF8.GetBytes(postdata.ToString());

                string ss;
                string message;
                string task;
                string status;

                try
                {
                    ss = DoPostRequest(url, data);
                    ss.Replace(" ", "");
                    ss.Replace("<", "&lt");
                    ss.Replace(">", "&gt");
                    status = DealwithXML(ss, "returnstatus");
                    message = DealwithXML(ss, "message");
                    task = DealwithXML(ss, "taskid");

                    tb_info.AppendText("短信发送状态：任务状态：" + status + "消息状态：" + message + " 任务批次ID:" + task+"\r\n");

                    tb_manaulSendState.Text = status + ";" + message;
                    manaulTaskid = task;



                }
                catch (Exception ee)
                {
                    tb_info.AppendText("发送请求异常：" + ee.Message+"\r\n");


                }



            }



            #endregion


        }

        private void bt_manualSend_Click(object sender, EventArgs e)
        {
            Sendmessage();
        }


        private void bt_manaulGetfeedback_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(manaulTaskid)) {
                string xml = GetContent(manaulTaskid);
                List<ReturnSms> rs = Rs(xml, "callbox", manaulTaskid);
                tb_feedbackinfo.Text = rs[0].content.ToString();
                tb_info.AppendText(rs[0].taskID + rs[0].content + rs[0].contentreceivetime.ToString()+"\r\n");
            }



      

        }

       

        private void bt_Manaulgetstate_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(manaulTaskid))
            {

                string xml = GetSendSmsResult(manaulTaskid);

                List<StatusReprot> sr = reportxml(xml, "statusbox", manaulTaskid);

                tb_manaulSendState.AppendText(sr[0].smsStatus.ToString());

                tb_info.AppendText(sr[0].smsStatus.ToString() + sr[0].smsreceivetime.ToString()+"\r\n");

            }
        }

        private void bt_edit_Click(object sender, EventArgs e)
        {
            PwdCheck p = new PwdCheck();
                   
            p.Show();
           // this.Hide();
            p.cs += P_cs;
           
            
        }

        private void P_cs(bool b)
        {
            if (b)
            {
                textBox2.Enabled = true;

            }
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
        }
    }
}
