using Swashbuckle.Swagger.Annotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TotallyNotRobots.Movies.Models;

namespace TotallyNotRobots.Movies.Api.Controllers
{
    [RoutePrefix("api/v1/movies")]
    public class MoviesController : ApiController
    {
        readonly MovieDBContext _context;
        public MoviesController(MovieDBContext context)
        {
            _context = context;
        }

        [Route("")]
        public IQueryable<Movie> GetMovies()
        {
            return _context.Movies;
        }

        [ResponseType(typeof(Movie))]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetMovie(int id)
        {
            Movie movie = await Task.Run(() => _context.Movies.Find(id));
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [ResponseType(typeof(void))]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> PutMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.ID)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Movie))]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Type = typeof(Movie))]
        public async Task<IHttpActionResult> PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new
            {
                controller = "movies",
                id = movie.ID
            }, movie);
        }

        [ResponseType(typeof(Movie))]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> DeleteMovie(int id)
        {
            Movie movie = await Task.Run(() => _context.Movies.Find(id));
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return Ok(movie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Count(e => e.ID == id) > 0;
        }
    }
}