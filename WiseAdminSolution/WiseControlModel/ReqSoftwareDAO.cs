using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAOMaster;

namespace WiseControlModel
{
  public class ReqSoftwareDAO:DAOMaster.DAOMaster
  {
      #region
      public DataTable GerenciaReqSoftware(int codigoReqSoftware, int configMinima, int sistema, int acao, String ConnectionString){
          try
          {
              parametros = new List<Parametro>();
              parametros.Add(new Parametro("@CODIGOREQ_SOFTWAR",codigoReqSoftware));
              parametros.Add(new Parametro("@CONFIG_MINIMA",configMinima));
              parametros.Add(new Parametro("@SISTEMA",sistema));
              parametros.Add(new Parametro("@ACAO",acao));

              return DAO.Execute(parametros, "SP_Gerencia_Req_Software", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));
          }
          catch (Exception ex)
          {
              
              throw ex;
          }
      

      }

      #endregion
    }
}
