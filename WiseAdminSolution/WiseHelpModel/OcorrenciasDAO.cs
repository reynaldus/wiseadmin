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
    public class OcorrenciasDAO:DAOMaster.DAOMaster
    {
        #region "Métodos"
        public DataTable GerenciaOcorrencias(int codigo, string descr, DateTime dtabertura, DateTime dtend,
            string contato, int status, int problema,int usuario, int acao, String ConnectionString)
        {
            try
            {
                parametros = new List<Parametro>();
                parametros.Add(new Parametro("@CODIGO", codigo));
                parametros.Add(new Parametro("@DESCR", descr));
                parametros.Add(new Parametro("@DTABERTURA", dtabertura));
                parametros.Add(new Parametro("@DTEND",dtend));
                parametros.Add(new Parametro("@CONTATO", contato));
                parametros.Add(new Parametro("@STATUS", status));
                parametros.Add(new Parametro("@PROBLEMA", problema));
                parametros.Add(new Parametro("@USUARIO", usuario));

                return DAO.Execute(parametros, "SP_Gerencia_Ocorrencias", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));



            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        #endregion
    }
}
