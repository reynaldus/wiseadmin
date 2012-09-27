using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ControllerMaster;
using WiseControlModel;


namespace WiseControlController
{
    public class HardwareTO : ControllerMaster.ControllerMaster
    {
        #region "Atributos"
        private int _codigohw;
        private int _tipohw;
        private int _departamento;
        private int _modelo;
        private HardwareDAO _dao;
        #endregion

        #region "GETTERS E SETTERS"

        public int Codigohw
        {
            get { return this._codigohw; }
            set { this._codigohw = value; }
        }
        public int Tipohw
        {
            get { return this._tipohw; }
            set { this._tipohw = value; }
        }
        public int Departamento
        {
            get { return this._departamento; }
            set { this._departamento = value; }
        }

        public int Modelo
        {
            get { return this._modelo; }
            set { this._modelo = value; }
        }
        #endregion

        #region "Métodos"
        public List<Object> gerenciaHardwareTO(int acao, String ConnectionString)
        {
            try
            {
                lista_dados = new List<object>();
                dt = new System.Data.DataTable();
                dt = _dao.GerenciaHardware(this._codigohw, this._tipohw, this._departamento, this._modelo, acao, ConnectionString);

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
                                HardwareTO item = new HardwareTO(false);
                                item.Codigohw = int.Parse(dt.Rows[x]["CODIGOHW"].ToString());
                                item.Tipohw = int.Parse(dt.Rows[x]["TIPOHW"].ToString());
                                item.Departamento = int.Parse(dt.Rows[x]["DEPARTAMENTO"].ToString());
                                item.Modelo = int.Parse(dt.Rows[x]["MODELO"].ToString());
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
        public HardwareTO(bool bdcon)
        {
            try
            {
                if (bdcon)
                {
                    this._dao = new HardwareDAO();
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
