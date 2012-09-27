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
    public  class TipoProblemaTO
    {
        #region "Atributos"
        private int _codigo;
        private String _descricao;
        private SLATO _sla;
        private DepartamentoTO _departamento;
        private TipoProblemaDAO _dao;
        #endregion
        #region "Métodos"
        #endregion
        #region "Construtores"
        public TipoProblemaTO(bool conbd, bool instanciadependent)
        {
            if (conbd)
            {
                this._dao = new TipoProblemaDAO();

            }
            if (instanciadependent)
            {
                this._departamento = new DepartamentoTO(false);
                this._sla = new SLATO(false);
            }

        }
        #endregion
    }
}
