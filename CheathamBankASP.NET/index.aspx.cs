using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheathamBankASP.NET
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private List<TextBox> txtBoxes = new List<TextBox>();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtBoxes.Add(txtFname);
            txtBoxes.Add(txtPhoneNumber);
            txtBoxes.Add(txtUsername);
            txtBoxes.Add(txtStreet);
            txtBoxes.Add(txtCity);
            txtBoxes.Add(txtState);
            txtBoxes.Add(txtZip);

            if (!IsPostBack)
            {
                Objects.Customer currentCustomer = new Objects.Customer();
                currentCustomer = Tools.CheathamCustomerDB.GetCustomer("755445");//<------------------------- Replace with session variable

                txtFname.Text = currentCustomer.Name;
                txtPhoneNumber.Text = currentCustomer.PhoneNumber;
                txtUsername.Text = "Replace";
                txtStreet.Text = currentCustomer.Address;
                txtCity.Text = currentCustomer.City;
                txtState.Text = currentCustomer.State;
                txtZip.Text = currentCustomer.Zip.ToString();
                txtHeader.Text = "Welcome, " + currentCustomer.Name + ".";

                Session["Customer"] = currentCustomer;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            this.TextBoxSwitch();
        }

        private void TextBoxSwitch() //Fix this shit
        {
            //If boxes are editable, save the content.
            if (txtFname.ReadOnly == false)
            {
                bool hasValue = true;

                foreach (TextBox textbox in txtBoxes)
                {
                    textbox.ReadOnly = true;
                    if (textbox.Text == "")
                    {
                        hasValue = false;// I have no faith this will actually work... fix later


                    }
                }
                if (hasValue)
                {

                    btnEdit.Text = "Edit";
                    btnEdit.CssClass = "btn btn-outline-dark btn-sm";

                    Objects.Customer updateCustomer = new Objects.Customer();

                    updateCustomer = (Objects.Customer)Session["Customer"];

                    updateCustomer.AccountNumber = 755445;// <------------------------------------Replace with session variable
                    updateCustomer.Name = txtFname.Text;
                    updateCustomer.PhoneNumber = txtPhoneNumber.Text;
                    updateCustomer.Address = txtStreet.Text;
                    updateCustomer.City = txtCity.Text;
                    updateCustomer.State = txtState.Text;
                    updateCustomer.Zip = Convert.ToInt32(txtZip.Text);

                    Session["Customer"] = updateCustomer;

                    bool hasUpdated = false;
                    hasUpdated = Tools.CheathamCustomerDB.UpdateCustomer(updateCustomer);//SQLDB UPDATE

                    if (hasUpdated)
                    {
                        txtHeader.Text = "Welcome, " + updateCustomer.Name + ".";
                        txtHeader.CssClass = "h4";
                    }
                    else
                    {
                        txtHeader.Text = "Database error";
                        txtHeader.CssClass = "alert alert-danger";
                    }


                }
                else
                {
                    this.TextBoxSwitch();
                    txtHeader.Text = "Customer information cannot be empty";
                    txtHeader.CssClass = "alert alert-warning";
                }
            }
            else//Boxes are not editable. Make them editable to update content.
            {

                foreach (TextBox textbox in txtBoxes)
                {
                    textbox.ReadOnly = false;
                }

                btnEdit.Text = "Save";
                btnEdit.CssClass = "btn btn-success btn-sm";

            }

        }

        protected void btnTransaction_Click(object sender, EventArgs e)
        {
            
        }
    }
}