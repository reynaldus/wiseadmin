using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAOMaster;

namespace WiseControlModel
{
    public class TipoComponentesDAO:DAOMaster.DAOMaster
    {
        #region"Métodos"
        public DataTable GerenciaTipoComponentes(int codigoTpComp, string nomeTpComp, int acao, string ConnectionString){
 
        try 
	{
	    parametros = new List<Parametro>();
        parametros.Add(new Parametro("@CODIGOTPCOMP", codigoTpComp));
        parametros.Add(new Parametro("@NOMETPCOMP", nomeTpComp));
        parametros.Add(new Parametro("@ACAO",acao));

        return DAO.Execute(parametros, "SP_Gerencia_Tipo_Componentes", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao)); 
                 
	}
	catch (Exception ex)
	{
		
		throw ex;
	}   
        
    }    
        #endregion
    }
}
