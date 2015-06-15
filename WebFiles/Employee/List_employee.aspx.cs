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
public partial class WebFiles_Employee_List_employee : System.Web.UI.Page
{
    public SqlDataReader ReadEmper;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Employ employ = new Employ();
            string empid = Request.QueryString["empid"];
            if (empid == "") ReadEmper = employ.Employee_list();
            else ReadEmper = employ.Employee_list(empid);
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
                    string sql = "delete from [Tb_employee] where E_ID='" + empid + "'";
                    SqlCommand sc = new SqlCommand(sql, Sqlconn);
                    sc.ExecuteNonQuery();
                }
                Sqlconn.Close();
                Response.Redirect("./List_employee.aspx?empid=");
            }
            else
            {
                Response.Redirect("./List_employee.aspx?empid=");
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
        if (empid == "") Response.Redirect("./List_employee.aspx?depid=");
        else Response.Redirect("./List_employee.aspx?empid=" + empid);
    }
    
}
