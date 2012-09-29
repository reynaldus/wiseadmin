using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAOMaster;
using ControllerMaster;
using WiseHelpModel;

namespace WiseHelpController
{
    public class AnexosTO:ControllerMaster.ControllerMaster
    {
        #region "Atributos"

        private int _codigo;
        private String _mime;
        private String _caminho;
        private int _apontamento;
        private int _conversa;

        private AnexosDAO _dao;
        
        #endregion

        #region "GETTERS E SETTERS"

        public int Codigo
        {
            get { return this._codigo; }
            set { this._codigo = value; }
        }

        public String Mime
        {
            get { return this._mime; }
            set { this._mime = value; }

        }

        public String Caminho
        {
            get { return this._caminho; }
            set { this._caminho = value; }
        }

        public int Apontamento
        {
            get { return this._apontamento; }
            set { this._apontamento = value; }

        }

        public int Conversa
        {
            get { return this._conversa; }
            set { this._conversa = value; }

        }

        #endregion

        #region "Métodos"

        public List<Object> GerenciaAnoxosTO(int acao, String ConnectionString)
        {
            try
            {
                lista_dados = new List<Object>();
                dt = new DataTable();
                dt = _dao.GerenciaAnexo(this._codigo, this._mime, this._caminho, this._apontamento, this._conversa, acao, ConnectionString);

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
                                AnexosTO item = new AnexosTO(false);

                                item.Codigo = int.Parse(dt.Rows[x]["CODIGO"].ToString());
                                item.Mime = dt.Rows[x]["MIME"].ToString();
                                item.Caminho = dt.Rows[x]["CAMINHO"].ToString();
                                item.Apontamento = int.Parse(dt.Rows[x]["APONTAMENTO"].ToString());
                                item.Conversa = int.Parse(dt.Rows[x]["CONVERSA"].ToString());
                                
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

        public AnexosTO(bool conbd)
        {
            if (conbd)
            {
                this._dao = new AnexosDAO();
            }
            
        }
        #endregion

    }
}
