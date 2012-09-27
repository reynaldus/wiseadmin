using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Services.Configuration;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using ControllerMaster;
using WiseHelpController;
using WiseAdmin.handlers.classes;
namespace WiseAdmin
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["User"] == null)) { Response.Redirect("Home.aspx"); }
            
        }


        #region "Métodos"
        private void Logar()
        {
            try
            {
                UsuarioTO user = new UsuarioTO(true, true, true);
                user.Login = txtLogin.Text.Trim();
                user.Psw = txtSenha.Text.Trim();
                String retorno = user.Logar(Worker.getConnectionString());
                if (retorno.Equals("S"))
                {
                    Session.Add("User", txtLogin.Text);
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    var idmodal = "#dialog-message";
                    var texto = "Usuário ou senha inválidos!!";
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "erro_msg", "document.getElementById('textoMsg').innerHTML='"+texto.ToString()+"';$('" + idmodal.ToString() + "').dialog('open');", true);
                }

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        #endregion
        #region "Eventos"
        protected void btnLogar_Click(object sender, EventArgs e)
        {
            Logar();
        }
        #endregion
    }
}