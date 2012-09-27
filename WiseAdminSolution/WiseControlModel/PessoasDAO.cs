using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAOMaster;

namespace WiseControlModel
{
   public class PessoasDAO:DAOMaster.DAOMaster
    {
        #region"Métodos"

        public DataTable GerenciaPessoas(int codigo, string eMail, int ramal, string dtNasc, string nome, int departamento, int acao, int tpcad, string cargo,string login, string psw, string ConnectionString) {

            try
            {
                parametros = new List<Parametro>();
                parametros.Add(new Parametro("@CODIGO", codigo));
                parametros.Add(new Parametro("@EMAIL",eMail));
                parametros.Add(new Parametro("@RAMAL", ramal));
                parametros.Add(new Parametro("@DTNASC", dtNasc));
                parametros.Add(new Parametro("@NOME", nome));
                parametros.Add(new Parametro("@DEPARTAMENTO", departamento));
                parametros.Add(new Parametro("@ACAO", acao));
                parametros.Add(new Parametro("@TPCAD",tpcad));
                parametros.Add(new Parametro("@CARGO",cargo));
                parametros.Add(new Parametro("@LOGIN", login));
                parametros.Add(new Parametro("@PSW", psw));


                return DAO.Execute(parametros, "SP_Gerencia_Pessoas", ConnectionString, DAOMaster.DAOMaster.getTimeOut(acao));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        #endregion
    }
}
