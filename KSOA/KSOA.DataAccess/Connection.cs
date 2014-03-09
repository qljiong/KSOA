using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U1City.Shop.DataAccess
{
    public class Connection
    {
        public static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["shopEntities"].ToString();
        public static string SqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["shopSqlEntities"].ToString();
    }
    
}
