using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPRG214.FormsLab.Data;

namespace CPRG214.FormsLab.App.Controls
{
    public partial class Registration : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            MarinaManager manager = new MarinaManager();
            Customer cust;
            cust = new Customer
            {
                    FirstName = txtRegFName.Text,
                    LastName = txtRegLName.Text,
                    Phone = txtRegPhone.Text,
                    City = txtRegCity.Text
            };
            if(!manager.RegisterUser(cust))
            {
                lblError.Visible = true;
            }
            else
            {
                lblError.Visible = false;
            }
            
        }
    }
}