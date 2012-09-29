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
    public class StatusDAO:DAOMaster.DAOMaster
    {
        #region "Métodos"
        public DataTable GerenciaStatus(int codigo, String descr, int acao, String ConnectionString)
        {
            try
            {
                parametros = new List<Parametro>();
                parametros.Add(new Parametro("@CODIGO", codigo));
                parametros.Add(new Parametro("@DESCR", descr));

                return DAO.Execute(parametros, "SP_Gerencia_Status", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }
        #endregion
    }
}
