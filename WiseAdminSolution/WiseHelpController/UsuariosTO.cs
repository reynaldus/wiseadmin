using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WiseHelpModel;
using ControllerMaster;

namespace WiseHelpController
{
    public class UsuariosTO : PessoasTO
    {
        #region "Atributos"
        private int _codigousuario;
        private String _login;
        private String _psw;
        private UsuariosDAO _dao;
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
        public String Psw
        {
            get { return this._psw; }
            set { this._psw = value; }
        }
        #endregion
        
        #region "Métodos"
        private List<Object> GerenciaUsuarios(int acao, String ConnectionString)
        {
            try
            {
                lista_dados = new List<object>();
                dt = new DataTable();
                dt = _dao.GerenciaUsuarios(this.CodigoUsuario, this.Login, this.Psw, this.Codigo, acao, ConnectionString);
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
                                UsuariosTO item = new UsuariosTO(false, false, true);
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

        #endregion

        #region "Construtores"

        public UsuariosTO(bool instanciausuario, bool instanciapessoa, bool instanciadependentes)
            : base( instanciapessoa, instanciadependentes)
        {
            if (instanciausuario)
            {
                this._dao = new UsuariosDAO();
            }

        }

        #endregion
    }
}
