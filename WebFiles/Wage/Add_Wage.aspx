<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add_Wage.aspx.cs" Inherits="WebFiles_Wage_Add_Wage" %>

<%@ Register Src="/UserControl/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<!DOCTYPE HTML>
<html>
<head runat="server">
    <title>添加工资信息</title>
</head>
<body>
    <uc1:Header ID="Header1" runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <h1 class="center-block text-center" style="max-width: 400px; position: relative">添加工资信息</h1>
                <form id="form1" runat="server" class="form-horizontal" method="post">
                    <div class="form-group">
                        <asp:DropDownList ID="Agreer" runat="server" type="text" class="form-control" placeholder="员工姓名"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="Day_Wage" runat="server" type="text" class="form-control" placeholder="单日工资"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="Work_Day" runat="server" class="form-control" placeholder="出勤天数"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="Paid_Wage" runat="server" type="text" class="form-control" placeholder="已付工资"></asp:TextBox>
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
