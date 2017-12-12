using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TotallyNotRobots.Movies.Web.ApiClient;
using TotallyNotRobots.Movies.Web.ApiClient.Models;
using TotallyNotRobots.Movies.Web.Models;
using TotallyNotRobots.Movies.Web.Presentation;

namespace TotallyNotRobots.Movies.Controllers
{
    [RoutePrefix("movies")]
    public class MoviesController : Controller
    {
        private readonly IApi _api;

        public MoviesController(IApi api)
        {
            _api = api;
        }

        [Route("")]
        public ActionResult Index(string genre, string filter)
        {
            var model = new MovieListViewModel(_api.Movies.GetMovies().AsQueryable())
            {
                Genre = genre,
                Filter = filter
            };
            ViewBag.Title = model.Title;
            return View(model);
        }

        [Route("details/{id:int}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var movie = _api.Movies.GetMovie(id.Value);
            if (movie == null)
                return HttpNotFound();

            var model = new MovieDetailsViewModel(_api, movie);
            model.triggerWords = new System.Collections.Generic.List<string>() { "have" };
            return View(model);
        }

        [Route("new")]
        public ActionResult Create()
        {
            return View(new Movie
            {
                ReleaseDate = DateTime.Now
            });
        }

        [Route("new")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (!ModelState.IsValid)
                return View(movie);

            _api.Movies.PostMovie(movie);
            return RedirectToAction("Index");
        }

        [Route("edit/{id:int}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var movie = _api.Movies.GetMovie(id.Value);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Route("edit/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (!ModelState.IsValid)
                return View(movie);

            _api.Movies.PutMovie(movie.ID.Value, movie);
            return RedirectToAction("Index");
        }

        [Route("delete/{id:int}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var movie = _api.Movies.GetMovie(id.Value);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Route("delete/{id:int}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _api.Movies.DeleteMovie(id);
            return RedirectToAction("Index");
        }

    }
}
