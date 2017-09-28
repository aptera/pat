using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TotallyNotRobots.Movies.Web.ApiClient.Models;
using TotallyNotRobots.Movies.Web.Presentation;

namespace TotallyNotRobots.Movies.Tests
{

    [TestClass]
    public partial class TheMovieListViewModel
    {
        [TestMethod]
        public void HasATitle()
        {
            Arrange();
            Assert.AreEqual("Movies", _model.Title);
        }

        [TestMethod]
        public void HasAListOfMovies()
        {
            Arrange();
            Assert.IsInstanceOfType(_model.Movies, typeof(IEnumerable<Movie>));
            Assert.AreEqual(4, _model.Movies.Count());
        }

        [TestMethod]
        public void HasAListOfGenres()
        {
            Arrange();
            Assert.IsInstanceOfType(_model.Genres, typeof(IEnumerable<string>));
            Assert.AreEqual(3, _model.Genres.Count());
        }

        [TestMethod]
        public void HasASampleMovie()
        {
            Arrange();
            Assert.IsInstanceOfType(_model.Sample, typeof(Movie));
        }

        [TestClass]
        public class GivenAGenre
        {
            [TestMethod]
            public void FiltersTheListOfMoviesByGenre()
            {
                Arrange();
                _model.Genre = "RomCom";
                AssertThatThisIsTheOnlyMovie(_model.Movies, "When Harry Met Sally");
            }
        }

        [TestClass]
        public class GivenNoGenre
        {
            [TestMethod]
            public void ShowsAllMovies()
            {
                Arrange();
                _model.Genre = "";
                Assert.AreEqual(4, _model.Movies.Count());
            }
        }

        [TestClass]
        public class GivenASearchFilter
        {
            [TestMethod]
            public void FiltersTheListOfMoviesByTitle()
            {
                Arrange();
                _model.Filter = "The";
                AssertThatThisIsTheOnlyMovie(_model.Movies, "The Fantastic Mr. Fox");
            }

            [TestClass]
            public class ThatDoesNotMatchTheTitlesCase
            {
                [TestMethod]
                public void IgnoresCaseWhenFilteringTheList()
                {
                    Arrange();
                    _model.Filter = "the";
                    AssertThatThisIsTheOnlyMovie(_model.Movies, "The Fantastic Mr. Fox");
                }
            }
        }

        [TestClass]
        public class GivenNoSearchFilter
        {
            [TestMethod]
            public void shows_all_movies_when_no_search_string_is_given()
            {
                Arrange();
                _model.Filter = "";
                Assert.AreEqual(4, _model.Movies.Count());
            }
        }

        static void AssertThatThisIsTheOnlyMovie(IEnumerable<Movie> movies, string title)
        {
            Assert.AreEqual(1, movies.Count());
            Assert.AreEqual(title, movies.First().Title);
        }

        static MovieListViewModel GetMovieList()
        {
            var movies = new List<Movie>(){
                new Movie(){ ID = 1, Title = "Saw", Genre = "Horror", Price = 5, Rating = "R", ReleaseDate = DateTime.Parse("10/29/2004")},
                new Movie(){ ID = 2, Title = "When Harry Met Sally", Genre = "RomCom", Price = 5, Rating = "R", ReleaseDate = DateTime.Parse("7/21/1989")},
                new Movie(){ ID = 3, Title = "The Fantastic Mr. Fox", Genre = "Indie", Price = 5, Rating = "PG", ReleaseDate = DateTime.Parse("11/29/2009")},
                new Movie(){ ID = 4, Title = "Phantasm", Genre = "Horror", Price = 5, Rating = "R", ReleaseDate = DateTime.Parse("3/28/1979")},
            };

            return new MovieListViewModel(movies.AsQueryable());
        }

        static MovieListViewModel _model;

        static void Arrange()
        {
            _model = GetMovieList();
        }
    }
}
