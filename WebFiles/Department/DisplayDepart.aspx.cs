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
public partial class WebFiles_Department_View_Depart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request.QueryString["depid"];
            string sql = "select * from [Tb_department] where D_ID='" + id + "'";
            string connstr = ConfigurationManager.ConnectionStrings["Mispersonalconn"].ConnectionString;
            SqlConnection Sqlconn = new SqlConnection(connstr);
            Sqlconn.Open();
            SqlCommand sc = new SqlCommand(sql, Sqlconn);
            SqlDataReader myreader = sc.ExecuteReader();
            if (myreader.Read())
            {
                TxtID.Text = myreader[0].ToString();
                TxtName.Text = myreader[1].ToString();
                TxtTel.Text = myreader[2].ToString();
                TxtAddress.Text = myreader[3].ToString();
                TxtChief.Text = myreader[4].ToString();
                TxtBelong.Text = myreader[5].ToString();
                Sqlconn.Close();
            }
        }
    }
 
    protected void Edit_Click(object sender, EventArgs e)
    {
            if ((string)Session["role"] == "1")
            {
                string sql = "update Tb_department set D_Name = N'" + TxtName.Text + "', D_Tel=N'" + TxtTel.Text + "',D_Address =N'" + TxtAddress.Text + "',D_Chief=N'" + TxtChief.Text + "',D_Belong=N'" + TxtBelong.Text + "' where D_ID=N'" + TxtID.Text + "'";
                string connstr = ConfigurationManager.ConnectionStrings["Mispersonalconn"].ConnectionString;
                SqlConnection Sqlconn = new SqlConnection(connstr);
                Sqlconn.Open();
                SqlCommand sc = new SqlCommand(sql, Sqlconn);
                sc.ExecuteNonQuery();
                //lbMessage.Text = "您已成功更新1条记录!";
                Sqlconn.Close();
                Response.Redirect("/WebFiles/Department/List_Depart.aspx?depid=");
            }
            else
            {
                Response.Write("<script>alert('只有管理员才可以进行此操作!')</script>");
            }
    }
}
