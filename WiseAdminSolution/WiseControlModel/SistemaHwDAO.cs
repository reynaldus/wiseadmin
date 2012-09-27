using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAOMaster;


namespace WiseControlModel
{
    public class SistemaHwDAO:DAOMaster.DAOMaster
    {
        #region "Métodos"

        public DataTable GerenciaSistemaHW(int codigosistemahw, int hardware, int software, int acao, String ConnectionString)
        {

            try
            {
                parametros = new List<Parametro>();
                parametros.Add(new Parametro("@CODIGOSISTEMAHW", codigosistemahw));
                parametros.Add(new Parametro("@HARDWARE", hardware));
                parametros.Add(new Parametro("@SOFTWARE", software));
                parametros.Add(new Parametro("@ACAO", acao));


                return DAO.Execute(parametros, "SP_Gerencia_Sistema_HW", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        #endregion
    }
}
