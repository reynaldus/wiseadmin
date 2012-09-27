using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAOMaster;

namespace WiseControlModel
{
    public class MarcasDAO:DAOMaster.DAOMaster
    {
        #region "Métodos"

        public DataTable GerenciaMarcas(int codigoMarca, string eMailSuporte, string nomeMarca, int acao, String ConnectionString) {
            try
            {
                parametros = new List<Parametro>();
                parametros.Add(new Parametro("@CODIGOMARCA", codigoMarca));
                parametros.Add(new Parametro("@EMAILSUPORTE", eMailSuporte));
                parametros.Add(new Parametro("@NOMEMARCA", nomeMarca));
                parametros.Add(new Parametro("@ACAO", acao));

                return DAO.Execute(parametros, "SP_Gerencia_Marcas", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        
        }
        #endregion
    }
}
