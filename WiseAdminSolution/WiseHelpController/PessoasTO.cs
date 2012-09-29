using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ControllerMaster;
using DAOMaster;
using WiseHelpModel;

namespace WiseHelpController
{
    public class PessoasTO : ControllerMaster.ControllerMaster
    {
        #region "Atributos"
        private int _codigo;
        private String _email;
        private int _ramal;
        private DateTime _dataNasc;
        private String _nome;
     
        private DepartamentoTO _departamento;
        private PessoasDAO _dao;
        
        #endregion

        #region "GETTERS E SETTERS"
        public int Codigo
        {
            get { return this._codigo; }
            set { this._codigo = value; }
        }
        public String Email
        {
            get { return this._email; }
            set { this._email = value; }
        }
        public int Ramal
        {
            get { return this._ramal; }
            set { this._ramal = value; }
        }
        public DateTime DataNascimento
        {
            get { return this._dataNasc; }
            set { this._dataNasc = value; }
        }
        public String Nome
        {
            get { return this._nome; }
            set { this._nome = value; }
        }
        public DepartamentoTO Departamento
        {
            get { return this._departamento; }
            set { this._departamento = value; }
        }

        #endregion
        
        #region "Métodos"

        public List<object> GerenciaPessoasTO(String cargo, String login, String Senha, int acao, int tpcadastro, String ConnectionString)
        {
            try
            {
                lista_dados = new List<object>();
                dt = new DataTable();
                dt = _dao.GerenciaPessoas(this.Codigo, this.Email, this.Ramal, this.DataNascimento, this.Nome, this.Departamento.Codigo, acao, tpcadastro, cargo, login, Senha, ConnectionString);
                if (!(dt == null))
                {

                    if (dt.Rows.Count > 0)
                    {

                        if (acao != 2)
                        {
                            lista_dados.Add(dt.Rows[0][0].ToString());

                        }
                        else
                        {
                            for (int x = 0; x < dt.Rows.Count; x++)
                            {
                                PessoasTO item = new PessoasTO(false, true);
                                item.Codigo = int.Parse(dt.Rows[x]["CODIGO"].ToString());
                                item.Email = dt.Rows[x]["EMAIL"].ToString();
                                item.Ramal = int.Parse(dt.Rows[x]["RAMAL"].ToString());
                                item.DataNascimento = DateTime.Parse(dt.Rows[x]["DTNASC"].ToString());
                                item.Departamento = new DepartamentoTO(false);
                                item.Departamento.Nome = dt.Rows[x]["DEPARTAMENTO"].ToString();
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
        
        public PessoasTO(bool conbd, bool instanciadependentes)
        {
            if (conbd)
            {
                this._dao = new PessoasDAO();
            }
                
            if (instanciadependentes) 
                {
                this._departamento = new DepartamentoTO(false);
                }
         }

        #endregion
    }
}
