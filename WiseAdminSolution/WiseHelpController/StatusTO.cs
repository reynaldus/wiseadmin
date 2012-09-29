using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ControllerMaster;
using WiseHelpModel;

namespace WiseHelpController
{
    public class StatusTO:ControllerMaster.ControllerMaster
    {
        #region "Atributos"

        private int _codigo;
        private String _descr;
        private  StatusDAO _dao;

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

        #endregion

        #region "Métodos"

        public List<object> GerenciaStatusTO(int acao, String ConnectionString)
        {
            try
            {
                lista_dados = new List<object>();
                dt = new DataTable();
                dt = _dao.GerenciaStatus(this._codigo, this._descr, acao, ConnectionString);

                if (!(dt == null))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (acao != 2)
                        {
                            lista_dados.Add(dt.Rows[0][0].ToString());

                        }
                        else {

                            for (int x = 0; x < dt.Rows.Count; x++)
                            {
                                StatusTO item = new StatusTO(false);
                                item.Codigo = int.Parse(dt.Rows[x]["CODIGO"].ToString());
                                item.Descr = dt.Rows[x]["DESCR"].ToString();

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

        public StatusTO(bool conbd) {

            if (conbd)
            {
                this._dao = new StatusDAO();
            }
        }

        #endregion
    }
}
