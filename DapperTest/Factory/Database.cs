using System.Configuration;

namespace DapperTest.Factory
{
    public class Database
    {
        public static string conVal(string conStr)
        {
            return ConfigurationManager.ConnectionStrings[conStr].ConnectionString;
        }
    }
}
