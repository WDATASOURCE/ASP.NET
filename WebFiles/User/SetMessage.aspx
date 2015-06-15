<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetMessage.aspx.cs" Inherits="WebFiles_User_SetMessage" %>

<%@ Register Src="/UserControl/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>发布公告</title>
</head>
<body>
    <uc1:Header ID="Header1" runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <h1 class="center-block text-center" style="max-width: 400px; position: relative">发布公告</h1>
                <form id="form1" runat="server" method="post" class="form-group">
                    <div class="form-group">
                        <textarea id="Text1" name="Text1" runat="server" class="form-control" rows="6"></textarea>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btn1" runat="server" class="form-control btn btn-primary" OnClick="Btn_Click" Text="发布"></asp:Button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
