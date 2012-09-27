using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAOMaster;

namespace WiseControlModel
{
    public class DepartamentosDAO:DAOMaster.DAOMaster
    {
        #region"Métodos"
        public DataTable GerenciaDepartamentos(int codigo, string eMail, int ramal, string nome, int acao, String ConectionString) {
            try
            {
                parametros = new List<Parametro>();
                parametros.Add(new Parametro("@CODIGO", codigo));
                parametros.Add(new Parametro("@EMAIL", eMail));
                parametros.Add(new Parametro("@RAMAL", ramal));
                parametros.Add(new Parametro("@NOME", nome));
                parametros.Add(new Parametro("@ACAO", acao));
                return DAO.Execute(parametros, "SP_Gerencia_Departamentos", ConectionString, DAOMaster.DAOMaster.getTimeOut(acao));

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        
        }
                

        #endregion

    }
}
