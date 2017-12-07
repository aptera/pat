using System.IO;

namespace TotallyNotRobots.Movies.TestingTools
{
    public class SqlServerQueryProvider : IQueryProvider
    {
        readonly Configuration _configuration;

        public SqlServerQueryProvider(Configuration configuration)
        {
            _configuration = configuration;
        }

        public string Backup(string database)
        {
            File.Delete(BackupFileName(database));
            return $"BACKUP DATABASE [{database}] TO DISK = '{BackupFileName(database)}'";
        }

        public string Restore(string database)
        {
            return
                $"ALTER DATABASE [{database}] SET Single_User WITH Rollback Immediate; " +
                $"RESTORE DATABASE [{database}] FROM DISK = '{BackupFileName(database)}'; " +
                $"ALTER DATABASE [{database}] SET Multi_User;";
        }

        string BackupFileName(string database)
        {
            return Path.Combine(_configuration.Get("sqlBackupLocation"), database) + ".bak";
        }

    }
}
