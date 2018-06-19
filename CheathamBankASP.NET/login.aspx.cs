using CheathamBankASP.NET.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheathamBankASP.NET
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Validate if has value
            if (txtUserName.Text !="" && txtPassword.Text !="")
            {
                //Gets custID for username
                int? custIDNull = LoginDB.authenticateUser(txtUserName.Text);

                if (custIDNull != null)//If username exists auth password
                {
                    int custID = (int)custIDNull;
                    if (LoginDB.authenticatePassword(custID, txtPassword.Text))
                    {
                        Session["CustID"] = custID;
                        Response.Redirect("index.aspx");
                    }
                    else
                    {
                        lblStatus.Text = "Invalid password.";
                        lblStatus.CssClass = "alert alert-warning";
                    }
                }
                else
                {
                    lblStatus.Text = "Invalid username";
                    lblStatus.CssClass = "alert alert-warning";
                }
            }
            else
            {
                lblStatus.Text = "Please enter a username and password";
                lblStatus.CssClass = "alert alert-primary";
            }
        }
    }
}