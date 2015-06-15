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
public partial class WebFiles_Department_List_Depart : System.Web.UI.Page
{
    public SqlDataReader ReadDepar;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            department depar = new department();
            string depid = Request.QueryString["depid"];
            if (depid == "") ReadDepar = depar.Query();
            else ReadDepar = depar.Query(depid);
        }
    }
    protected void btn_delete_Click(object sender, EventArgs e)
    {
        if ((string)Session["role"] == "1")
        {
            if (Request["checkbox1"] == null) Response.Redirect("./List_Depart.aspx?depid=");
            string allDep = Request["checkbox1"].ToString();
            string[] dep = allDep.Split(new Char[] { ',' });
            string connstr = ConfigurationManager.ConnectionStrings["Mispersonalconn"].ConnectionString;
            SqlConnection Sqlconn = new SqlConnection(connstr);
            Sqlconn.Open();
            Employ emper = new Employ();
            for (int i = 0; i < dep.Length; i++)
            {
                string depid = dep[i];
                emper.Update(depid);
                string sql = "delete from [Tb_department] where D_ID='" + depid + "'";
                SqlCommand sc = new SqlCommand(sql, Sqlconn);
                sc.ExecuteNonQuery();
            }
            Sqlconn.Close();
            Response.Redirect("./List_Depart.aspx?depid=");

        }
        else
        {
            Response.Write("<script>alert('只有管理员才可以进行此操作!')</script>");
        }
    }
    protected void Bnt_Click(object sender, EventArgs e)
    {
        string depid = TxtSearch.Text.Trim();
        if (depid == "") Response.Redirect("./List_Depart.aspx?depid=");
        else Response.Redirect("./List_Depart.aspx?depid="+depid);
    }
}
