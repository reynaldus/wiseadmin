using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WiseControlModel;
using System.Data;
using ControllerMaster;


namespace WiseControlController
{
    public class ReqComponentesTO : ControllerMaster.ControllerMaster
    {

        #region "Atributos"
        private int _codigoreqcomponentes;
        private int _requisito;
        private int _componente;
        private ReqComponentesDAO _dao;
        #endregion

        #region "GETTERS E SETTERS"

        public int CodigoReqComponentes
        {
            get { return this._codigoreqcomponentes; }
            set { this._codigoreqcomponentes = value; }
        }
        public int Requisito
        {
            get { return this._requisito; }
            set { this._requisito = value; }

        }

        public int Componente
        {
            get { return this.Componente; }
            set { this._componente = value; }

        }
        #endregion
        #region "Métodos"
        public List<Object> gerenciaReqComponentesTO(int acao, String ConnectionString)
        {

            try
            {
                //INSTANCIA LISTA DE OBJETOS PARA RETORNO
                lista_dados = new List<object>();

                //INSTANCIA DATATABLE QUE RECEBERÁ DADOS DA DAO
                dt = new System.Data.DataTable();

                //BUSCO DADOS NA DAO
                dt = _dao.GerenciaReqComponentes(this.CodigoReqComponentes, this.Requisito, this.Componente, acao, ConnectionString);

                //VERIFICO SE NÃO VOLTOU NULO
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

                                ReqComponentesTO item = new ReqComponentesTO(false);
                                item.CodigoReqComponentes = int.Parse(dt.Rows[x]["CODIGOREQ_COMPONENTES"].ToString());
                                item.Requisito = int.Parse(dt.Rows[x]["REQUISITO"].ToString());
                                item.Componente = int.Parse(dt.Rows[x]["COMPONENTE"].ToString());
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
        public ReqComponentesTO(bool conbd)
        {

            try
            {
                if (conbd)
                {
                    this._dao = new ReqComponentesDAO();
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


