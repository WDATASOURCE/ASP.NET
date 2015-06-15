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
public partial class WebFiles_Employee_DisplayEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            this.TxtBirth.Attributes.Add("onfocus", "javascript:calendar()");

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
            string empid = Request.QueryString["empid"];
            Employ empler = new Employ();
            SqlDataReader ReadEmp = empler.Employee_list(empid);
            if (ReadEmp.Read())
            {
                TxtID.Text = ReadEmp["E_ID"].ToString().Trim();
                TxtName.Text = ReadEmp["E_Name"].ToString().Trim();
                TxtBirth.Text = ReadEmp["E_Birth"].ToString().Trim();
                TxtAddress.Text = ReadEmp["E_Address"].ToString().Trim();
                TxtTel.Text = ReadEmp["E_Tel"].ToString().Trim();
                TxtIntro.Text = ReadEmp["E_Intro"].ToString().Trim();
            }
        }
    }
    protected void btn_edit_Click(object sender, EventArgs e)
    {
        if ((string)Session["role"] == "1")
        {
            Employ emp = new Employ();
            emp.Update(TxtID.Text.Trim(), TxtName.Text.Trim(), Sex.SelectedValue, TxtBirth.Text.Trim(), TxtTel.Text.Trim(), TxtAddress.Text.Trim(), Agreer.SelectedValue, TxtIntro.Text.Trim()  );
            Response.Write("<script>alert('操作成功!')</script>");
            Response.Redirect("/WebFiles/Employee/List_employee.aspx?empid=");
        } 
            else
            {
                Response.Write("<script>alert('只有管理员才可以进行此操作!')</script>");
            }
    }
}
