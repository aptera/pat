using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using TotallyNotRobots.Movies.Models;

namespace TotallyNotRobots.Movies.Api.Controllers
{
    [RoutePrefix("api/v1/movies/{movieID}/reviews")]
    public class ReviewsController : ApiController
    {
        private readonly MovieDBContext _context;

        public ReviewsController(MovieDBContext context)
        {
            _context = context;
        }

        [Route("")]
        public IEnumerable<Review> Get(int movieID)
        {
            return Movie(movieID).Reviews;
        }

        [Route("")]
        public Review Post(int movieID, Review review)
        {
            Movie(movieID).Reviews.Add(review);
            _context.SaveChanges();
            return review;
        }

        private Movie Movie(int movieID)
        {
            return _context.Movies
                .Include("Reviews")
                .FirstOrDefault(m => m.ID == movieID);
        }
    }
}
