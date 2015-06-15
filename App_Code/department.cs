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

public class department
{
    
		 //先申明一系列常用的对象
        private string connstr;
        private SqlConnection Sqlconn;
        private SqlCommand Sqlcmd;
        private SqlDataAdapter Sqladpter;
        private DataSet ds;
        private SqlDataReader Sqlreader;

	public department()
	{//初始化所有的实例
            connstr = ConfigurationManager.ConnectionStrings["Mispersonalconn"].ConnectionString;
            Sqlconn = new SqlConnection(connstr);
            Sqlcmd = new SqlCommand();
            Sqladpter = new SqlDataAdapter();
            ds = new DataSet();
	}

    public SqlDataReader Query(string depid)
    {
        Sqlcmd.CommandText = "select * from Tb_department where D_ID = "+ depid;
        Sqlcmd.Connection = Sqlconn;
        if (Sqlconn.State == ConnectionState.Closed) { Sqlconn.Open(); }
        Sqlreader = Sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);
        return Sqlreader;
    }

    public SqlDataReader Query()
    {
        Sqlcmd.CommandText = "select * from Tb_department";
        Sqlcmd.Connection = Sqlconn;
        if (Sqlconn.State == ConnectionState.Closed) { Sqlconn.Open(); }
        Sqlreader = Sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);
        return Sqlreader;
    }

    public void Insert(string D_ID, string D_Name,string D_Tel, string D_Address, string D_Chief, string D_Belong)
    { 
        Sqlcmd.CommandText = "insert into [Tb_department] values(N'" + D_ID + "',N'" + D_Name + "',N'" + D_Tel + "',N'" + D_Address + "',N'" + D_Chief + "',N'" + D_Belong + "')";
        Sqlcmd.Connection = Sqlconn;
        Sqlconn.Open();
        Sqlcmd.ExecuteNonQuery();
    }
}
