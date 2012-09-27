using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ControllerMaster;
using DAOMaster;
using WiseHelpModel;

namespace WiseHelpController
{
    public class SLATO:ControllerMaster.ControllerMaster
    {
        #region "Atributos"
        private int _codigoSLA;
        private double _tempoatendimento;
        private SlaDAO _dao;
        #endregion
        #region "GETTERS E SETTERS"
        public int CodigoSLA
        {
            get { return this._codigoSLA; }
            set { this._codigoSLA = value; }
        }
        public double TempoAtendimento
        {
            get { return this._tempoatendimento; }
            set { this._tempoatendimento = value; }
        }

        #endregion
        #region "Métodos"
        public List<object> gerenciaSLA(int acao, String ConnectionString)
        {
            try
            {
                lista_dados = new List<object>();
                dt = new DataTable();
                dt = _dao.GerenciaSLA(this.CodigoSLA, this.TempoAtendimento, acao, ConnectionString);
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
                                SLATO item = new SLATO(false);
                                item.CodigoSLA = int.Parse(dt.Rows[x]["CODIGO"].ToString());
                                item.TempoAtendimento = double.Parse(dt.Rows[x]["TEMPOATENDIMENTO"].ToString());
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
        public SLATO(bool conbd)
        {
            if (conbd)
            {
                this._dao = new SlaDAO();
            }
        }
        #endregion
    }
}
