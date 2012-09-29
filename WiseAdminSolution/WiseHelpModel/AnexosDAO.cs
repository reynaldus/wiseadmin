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
    public class AnexosDAO:DAOMaster.DAOMaster
    {
        #region "Métodos"

        public DataTable GerenciaAnexo(int codigo, String mime, String caminho, int apontamento, int conversa, int acao, String ConnectionString)
        {
            try
            {
                parametros = new List<Parametro>();
                parametros.Add(new Parametro("@CODIGO", codigo));
                parametros.Add(new Parametro("@MIME", mime));
                parametros.Add(new Parametro("@CAMINHO", caminho));
                parametros.Add(new Parametro("@APONTAMENTO", apontamento));
                parametros.Add(new Parametro("@CONVERSA", conversa));
                return DAO.Execute(parametros, "SP_Gerencia_Anexos", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        #endregion
    }
}
