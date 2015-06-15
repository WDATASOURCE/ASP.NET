<%@ Page Language="C#" CodePage="936" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Add_employee.aspx.cs" Inherits="WebFiles_Employee_Add_employee" %>

<%@ Register Src="/UserControl/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<!DOCTYPE HTML>
<html>
<head runat="server">
    <title>添加员工信息</title>
</head>
<body>
    <uc1:Header ID="Header1" runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <h1 class="center-block text-center" style="max-width: 400px; position: relative">添加员工</h1>
                <form id="form1" runat="server" class="form-horizontal" method="post">
                    <div class="form-group">
                        <asp:TextBox ID="tb_id" runat="server" type="text" class="form-control" placeholder="员工编号"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="tb_name" runat="server" type="text" class="form-control" placeholder="员工姓名"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:DropDownList ID="sex" runat="server" class="form-control">
                            <asp:ListItem Selected="True">男</asp:ListItem>
                            <asp:ListItem>女</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="tb_birth" runat="server" class="form-control" placeholder="出生日期"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="tb_tel" runat="server" type="text" class="form-control" placeholder="联系电话"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="tb_address" runat="server" type="text" class="form-control" placeholder="联系地址"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:DropDownList ID="Agreer" runat="server" type="text" class="form-control" placeholder="所属部门"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="tb_intro" runat="server" type="text" class="form-control" placeholder="个人简介"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="add" runat="server" class="btn btn-block btn-primary" Text="添加" OnClick="add_Click" />
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
