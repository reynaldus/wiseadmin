using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAOMaster;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WiseHelpModel
{
    public class AnalistasDAO:DAOMaster.DAOMaster
    {
        #region "Métodos"
        public DataTable GerenciaAnalistas(int codigoanalista, String cargo, int codigopessoa, int acao, String ConnectionString)
        {
            try
            {
                parametros = new List<Parametro>();
                parametros.Add(new Parametro("@CODIGO", codigoanalista));
                parametros.Add(new Parametro("@CARGO", cargo));
                parametros.Add(new Parametro("@PESSOA", codigopessoa));
                parametros.Add(new Parametro("@ACAO", acao));
                
                return DAO.Execute(parametros, "SP_Gerencia_Analistas ", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}
