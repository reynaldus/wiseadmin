using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAOMaster;

namespace WiseControlModel
{
   public class ModelosDAO:DAOMaster.DAOMaster
    {
        #region "Métodos"

       public DataTable GerenciaModelos(int codigomodel, string descrmodel, int marca, int acao, String ConnectionString)
       {
           try
           {
               parametros = new List<Parametro>();
               parametros.Add(new Parametro("@CODIGOMODEL", codigomodel));
               parametros.Add(new Parametro("@DESCRMODEL", descrmodel));
               parametros.Add(new Parametro("@MARCA",marca));
               parametros.Add(new Parametro("@ACAO",acao));

               return DAO.Execute(parametros, "SP_Gerencia_Modelos", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));
           }
           catch (Exception ex)
           {
               
               throw ex;
           }
       }
        #endregion
    }
}
