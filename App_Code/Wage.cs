using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Wage 的摘要说明
/// </summary>
/// 
    public class Wage
    {

        //先申明一系列常用的对象
        private string connstr;
        private SqlConnection Sqlconn;
        private SqlCommand Sqlcmd;
        private SqlDataAdapter Sqladpter;
        private DataSet ds;
        private SqlDataReader Sqlreader;

        public Wage()
        {//初始化所有的实例
            connstr = ConfigurationManager.ConnectionStrings["Mispersonalconn"].ConnectionString;
            Sqlconn = new SqlConnection(connstr);
            Sqlcmd = new SqlCommand();
            Sqladpter = new SqlDataAdapter();
            ds = new DataSet();
        }

        public DataSet TdataSet(string sql)
        {//返回内存数据库
            Sqladpter.SelectCommand = new SqlCommand(sql, Sqlconn);
            Sqladpter.Fill(ds, "temp");
            return ds;
        }

        public SqlDataReader Wage_list(string id)
        {
            Sqlcmd.CommandText = "select * from Tb_Wage where E_ID ='" + id +"'";
            Sqlcmd.Connection = Sqlconn;
            if (Sqlconn.State == ConnectionState.Closed) { Sqlconn.Open(); }
            Sqlreader = Sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);
            return Sqlreader;
        }
        public SqlDataReader Wage_list()
        {
            Sqlcmd.CommandText = "select * from Tb_Wage";
            Sqlcmd.Connection = Sqlconn;
            if (Sqlconn.State == ConnectionState.Closed) { Sqlconn.Open(); }
            Sqlreader = Sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);
            return Sqlreader;
        }

        public void Update(string empid, string daywage, string workday, string allwage, string paidwage, string unpaidwage)
        {//执行更新动作 
            Sqlcmd.CommandText = "update [Tb_Wage] set Day_Wage=" + daywage + ",Work_Day=" + workday + ",All_Wage=" + allwage + ",Paid_Wage=" + paidwage + ", Unpaid_Wage=" + unpaidwage + " where E_ID='" + empid + "'";
            Sqlcmd.Connection = Sqlconn;
            Sqlconn.Open();
            Sqlcmd.ExecuteNonQuery();
        }

        public void Delete(string ID)
        {//执行删除动作
            Sqlcmd.CommandText = "delete from [Tb_employee] where E_ID='" + ID+ "'";
            Sqlcmd.Connection = Sqlconn;
            Sqlconn.Open();
            Sqlcmd.ExecuteNonQuery();
        }
        public void Insert(string empid, string empName, string daywage, string workday, string allwage, string paidwage, string unpaidwage)
        {//执行添加动作    
            Sqlcmd.CommandText = "insert into [Tb_Wage] values('" + empid + "',N'" + empName + "',N'" + daywage + "',N'" + workday + "','" + allwage + "',N'" + paidwage + "',N'" + unpaidwage + "')";
            Sqlcmd.Connection = Sqlconn;
            Sqlconn.Open();
            Sqlcmd.ExecuteNonQuery();
        }
    }
