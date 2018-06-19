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
                    <div class="col-sm-3" style="text-align: right">
                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="Months" DataTextField="monthName" DataValueField="monthName" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="Months" runat="server" ConnectionString="<%$ ConnectionStrings:CheathamCustomer %>" SelectCommand="SELECT [monthName] FROM [Months]"></asp:SqlDataSource>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12 text-center">
                        <asp:GridView ID="gvTransactions" runat="server" Width="549px" CssClass="table"
                            AutoGenerateColumns="False" DataKeyNames="CustAccountNumber" DataSourceID="TransactionDataSource">
                            <Columns>
                                <asp:BoundField DataField="TransactionNumber" HeaderText="Transaction Number" ReadOnly="true" />
                                <asp:BoundField DataField="CustAccountNumber" HeaderText="Account Number" ReadOnly="true" />
                                <asp:BoundField DataField="TransactionType" HeaderText="Type" ReadOnly="true" />
                                <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="true" />
                                <asp:BoundField DataField="TransactionAmount" HeaderText="Amount" ReadOnly="true" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="TransactionDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:CheathamCustomer %>"
                            SelectCommand="SELECT * FROM [Transaction] WHERE ([CustAccountNumber] = @CustAccountNumber) ORDER BY [Date] DESC">

                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="null" Name="CustAccountNumber" SessionField="CustID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
            </div>
        <!-- Modal -->
        <div class="modal fade" id="DepositModal" tabindex="-1" role="dialog" aria-labelledby="DepositModal" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">New Deposit</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <h6 style="padding-right:5px; padding-left:25px; padding-top:5px">Deposit Amount</h6>
                            <asp:TextBox ID="txtAddTransAmount" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnAddTransaction" runat="server" Text="Submit" OnClick="btnAddTransaction_Click" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
        </div>
    <!-- Button trigger modal -->
    <div class="container text-right">
                        <asp:Label ID="lblAlert" runat="server" Text=""></asp:Label>
    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#DepositModal">
        Make Deposit
    </button>
    </div>
    </form>
    </asp:Content>
