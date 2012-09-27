using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Misc;
using ControllerMaster;
using WiseHelpController;
using System.Web.Services;

namespace WiseAdmin.handlers
{
    /// <summary>
    /// Handler Gerenciador do LOGON
    /// </summary>
    public class Logon : IHttpHandler
    {
        #region "Process Request"
        public void ProcessRequest(HttpContext context)
        {
            String requisicao = context.Request["funcao"];
            int codreq = Misc.Misc.GetFuncaoLogon(requisicao);
            JavaScriptSerializer js = new JavaScriptSerializer();
            switch (codreq)
            {
                case 1:
                     String ret = Logar(context.Request["user"],context.Request["psw"]);
                     context.Response.Write(js.Serialize(ret));
                    break;
                    
               

            }
            
        }
        #endregion
        #region "Métodos"
        public String Logar(String usuario, String password)
        {
            try
            {
                UsuarioTO user = new UsuarioTO(true, true, true, usuario, password);
                String retorno = user.Logar(classes.Worker.getConnectionString());
                return retorno;
                
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }


        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}