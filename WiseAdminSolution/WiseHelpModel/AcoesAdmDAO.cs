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
   public class AcoesAdmDAO:DAOMaster.DAOMaster
   {
       #region "Métodos"
       public DataTable GerenciaAcoesAdm(int codigoacaoadm, String descricao, int acao, String ConnectionString)
       {
           try
           {
               parametros = new List<Parametro>();
               parametros.Add(new Parametro("@CODIGO", codigoacaoadm));
               parametros.Add(new Parametro("@DESCR",descricao));
               parametros.Add(new Parametro("@ACAO",acao));

               return DAO.Execute(parametros, "SP_Gerencia_AcoesAdm ", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));
           }
           catch (Exception ex)
           {
               
               throw ex;
           }
       }
       #endregion
   }
}
