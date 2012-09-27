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
        private string _descrmodel;
        private string _nometpcomp;
        private ComponentesDAO _dao;
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
        public string DescrModel
        {
            get { return this._descrmodel; }
            set { this._descrmodel = value; }
        }

        public string NomeTpComp
        {
            get { return this._nometpcomp; }
            set { this._nometpcomp = value; }

        }
        #endregion
        #region"Métodos"
        public List<Object> gerenciaComponentesTO(int acao, String ConnectionString)
        {
            try
            {
                lista_dados = new List<Object>();
                dt = new System.Data.DataTable();
                dt = _dao.GerenciaComponentes(this._codigocomp, this._descrcomp, this._descrmodel, this._nometpcomp, acao, ConnectionString);
                
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
                                ComponentesTO item = new ComponentesTO(false);
                                item.CodigoComp = int.Parse(dt.Rows[x]["CODIGOCOMP"].ToString());
                                item.DescrComp = dt.Rows[x]["DESCRCOMP"].ToString();
                                item.DescrModel = dt.Rows[x]["DESCRMODEL"].ToString();
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

        public ComponentesTO(bool conbd)
        {
            try
            {
                if (conbd)
                {
                    this._dao = new ComponentesDAO();
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