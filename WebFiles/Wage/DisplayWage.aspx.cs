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
public partial class WebFiles_Wage_DisplayWage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string connstr = ConfigurationManager.ConnectionStrings["Mispersonalconn"].ConnectionString;
            SqlConnection Sqlconn = new SqlConnection(connstr);
            DataSet ds = new DataSet();
            Sqlconn.Close();
            string empid = Request.QueryString["empid"];
            Wage empler = new Wage();
            SqlDataReader ReadEmp = empler.Wage_list(empid);
            if (ReadEmp.Read())
            {
                TxtID.Text = ReadEmp["E_ID"].ToString().Trim();
                TxtName.Text = ReadEmp["E_Name"].ToString().Trim();
                TxtWage.Text = ReadEmp["Day_Wage"].ToString().Trim();
                TxtDay.Text = ReadEmp["Work_Day"].ToString().Trim();
                TxtPaid.Text = ReadEmp["Paid_Wage"].ToString().Trim();
            }
        }
    }
    protected void btn_edit_Click(object sender, EventArgs e)
    {
        if ((string)Session["role"] == "1")
        {
            Wage emp = new Wage();
            int a = Convert.ToInt32(TxtWage.Text.Trim());
            int b = Convert.ToInt32(TxtDay.Text.Trim());
            int c = Convert.ToInt32(TxtPaid.Text.Trim());
            int m = a * b;
            int n = m - c;
            string sm = Convert.ToString(m);
            string sn = Convert.ToString(n);

            emp.Update(TxtID.Text.Trim(), TxtWage.Text.Trim(), TxtDay.Text.Trim(), sm, TxtPaid.Text.Trim(), sn);
            Response.Write("<script>alert('操作成功!')</script>");
            Response.Redirect("/WebFiles/Wage/List_Wage.aspx?empid=");
        }
        else
        {
            Response.Write("<script>alert('只有管理员才可以进行此操作!')</script>");
        }
    }
}
