using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DAOMaster;

namespace WiseHelpModel
{
    public class SlaDAO:DAOMaster.DAOMaster
    {
        #region "Métodos"
        public DataTable GerenciaSLA(int codigosla, double temposla, int acao, String ConnectionString)
        {
            try
            {
                parametros = new List<Parametro>();
                parametros.Add(new Parametro("@CODIGO",codigosla));
                parametros.Add(new Parametro("@TEMPOATENDIMENTO",temposla));
                parametros.Add(new Parametro("@ACAO",acao));
                
                return DAO.Execute(parametros, "SP_Gerencia_SLA", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        #endregion
    }
}

