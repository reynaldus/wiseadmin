using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAOMaster;
    
namespace WiseControlModel
{
   public class ComponentesDAO:DAOMaster.DAOMaster
    {
        #region"Métodos"
        public DataTable GerenciaComponentes(int codigocomp, string descrcomp, string descrmodel, string nometpcomp, int acao, String ConnectionString) {

            try
            {
                parametros = new List<Parametro>();
                parametros.Add(new Parametro("@CODIGOCOMP",codigocomp));
                parametros.Add(new Parametro("@DESCRCOMP", descrcomp));
                parametros.Add(new Parametro("@DESCRMODEL",descrmodel));
                parametros.Add(new Parametro("@NOMETPCOMP",nometpcomp));
                parametros.Add(new Parametro("@ACAO",acao));

                return DAO.Execute(parametros, "SP_Gerencia_Componentes", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));


            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }    
        #endregion
    }
}
