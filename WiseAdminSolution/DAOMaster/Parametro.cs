using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAOMaster
{
   public class Parametro
   {
       #region "Atributos"
       private String _nomeparametro;
       private Object _parametro;

       #endregion
       #region "GETTERS E SETTERS"
       public String NomeParametro
       {
           get { return this._nomeparametro; }
           set { this._nomeparametro = value; }
       }
       public Object ParametroValor
       {
           get { return this._parametro; }
           set { this._parametro = value; }
       }
       #endregion
       #region "Construtores"
       public Parametro()
       {
       }
       public Parametro(String nomeparametro, Object parametro)
       {
           this.NomeParametro = nomeparametro;
           this.ParametroValor = parametro;
       }
       #endregion
   }
}
