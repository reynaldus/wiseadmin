using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAOMaster;

namespace WiseControlModel
{
   public class ApontamentosHwDAO:DAOMaster.DAOMaster
    {
        #region"métodos"
        public DataTable GerenciaApontamentosHW(int codigoApontHw, int apontamento, int hw, int acao, string ConectionString)
        {
            try
            {
                parametros = new List<Parametro>();
                parametros.Add(new Parametro("@CODIGOAPONTHW", codigoApontHw));
                parametros.Add(new Parametro("@APONTAMENTO", apontamento));
                parametros.Add(new Parametro("@HW", hw));
                parametros.Add(new Parametro("@ACAO",acao));

                return DAO.Execute(parametros, "SP_Gerencia_Apontamentos_HW", ConectionString, DAOMaster.DAOMaster.getTimeOut(acao));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        #endregion
    }
    
}