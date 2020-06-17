using System.Data.SqlClient;
using System.Web.Configuration;

namespace DocManagement
{
    public static class ConnectionFactory
    {
        
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
