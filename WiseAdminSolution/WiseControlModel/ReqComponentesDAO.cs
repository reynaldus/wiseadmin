using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAOMaster;

namespace WiseControlModel
{
    public class ReqComponentesDAO:DAOMaster.DAOMaster
    {
        #region"Métodos"

        public DataTable GerenciaReqComponentes(int codigoreqcomponentes, int requisito, int componente, int acao, String ConnectionString ) {

            try
            {
                parametros = new List<Parametro>();
                parametros.Add(new Parametro("@CODIGOREQ_COMPONENTES",codigoreqcomponentes));
                parametros.Add(new Parametro("@REQUISITO",requisito));
                parametros.Add(new Parametro("@COMPONENTE", componente));
                parametros.Add(new Parametro("@ACAO",acao));

                return DAO.Execute(parametros, "SP_Gerencia_Req_Componentes", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }


        #endregion
    }
}
