using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAOMaster;
namespace WiseHelpModel
{
    public class UsuariosDAO : DAOMaster.DAOMaster
    {
        #region "Métodos"
        public DataTable GerenciaUsuarios(int codigousuario, String login, String psw, int codigopessoa, int acao, String ConnectionString)
        {
            try
            {
                parametros = new List<Parametro>();
                parametros.Add(new Parametro("@CODIGO", codigousuario));
                parametros.Add(new Parametro("@LOGIN", login));
                parametros.Add(new Parametro("@PSW", psw));
                parametros.Add(new Parametro("@PESSOA", codigopessoa));
                parametros.Add(new Parametro("@ACAO", acao));
       
                return DAO.Execute(parametros, "SP_Gerencia_Usuarios ", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}
