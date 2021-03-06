using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPRG214.FormsLab.Data;

namespace CPRG214.FormsLab.App
{
    public partial class AvailableSlips : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var manager = new MarinaManager();
                var docks = manager.GetDocks();
                ddlDocks.DataSource = docks;
                ddlDocks.DataBind();
                var availableSlips = manager.GetAvailableSlipIDs(1);
                ddlAvailable.DataSource = availableSlips;
                ddlAvailable.DataBind();
            }
        }
        protected void DdlDocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            var manager = new MarinaManager();
            int dockID = Convert.ToInt32(ddlDocks.SelectedValue);
            var availableSlips = manager.GetAvailableSlipIDs(dockID);
            ddlAvailable.DataSource = availableSlips;
            ddlAvailable.DataBind();

        }
        protected void ddlAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            var manager = new MarinaManager();
            int slipID = Convert.ToInt32(ddlAvailable.SelectedValue);
            txtLength.Text = Convert.ToString(manager.GetSlipLength(slipID));
            txtWidth.Text = Convert.ToString(manager.GetSlipWidth(slipID));
        }
    }
}