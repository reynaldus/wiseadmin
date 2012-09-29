using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAOMaster;

namespace WiseControlModel
{
   public class CategoriasSwDAO:DAOMaster.DAOMaster
    {
        #region "Métodos"
    
        public DataTable GerenciaCategoriasSW(int codigocatsw, int nomecatsw, int acao, String ConnectionString)
        {
            try
            {
 
            parametros = new List<Parametro>();
            parametros.Add(new Parametro("@CODIGOCATSW",codigocatsw));
            parametros.Add(new Parametro("@NOMECATSW", nomecatsw));
            parametros.Add(new Parametro("@ACAO",acao));

            return DAO.Execute(parametros, "SP_Gerencia_Categorias_SW", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }


        }
        #endregion
    }
}
