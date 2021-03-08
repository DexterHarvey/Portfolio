using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPRG214.FormsLab.Data;
using CPRG214.FormsLab.App;

namespace CPRG214.FormsLab.App.Controls
{
    public partial class Docks : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = new MarinaManager();
            var docks = manager.GetDocks();
            ddlDocks.DataSource = docks;
            ddlDocks.DataBind();
        }

    }
}