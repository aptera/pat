using Owin;
using System.Data.Entity.Migrations;

namespace TotallyNotRobots.Movies.Api
{
    public partial class Startup
    {
        public void UpdateDatabase(IAppBuilder app)
        {
            var migrations = new DbMigrator(new Migrations.Configuration());
            migrations.Update();
        }
    }
}