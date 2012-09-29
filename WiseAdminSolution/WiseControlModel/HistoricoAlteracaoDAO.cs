using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAOMaster;
using WiseControlModel;

namespace WiseControlModel
{
    class HistoricoAlteracaoDAO:DAOMaster.DAOMaster
    {
        #region "Métodos"

        public DataTable GerenciaHistoricoAlteracao(int codigoalter, string alteracao, DateTime dataalt, string motivoalt, int usuariohw, int acao, String ConnectionString) 
        {
            try
            {
             
                parametros = new List<Parametro>();
 
                parametros.Add(new Parametro("@CODIGOALTER", codigoalter));
                parametros.Add(new Parametro("@ALTERACAO", alteracao));
                parametros.Add(new Parametro("@DATAALT", dataalt));
                parametros.Add(new Parametro("@MOTIVOALT", motivoalt));
                parametros.Add(new Parametro("@USUARIO_HW", usuariohw));
                
                
                return DAO.Execute(parametros, "SP_Gerencia_HistoricoAlteracoes", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));


            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        #endregion
    }
}
