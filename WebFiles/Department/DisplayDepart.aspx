<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DisplayDepart.aspx.cs" Inherits="WebFiles_Department_View_Depart" %>

<%@ Register Src="/UserControl/Header.ascx" TagName="Header" TagPrefix="uc1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>更新部门信息</title>
</head>
<body>
    <uc1:Header ID="Header2" runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <h1 class="center-block text-center" style="max-width: 400px; position: relative">更新部门信息</h1>
                <form runat="server" method="post" class="form-group">
                    <div class="form-group">
                        <asp:TextBox ID="TxtID" runat="server" type="text" class="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtName" runat="server" type="text" class="form-control" placeholder="部门名称"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtTel" runat="server" type="text" class="form-control" placeholder="联系方式"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtAddress" runat="server" type="text" class="form-control" placeholder="联系地址"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtChief" runat="server" type="text" class="form-control" placeholder="负责人"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtBelong" runat="server" type="text" class="form-control" placeholder="所属部门" Style="display: none"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="Edit" runat="server" class="btn btn-block btn-primary" OnClick="Edit_Click" Text="更新" />
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
