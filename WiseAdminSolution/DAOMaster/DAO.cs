using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DAOMaster
{
    public abstract class DAO
    {
        #region "Atributos"
        /// <summary>
        /// Connection Factory para execução de operações no SGBD
        /// </summary>
        /// <param name="parametros">Lista de Parametros</param>
        /// <param name="ProcedureName">Nome da Procedure</param>
        /// <param name="ConnectionString">String de Conexão</param>
        /// <returns></returns>
        public static DataTable Execute( List<Parametro> parametros,String ProcedureName,String ConnectionString, int TimeOut)
        {
            //Instanciando classe de conexão
            SqlConnection con = new SqlConnection() ;
            try
            {
                //Declaração do comando a ser executado
                SqlCommand comando;

                //Declaração do adaptador a ser usado
                SqlDataAdapter adaptador;

                //Declaração e instanciamento do Datatable a ser consumido
                DataTable dt = new DataTable();

                //Reinstanciando Conexão passando a String de Conexão
                con = new SqlConnection(ConnectionString);

                //Abrindo Conexão
                con.Open();

                //Instanciando Comando e enviando nome da procedure e Connection
                comando = new SqlCommand(ProcedureName, con);

                //Definindo o comando como Stored Procedure
                comando.CommandType = CommandType.StoredProcedure;

                //Definindo o TimeOut do Comando
                comando.CommandTimeout = TimeOut;
                
                // Verifica se procedure possui parâmetros
                if (parametros.Count > 0)
                {
                    //inicia for para adicionar parâmetros
                    for (int x = 0; x < parametros.Count; x++)
                    {
                        //Adiciona parâmetros ao comando
                        comando.Parameters.AddWithValue(parametros[x].NomeParametro, parametros[x].ParametroValor);
                    }
                }
                
                //Instancia o adaptador e associa o comando a ele
                adaptador = new SqlDataAdapter(comando);
                
                //Executa o adaptador armazenando o resultado do comando na Datatable DT
                adaptador.Fill(dt);
                
                //Fecha Conexão
                con.Close();

                //Retorna Dados
                return dt;

            }
            catch (Exception ex)
            {
                //Lança Exceção
                throw ex;
            }
            finally
            {
                //Se conexão ainda estive ativa e não for nula
                if (!(con == null))
                {
                    //Libera recursos alocados a conexão
                    con.Dispose();
                }
            }

        }
        
        #endregion
    }
}
