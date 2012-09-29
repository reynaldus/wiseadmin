using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAOMaster;

namespace WiseControlModel
{
    public class TiposDAO:DAOMaster.DAOMaster
    {
        #region "Métodos"

        public DataTable GerenciaTipos(int codigotipo, string descrtipo, int categoria, int acao, String ConnectionString) {
            try
            {
                parametros = new List<Parametro>();
                parametros.Add(new Parametro("@CODIGOTIPO",codigotipo));
                parametros.Add(new Parametro("@DESCRTIPO",descrtipo));
                parametros.Add(new Parametro("@CATEGORIA",categoria));
                parametros.Add(new Parametro("@ACAO",acao));

                return DAO.Execute(parametros, "SP_Gerencia_Tipos", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
 
        
        }
            
        #endregion

    }
}
