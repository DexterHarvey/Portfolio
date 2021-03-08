using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPRG214.FormsLab.App
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Context.User.Identity.IsAuthenticated)
            {
                uxWelcome.InnerText = $"Welcome {Context.User.Identity.Name}";
                aReg.Disabled = false;
                aReg.Visible = true;
            }
            else
            {
                uxWelcome.InnerText = "";
                aReg.Disabled = true;
                aReg.Visible = false;
            }
        }
    }
}