        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ControllerMaster;
using WiseControlModel;

namespace WiseControlController
{
    public class ComponentesTO:ControllerMaster.ControllerMaster
    {
        #region "Atributos"
        private int _codigocomp;
        private string _descrcomp;

        private ComponentesDAO _dao;

        private ModelosTO _modelo;
        private TipoComponentesTO _tipocomp;
                      
        #endregion

        #region "GETTERS E SETTERS"

        public int CodigoComp
        {
            get { return this._codigocomp; }
            set { this._codigocomp = value; }
        }
        public string DescrComp
        {
            get { return this._descrcomp; }
            set { this._descrcomp = value; }
        }

        public ModelosTO Modelo
        {
            get { return this._modelo; }
            set { this._modelo = value; }
        }

        public TipoComponentesTO TipoComp
        {
            get { return this._tipocomp; }
            set { this._tipocomp = value; }

        }
        #endregion
 
        #region"Métodos"
        public List<Object> gerenciaComponentesTO(int acao, String ConnectionString)
        {
            try
            {
                lista_dados = new List<Object>();
                dt = new System.Data.DataTable();
                dt = _dao.GerenciaComponentes(this._codigocomp, this._descrcomp, this._modelo.CodigoModel, this._tipocomp.CodigoTpComp, acao, ConnectionString);
                
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
                                ComponentesTO item = new ComponentesTO(false, true);
                                item.CodigoComp = int.Parse(dt.Rows[x]["CODIGOCOMP"].ToString());
                                item.DescrComp = dt.Rows[x]["DESCRCOMP"].ToString();

                                //Modelo
                                item._modelo.CodigoModel = int.Parse(dt.Rows[x]["CODIGOMODEL"].ToString());
                                item._modelo.DescModel = dt.Rows[x]["DESCRMODEL"].ToString();

                                //TipoComponentes
                                item._tipocomp.CodigoTpComp = int.Parse(dt.Rows[x]["CODIGOTPCOMP"].ToString());
                                item._tipocomp.NomeTpComp = dt.Rows[x]["NOMETPCOMP"].ToString();
                                
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

        public ComponentesTO(bool conbd, bool instanciadependente)
        {
            try
            {
                if (conbd)
                {
                    this._dao = new ComponentesDAO();
                }

                if (instanciadependente)
                {
                    _modelo = new ModelosTO(true, false);
                    _tipocomp = new TipoComponentesTO(false);
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