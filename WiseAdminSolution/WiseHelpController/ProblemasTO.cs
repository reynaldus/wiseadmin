using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ControllerMaster;
using WiseHelpModel;

namespace WiseHelpController
{
    public class ProblemasTO:ControllerMaster.ControllerMaster
    {
        #region "Atributos"

        private int _codigo;
        private String _descr;
        private ProblemasDAO _dao;
        
        private SLATO _sla;
        private TipoProblemaTO _tipoproblema;
        #endregion

        #region "GETTERS E SETTERS"

        public int Codigo
        {
            get { return this._codigo; }
            set { this._codigo = value; }

        }

        public String Descr
        {
            get { return this._descr; }
            set { this._descr = value; }

        }

        public SLATO Sla
        {
            get { return this._sla; }
            set { this._sla = value; }
        
        }

        public TipoProblemaTO TipoProblema
        {
            get { return this._tipoproblema; }
            set { this._tipoproblema = value; }
                    
        }
        #endregion

        #region "Métodos"

        public List<Object> GerenciaProblemasTO(int acao, String ConnectionString)
        {
            try
            {
                lista_dados = new List<Object>();
                dt = new DataTable();
                dt = _dao.GerenciaProblemas(this._codigo, this._descr, this.Sla.CodigoSLA, this.TipoProblema.Codigo, acao, ConnectionString);

                if (!(dt==null))
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
                                ProblemasTO item = new ProblemasTO(false, true);

                                item.Codigo = int.Parse(dt.Rows[x]["CODIGO"].ToString());
                                item.Descr = dt.Rows[x]["DESCR"].ToString();
                                
                                item.Sla.CodigoSLA = int.Parse(dt.Rows[x]["CODIGO"].ToString());
                                item.Sla.TempoAtendimento = double.Parse(dt.Rows[x]["TEMPOATENDIMENTO"].ToString());
    
                                item.TipoProblema.Codigo = int.Parse(dt.Rows[x]["CODIGO"].ToString());
                                item.TipoProblema.Descr =  dt.Rows[x]["DESCR"].ToString();
                                    
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

        public ProblemasTO(bool conbd, bool instanciadependentes)
        {
            if (conbd)
            {
                this._dao = new ProblemasDAO();
            }

            if (instanciadependentes)
            {
                
                this._sla = new SLATO(false);
                this._tipoproblema = new TipoProblemaTO(false, true);
            }

        }


        #endregion

    }
}
