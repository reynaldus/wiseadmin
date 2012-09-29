using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAOMaster;

namespace WiseControlModel
{
    public class ApontamentosDAO:DAOMaster.DAOMaster
    {
        #region "Métodos"
        public DataTable GerenciaApontamentos(int codigo, string descr, string dtapontamento, int ocorrencia, int analista, int acao, String ConnectionString) 
        {
            try
            {
                parametros = new List<Parametro>();
                    
                parametros.Add(new Parametro("@DESCR", descr));
                parametros.Add(new Parametro("@DTAPONTAMENTO", dtapontamento));
                parametros.Add(new Parametro("@OCORRENCIA", ocorrencia));
                parametros.Add(new Parametro("@ANALISTA", analista));
                parametros.Add(new Parametro("@ACAO", acao));

                return DAO.Execute(parametros, "SP_Gerencia_Apontamentos", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));
                
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        #endregion
    }
}
    