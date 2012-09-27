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
    public class ProblemasDAO:DAOMaster.DAOMaster
    {
        #region "Métodos"

        public DataTable GerenciaProblemas(int codigo, string descr, int sla, int tipoproblema, int acao, String ConnectionString) 
        {
            try
            {
                //INSTANCIA
                parametros = new List<Parametro>();
                //MANEIRA 1 de preencher lista
                parametros.Add(new Parametro("@CODIGO", codigo));
                parametros.Add(new Parametro("@DESCR", descr));
                parametros.Add(new Parametro("@SLA", sla));
                parametros.Add(new Parametro("@TIPOPROBLEMA", tipoproblema));

                /*MANEIRA 2 de preencher lista
                Parametro p = new Parametro("@DESCR", descr);
                parametros.Add(p);
                */

                return  DAO.Execute(parametros, "SP_Gerencia_Problemas", ConnectionString, getTimeOut(acao));
           
                    


            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        #endregion
    }
}
