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
        public void WhenANewReviewIsPosted_SavesTheReview()
        {
            var firstMovieID = _api.Movies.GetMovies().FirstOrDefault().ID ?? 0;
            var created = _api.Reviews.Post(firstMovieID, new Review
            {
                Comments = "Best. Movie. Evar."
            });

            var reviews = _api.Reviews.Get(firstMovieID);

            Assert.IsNotNull(created?.ID);
            var review = reviews.First(r => r.ID == created.ID);
            Assert.AreEqual("Best. Movie. Evar.", review.Comments);
        }

        [TestMethod]
        public void WhenAReviewIsDeleted_DeletesTheReview()
        {
            var firstMovieID = _api.Movies.GetMovies().FirstOrDefault().ID ?? 0;
            var reviews = _api.Reviews.Get(firstMovieID);
            var firstReview = reviews.FirstOrDefault();

            _api.Reviews.DeleteReview(firstMovieID, firstReview.ID ?? 0);

            var deletedReview = _api.Reviews.GetReview(firstMovieID, firstReview.ID ?? 0);
            Assert.IsNull(deletedReview);
        }

    }
}
