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

public partial class WebFiles_Wage_Add_Wage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string connstr = ConfigurationManager.ConnectionStrings["Mispersonalconn"].ConnectionString;
            SqlConnection Sqlconn = new SqlConnection(connstr);
            DataSet ds = new DataSet();
            string Agreerstr = "select E_ID,E_Name from Tb_employee order by E_ID";
            SqlDataAdapter SqlAgreer = new SqlDataAdapter(Agreerstr, Sqlconn);
            SqlAgreer.Fill(ds, "Agreer");
            Agreer.DataSource = ds.Tables["Agreer"].DefaultView;
            Agreer.DataTextField = "E_Name";
            Agreer.DataValueField = "E_ID";
            Agreer.DataBind();
            //Agreer.DataTextField = Agreer.DataValueField + "(" + Agreer.DataTextField + ")";
            Sqlconn.Close();
        }
    }


    protected void add_Click(object sender, EventArgs e)
    {
        if (Agreer.Text.Trim() == "")
        {
            Response.Write("<script>alert('员工不能为空')</script>");
            return;
        }
        if (Day_Wage.Text.Trim() == "")
        {
            Response.Write("<script>alert('工资不能为空')</script>");
            return;
        }
        if (Work_Day.Text.Trim() == "")
        {
            Response.Write("<script>alert('出勤天数不能为空')</script>");
            return;
        }

        if (Paid_Wage.Text.Trim() == "")
        {
            Response.Write("<script>alert('已付工资不能为空')</script>");
            return;
        }
        Wage Registor = new Wage();
        int a = Convert.ToInt32(Day_Wage.Text.Trim());
        int b = Convert.ToInt32(Work_Day.Text.Trim());
        int c = Convert.ToInt32(Paid_Wage.Text.Trim());
        int m = a * b;
        int n = m - c;
        string sm = Convert.ToString(m);
        string sn = Convert.ToString(n);

        //string namesql = "select E_Name from Tb_employee order by E_ID";


        Registor.Insert(Agreer.SelectedValue, Agreer.SelectedItem.Text , Day_Wage.Text.Trim(), Work_Day.Text.Trim(),sm, Paid_Wage.Text.Trim(),sn);
        Response.Redirect("/WebFiles/Wage/List_Wage.aspx?empid=");
    }
}