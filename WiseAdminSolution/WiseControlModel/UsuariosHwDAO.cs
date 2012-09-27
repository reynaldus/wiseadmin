using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAOMaster;

namespace WiseControlModel
{
   public class UsuariosHwDAO:DAOMaster.DAOMaster
   {
       #region "Métodos"

       public DataTable GerenciaUsuariosHW(int codigoAtivos, int usuario, int ativoHw, int acao, String ConnectionString ) {
           try
           {
               parametros = new List<Parametro>();
               parametros.Add(new Parametro("@CODIGOATIVOS",codigoAtivos));
               parametros.Add(new Parametro("@USUARIO",usuario));
               parametros.Add(new Parametro("@ATIVOHW",ativoHw));
               parametros.Add(new Parametro("@ACAO",acao));

               return DAO.Execute(parametros, "SP_Gerencia_Usuarios_HW", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));
           }
           catch (Exception ex)
           {
               
               throw ex;
           }
       
       } 


       #endregion
   }
}
