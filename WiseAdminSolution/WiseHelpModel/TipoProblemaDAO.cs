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
    public class TipoProblemaDAO : DAOMaster.DAOMaster
    {
        #region "Métodos"

        public DataTable GerenciaTipoProblema(int codigo, string descr, int sla, int departamento, int acao, String ConnectionString)
        {
            try 
            	{
	        
                    parametros = new List<Parametro>();
                    parametros.Add(new Parametro("@CODIGO",codigo));
                    parametros.Add(new Parametro("@DESCR", descr));    
                    parametros.Add(new Parametro("@SLA", sla));
                    parametros.Add(new Parametro("@DEPARTAMENTO", departamento));

                    return DAO.Execute(parametros, "SP_Gerencia_TipoProblema", ConnectionString, getTimeOut(acao));    
		
            	}
	        catch (Exception ex)
	            {
		
		        throw ex;
	            }
        }

        #endregion
    }
    }
