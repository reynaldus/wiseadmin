using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using ControllerMaster;
using WiseControlController;
using WiseControlModel;

namespace WiseControlController
{
    public class PessoasTO:WiseHelpController.PessoasTO
        
    {
        #region "Atributos"

        private PessoasDAO _dao;
        
        #endregion

        #region "GETTERS E SETTERS"
        
        #endregion

        #region "Métodos"

        public List<object> GerenciaPessoasTO(int acao, String ConnectionString) 
        {
            try
            {
                lista_dados = new List<object>();
                dt = new System.Data.DataTable();

                dt = _dao.GerenciaPessoas();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        #endregion

        #region "Construtores"

        public PessoasTO(bool conbd, bool pessoapai, bool instdepenpai)
            : base(pessoapai, instdepenpai)
        {
            if (conbd)
            {
                this._dao = new PessoasDAO();
            }
        }


        #endregion

    }
}
