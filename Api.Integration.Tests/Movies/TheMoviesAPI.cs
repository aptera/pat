using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TotallyNotRobots.Movies.Api.Integration.Tests.ApiClient;
using TotallyNotRobots.Movies.Api.Integration.Tests.ApiClient.Models;

namespace TotallyNotRobots.Movies.Api.Integration.Tests.Movies
{
    [TestClass]
    public class TheMoviesAPI : APITests
    {
        [TestMethod]
        public void GetsAListOfMovies()
        {
            var movies = _api.Movies.GetMovies();
            Assert.AreEqual(4, movies.Count());
        }

        [TestMethod]
        public void GivenANewMovie_SavesTheMovie()
        {
            var response = _api.Movies.PostMovie(new Movie
            {
                Title = "Duke of Overkill",
                Genre = "Action",
                ReleaseDate = new DateTime(1985, 4, 5),
                Price = 12.34,
                Rating = "R"
            });

            var movie = _api.Movies.GetMovie(response?.ID ?? 0);
            Assert.AreEqual("Duke of Overkill", movie.Title);
        }

        [TestMethod]
        public void WhenDeletingAMovie_RemovesTheMovieFromTheList()
        {
            var movies = _api.Movies.GetMovies();
            var movieToDelete = movies.ElementAt(2);

            _api.Movies.DeleteMovie(movieToDelete.ID ?? 0);

            movies = _api.Movies.GetMovies();
            CollectionAssert.DoesNotContain(movies.Select(m => m.Title).ToList(), movieToDelete.Title);
        }

        [TestMethod]
        public void GivenAnUpdatedMovie_SavesTheChanges()
        {
            var movie = _api.Movies.GetMovies().First();
            var halfPrice = movie.Price / 2;
            movie.Price = halfPrice;

            _api.Movies.PutMovie(movie.ID ?? 0, movie);

            var updated = _api.Movies.GetMovie(movie.ID ?? 0);
            Assert.AreEqual(halfPrice.Value, updated.Price.Value, 0.01D);
        }

    }
}
