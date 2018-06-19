<%@ Page Title="" Language="C#" MasterPageFile="~/CheathamBank.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CheathamBankASP.NET.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login -:|:- Cheatham Bank</title>
    <style type="text/css">
        .auto-style1 {
            height: 32px;
        }

        .auto-style2 {
            width: 453px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <h2 class="text-center">Customer Login</h2>
            <div class="jumbotron">
            <div class="col-12">
                <table class="w-100">
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2 text-right" style="padding-right: 2em;">Username</td>
                        <td class="auto-style1">
                            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2 text-right" style="padding-right: 2em;">Password</td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td></td>
                    </tr>
                </table>
                <div class="row">
                    <div class="col-md-1 offset-7">
                        <asp:LinkButton ID="btnLogin" runat="server" CssClass="btn btn-outline-primary" Width="72px" OnClick="btnLogin_Click">Login
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
            </div>
        </div>

    </form>

</asp:Content>
