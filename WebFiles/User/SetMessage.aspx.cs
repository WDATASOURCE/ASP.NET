using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class WebFiles_User_SetMessage : System.Web.UI.Page
{
    public string Message;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Message = getMessage("/message.txt");
        }
    }

    protected void Btn_Click(object sender, EventArgs e)
    {
        if (Request.Form["Text1"] == null) Message = "";
        else
        {
            Message = Request.Form["Text1"].ToString().Trim();
            setMessage("/message.txt", Message);
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

    public void setMessage(string strfile, string message)
    {
        StreamWriter wr = new StreamWriter(Server.MapPath(strfile), false, System.Text.Encoding.Default);
        wr.Write(message);
        wr.Close();
        Response.Redirect("/WebFiles/Employee/List_employee.aspx?empid=");
    }
   
}