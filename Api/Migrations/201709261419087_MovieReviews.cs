namespace TotallyNotRobots.Movies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieReviews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Comments = c.String(nullable: false),
                        Movie_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Movies", t => t.Movie_ID)
                .Index(t => t.Movie_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Movie_ID", "dbo.Movies");
            DropIndex("dbo.Reviews", new[] { "Movie_ID" });
            DropTable("dbo.Reviews");
        }
    }
}
