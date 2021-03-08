using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPRG214.FormsLab.Data;

namespace CPRG214.FormsLab.App.Controls
{
    public partial class AvailableSlips : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void LoadWithData(int dockID)
        {
            var manager = new MarinaManager();
            var availableSlips = manager.GetAvailableSlips(dockID);
            ddlAvailable.DataSource = availableSlips;
            ddlAvailable.DataBind();
        }
    }
}