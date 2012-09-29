using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WiseHelpModel;
using ControllerMaster;
namespace WiseHelpController
{
    public class AnalistasTO : PessoaTO
    {
        #region "Atributos"
        private int _codigoanalista;
        private String _cargo;
        private AnalistasDAO _analistadao;
        #endregion
        #region "GETTERS E SETTERS"
        public int CodigoAnalista
        {
            get { return this._codigoanalista; }
            set { this._codigoanalista = value; }
        }
        public String Cargo
        {
            get { return this._cargo; }
            set { this._cargo = value; }
        }
        #endregion
        #region "Métodos"
        public List<object> GerenciaAnalistas(int acao, String ConnectionString)
        {
            try
            {
                dt = new DataTable();
                lista_dados = new List<object>();
                dt = _analistadao.GerenciaAnalistas(this.CodigoAnalista, this.Cargo, this.Codigo, acao, ConnectionString);
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
                                AnalistasTO item = new AnalistasTO(false, false, true);
                                item.Codigo = int.Parse(dt.Rows[x]["CODIGOUSUARIO"].ToString());
                                item.Cargo = dt.Rows[x]["CARGO"].ToString();
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
        public AnalistasTO(bool ConBDAnalista, bool ConBDPessoa, bool instanciaoutros)
            : base(ConBDPessoa, instanciaoutros)
        {
            if (ConBDAnalista)
            {
                this._analistadao = new AnalistasDAO();
            }
        }
        #endregion

    }
}
