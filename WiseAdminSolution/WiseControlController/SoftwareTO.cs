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
        private SoftwareDAO _dao;

        private MarcasTO _marcasw;
        private CategoriasSwTO _categoriasw;
        

        #endregion

        #region "GETTERS E SETTERS"

        public int CodigoSw
        {

            get { return this._codigosw; }
            set { this._codigosw = value; }
        }

        public String Licenca
        {

            get { return this._licenca; }
            set { this._licenca = value; }
        }

        public String NomeSw
        {

            get { return this._nomesw; }
            set { this._nomesw = value; }
        }

        public MarcasTO MarcaSw
        {

            get { return this._marcasw; }
            set { this._marcasw = value; }
        }

        public CategoriasSwTO CategoriaSw
        {

            get { return this._categoriasw; }
            set { this._categoriasw = value; }
        }

        #endregion


        #region "Métodos"

        public List<Object> gerenciaSoftwareTO(int acao, String ConnectionString)
        {


            try
            {
                lista_dados = new List<object>();
                dt = new System.Data.DataTable();
                dt = _dao.GerenciaSotware(this._codigosw, this._licenca, this._nomesw, this._marcasw.CodigoMarca, this._categoriasw.CodigoCatSw, acao, ConnectionString);
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
                                item.CodigoSw = int.Parse(dt.Rows[x]["CODIGOSW"].ToString());
                                item.Licenca = dt.Rows[x]["LICENCA"].ToString();
                                item.NomeSw = dt.Rows[x]["NOMESW"].ToString();
                                
                                //Marcas
                                item._marcasw.CodigoMarca = int.Parse(dt.Rows[x]["CODIGOMARCA"].ToString());
                                item._marcasw.EmailSuporte = dt.Rows[x]["EMAILSUPORTE"].ToString();
                                item._marcasw.NomeMarca = dt.Rows[x]["NOMEMARCA"].ToString();

                                //Categorias
                                item._categoriasw.CodigoCatSw = int.Parse(dt.Rows[x]["CODIGO"].ToString());
                                item._categoriasw.NomeCatSw = dt.Rows[x]["DESCRCAT"].ToString();

                                
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
