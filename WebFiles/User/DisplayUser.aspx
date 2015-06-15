<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DisplayUser.aspx.cs" Inherits="WebFiles_User_User_view" %>

<%@ Register Src="/UserControl/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>用户信息</title>
</head>
<body>
    <uc1:Header ID="Header1" runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <form class="form-horizontal panel-body" method="post" runat="server">
                    <div class="panel panel-default">
                        <div class="panel-heading">基本设置</div>
                        <br />
                        <div class="form-group">
                            <label class="col-sm-3 control-label">用户名</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="TxtUserID" class="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label">姓名</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="TxtUserName" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-4"></div>
                            <div class="control-label col-sm-4">
                                <asp:Button class="btn btn-default btn-block" ID="Edit" runat="server" OnClick="Edit_Click" Text="修改"></asp:Button>
                            </div>
                            <div class="col-sm-4"></div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" href="#collapse_change_pass" class="collapsed">修改密码 </a>
                            </h4>
                        </div>
                        <div class="panel-collapse collapse" id="collapse_change_pass">
                            <br />
                            <div class="form-group" runat="server">
                                <label class="col-sm-3 control-label">原始密码</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="TxtPassold" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">新密码</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="TxtPass" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">重复新密码</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="TxtPass1" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-4"></div>
                                <div class="control-label col-sm-4">
                                    <asp:Button ID="but2" runat="server" class="btn btn-default btn-block" OnClick="Click_Change_Pass" Text="修改"></asp:Button>
                                </div>
                                <div class="col-sm-4"></div>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
            <div class="col-md-2"></div>
        </div>
    </div>
</body>
</html>
