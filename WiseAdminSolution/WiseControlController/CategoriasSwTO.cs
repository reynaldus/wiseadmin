using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ControllerMaster;
using WiseControlModel;

namespace WiseControlController
{
    public class CategoriasSwTO:ControllerMaster.ControllerMaster
    {
        #region "Atributos"
        private int _codigocatsw;
        private int _nomecatsw;
        private CategoriasSwDAO _dao;
        #endregion

        #region "GETTERS E SETTERS"
        public int CodigoCatSw
        {
            get{return this._codigocatsw;}
            set{this._codigocatsw = value;}
        }

        public int NomeCatSw 
        {
            get{return this._nomecatsw;}
            set{this._nomecatsw = value;}
        }
        #endregion

        #region "Métodos"

        public List<Object> gerenciaCategoriasSwTO(int acao, String ConnectionString)
        {
            try
            {
                lista_dados = new List<object>();
                dt = new System.Data.DataTable();
                dt = _dao.GerenciaCategoriasSW(this.CodigoCatSw, this.NomeCatSw, acao, ConnectionString);

                if(!(dt == null))
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
                                CategoriasSwTO item = new CategoriasSwTO(false);
                                item.CodigoCatSw = int.Parse(dt.Rows[x]["CODIGOCATSW"].ToString());
                                item.NomeCatSw = int.Parse(dt.Rows[x]["NOMECATSW"].ToString());
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
        public CategoriasSwTO(bool conbd) 
        {
            if (conbd)
            {
                this._dao = new CategoriasSwDAO(); 
            }
        }

        #endregion
    }
}
