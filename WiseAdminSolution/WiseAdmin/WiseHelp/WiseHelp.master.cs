using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WiseAdmin.WiseHelp
{
    public partial class WiseHelp : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) {

                Response.Redirect("../Default.aspx");
                

            }
            else
            {
                Master.CssClassChange("wisehelp");
                Master.CaminhoWiseHelp = "Default.aspx";
                Master.CaminhoWiseChat = "../WiseChat/";
                Master.CaminhoWiseControl = "../WiseControl/";
                Master.CaminhoWiseRemote = "../WiseRemote/";
                Master.CaminhoWiseAdmin = "../Default.aspx";
                Master.CaminhoLogOut = "../LogOut.aspx";
            }
        }
    }
}