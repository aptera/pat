using System.Data.Entity.Migrations;

namespace TotallyNotRobots.Movies.Api
{
    public partial class Startup
    {
        public static void UpdateDatabase()
        {
            var migrations = new DbMigrator(new Migrations.Configuration());
            migrations.Update();
        }
    }
}