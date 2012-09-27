using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ControllerMaster;
using WiseControlModel;

namespace WiseControlController
{
    public class ModelosTO:ControllerMaster.ControllerMaster
    {
        #region "Atributos"
        private int _codigomodel;
        private string _descrmodel;
        private int _marca;
        private ModelosDAO _dao;
        #endregion

        #region "GETTERS E SETTERS"
        public int CodigoModel 
        {   
            get { return this._codigomodel;}
            set { this._codigomodel = value; }
        }
        public string DescModel 
        {
            get { return this._descrmodel; }
            set { this._descrmodel = value; }
        }
        public int Marca 
        {
            get { return this._marca; }
            set { this._marca = value; }
        }
        #endregion

        #region "Métodos"

        public List<Object> GerenciaModelosTO(int acao, String ConnectionString) 
        {
            try
            {
                lista_dados = new List<object>();
                dt = new System.Data.DataTable();
                dt = _dao.GerenciaModelos(this._codigomodel, this._descrmodel, this._marca, acao, ConnectionString);

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
                                ModelosTO item = new ModelosTO(false);
                                item.CodigoModel = int.Parse(dt.Rows[x]["CODIGOMODEL"].ToString());
                                item.DescModel = dt.Rows[x]["DESCRMODEL"].ToString();
                                item.Marca = int.Parse(dt.Rows[x]["MARCA"].ToString());
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
        public ModelosTO(bool conbd)
        {
            try
            {
                this._dao = new ModelosDAO();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        #endregion

    }
}
