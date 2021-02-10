using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;

namespace 获取交换机的mac地址表
{
    internal class SqlHelpher
    {
        private static readonly string s = @"data source=172.16.0.12; initial catelog =sms;uid=sa;pwd=Rcrmyy3162";

        private SqlConnection conn = new SqlConnection(s);
    }
}
