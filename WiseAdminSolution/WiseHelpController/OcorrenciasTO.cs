using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ControllerMaster;
using WiseHelpModel;

namespace WiseHelpController
{
    public class OcorrenciasTO:ControllerMaster.ControllerMaster
    {
        #region "Atributos"

        //Da própria classe
        private int _codigo;
        private String _descr;
        private DateTime _dtabertura;
        private DateTime _dtend;
        private String _contato;
        private OcorrenciasDAO _dao;

        //Herança
        private StatusTO _status;
        private ProblemasTO _problemas;
        private UsuarioTO _usuario;
        
        #endregion

        #region "GETTERS E SETTERS"

        public int Codigo
        {
            get { return this._codigo; }
            set { this._codigo = value; }
        }

        public DateTime DtAbertura
        {
            get { return this._dtabertura; }
            set { this._dtabertura = value; }

        }

        public String Descr
        {
            get { return this._descr; }
            set { this._descr = value; }
                    
        }

        public DateTime DTend
        {
            get { return this._dtend; }
            set { this._dtend = value; }
        
        }

        public String Contato
        {
            get { return this._contato; }
            set { this._contato = value; }
 
        }

        public StatusTO Status
        {
            get { return this._status; }
            set { this._status = value; }
        }

        public ProblemasTO Problemas
        {
            get { return this._problemas; }
            set { this.Problemas = value; }
        
        }

        public UsuarioTO Usuario
        {
            get { return this._usuario; }
            set { this._usuario = value; }
        }





        #endregion

        #region "Métodos"

        public List<object> GerenciaOcorrenciasTO(int acao, String ConnectionString) 
        {
            try
            {
                lista_dados = new List<object>();
                dt = new DataTable();
                dt =_dao.GerenciaOcorrencias(this._codigo, this._descr, this._dtabertura,this._dtend, this._contato, this._status.Codigo, this._problemas.Codigo, this._usuario.CodigoUsuario, acao, ConnectionString);

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
                                OcorrenciasTO item = new OcorrenciasTO(false,true);

                                item.Codigo = int.Parse(dt.Rows[x]["CODIGO"].ToString());
                                item.Descr = dt.Rows[x]["DESCR"].ToString();
                                item.DtAbertura = DateTime.Parse(dt.Rows[x]["DTABERTURA"].ToString());
                                item.DTend = DateTime.Parse(dt.Rows[x]["DTEND"].ToString()); 
                                item.Contato = dt.Rows[x]["CONTATO"].ToString();

                                item._status.Codigo = int.Parse(dt.Rows[x]["CODIGO"].ToString());
                                item._status.Descr = dt.Rows[x]["DESCR"].ToString();

                                item._problemas.Codigo = int.Parse(dt.Rows[x]["CODIGO"].ToString());
                                item._problemas.Descr = dt.Rows[x]["DESCR"].ToString();

                                item._usuario.Codigo = int.Parse(dt.Rows[x]["CODIGO"].ToString());
                                item._usuario.Login = dt.Rows[x]["LOGIN"].ToString();
                                item._usuario.Nome = dt.Rows[x]["NOME"].ToString();
                                item._usuario.Email = dt.Rows[x]["EMAIL"].ToString();
                                item._usuario.Ramal = int.Parse(dt.Rows[x]["RAMAL"].ToString());
                                item._usuario.DataNascimento = DateTime.Parse(dt.Rows[x]["DTNASC"].ToString());



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

        #region "Costrutores"

        public OcorrenciasTO(bool conbd,  bool instanciadependente)
           
        {
         
            if (conbd)
            {
                this._dao = new OcorrenciasDAO();
            }

            if (instanciadependente)
            {
                this._status = new StatusTO(false);
                this._problemas = new ProblemasTO(false, true);
                this._usuario = new UsuarioTO(true, true, true);
            }
            
            
        }
        #endregion
    }
}
