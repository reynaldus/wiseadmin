using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WiseAdmin.handlers.classes
{
    public abstract class Worker
    {
        public static String getConnectionString()
        {
            try
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["WISEADMINConnectionString"].ConnectionString;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }


    }
}