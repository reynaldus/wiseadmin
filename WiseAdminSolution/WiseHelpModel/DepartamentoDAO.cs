using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAOMaster;

namespace WiseHelpModel
{
   public class DepartamentoDAO:DAOMaster.DAOMaster
   {
       #region "Métodos"
       public DataTable GerenciaDepartamentos(int codigodepartamento,String email,int ramal,String nome,int acao,String ConnectionString)
       {
           try
           {
               parametros = new List<Parametro>();
               parametros.Add(new Parametro("@CODIGO", codigodepartamento));
               parametros.Add(new Parametro("@EMAIL",email));
               parametros.Add(new Parametro("@RAMAL", ramal));
               parametros.Add(new Parametro("@NOME",nome));
               parametros.Add(new Parametro("@ACAO", acao));
               return DAO.Execute(parametros, "SP_Gerencia_Departamentos ", ConnectionString, getTimeOut(acao));
           }
           catch (Exception ex)
           {
               
               throw ex;
           }
       }

       #endregion
   }
}
