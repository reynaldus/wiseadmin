using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WiseControlModel;


namespace WiseControlController
{
    public class SoftwareTO : ControllerMaster.ControllerMaster
    {
        #region "Atributos"

        private int _codigosw;
        private string _licenca;
        private string _nomesw;
        private int _marcasw;
        private int _categoria_sw;
        private SoftwareDAO _dao;

        #endregion

        #region "GETTERS E SETTERS"

        public int Codigosw
        {

            get { return this._codigosw; }
            set { this._codigosw = value; }
        }

        public String Licenca
        {

            get { return this._licenca; }
            set { this._licenca = value; }
        }

        public String Nomesw
        {

            get { return this._nomesw; }
            set { this._nomesw = value; }
        }

        public int Marcasw
        {

            get { return this._marcasw; }
            set { this._marcasw = value; }
        }

        public int Categoriasw
        {

            get { return this._categoria_sw; }
            set { this._categoria_sw = value; }
        }

        #endregion


        #region "Métodos"

        public List<Object> gerenciaSoftwareTO(int acao, String ConnectionString)
        {


            try
            {
                lista_dados = new List<object>();
                dt = new System.Data.DataTable();
                dt = _dao.GerenciaSotware(this.Codigosw, this._licenca, this._nomesw, this._marcasw, this._categoria_sw, acao, ConnectionString);
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
                                SoftwareTO item = new SoftwareTO(false);
                                item.Categoriasw = int.Parse(dt.Rows[x]["CODIGOSW"].ToString());
                                item.Licenca = dt.Rows[x]["LICENCA"].ToString();
                                item.Nomesw = dt.Rows[x]["NOMESW"].ToString();
                                item.Marcasw = int.Parse(dt.Rows[x]["MARCASW"].ToString());
                                item.Categoriasw = int.Parse(dt.Rows[x]["CATEGORIA_SW"].ToString());
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
        public SoftwareTO(bool conbd)
        {

            try
            {
                if (conbd)
                {
                    this._dao = new SoftwareDAO();
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
