using System.Linq;
using TotallyNotRobots.Movies.Web.ApiClient.Models;

namespace TotallyNotRobots.Movies.Web.Models
{
    public static class MovieSpecifications
    {
        public static IQueryable<Movie> ByGenre(this IQueryable<Movie> movies, string genre)
        {
            return movies.Where(m =>
                    (genre == null ||
                      genre.Trim() == string.Empty) ||
                      m.Genre.Equals(genre));
        }
        public static IQueryable<Movie> ByPartialTitle(this IQueryable<Movie> movies, string title)
        {
            return movies.Where(m => (title == null ||
                      title.Trim() == string.Empty) ||
                      m.Title.ToLower().Contains(title.ToLower()));
        }
    }
}