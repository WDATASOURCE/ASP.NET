<%@ Page Language="C#" CodePage="936" AutoEventWireup="true" EnableEventValidation="false" CodeFile="DisplayEmployee.aspx.cs" Inherits="WebFiles_Employee_DisplayEmployee" %>

<%@ Register Src="/UserControl/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<!DOCTYPE html >

<html>
<head runat="server">
    <title>更新员工信息</title>
</head>

<body>
    <uc1:Header ID="Header1" runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <h1 class="center-block text-center" style="max-width: 400px; position: relative">更新员工信息</h1>

                <form runat="server" method="post" class="form-group">
                    <div class="form-group">
                        <asp:TextBox ID="TxtID" runat="server" type="text" class="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtName" runat="server" type="text" class="form-control" placeholder="员工姓名"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:DropDownList ID="Sex" runat="server" class="form-control">
                            <asp:ListItem Selected="True">男</asp:ListItem>
                            <asp:ListItem>女</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtBirth" runat="server" type="text" class="form-control" placeholder="出生年月"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtTel" runat="server" type="text" class="form-control" placeholder="联系电话"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtAddress" runat="server" type="text" class="form-control" placeholder="联系地址"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:DropDownList ID="Agreer" runat="server" type="text" class="form-control" placeholder="所属部门"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtIntro" runat="server" type="text" class="form-control" placeholder="个人简介"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btn_edit" runat="server" class="btn btn-block btn-primary" OnClick="btn_edit_Click" Text="更新" />
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
