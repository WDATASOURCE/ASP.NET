<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DisplayWage.aspx.cs" Inherits="WebFiles_Wage_DisplayWage" %>

<%@ Register Src="/UserControl/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<!DOCTYPE html >

<html>
<head runat="server">
    <title>更新工资信息</title>
</head>

<body>
    <uc1:Header ID="Header1" runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <h1 class="center-block text-center" style="max-width: 400px; position: relative">更新信息</h1>
                <form runat="server" method="post" class="form-group">
                    <div class="form-group">
                        <asp:TextBox ID="TxtID" runat="server" type="text" class="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtName" runat="server" type="text" class="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtWage" runat="server" type="text" class="form-control" placeholder="单日工资"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtDay" runat="server" type="text" class="form-control" placeholder="出勤天数"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtPaid" runat="server" type="text" class="form-control" placeholder="已付工资"></asp:TextBox>
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
