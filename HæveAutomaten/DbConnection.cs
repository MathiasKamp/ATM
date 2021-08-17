using System.Configuration;

namespace HæveAutomaten
{
    /// <summary>
    /// Class is used to get the database connection string from app.config file
    /// </summary>
    public static class DbConnection
    {
        /// <summary>
        /// returns the database string from app.config
        /// </summary>
        /// <returns>string</returns>
        public static string dbCon ()
        {
            return ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
        }
    }
}