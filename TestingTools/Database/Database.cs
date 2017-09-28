using System.Data.SqlClient;

namespace TotallyNotRobots.Movies.TestingTools
{
    public class Database
    {
        readonly string _connectionString;
        readonly Configuration _configuration;

        public Database(Configuration configuration)
        {
            _connectionString = configuration.Get("connectionString");
            _configuration = configuration;
        }

        public void Backup()
        {
            Execute(BackupSql());
        }

        public void Restore()
        {
            Execute(RestoreSql());
        }

        static string DatabaseName(string connectionString)
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            return builder.InitialCatalog;
        }

        static int ConnectionTimeout(string connectionString)
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            return builder.ConnectTimeout;
        }

        public bool IsLocal()
        {
            var builder = new SqlConnectionStringBuilder(_connectionString);
            return builder.DataSource.Contains("(localdb)");
        }

        static bool IsAzure(string connectionString)
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            return builder.DataSource.Contains(".database.windows.net");
        }

        IQueryProvider Provider()
        {
            return IsAzure(_connectionString)
                ? new SqlAzureQueryProvider() as IQueryProvider
                : new SqlServerQueryProvider(_configuration) as IQueryProvider;
        }

        string BackupSql()
        {
            var database = DatabaseName(_connectionString);
            return Provider().Backup(database);
        }

        string RestoreSql()
        {
            var database = DatabaseName(_connectionString);
            return Provider().Restore(database);
        }

        void Execute(string sql)
        {
            using (var connection = new SqlConnection(Master(_connectionString)))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = sql;
                command.CommandTimeout = ConnectionTimeout(_connectionString);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        static string Master(string connectionString)
        {
            var builder = new SqlConnectionStringBuilder(connectionString)
            {
                InitialCatalog = "master"
            };
            return builder.ConnectionString;
        }

    }
}
