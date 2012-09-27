using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ControllerMaster;
using WiseControlModel;


namespace WiseControlController
{
    public class ReqSoftwareTO : ControllerMaster.ControllerMaster
    {
        #region"Atributos"
        private int _codigoreqsoftware;
        private int _configminima;
        private int _sistema;
        private ReqSoftwareDAO _dao;
        #endregion
        #region "GETTERS E SETTERS"

        public int CodigoReqSoftware
        {
            get { return this._codigoreqsoftware; }
            set { this._codigoreqsoftware = value; }
        }

        public int ConfigMinima
        {
            get { return this._configminima; }
            set { this._configminima = value; }

        }
        public int Sistema
        {
            get { return this._sistema; }
            set { this._sistema = value; }
        }

        #endregion

        #region "Métodos"

        public List<Object> gerenciaReqSoftwareTO(int acao, String ConnectionString)
        {
            try
            {
                lista_dados = new List<object>();
                dt = new System.Data.DataTable();
                dt = _dao.GerenciaReqSoftware(this._codigoreqsoftware, this._configminima, this._sistema, acao, ConnectionString);

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
                                ReqSoftwareTO item = new ReqSoftwareTO(false);
                                item.CodigoReqSoftware = int.Parse(dt.Rows[x]["CODIGOREQ_SOFTWARE"].ToString());
                                item.ConfigMinima = int.Parse(dt.Rows[x]["CONFIG_MINIMA"].ToString());
                                item.Sistema = int.Parse(dt.Rows[x]["SISTEMA"].ToString());
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

        public ReqSoftwareTO(bool conbd)
        {
            try
            {
                this._dao = new ReqSoftwareDAO();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

    }
}
