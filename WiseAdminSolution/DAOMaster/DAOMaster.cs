using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
namespace DAOMaster
{
   public abstract class DAOMaster
   {
       #region "Atributos"
       protected List<Parametro> parametros;
       protected const int TIMEOUT_INSERT = 500;
       protected const int TIMEOUT_SELECT = 500;
       protected const int TIMEOUT_DELETE = 500;
       protected const int TIMEOUT_UPDATE = 500;
       public static int getTimeOut(int acao)
       {
           switch (acao)
           {
               case 1: return DAOMaster.TIMEOUT_INSERT;
               case 2: return DAOMaster.TIMEOUT_SELECT;
               case 3: return DAOMaster.TIMEOUT_DELETE;
               case 4: return DAOMaster.TIMEOUT_UPDATE;
               default: return DAOMaster.TIMEOUT_SELECT;
           }
       }
       #endregion
   }
}
