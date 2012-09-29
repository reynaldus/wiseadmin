using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ControllerMaster;
using WiseHelpModel;
namespace WiseHelpController
{
    public class AcoesAdmSLATO:ControllerMaster.ControllerMaster
    {
        #region "Atributos"
        private int _codigoacaoadmsla;
        private AcoesSlaDAO _dao;

        private AcoesAdmTO _acaoadm;
        private SLATO _sla;
                
        #endregion
        
        #region "GETTERS E SETTERS"
        public int CodigoAcaoAdmSLA
        {
            get { return this._codigoacaoadmsla; }
            set { this._codigoacaoadmsla = value; }
        }
        
        public AcoesAdmTO AcaoAdm
        {
            get { return this._acaoadm; }
            set { this._acaoadm = value; }
        }
        
        public SLATO Sla
        {
            get { return this._sla; }
            set { this._sla = value; }
        }
        #endregion
        
        #region "Métodos"
        public List<object> GerenciaAcoesAdmSLATO(int acao, String ConnectionString)
        {
            try
            {
                dt = new DataTable();
                lista_dados = new List<object>();
                
                dt = _dao.gerenciaAcoesSLA(this._codigoacaoadmsla, this._acaoadm.Codigo, this._sla.CodigoSLA, acao, ConnectionString);
                
                
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
                                AcoesAdmSLATO item = new AcoesAdmSLATO(false, true);

                                item.CodigoAcaoAdmSLA = int.Parse(dt.Rows[x]["SLAACAOCODIGO"].ToString());
                                
                                item.Sla.CodigoSLA = int.Parse(dt.Rows[x]["CODIGO"].ToString());
                                item.Sla.TempoAtendimento = double.Parse(dt.Rows[x]["TEMPOATENDIMENTO"].ToString());
                                
                                item.AcaoAdm.Codigo = int.Parse(dt.Rows[x]["ACAOADMCODIGO"].ToString());

                                item.AcaoAdm.Descricao = dt.Rows[x]["ACAO"].ToString();
                                
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conbd">Se verdadeiro instancia DAO</param>
        /// <param name="instanciadependentes">Se verdadeiro instancia dependentes</param>
        public AcoesAdmSLATO(bool conbd, bool instanciadependentes)
        {
            if (conbd)
            {
                this._dao = new AcoesSlaDAO();
            }
            if (instanciadependentes)
            {
                this.AcaoAdm = new AcoesAdmTO(false);
                this.Sla = new SLATO(false);
            }
        }
        #endregion


    }
}
