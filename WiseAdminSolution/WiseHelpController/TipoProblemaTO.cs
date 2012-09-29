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
    public class TipoProblemaTO:ControllerMaster.ControllerMaster
     {
        #region "Atributos"
        //Classe
        private int _codigo;
        private String _descr;
        private TipoProblemaDAO _dao;
        //Herança
        private SLATO _sla;
        private DepartamentoTO _departamento;
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

        public DepartamentoTO Departamento{

            get { return this._departamento; }
            set { this._departamento = value; }
        }

        #endregion
        
        #region "Métodos"

        public List<object> GerenciaTipoProblemaTO(int acao, String ConnectionString) 
        {
            lista_dados = new List<object>();
            dt = new DataTable();
            dt = _dao.GerenciaTipoProblema(this._codigo, this._descr, this._sla.CodigoSLA, this._departamento.Codigo, acao, ConnectionString);

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
                            TipoProblemaTO item = new TipoProblemaTO(false, true);
                            item.Codigo = int.Parse(dt.Rows[x]["CODIGO"].ToString());
                            item.Descr = dt.Rows[x]["DESCR"].ToString();

                            item._sla.CodigoSLA = int.Parse(dt.Rows[x]["CODIGO"].ToString());
                            item._sla.TempoAtendimento = double.Parse(dt.Rows[x]["TEMPOATENDIMENTO"].ToString());

                            item._departamento.Codigo = int.Parse(dt.Rows[x]["CODIGO"].ToString());
                            item._departamento.Email = dt.Rows[x]["EMAIL"].ToString();
                            item._departamento.Ramal = int.Parse(dt.Rows[x]["RAMAL"].ToString());
                            item._departamento.Nome = dt.Rows[x]["NOME"].ToString();

                            lista_dados.Add(item);





                        }

                    }
                }
            }
            return lista_dados;


        }

        #endregion
        #region "Construtores"
        public TipoProblemaTO(bool conbd, bool instanciadependente)
        {
            if (conbd)
            {
                this._dao = new TipoProblemaDAO();

            }
            if (instanciadependente)
            {
               
                this._sla = new SLATO(false);
                this._departamento = new DepartamentoTO(false);
            }

        }
        #endregion
    }
}
