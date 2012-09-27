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
        public DataTable GerenciaSLA(int codigoSLA, double TempoSLA, int acao, String ConnectionString)
        {
            try
            {
                parametros = new List<Parametro>();
                parametros.Add(new Parametro("@CODIGO",codigoSLA));
                parametros.Add(new Parametro("@TEMPOATENDIMENTO",TempoSLA));
                parametros.Add(new Parametro("@ACAO",acao));
                return DAO.Execute(parametros, "SP_Gerencia_SLA", ConnectionString, getTimeOut(acao));

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        #endregion
    }
}

