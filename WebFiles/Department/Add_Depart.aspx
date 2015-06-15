<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add_Depart.aspx.cs" Inherits="WebFiles_Department_Add_Depart" %>

<%@ Register Src="/UserControl/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<!DOCTYPE html >
<head runat="server">
    <title>添加部门信息</title>
</head>
<body>
    <uc1:Header ID="Header1" runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <h1 class="center-block text-center" style="max-width: 400px; position: relative">添加部门信息</h1>
                <form id="form1" runat="server" method="post">
                    <div class="form-group">
                        <asp:TextBox ID="tb_id" runat="server" type="text" class="form-control" placeholder="部门编号"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="tb_name" runat="server" type="text" class="form-control" placeholder="部门名称"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="tb_tel" runat="server" type="text" class="form-control" placeholder="联系方式"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="tb_address" runat="server" type="text" class="form-control" placeholder="联系地址"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="tb_chief" runat="server" type="text" class="form-control" placeholder="负责人"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="tb_belong" runat="server" type="text" class="form-control" Text="0" Style="display: none"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btn_add" runat="server" class="btn btn-block btn-primary" Text="添加" OnClick="btn_add_Click" />
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>