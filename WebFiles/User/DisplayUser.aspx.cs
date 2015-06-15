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
public partial class WebFiles_User_User_view : System.Web.UI.Page
{
    public  string userId;
    public  string userName;
    public string userPass;
    public string userRole;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Name"] != null)
            {
                userId = Session["UserId"].ToString().Trim();
                userName = Session["Name"].ToString().Trim();
                userPass = Session["Pass"].ToString().Trim();
                userRole = Session["Role"].ToString().Trim();
                TxtUserID.Text = userId;
                TxtUserName.Text = userName;
            }
            else
            {
                Response.Write("<script>alert('您还没有登录或者登陆超时，请重新登陆！')</script>");
                Response.Redirect("/Default.aspx"); 
            }
        }
    }
    protected void Edit_Click(object sender, EventArgs e)
    {
            if (Session["Role"].ToString().Trim() == "1")
            {
                Session["Name"]= userName = TxtUserName.Text;
                userId = Session["UserId"].ToString().Trim();
                userPass = Session["Pass"].ToString().Trim();
                userRole = Session["Role"].ToString().Trim();
                user User = new user();
                User.Update(userId, userName, userPass, userRole);
                Response.Write("<script>alert('操作成功！')</script>");
                Response.Redirect("/WebFiles/User/DisplayUser.aspx");
            }
            else
            {
                Response.Write("<script>alert('只有管理员才可以进行此操作!')</script>");
            }
    }
    protected void Click_Change_Pass(object sender, EventArgs e)
    {
            if ((string)Session["role"] == "1")
            {
                userPass = Session["Pass"].ToString().Trim();
                userName = Session["Name"].ToString().Trim();
                userRole = Session["Role"].ToString().Trim();
                //Response.Write("<script>alert('"+userPass+"')</script>");
                if (TxtPassold.Text == userPass)
                {
                    if (TxtPass.Text == TxtPass1.Text)
                    {
                        Session["Pass"] = userPass = TxtPass1.Text;
                        user User = new user();
                        User.Update(userId, userName, userPass, userRole);
                        Response.Write("<script>alert('操作成功！')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('对不起，您两次输入的密码不一致，请重新输入！')</script>");
                        return;
                    }
                }
                else
                {
                    Response.Write("<script>alert('对不起，你输入的原始密码有误，请重新输入！')</script>");
                    return;
                }
            }
            else
            {
                Response.Write("<script>alert('只有管理员才可以进行此操作!')</script>");
            }
        }
}
