﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DAOMaster;

namespace WiseHelpModel
{
   public class AcoesSlaDAO:DAOMaster.DAOMaster
   {
       #region "Métodos"
       public DataTable gerenciaAcoesSLA(int codigoacaosla, int codigoacao, int sla, int acao, String ConnectionString)
       {
           try
           {
               parametros = new List<Parametro>();
               parametros.Add(new Parametro("@CODIGO", codigoacaosla));
               parametros.Add(new Parametro("@ACAO", codigoacao));
               parametros.Add(new Parametro("@SLA",sla));
               parametros.Add(new Parametro("@OPCAO", acao));

               return DAO.Execute(parametros, "SP_Gerencia_AcoesSLA", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));
           }
           catch (Exception ex)
           {
               
               throw ex;
           }
       }
       #endregion
   }
}
