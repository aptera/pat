namespace TotallyNotRobots.Movies.TestingTools
{
    public class SqlAzureQueryProvider : IQueryProvider
    {
        public string Backup(string database)
        {
            return $"CREATE DATABASE [{BackupName(database)}] AS COPY OF [{database}]";
        }

        public string Restore(string database)
        {
            return
                $"ALTER DATABASE [{database}] Modify Name = [{TestedName(database)}]; " +
                $"ALTER DATABASE [{BackupName(database)}] Modify Name = [{database}]; " +
                $"DROP DATABASE [{TestedName(database)}]; ";
        }

        string BackupName(string database)
        {
            return $"{database}-backup";
        }

        string TestedName(string database)
        {
            return $"{database}-tested";
        }

    }
}
