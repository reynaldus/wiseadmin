using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ControllerMaster;
using WiseControlModel;

namespace WiseControlController
{
    public class TipoComponentesTO:ControllerMaster.ControllerMaster
    {
        #region "Atributos"
        private int _codigotpcomp;
        private string _nometpcomp;
        
        private TipoComponentesDAO _dao;
        
        #endregion

        #region "GETTERS E SETTER"

        public int CodigoTpComp
        {
            get { return this._codigotpcomp; }
            set { this._codigotpcomp = value; }
        
        }

        public string NomeTpComp
        {
            get { return this._nometpcomp; }
            set { this._nometpcomp = value; }
        } 

        #endregion

        #region "Métodos"

        public List<Object> GerenciaTipoComponentesTO(int acao, String ConnectionString) 
        {
            try
            {
                lista_dados = new List<Object>();
                dt = new System.Data.DataTable();
                dt = _dao.GerenciaTipoComponentes(this._codigotpcomp, this._nometpcomp, acao, ConnectionString);

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
                                TipoComponentesTO item = new TipoComponentesTO(false);
                                item.CodigoTpComp = int.Parse(dt.Rows[x]["CODIGOTPCOMP"].ToString());
                                item.NomeTpComp = dt.Rows[x]["NOMETPCOMP"].ToString();
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

        #region "Contrutores"
        
        public TipoComponentesTO(bool condb)
        {
            try
            {
                this._dao = new TipoComponentesDAO();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        
        }
        #endregion
    }
}
