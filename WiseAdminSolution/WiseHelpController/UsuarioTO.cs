using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WiseHelpModel;
using ControllerMaster;

namespace WiseHelpController
{
    public class UsuarioTO:PessoaTO
    {
        #region "Atributos"
        private int _codigousuario;
        private String _login;
        private String _psw;
        private UsuarioDAO _daouser;

        #endregion
        #region "GETTERS E SETTERS"
        public int CodigoUsuario
        {
            get { return this._codigousuario; }
            set { this._codigousuario = value; }
        }
        public String Login
        {
            get { return this._login; }
            set { this._login = value; }
        }
        public String Psw {
            get { return this._psw; }
            set { this._psw = value; }       
        }

        #endregion
        #region "Métodos"
        public List<object> GerenciaUsuarios(int acao, String ConnectionString)
        {
            try
            {
                lista_dados = new List<object>();
                dt = new DataTable();
                dt = _daouser.GerenciaUsuarios(this.CodigoUsuario, this.Login, this.Psw, this.Codigo, acao, ConnectionString);
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
                                UsuarioTO item = new UsuarioTO(false, false, true);
                                item.Codigo = int.Parse(dt.Rows[x]["CODIGOUSUARIO"].ToString());
                                item.Login = dt.Rows[x]["LOGIN"].ToString();
                                item.Nome = dt.Rows[x]["NOME"].ToString();
                                item.Email = dt.Rows[x]["EMAIL"].ToString();
                                item.Ramal = int.Parse(dt.Rows[x]["RAMAL"].ToString());
                                item.DataNascimento = DateTime.Parse(dt.Rows[x]["DTNASC"].ToString());
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
        public String Logar(String ConnectionString)
        {
            try
            {
                dt = new DataTable();
                dt = this._daouser.LogarUsuario(this.Login, this.Psw, ConnectionString);
                if (!(dt == null))
                {
                    if (dt.Rows.Count > 0)
                    {
                        return dt.Rows[0][0].ToString();
                    }

                }
                else
                {
                    return "Não Logado!";
                }
                return "Não Logado";
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
               
        #endregion

        #region "Construtores"
        public UsuarioTO(bool instanciausuario, bool instanciapessoa, bool instanciadependentes)
            : base(instanciapessoa, instanciadependentes)
        {
            if (instanciausuario)
            {
                this._daouser = new UsuarioDAO();
            }
        
        }
        public UsuarioTO(bool instanciausuario, bool instanciapessoa, bool instanciadependentes, String Usuario, String Senha)
            :base(instanciapessoa,instanciadependentes)
        {
            if (instanciausuario)
            {
                this._daouser = new UsuarioDAO();
            }
            this.Login = Usuario;
            this.Psw = Senha;
        }
        #endregion
    }
}
