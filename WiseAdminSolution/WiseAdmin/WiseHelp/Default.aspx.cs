using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WiseAdmin.WiseHelp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WiseHelp wp = (WiseHelp)Master;
            if (Session["User"] == null)
            {
                
                Response.Redirect("../Default.aspx");
            }


        }
    }
}