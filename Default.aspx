<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE HTML>
<html>
<head runat="server">
    <title>欢迎使用</title>
    <link rel="stylesheet" href="./css/bootstrap.css">
    <script src="./js/jquery-2.1.4.min.js"></script>
    <script src="./js/bootstrap.js"></script>
</head>

<body>

    <nav class="navbar navbar-default" style="height: 50px">
        <div class="container-fluid">
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <h3 class="nav navbar-text" style="font-weight: bold;">
                    <a href="/Default.aspx"><span class="glyphicon glyphicon-home inline_icon" style="color: black" id="back_icon" title="欢迎登陆"></span></a>欢迎使用人事管理系统
                </h3>
                <!--button type="button" class="btn btn-default btn-sm navbar-right navbar-btn" data-toggle="modal" data-target="#myModal">提示</!--button-->
            </div>
        </div>
    </nav>
    <div class="modal fade" id="myModal" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span>&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">提示</h4>
                </div>
                <div class="modal-body">
                    
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">关闭</button>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div class="alert alert-danger fade in hide" id="danger-block" role="alert" style="text-align: center">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <asp:Label ID="lbMessage" runat="server"></asp:Label>
                </div>
            </div>
            <div class="col-md-4 col-md-offset-4">
                <h1 class="center-block text-center" style="max-width: 400px; position: relative">请您登陆</h1>
                <div class="form-group">
                    <form id="form1" runat="server" method="post" class="form-group">
                        <div class="form-group">
                            <asp:TextBox ID="TxtUser" runat="server" class="form-control" type="text" name="tid" placeholder="请输入用户名" />
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="TxtPwd" runat="server" class="form-control" type="password" name="password" TextMode="Password" placeholder="请输入密码" />
                        </div>
                        <asp:DropDownList ID="role" runat="server" class="form-control" name="sess">
                            <asp:ListItem Selected="True" Value="30">记住我(默认时间)</asp:ListItem>
                            <asp:ListItem Value="60">1小时</asp:ListItem>
                            <asp:ListItem Value="120">2小时</asp:ListItem>
                            <asp:ListItem Value="300">5小时</asp:ListItem>
                        </asp:DropDownList><br />
                        <asp:Button ID="Btn_Login" runat="server" class="btn btn-block btn-primary" Text="登录" OnClick="Btn_Login_Click"></asp:Button>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('<%=MessageName%>').removeClass("hide");
        });

    </script>
</body>
</html>
