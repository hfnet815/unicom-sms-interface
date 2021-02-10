using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace 联通短信发送接口
{
    internal class SqlHelper
    {
        private readonly static string sqllink = "Data Source=172.16.0.3;initial catalog=SMS;user id= sa;password=Rcrmyy3162";

        private SqlConnection conn = new SqlConnection(sqllink);
        private string stime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + " " + "17:00:00";

        /// <summary>
        /// 获取需要发送短信的预约病人列表，屏蔽没有电话的，预约没有电话的由SQL数据库进行周期性更新
        /// </summary>
        /// <returns></returns>
        public List<AppointmentofPatients> GetSmsConcent()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            string s = @"SELECT vac01,VAA05,  VAC20, VAC37 FROM VAC5 AS A JOIN VAA1 AS B ON A.VAA01=B.VAA01 WHERE A.send_flag=0 AND LEN(VAC20)>9 AND DATEDIFF(hh, vac37,getdate())< 20 ";

            SqlCommand com = new SqlCommand(s, conn);
            List<AppointmentofPatients> mess = new List<AppointmentofPatients>();

            try
            {
                SqlDataReader sda = com.ExecuteReader();

                while (sda.Read())
                {
                    AppointmentofPatients aop = new AppointmentofPatients();
                    aop.vac01 = sda[0].ToString();
                    aop.vaa05 = sda[1].ToString();
                    aop.vac20 = sda[2].ToString();
                    aop.vac37 = sda[3].ToString();

                    mess.Add(aop);
                }
            }
            finally
            {
                conn.Close();
            }
            return mess;
        }

        /// 获取门诊就诊病人列表，数据逻辑及约束在数据库中处理。

        public List<string> Getvaa35()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            //string stime = DateTime.Now.AddDays(-1).ToLongDateString().ToString() + "17:00:00";
            string s = @"select VAA35  from sms_daily where TaskID='0'  and vac37>'" + stime + "'";

            SqlCommand com = new SqlCommand(s, conn);
            List<string> mess = new List<string>();

            try
            {
                SqlDataReader sda = com.ExecuteReader();

                while (sda.Read())
                {
                    mess.Add(sda[0].ToString());
                }
            }
            finally
            {
                conn.Close();
            }
            return mess;
        }

        public List<string> ManualGetvaa35(string begintime, string endtime)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            string s = @"select VAA35  from sms_daily where TaskID='0'  and vac37>'" + begintime + "' and vac37<='" + endtime + "'";

            SqlCommand com = new SqlCommand(s, conn);
            List<string> mess = new List<string>();

            try
            {
                SqlDataReader sda = com.ExecuteReader();

                while (sda.Read())
                {
                    mess.Add(sda[0].ToString());
                }
            }
            finally
            {
                conn.Close();
            }
            return mess;
        }

        public List<string> Gettaskid()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            string s = @"select distinct taskid from sms_daily where taskid!='0' and vac37> '" + stime + "'";

            SqlCommand com = new SqlCommand(s, conn);

            List<string> mess = new List<string>();

            try
            {
                SqlDataReader sda = com.ExecuteReader();

                while (sda.Read())
                {
                    mess.Add(sda[0].ToString());
                }
            }
            finally
            {
                conn.Close();
            }
            return mess;
        }

        public List<string> ManualGetTaskId(string begintime, string endtime)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            string s = @"select distinct taskid from sms_daily where taskid!='0' and vac37> '" + begintime + "' and vac37<='" + endtime + "'";

            SqlCommand com = new SqlCommand(s, conn);

            List<string> mess = new List<string>();

            try
            {
                SqlDataReader sda = com.ExecuteReader();

                while (sda.Read())
                {
                    mess.Add(sda[0].ToString());
                }
            }
            finally
            {
                conn.Close();
            }
            return mess;
        }

        public int updateReturntaskid(string phonenumber, string taskid)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            string s = @"update sms_daily set taskID='" + taskid + "',SendTime='" + DateTime.Now.ToString() + "'" + " where vaa35 in (" + phonenumber + ") and vac37> '" + stime + "'";

            SqlCommand com = new SqlCommand(s, conn);

            int i = com.ExecuteNonQuery();

            return i;
        }

        public int ManualUpdateReturnTaskid(string phonenumber, string taskid, string begintime, string endtime)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            string s = @"update sms_daily set taskID='" + taskid + "',SendTime='" + DateTime.Now.ToString() + "'" + " where vaa35 in (" + phonenumber + ") and vac37> '" + begintime + "' and vac37<='" + endtime + "'";

            SqlCommand com = new SqlCommand(s, conn);

            int i = com.ExecuteNonQuery();

            return i;
        }

        public void updatereportstatus(List<StatusReprot> sr)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            foreach (var s in sr)
            {
                string sql = @"update sms_daily set smsStatus= '" + s.smsStatus.ToString() + "', smsreceivetime= '" + s.smsreceivetime.ToString() + "' where taskid='" + s.taskID + "' and vaa35='" + s.vaa35 + "' and vac37>'" + stime + "'";

                SqlCommand com = new SqlCommand(sql, conn);

                com.ExecuteNonQuery();
            }
        }

        public void ManualUpdateReprotStatus(List<StatusReprot> sr, string begintime, string endtime)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            foreach (var s in sr)
            {
                string sql = @"update sms_daily set smsStatus= '" + s.smsStatus.ToString() + "', smsreceivetime= '" + s.smsreceivetime.ToString() + "' where taskid='" + s.taskID + "' and vaa35='" + s.vaa35 + "' and vac37>'" + begintime + "' and vac37<='" + endtime + "'";

                SqlCommand com = new SqlCommand(sql, conn);

                com.ExecuteNonQuery();
            }
        }

        public void updateContent(List<ReturnSms> rs)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            foreach (var s in rs)
            {
                string sql = @"update sms_daily set content= '" + s.content.ToString() + @"', contentreceivetime= '" + s.contentreceivetime + @"' where vaa35 = '" + s.vaa35 + "' and taskid='" + s.taskID.ToString() + "'";

                SqlCommand com = new SqlCommand(sql, conn);

                com.ExecuteNonQuery();

                string st = @" insert into ReturnContent values('" + s.taskID + "','" + s.Returnid + "','" + s.vaa35 + "','" + s.content + "','" + s.contentreceivetime + "')";

                SqlCommand comm = new SqlCommand(st, conn);

                comm.ExecuteNonQuery();
            }
        }
    }
}
