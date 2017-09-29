using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TotallyNotRobots.Movies.Api.Integration.Tests.ApiClient;
using TotallyNotRobots.Movies.Api.Integration.Tests.ApiClient.Models;

namespace TotallyNotRobots.Movies.Api.Integration.Tests.Movies
{
    [TestClass]
    public class TheReviewsAPI : APITests
    {
        [TestMethod]
        public void GivenANewReview_SavesTheReview()
        {
            var id = _api.Movies.GetMovies().FirstOrDefault().ID;
            var review = _api.Reviews.Post(id ?? 0, new Review() { Comments = "It Rocks!!!" });

            Assert.IsNotNull(review);
            Assert.AreNotEqual(0, review.ID);

        }

        [TestMethod]
        public void GetsAListOfReviews()
        {
            int? id = PostReview();

            var reviews = _api.Reviews.GetReviews(id ?? 0);

            Assert.IsTrue(reviews.Count > 0);
        }

        private static int? PostReview()
        {
            var id = _api.Movies.GetMovies().FirstOrDefault().ID;
            var review = _api.Reviews.Post(id ?? 0, new Review() { Comments = "It Rocks!!!" });
            return id;
        }
    }
}
