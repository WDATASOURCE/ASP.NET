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

    public class Employ
    {

        //先申明一系列常用的对象
        private string connstr;
        private SqlConnection Sqlconn;
        private SqlCommand Sqlcmd;
        private SqlDataAdapter Sqladpter;
        private DataSet ds;
        private SqlDataReader Sqlreader;

        public Employ()
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

        public SqlDataReader Employee_list(string id)
        {
            Sqlcmd.CommandText = "select * from Tb_employee where E_ID ='" + id + "'";
            Sqlcmd.Connection = Sqlconn;
            if (Sqlconn.State == ConnectionState.Closed) { Sqlconn.Open(); }
            Sqlreader = Sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);
            return Sqlreader;
        }
        public SqlDataReader Employee_list()
        {
            Sqlcmd.CommandText = "select * from Tb_employee order by E_ID";
            Sqlcmd.Connection = Sqlconn;
            if (Sqlconn.State == ConnectionState.Closed) { Sqlconn.Open(); }
            Sqlreader = Sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);
            return Sqlreader;
        }

        public void Update(string depid)
        {
            Sqlcmd.CommandText = "update [Tb_employee] set D_Name= NULL where D_Name='" + depid + "'";
            Sqlcmd.Connection = Sqlconn;
            Sqlconn.Open();
            Sqlcmd.ExecuteNonQuery();
        }
        public void Update(string empid, string empName, string empSex, string empBirth, string empTel, string empAddress, string agreer, string info)
        {//执行更新动作 
            Sqlcmd.CommandText = "update [Tb_employee] set E_Name=N'" + empName + "',E_Sex=N'" + empSex + "',E_Birth=N'" + empBirth + "',E_Tel=N'" + empTel + "',E_Address=N'" + empAddress + "', D_Name=N'"+agreer+"', E_Intro=N'"+info+"' where E_ID='" + empid + "'";
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
        public void Insert(string E_ID, string E_Name, string E_Sex, string E_Birth, string E_Tel, string E_Address, string D_Name, string E_Intro, string E_Picurl)
        {//执行添加动作    
            Sqlcmd.CommandText = "insert into [Tb_employee] values('" + E_ID + "',N'" + E_Name + "',N'" + E_Sex + "',N'" + E_Birth + "','" + E_Tel + "',N'" + E_Address + "',N'" + E_Intro + "',N'" + E_Picurl +"', N'"+ D_Name+ "')";
            Sqlcmd.Connection = Sqlconn;
            Sqlconn.Open();
            Sqlcmd.ExecuteNonQuery();
        }
    }
