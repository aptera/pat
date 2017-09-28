namespace TotallyNotRobots.Movies.TestingTools
{
    public interface IQueryProvider
    {
        string Backup(string database);
        string Restore(string database);
    }
}