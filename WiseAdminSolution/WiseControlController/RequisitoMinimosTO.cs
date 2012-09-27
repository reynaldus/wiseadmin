using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ControllerMaster;
using WiseControlModel;

namespace WiseControlController
{
    public class RequisitoMinimosTO : ControllerMaster.ControllerMaster
    {
        #region "atributos"

        private int _codigoreq;
        private string _componentes;
        private RequisitosMinimosDAO _dao;

        #endregion

        #region"GETTES E SETTES"

        public int CodigoReq
        {

            get { return this._codigoreq; }
            set { this._codigoreq = value; }

        }

        public String Componentes
        {

            get { return this._componentes; }
            set { this._componentes = value; }
        }


        #endregion

        #region"Metodo"
        public List<Object> gerenciaRequisitosMinimosTO(int acao, string ConnectionString)
        {


            try
            {
                lista_dados = new List<object>();
                dt = new System.Data.DataTable();
                dt = _dao.GerenciaRequisitosMinimos(this._codigoreq, this._componentes, acao, ConnectionString);
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
                                RequisitoMinimosTO item = new RequisitoMinimosTO(false);
                                item.CodigoReq = int.Parse(dt.Rows[x]["CODIGOREQ"].ToString());
                                item.Componentes = dt.Rows[x]["COMPONENTES"].ToString();
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
        #region"Construtor"

        public RequisitoMinimosTO(bool conbd)
        {

            try
            {
                if (conbd)
                {
                    this._dao = new RequisitosMinimosDAO();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        #endregion

        }


    }
}
