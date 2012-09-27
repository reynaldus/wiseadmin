using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WiseAdmin
{
    public partial class Default : System.Web.UI.MasterPage
    {
        public String TituloSistema
        {
            get { return lblTitulo.Text; }
            set { lblTitulo.Text = value; }
        }
        public String CaminhoWiseHelp = "WiseHelp/";
        public String CaminhoWiseControl = "WiseControl/";
        public String CaminhoWiseChat = "WiseChat/";
        public String CaminhoWiseRemote = "WiseRemote";
        public String CaminhoLogOut = "Logout.aspx";
        public String CaminhoWiseAdmin = "Default.aspx";
        
        
        public void CssClassChange( String Sistema) {
            try
            {
                if (Sistema.Equals("wisehelp")) { btnWiseHelp.CssClass = "btnPadraoGreen"; }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        
        
        }        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnWiseHelp_Click(object sender, EventArgs e)
        {
            Response.Redirect(CaminhoWiseHelp);
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect(CaminhoLogOut);
        }

        #region "Redirects"

        #endregion
    }
}