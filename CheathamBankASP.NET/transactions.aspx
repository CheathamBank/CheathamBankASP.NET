<%@ Page Title="" Language="C#" MasterPageFile="~/CheathamBank.Master" AutoEventWireup="true" CodeBehind="transactions.aspx.cs" Inherits="CheathamBankASP.NET.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Transactions -:|:- CheathamBank</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1 class="text-center">Transcations</h1>
                </div>
            </div>
            <div class="jumbotron jumboOverride">
                <div class="row">
                </div>
                <div class="row">
                    <div class="col-sm-6">
                    </div>
                    <div class="col-sm-3" style="text-align:right">
                        2
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12" style="background-color: greenyellow">
                        3
                        <asp:GridView ID="GridView1" runat="server" Width="549px" CssClass="">
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
