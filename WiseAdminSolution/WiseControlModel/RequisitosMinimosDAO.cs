using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAOMaster;


namespace WiseControlModel
{
    public class RequisitosMinimosDAO:DAOMaster.DAOMaster
    {
        #region"Métodos"
        public DataTable GerenciaRequisitosMinimos(int codigoreq, string componentes, int acao, String ConnectionString) {
            try
            {
            parametros = new List<Parametro>();
            parametros.Add(new Parametro("@CODIGOREQ",codigoreq));
            parametros.Add(new Parametro("@COMPONENTES",componentes ));
            parametros.Add(new Parametro("@ACAO", acao));

            return DAO.Execute(parametros, "SP_Gerencia_Requisitos_Minimos",ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }
        #endregion
    }
}
