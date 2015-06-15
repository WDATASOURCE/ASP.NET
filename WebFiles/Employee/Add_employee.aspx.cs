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
public partial class WebFiles_Employee_Add_employee : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

           // this.tb_birth.Attributes.Add("onfocus", "javascript:calendar()");

            string connstr = ConfigurationManager.ConnectionStrings["Mispersonalconn"].ConnectionString;
            SqlConnection Sqlconn = new SqlConnection(connstr);
            DataSet ds = new DataSet();
            string Agreerstr = "select D_ID,D_Name from Tb_department order by D_ID desc";
            SqlDataAdapter SqlAgreer = new SqlDataAdapter(Agreerstr, Sqlconn);
            SqlAgreer.Fill(ds, "Agreer");
            Agreer.DataSource = ds.Tables["Agreer"].DefaultView;
            Agreer.DataTextField = "D_Name";
            Agreer.DataValueField = "D_ID";
            Agreer.DataBind();
            Sqlconn.Close();
        }
    }


    protected void add_Click(object sender, EventArgs e)
    {
        if (tb_id.Text.Trim() == "")
        {
            Response.Write("<script>alert('员工编号不能为空')</script>");
            return;
        }
        if (tb_name.Text.Trim() == "")
        {
            Response.Write("<script>alert('员工姓名不能为空')</script>");
            return;
        }
        if (tb_birth.Text.Trim() == "")
        {
            Response.Write("<script>alert('出生年月不能为空')</script>");
            return;
        }

        if (tb_tel.Text.Trim() == "")
        {
            Response.Write("<script>alert('联系电话不能为空')</script>");
            return;
        }
        if (tb_address.Text.Trim() == "")
        {
            Response.Write("<script>alert('联系地址不能为空')</script>");
            return;
        }
        Employ Registor = new Employ();
        //string pic= "~/WebFiles/Images/" + picurl.SelectedValue + ".GIF";
        Registor.Insert(tb_id.Text.Trim(),tb_name.Text.Trim(),sex.SelectedValue,tb_birth.Text.Trim(),tb_tel.Text.Trim(),tb_address.Text.Trim(),Agreer.SelectedValue,tb_intro.Text.Trim()," ");
        Response.Redirect("/WebFiles/Employee/List_employee.aspx?empid=");
    }
}
