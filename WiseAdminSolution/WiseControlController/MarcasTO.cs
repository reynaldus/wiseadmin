using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ControllerMaster;
using WiseControlModel;

namespace WiseControlController
{
    public class MarcasTO : ControllerMaster.ControllerMaster
    {
        #region "Atributos"
        private int _codigomarca;
        private string _emailsuporte;
        private string _nomemarca;
        
        private MarcasDAO _dao;
        #endregion

        #region "GETTERS E SETTERS"

        public int CodigoMarca
        {
            get { return this._codigomarca; }
            set { this._codigomarca = value; }
        }
        public string EmailSuporte
        {
            get { return this._emailsuporte; }
            set { this._emailsuporte = value; }
        }
        public string NomeMarca
        {
            get { return this._nomemarca; }
            set { this._nomemarca = value; }
        }

        #endregion

        #region "Métodos"

        public List<Object> gerenciaMarcasTO(int acao, String ConnectionString)
        {
            try
            {
                lista_dados = new List<object>();
                dt = new System.Data.DataTable();
                dt = _dao.GerenciaMarcas(this._codigomarca, this._emailsuporte, this._nomemarca, acao, ConnectionString);

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
                                MarcasTO item = new MarcasTO(false);
                                
                                item.CodigoMarca = int.Parse(dt.Rows[x]["CODIGOMARCA"].ToString());
                                item.EmailSuporte = dt.Rows[x]["EMAILSUPORTE"].ToString();
                                item.NomeMarca = dt.Rows[x]["NOMEMARCA"].ToString();
                          
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
        public MarcasTO(bool conbd)
        {
            try
            {
                if (conbd)
                {
                    this._dao = new MarcasDAO();
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
