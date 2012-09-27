using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ControllerMaster;
using WiseControlModel;

namespace WiseControlController
{
    public class TiposTO:ControllerMaster.ControllerMaster
    {
        #region "Atributos"
 
        private int _codigotipo;
        private string _descrtipo;
        private int _categoria;
        private TiposDAO _dao;
        
        #endregion

        #region "GETTERS E SETTERS"

        public int CodigoTipo
        {
            get { return this._codigotipo;}
            set { this._codigotipo = value; }
        }

        public string DescrTipo
        {
            get { return this._descrtipo; }
            set { this._descrtipo = value; }
        }

        public int Categoria
        {
            get { return this._categoria; }
            set { this._categoria = value; }
        }

        #endregion

        #region "Métodos"

        public List<Object> GerenciaTiposTO(int acao, String ConnectionString) 
        {
            try
            {
                lista_dados = new List<object>();
                dt = new System.Data.DataTable();
                dt = _dao.GerenciaTipos(this._codigotipo, this._descrtipo, this._categoria, acao, ConnectionString);

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
                                TiposTO item = new TiposTO(false);
                                item.CodigoTipo = int.Parse(dt.Rows[x]["CODIGOTIPO"].ToString());
                                item.DescrTipo = dt.Rows[x]["DESCRTIPO"].ToString();
                                item.Categoria = int.Parse(dt.Rows[x]["CATEGORIA"].ToString());
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

        public TiposTO(bool conbd) 
        {
            this._dao = new TiposDAO();
        }
        #endregion
    }
}
