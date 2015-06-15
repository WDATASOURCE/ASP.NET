using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
public class user
{
    //先申明一系列常用的对象
    private string connstr;
    private SqlConnection Sqlconn;
    private SqlCommand Sqlcmd;
    private SqlDataAdapter Sqladpter;
    private DataSet ds;
    private SqlDataReader Sqlreader;

    public user()
    {//初始化所有的实例
        connstr = ConfigurationManager.ConnectionStrings["Mispersonalconn"].ConnectionString;
        Sqlconn = new SqlConnection(connstr);
        Sqlcmd = new SqlCommand();
        Sqladpter = new SqlDataAdapter();
        ds = new DataSet();
    }
    public SqlDataReader Login(string sql)
    {
        Sqlcmd.CommandText =sql;
        Sqlcmd.Connection = Sqlconn;
        if (Sqlconn.State == ConnectionState.Closed) { Sqlconn.Open(); }
        Sqlreader=Sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);
        return Sqlreader;
    }

    public DataSet Search(string sql)
    {//返回内存数据库
        Sqladpter.SelectCommand = new SqlCommand(sql, Sqlconn);
        Sqladpter.Fill(ds, "temp");
        return ds;
    }

    public void Update(string ID,string userName,string userPass,string userRole)
    {//执行更新动作 
        Sqlcmd.CommandText = "update Tb_User_Login set userName=N'" + userName + "',userPass='" + userPass + "',userRole ='" + userRole + "' where ID='" + ID +"'";
        //Sqlcmd.CommandText = "update Tb_User_Login set userName =N'"+userName+"', userPass='"+userPass+"', userRole='"+userRole+"';";
        Sqlcmd.Connection = Sqlconn;
        Sqlconn.Open();
        Sqlcmd.ExecuteNonQuery();
        //System.Web.HttpContext.Current.Response.Write("<script>alert('只有管理员才可以进行此操作!')</script>");
    }
    public void Delete(string ID)
    {//执行删除动作
        Sqlcmd.CommandText = "delete from [Tb_User_Login] where [ID]='" +ID+ "'";
        Sqlcmd.Connection = Sqlconn;
        Sqlconn.Open();
        Sqlcmd.ExecuteNonQuery();
    }
    public void Insert(string ID, string userName, string userPass, string userRole)
    {//执行添加动作 
        Sqlcmd.CommandText = "insert into [Tb_User_Login] values('" + ID + "','" + userName + "','" + userPass + "','" + userRole + "')";
        Sqlcmd.Connection = Sqlconn;
        Sqlconn.Open();
        Sqlcmd.ExecuteNonQuery(); 
    }
}
