using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAOMaster;


namespace WiseControlModel
{
    public class HardwareDAO:DAOMaster.DAOMaster
    {
        #region "Métodos"

        public DataTable GerenciaHardware(int codigoHw, int tipoHw, int departamento, int modelo, int acao, String ConnectionString)
        {
            try
            {
                parametros = new List<Parametro>();
                parametros.Add(new Parametro("@CODIGOHW", codigoHw));
                parametros.Add(new Parametro("@TIPOHW", tipoHw));
                parametros.Add(new Parametro("@DEPARTAMENTO", departamento));
                parametros.Add(new Parametro("@MODELO", modelo));
                parametros.Add(new Parametro("@ACAO", acao));

                return DAO.Execute(parametros, "SP_Gerencia_Hardware", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }
        #endregion
    }
}
