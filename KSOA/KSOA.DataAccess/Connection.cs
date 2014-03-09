using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSOA.DataAccess
{
    public class Connection
    {
        public static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KSOAEntities"].ToString();
        public static string SqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KSOASqlEntities"].ToString();
    }
    
}
