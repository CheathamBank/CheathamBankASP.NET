using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheathamBankASP.NET
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private int custIDSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CustID"] == null)
                {
                    Response.Redirect("login.aspx");
                }
            }
            custIDSession = (int)Session["CustID"];
        }

        protected void TransactionDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void btnAddTransaction_Click(object sender, EventArgs e)
        {
            decimal decDeposit;
            if (decimal.TryParse(txtAddTransAmount.Text, out decDeposit))
            {
                Objects.Deposit newDeposit = new Objects.Deposit();
                Random num = new Random();

                newDeposit.Amount = decDeposit;
                newDeposit.TransNumber = (num.Next(1, 100600) * num.Next(1000, 10900));
                newDeposit.CustAccountNumber = (int)Session["CustID"];
                newDeposit.Date = DateTime.Today;
                newDeposit.TransType = "deposit";

                if (Tools.CheathamCustomerDB.AddDeposit(newDeposit))
                {
                    lblAlert.Text = "Success";
                    lblAlert.CssClass = "alert alert-success";
                    gvTransactions.DataBind();
                }
                else
                {
                    lblAlert.Text = "Could not add desposit";
                    lblAlert.CssClass = "alert alert-danger";
                }
            }
            else // Invalid Data
            {
                lblAlert.Text = "Invalid amount.";
                lblAlert.CssClass = "alert alert-warning";
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int monthID = DropDownList1.SelectedIndex;
            
            if (monthID > 0) //if 0, - Select Month - is selected
            {

                DataTable dt;
                dt = Tools.CheathamCustomerDB.GetTransactions(monthID.ToString(), custIDSession);


                if (dt != null)
                {
                    gvTransactions.DataSourceID = "";//original data source 
                    gvTransactions.DataSource = dt;//new data source via ADO.NET
                    gvTransactions.DataBind();//refreshes gridview after changing source
                    lblAlert.CssClass = "";
                    lblAlert.Text = "";
                }
                else
                {
                    gvTransactions.DataSourceID = "";
                    gvTransactions.DataSource = null;
                    gvTransactions.DataBind();
                    lblAlert.CssClass = "alert alert-warning";
                    lblAlert.Text = "No transactions found";
                }
            }
            else if(monthID == 0)//Reset to view all transactions
            {
                Response.Redirect("transactions.aspx");
            }




        }
    }
}