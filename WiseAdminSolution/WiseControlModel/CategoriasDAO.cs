    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAOMaster;

namespace WiseControlModel
{
    public class CategoriasDAO:DAOMaster.DAOMaster
    {
        #region " Métodos "
        
        public DataTable GerenciaCategorias(int codCat, string descrCat, int acao, string ConectionString){
            try
            {
                parametros = new List<Parametro>();
                parametros.Add(new Parametro("@CODIGOCAT",codCat));
                parametros.Add(new Parametro("@DESCRCAT",descrCat));
                parametros.Add(new Parametro("@ACAO",acao));

                return DAO.Execute(parametros, "SP_Gerencia_Categorias ",ConectionString, DAOMaster.DAOMaster.getTimeOut(acao));   

            }
            catch (Exception ex)
            {
                
                throw ex;
            }  
        
        }
        #endregion

    }
}
