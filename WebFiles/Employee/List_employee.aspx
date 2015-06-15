<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List_employee.aspx.cs" Inherits="WebFiles_Employee_List_employee" %>

<%@ Register Src="/UserControl/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>员工列表</title>
    <script type="text/javascript">
        function selectAll(name) {
            var a = document.getElementsByName(name);
            if (a[0].checked) {
                for (var i = 0; i < a.length; i++) {
                    if (a[i].type == "checkbox") a[i].checked = false;
                }
            } else {
                for (var i = 0; i < a.length; i++) {
                    if (a[i].type == "checkbox") a[i].checked = true;
                }
            }
        }
    </script>

</head>
<body>
    <uc1:Header ID="Header1" runat="server" />
    <div class="container">
        <div class="tab-content">
            <div class="tabbable">
                <ul class="nav nav-tabs">
                    <li class="active"><a href="/WebFiles/Employee/List_employee.aspx?empid=" data-toggle="tab1">员工信息</a></li>
                    <li><a href="/WebFiles/Department/List_Depart.aspx?depid=" data-toggle="tab2">部门信息</a></li>
                    <li><a href="/WebFiles/Wage/List_Wage.aspx?empid=" data-toggle="tab3">工资管理</a></li>
                </ul>
                <div class="tab-pane active" id="tab1">
                    <br />
                    <form id="form1" runat="server" method="post">
                        <table class="table table-condensed table-responsive">
                            <thead>
                                <tr style="text-align: center">
                                    <td style="width: 35%"></td>
                                    <td><a class="btn btn-primary btn-sm" href="/WebFiles/Employee/Add_employee.aspx">添加员工信息</a></td>
                                    <td>
                                        <button type="button" class="btn btn-primary btn-sm" onclick="selectAll('checkbox1')">全选/全不选</button></td>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" class="btn btn-sm btn-danger" Text="删除所选记录" OnClick="btn_delete_Click"></asp:Button></td>
                                    <td style="width: 35%">
                                        <div class="navbar-form navbar-right" role="search">
                                            <div class="form-group">
                                                <asp:TextBox ID="TxtSearch" runat="server" class="form-control" placeholder="Search"></asp:TextBox>
                                            </div>
                                            <asp:Button ID="Bnt" runat="server" class="btn btn-primary" Text="搜索" OnClick="Bnt_Click"></asp:Button>
                                        </div>
                                    </td>
                                </tr>
                            </thead>
                        </table>
                        <table class="table table-striped table-bordered table-hover table-condensed">
                            <tr style="text-align: center">
                                <td>选择</td>
                                <td>员工编号</td>
                                <td>员工姓名</td>
                                <td>员工性别</td>
                                <td>出生年月</td>
                                <td>联系电话</td>
                                <td>联系地址</td>
                                <td>所属部门</td>
                                <td>操作</td>
                            </tr>
                            <%
                                if (ReadEmper != null)
                                {
                                    while (ReadEmper.Read())
                                    {
                                        string empid = ReadEmper["E_ID"].ToString().Trim();
                                        Response.Write("<tr style = 'text-align:center'>");
                                        Response.Write("<td><input type = 'checkbox' name= 'checkbox1' id ='" + empid + "' value ='" + empid + "'/></td>\n");
                                        Response.Write("<td>" + empid + "</td> \n <td>" + ReadEmper["E_Name"].ToString().Trim() + "</td> \n <td>" + ReadEmper["E_Sex"].ToString().Trim() + "</td> \n <td>" + ReadEmper["E_Birth"].ToString().Trim() + "</td> \n <td>" + ReadEmper["E_tel"].ToString().Trim() + "</td> \n <td>" + ReadEmper["E_Address"].ToString().Trim() + "</td> \n <td>" + ReadEmper["D_Name"].ToString().Trim() + "</td>\n");
                                        Response.Write("<td> <a class = 'btn btn-info btn-xs' href='/WebFiles/Employee/DisplayEmployee.aspx?empid=" + empid + "'>修改</a></td>\n");
                                        Response.Write("</tr>\n");
                                    }
                                }
                            %>
                        </table>
                        <table class="table table-condensed table-responsive">
                            <thead>
                                <tr style="text-align: center">
                                    <td style="width: 35%"></td>
                                    <td><a class="btn btn-primary btn-sm" href="/WebFiles/Employee/Add_employee.aspx">添加员工信息</a></td>
                                    <td>
                                        <button type="button" class="btn btn-primary btn-sm" onclick="selectAll('checkbox1')">全选/全不选</button></td>
                                    <td>
                                        <asp:Button ID="Del_But" runat="server" class="btn btn-sm btn-danger" Text="删除所选记录" OnClick="btn_delete_Click"></asp:Button></td>
                                    <td style="width: 35%"></td>
                                </tr>
                            </thead>
                        </table>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
