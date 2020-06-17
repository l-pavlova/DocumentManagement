using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DocManagement
{
    public static class ConnectionFactory
    {
        
        //try break, put actaull pool if no work update: it work!
        private static string GetConnection()
        {
            return WebConfigurationManager.ConnectionStrings["DocManagement.Properties.Settings.Setting"].ConnectionString;
        }
        public static SqlConnection GetDbConnection()
        {
            string connectionString = GetConnection();
            return new SqlConnection(connectionString);
        }
    }
}
