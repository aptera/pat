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
        public IEnumerable<Review> getReviews(int movieID)
        {
            return _context.Movies.Include("Reviews")
                .FirstOrDefault(m => m.ID == movieID).Reviews;
        }

        [Route("")]
        public Review post(int movieID, Review newReview)
        {
            var movie = _context.Movies.Find(movieID);
            movie.Reviews.Add(newReview);
            _context.SaveChanges();
            return newReview;
        }
    }
}
