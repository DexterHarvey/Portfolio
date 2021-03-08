using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPRG214.FormsLab.Data;
using System.Web.Security;

namespace CPRG214.FormsLab.App
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Context.User.Identity.IsAuthenticated)
                {
                    lblError.Visible = false;
                    loginTable.Visible = true;
                    registerTable.Visible = false;
                    btnSubmit.Visible = false;
                    btnLogOut.Visible = true;
                }
                else
                {
                    lblError.Visible = false;
                    registerTable.Visible = true;
                    btnSubmit.Visible = true;
                    btnLogOut.Visible = false;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var authManager = new AuthenticationManager();
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            if (authManager.IsNotNull(firstName, lastName))
            {
                var customer = AuthenticationManager.Authenticate(txtFirstName.Text, txtLastName.Text);
                Session.Add("Customer", customer);
                FormsAuthentication.RedirectFromLoginPage(customer.FirstName, false);
            }
            else
            {
                lblError.Text = "Invalid credentials. Please try again.";
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Response.Redirect("~/Home");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

        }
    }
}