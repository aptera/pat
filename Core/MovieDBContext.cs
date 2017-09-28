using System.Data.Entity;

namespace TotallyNotRobots.Movies.Models
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual IDbSet<Movie> Movies { get; set; }
    }
}