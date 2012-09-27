using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ControllerMaster;
using WiseControlModel;

namespace WiseControlController
{
    public class SistemaHwTO : ControllerMaster.ControllerMaster
    {
        #region "Atributos"
        private int _codigosistemahw;
        private int _hardware;
        private int _software;
        private SistemaHwDAO _dao;
        #endregion

        #region "GETTERS E SETTER"
        public int CodigoSistemaHw
        {
            get { return this._codigosistemahw; }
            set { this._codigosistemahw = value; }

        }
        public int Hardware
        {
            get { return this._hardware; }
            set { this._hardware = value; }
        }

        public int Software
        {
            get { return this._software; }
            set { this._software = value; }
        }

        #endregion

        #region "Métodos"

        public List<Object> gerenciaSistemaHw(int acao, String ConnectionString)
        {

            try
            {
                lista_dados = new List<Object>();
                dt = new System.Data.DataTable();
                dt = _dao.GerenciaSistemaHW(this._codigosistemahw, this._hardware, this._software, acao, ConnectionString);

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
                                SistemaHwTO item = new SistemaHwTO(false);
                                item.CodigoSistemaHw = int.Parse(dt.Rows[x]["CODIGOSISTEMAHW"].ToString());
                                item.Hardware = int.Parse(dt.Rows[x]["HARDWARE"].ToString());
                                item.Software = int.Parse(dt.Rows[x]["SOFTWARE"].ToString());
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

        public SistemaHwTO(bool conbd)
        {
            try
            {
                this._dao = new SistemaHwDAO();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
