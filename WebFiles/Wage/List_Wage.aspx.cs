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
public partial class WebFiles_Wage_List_Wage : System.Web.UI.Page
{
    public SqlDataReader ReadEmper;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Wage employ = new Wage();
            string empid = Request.QueryString["empid"];
            
            if (empid == "") ReadEmper = employ.Wage_list();
            else ReadEmper = employ.Wage_list(empid);
        }
    }

    protected void btn_delete_Click(object sender, EventArgs e)
    {
        if ((string)Session["role"] == "1")
        {
            if (Request["checkbox1"] != null)
            {
                string allEmp = Request["checkbox1"].ToString();
                string[] emp = allEmp.Split(new Char[] { ',' });
                string connstr = ConfigurationManager.ConnectionStrings["Mispersonalconn"].ConnectionString;
                SqlConnection Sqlconn = new SqlConnection(connstr);
                Sqlconn.Open();
                for (int i = 0; i < emp.Length; i++)
                {
                    string empid = emp[i];
                    string sql = "delete from [Tb_Wage] where E_ID='" + empid + "'";
                    SqlCommand sc = new SqlCommand(sql, Sqlconn);
                    sc.ExecuteNonQuery();
                }
                Sqlconn.Close();
                Response.Redirect("./List_Wage.aspx?empid=");
            }

            else
            {
                Response.Redirect("./List_Wage.aspx?empid=");
            }
        }
        else
        {
            Response.Write("<script>alert('只有管理员才可以进行此操作!')</script>");
        }
    }

    protected void btn_add_Click(object sender, EventArgs e)
    {
        if ((string)Session["role"] == "1")
        {
            if (Request["checkbox1"] != null)
            {
                string allEmp = Request["checkbox1"].ToString();
                string[] emp = allEmp.Split(new Char[] { ',' });
                string connstr = ConfigurationManager.ConnectionStrings["Mispersonalconn"].ConnectionString;
                SqlConnection Sqlconn = new SqlConnection(connstr);
                Sqlconn.Open();
                for (int i = 0; i < emp.Length; i++)
                {
                    string empid = emp[i];
                    string sql1 = "update [Tb_Wage] set Work_Day = Work_Day + 1 where E_ID='" + empid + "'";
                    string sql2 = "update [Tb_Wage] set All_Wage = All_Wage + Day_Wage where E_ID='" + empid + "'";
                    string sql3 = "update [Tb_Wage] set Unpaid_Wage = Unpaid_Wage + Day_Wage where E_ID='" + empid + "'";
                    SqlCommand sc1 = new SqlCommand(sql1, Sqlconn);
                    SqlCommand sc2 = new SqlCommand(sql2, Sqlconn);
                    SqlCommand sc3 = new SqlCommand(sql3, Sqlconn);
                    sc1.ExecuteNonQuery();
                    sc2.ExecuteNonQuery();
                    sc3.ExecuteNonQuery();
                }
                Sqlconn.Close();
                Response.Redirect("./List_Wage.aspx?empid=");
            }

            else
            {
                Response.Redirect("./List_Wage.aspx?empid=");
            }
        }
        else
        {
            Response.Write("<script>alert('只有管理员才可以进行此操作!')</script>");
        }
    }

    protected void Bnt_Click(object sender, EventArgs s)
    {
        string empid = TxtSearch.Text.Trim();
        if (empid == "") Response.Redirect("./List_Wage.aspx?depid=");
        else Response.Redirect("./List_Wage.aspx?empid=" + empid);
    }

}
