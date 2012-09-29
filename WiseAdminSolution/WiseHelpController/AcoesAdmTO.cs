using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WiseHelpModel;
using System.Data;
using ControllerMaster;
namespace WiseHelpController
{
    public class AcoesAdmTO : ControllerMaster.ControllerMaster
    {
        #region "Atributos"
        /// <summary>
        /// Todo Atributo private deve ter todas as letras 
        /// minusculas e começar com _
        /// 
        /// </summary>
        private int _codigo;
        private String _descricao;

        private AcoesAdmDAO _dao;
        
        #endregion
        #region "GETTERS E SETTERS"
        public int Codigo
        {
            get { return this._codigo; }
            set { this._codigo = value; }
        }
        public String Descricao
        {
            get { return this._descricao; }
            set { this._descricao = value; }
        }

        #endregion
        #region "Métodos"
        public List<Object> gerenciaAcoesAdmTO(int acao, String ConnectionString)
        {
            try
            {
                //INSTANCIA LISTA DE OBJETOS PARA RETORNO
                lista_dados = new List<object>();

                //INSTANCIA DATATABLE QUE RECEBERÁ DADOS DA DAO
                dt = new System.Data.DataTable();

                //BUSCO DADOS NA DAO
                dt = _dao.GerenciaAcoesAdm(this._codigo, this._descricao, acao, ConnectionString);

                //VERIFICO SE NÃO VOLTOU NULO
                if (!(dt == null))
                {
                    // VERIFICO SE REGISTROS SÃO MAIORES que 0(ZERO)
                    if (dt.Rows.Count > 0)
                    {
                        //VERIFICO SE ação é diferente de 2 - Leitura
                        if (acao != 2)
                        {
                            //Adiciono mensagem de retorno para aplicação
                            lista_dados.Add(dt.Rows[0][0].ToString());
                        }
                        //SE ação for igual a 2 efetuar leitura de dados
                        else
                        {
                            //
                            for (int x = 0; x < dt.Rows.Count; x++)
                            {
                                AcoesAdmTO item = new AcoesAdmTO(false);
                                item.Codigo = int.Parse(dt.Rows[x]["CODIGO"].ToString());
                                item.Descricao = dt.Rows[x]["DESCR"].ToString();
                                lista_dados.Add(item);
                            }
                        }
                    }
                }
                return lista_dados;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
        #region "Construtores"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conbd"> 
        /// Se verdadeiro inicia objeto de comunicação com DAO
        ///  </param>
        public AcoesAdmTO(bool conbd)
        {
            try
            {
                if (conbd)
                {
                    this._dao = new AcoesAdmDAO();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
