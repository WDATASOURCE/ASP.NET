﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    public string MessageName;
     #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            


        }
        #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MessageName = null;
        }
    }
    protected void Btn_Login_Click(object sender, EventArgs e)
    {
        if (TxtUser.Text.Trim() == "" || TxtPwd.Text.Trim() == "")
        {
            if (TxtUser.Text.Trim() == "" && TxtPwd.Text.Trim() == "") lbMessage.Text = "请填写用户名和密码!";
            else if (TxtUser.Text.Trim() == "") lbMessage.Text = "请填写用户名！";
            else lbMessage.Text = "请填写密码！";
            MessageName = "#danger-block";
            return;
        }
        user userLogin = new user();
        bool isok = false;

        string sql = "select * from Tb_User_Login where isnull(ID,'')='" + TxtUser.Text.Trim() + "' and isnull(userPass,'')='" + TxtPwd.Text.Trim() + "'and isnull(userRole,'')='1'";
        SqlDataReader myReader = userLogin.Login(sql);
        if (myReader.Read())
        {
            int time = Convert.ToInt32(role.SelectedValue);
            Session.Timeout = time;
            Session["UserId"] = myReader["ID"].ToString().Trim();
            Session["Name"] = myReader["userName"].ToString().Trim();//保存用户名称
            Session["Pass"] = myReader["userPass"].ToString().Trim();//保存用户密码
            Session["Role"] = myReader["userRole"].ToString().Trim();//保存用户权限.		
            isok = true;
        }

        if (!isok)
        {
            lbMessage.Text = "用户名称或密码错误，登陆失败!";
            MessageName = "#danger-block";
            return;
        }
        else
        {
            MessageName = null;
            Response.Redirect("/WebFiles/Employee/List_employee.aspx?empid=");
        }
    }
}



















