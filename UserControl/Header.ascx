<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Control_WebUserControl" %>

<link rel="stylesheet" href="/css/bootstrap.css">
<script src="/js/jquery-2.1.4.min.js"></script>
<script src="/js/bootstrap.js"></script>
<style>
    #pop_bar {
        position: fixed;
        left: 20px;
        bottom: 15%;
        z-index: 100;
    }

    @media (max-width: 767px) {
        #pop_bar {
            bottom: 20px;
        }
    }

    @media (min-width: 768px) {
        #pop_bar:hover #pop_bar_list {
            display: block;
            margin-left: 0;
            transition: 0.15s;
        }

        #pop_bar:hover #pop_button {
            opacity: 0.8;
            -webkit-transform: rotate(315deg);
            transform: rotate(315deg);
            transition: 0.3s;
            box-shadow: 0 6px 12px rgba(0, 0, 0, 0.175);
        }
    }

    #pop_button {
        width: 48px;
        height: 48px;
        background-color: rgb(50, 118, 177);
        border-radius: 24px;
        opacity: 0.4;
        transition: 0.6s;
        position: relative;
    }

    #pop_bar_list a {
        white-space: inherit;
    }

        #pop_bar_list a b {
            margin-right: 10px;
        }

    #pop_bar_list {
        display: block;
        position: relative;
        bottom: 48px;
        margin-bottom: 10px;
        max-width: 200px;
        margin-left: -400px;
    }

    .open #pop_bar_list {
        display: block;
        margin-left: 0;
    }

    #pop_button {
        display: block;
        position: absolute;
        bottom: 0;
        left: 0;
    }

    .open #pop_button {
        opacity: 0.8;
        -webkit-transform: rotate(315deg);
        transform: rotate(315deg);
        box-shadow: 0 6px 12px rgba(0, 0, 0, 0.175);
    }

    #pop_button:before,
    #pop_button:after {
        content: '';
        position: absolute;
        background-color: #ffffff;
        left: 50%;
        top: 50%;
    }

    #pop_button:before {
        width: 4px;
        height: 36px;
        margin-left: -2px;
        margin-top: -18px;
        border-radius: 2px;
    }

    #pop_button:after {
        width: 36px;
        height: 4px;
        margin-top: -2px;
        margin-left: -18px;
        border-radius: 2px;
    }
</style>

<nav class="navbar navbar-default" style="height: 50px">
    <div class="container-fluid">
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <h3 class="nav navbar-text" style="font-weight: bold;">
                <a href="/WebFiles/Employee/List_employee.aspx?empid="><span class="glyphicon glyphicon-home inline_icon" style="color: black" id="back_icon" title="转到主页"></span></a>&nbsp;欢迎使用人事管理系统
            </h3>
            <div class="navbar navbar-text navbar-right">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;</div>
            <!-- Single button -->
            <div class="btn-group navbar-right">
                <button type="button" class="btn btn-default navbar-btn btn-sm navbar-right dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                    欢迎 &nbsp; <b>
                        <asp:Label ID="lbMessage" runat="server"></asp:Label></b>
                    <span class="caret"></span>
                </button>
                <ul class="dropdown-menu" role="menu">
                    <li><a href="/WebFiles/User/DisplayUser.aspx">个人信息</a></li>
                    <li><a href="/WebFiles/User/SetMessage.aspx">发布公告</a></li>
                    <li><a href="/WebFiles/User/Logout.aspx">退出登录</a></li>
                </ul>
            </div>
            <button type="button" class="btn btn-default btn-sm navbar-right navbar-btn" data-toggle="modal" data-target="#myModal">公告</button>&nbsp&nbsp&nbsp&nbsp;
        </div>
    </div>
</nav>
<div class="modal fade" id="myModal" tabindex="-1">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal"><span>&times;</span></button>
                <h4 class="modal-title" id="myModalLabel">公告</h4>
            </div>
            <div class="modal-body">
                <ul>
                    <%=Message%>
                </ul>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-primary" data-dismiss="modal">关闭</button>
            </div>
        </div>
    </div>
</div>
<div id="pop_bar">
    <ul class="dropdown-menu" id="pop_bar_list">

        <li><a href="/WebFiles/Employee/List_employee.aspx?empid=">员工信息</a></li>
        <!--<td> / </td>-->

        <li><a href="/WebFiles/Department/List_Depart.aspx?depid=">部门信息</a></li>
        <!--<td> / </td>-->

        <li><a href="/WebFiles/Wage/List_Wage.aspx?empid=">工资管理</a></li>
        <!--<td> / </td>-->

        <li><a href="/WebFiles/Employee/Add_employee.aspx">添加员工</a></li>
        <!--<td> / </td>-->

        <li><a href="/WebFiles/Department/Add_Depart.aspx">添加部门</a></li>
        <!--<td> / </td>-->

        <li><a href="/WebFiles/Wage/Add_Wage.aspx">添加工资</a></li>
        <!--<td> / </td>-->

        <li role="presentation" class="divider"></li>
        <li><a href="/WebFiles/User/DisplayUser.aspx">个人信息</a></li>
        <li><a href="/WebFiles/User/SetMessage.aspx">发布公告</a></li>
        <li><a href="/WebFiles/User/Logout.aspx">退出登录</a></li>

    </ul>
    <a class="dropdown-toggle" id="pop_button" data-toggle="dropdown" href="#">
        <div></div>
    </a>
    <iframe id="tmp_downloadhelper_iframe" style="display: none;"></iframe>
</div>
