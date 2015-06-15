using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Control_WebUserControl : System.Web.UI.UserControl
{
    public string Message;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] == null)
        {
            Response.Write("<script>alert('您还没有登录或者登陆超时，请重新登陆！')</script>");
            Response.Redirect("/Default.aspx");
        }
        else
        {
            Message = getMessage("/message.txt");
            lbMessage.Text = (string)Session["Name"];
        }
    }
    public string getMessage(string strfile)
    {
        string strout;
        strout = "";
        if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(strfile)))
        {
            StreamReader sr = new StreamReader(Server.MapPath(strfile), System.Text.Encoding.Default);
            String input = sr.ReadToEnd();
            sr.Close();
            strout = input;
        }
        return strout;
    }
}
