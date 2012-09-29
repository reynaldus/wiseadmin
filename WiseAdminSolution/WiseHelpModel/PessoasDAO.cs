using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAOMaster;
namespace WiseHelpModel
{
    public class PessoasDAO:DAOMaster.DAOMaster
    {
        #region "Métodos"
        public DataTable GerenciaPessoas(int codigopessoa, String email, int ramal, DateTime datanasc, String nome, int departamento, int acao,
                                         int tpcadastro, String cargo, String login, String psw, String ConnectionString)
        {
            try
            {
                parametros = new List<Parametro>();
                parametros.Add(new Parametro("@CODIGO",codigopessoa));
                parametros.Add(new Parametro("@EMAIL", email));
                parametros.Add(new Parametro("@RAMAL", ramal));
                parametros.Add(new Parametro("@DTNASC", datanasc));
                parametros.Add(new Parametro("@NOME", nome));
                parametros.Add(new Parametro("@DEPARTAMENTO", departamento));
                parametros.Add(new Parametro("@ACAO", acao));
                parametros.Add(new Parametro("@TPCAD", tpcadastro));
                parametros.Add(new Parametro("@CARGO", cargo));
                parametros.Add(new Parametro("@LOGIN", login));
                parametros.Add(new Parametro("@PSW", psw));
    
                return DAO.Execute(parametros, "SP_Gerencia_Pessoas ", ConnectionString, getTimeOut(acao));

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        #endregion
    }
}
