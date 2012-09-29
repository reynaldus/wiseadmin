using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DAOMaster;

namespace WiseChatModel
{
    public class AnexosDAO:DAOMaster.DAOMaster
    {
        #region "Métodos"
        
        public DataTable GerenciaAnexosDAO(String ConnectionString, int acao)
        {
            try
            {
                parametros = new List<Parametro>();
                parametros.Add(new Parametro("",));

                return DAO.Execute(parametros, "SP_GERENCIA_ANEXOS", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        #endregion
    }
}
