using Microsoft.VisualStudio.TestTools.UnitTesting;
using TotallyNotRobots.Movies.TestingTools;

namespace Web.UI.Tests
{
    [TestClass]
    public class Context
    {
        static TestContext _context;
        static Database _database;

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            _context = context;
            _database = new Database(GetConfiguration());
            _database.Backup();
        }

        public static Configuration GetConfiguration()
        {
            return new Configuration(_context);
        }

        [AssemblyCleanup]
        public static void AfterAll()
        {
            _database.Restore();
        }
    }
}
