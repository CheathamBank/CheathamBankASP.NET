<%@ Page Title="" Language="C#" MasterPageFile="~/CheathamBank.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CheathamBankASP.NET.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Customer Page -:|:- Cheatham Bank</title>
        <style type="text/css">
        .auto-style1 {
            width: 201px;
        }

        .auto-style2 {
            width: 164px;
        }

        .auto-style3 {
            width: 201px;
            height: 38px;
        }

        .auto-style4 {
            width: 164px;
            height: 38px;
        }

        .auto-style8 {
            height: 38px;
        }

        .auto-style9 {
            width: 100%;
        }

        .jumboOverride {
            padding-top: .5rem;
            padding-bottom: .5em;
            padding-right: .5em;
        }

        .greetingRow {
            padding-bottom: 10px;
        }
        .bigText {
            background-color:blue;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
   <h1 class="text-center">Cheatham Bank & Trust</h1>
    <br />
    <form id="form1" runat="server">
        <div class="container">
            <div class="jumbotron jumboOverride">
                <div class="row greetingRow">
                    <div class="col-sm-6">
                        <asp:Label ID="txtHeader" runat="server" CssClass="h4">Test</asp:Label>
                    </div>
                    <div class="col-sm-6 text-right">
                        <asp:Button ID="btnEdit" runat="server" Height="30px" Text="Edit" Width="53px" CssClass="btn btn-outline-dark btn-sm" OnClick="btnEdit_Click" >
                            
                        </asp:Button>
                    </div>
                </div>
                <table class="auto-style9">
                    <tr>
                        <td class="auto-style3">Username</td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="disabled" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td class="auto-style8"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">First Name</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="txtFname" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Phone Number</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="txtPhoneNumber" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Street</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="txtStreet" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">City</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="txtCity" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">State</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="txtState" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Zip</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="txtZip" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td class="text-right">
                            <asp:LinkButton ID="btnTransaction" runat="server" Text="Transactions &lt;span class=&quot;fa fa-exchange-alt&quot;&gt;&lt;/span&gt;
                            " CssClass="btn btn-info" OnClick="btnTransaction_Click" PostBackUrl="~/transactions.aspx"></asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</asp:Content>
