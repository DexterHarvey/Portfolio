using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPRG214.FormsLab.Data;

namespace CPRG214.FormsLab.App.Controls
{
    public partial class CurrentLeases : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = new MarinaManager();
            var customer = (Customer)Session["Customer"];
            int userID = customer.ID;
            var currentLeases = manager.GetLeasesByCustomer(userID);
            grdLeases.DataSource = currentLeases;
            grdLeases.DataBind();
        }
        public void Refresh()
        {
            var manager = new MarinaManager();
            var customer = (Customer)Session["Customer"];
            int userID = customer.ID;
            var currentLeases = manager.GetLeasesByCustomer(userID);
            grdLeases.DataSource = currentLeases;
            grdLeases.DataBind();
        }

    }
}