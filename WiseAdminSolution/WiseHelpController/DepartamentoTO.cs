using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WiseHelpModel;
using System.Data;
using DAOMaster;
using ControllerMaster;
namespace WiseHelpController
{
   public class DepartamentoTO:ControllerMaster.ControllerMaster
   {
       #region "Atributos"
       private int _codigo;
       private String _email;
       private int _ramal;
       private String _nome;
       private DepartamentoDAO _dao;
       #endregion
       #region "GETTERS E SETTERS"
       public int Codigo
       {
           get { return this._codigo; }
           set { this._codigo = value; }
       }
       public String Email
       {
           get { return this._email; }
           set { this._email = value; }
       }
       public int Ramal
       {
           get { return this._ramal; }
           set { this._ramal = value; }
       }
       public String Nome
       {
           get { return this._nome; }
           set { this._nome = value; }
       }
       #endregion
       #region "Métodos"
       public List<object> gerenciaDepartamentos(int acao, String ConnectionString)
       {
           try
           {
               lista_dados = new List<object>();
               dt = new DataTable();
               dt = _dao.GerenciaDepartamentos(this.Codigo, this.Email, this.Ramal, this.Nome, acao, ConnectionString);
               if (!(dt == null))
               {
                   if (dt.Rows.Count > 0)
                   {
                       for (int x = 0; x < dt.Rows.Count; x++)
                       {
                           DepartamentoTO item = new DepartamentoTO(false);
                           item.Codigo = int.Parse( dt.Rows[x]["CODIGO"].ToString());
                           item.Email = dt.Rows[x]["EMAIL"].ToString();
                           item.Ramal = int.Parse(dt.Rows[x]["RAMAL"].ToString());
                           item.Nome = dt.Rows[x]["NOME"].ToString();
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
       public DepartamentoTO(bool conbd)
       {
           if (conbd)
           {
               this._dao = new DepartamentoDAO();
           }
       }
       #endregion
   }
}
