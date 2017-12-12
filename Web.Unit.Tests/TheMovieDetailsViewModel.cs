using FakeItEasy;
using Microsoft.Rest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TotallyNotRobots.Movies.Web.ApiClient;
using TotallyNotRobots.Movies.Web.ApiClient.Models;
using TotallyNotRobots.Movies.Web.Models;

namespace TotallyNotRobots.Movies.Web.Unit.Tests
{
    [TestClass]
    public class TheMovieDetailsViewModel
    {
        static IApi api;

        [TestMethod]
        public void HasAMovie()
        {
            Assert.AreEqual(5, GetModel(5).Movie.ID);
        }

        [TestMethod]
        public void LoadsTheReviewsFromTheAPI()
        {
            var model = GetModel(5);
            ArrangeReviewsForMovie(5, new List<Review> {
                            new Review(),
                            new Review()
                        });
            Assert.AreEqual(2, model.Reviews.Count());
        }

        [TestClass]
        public class WhenCleaningAReview
        {
            [TestClass]
            public class GivenAReviewWithNoTriggerWords
            {
                [TestMethod]
                public void ReturnsTheReview()
                {
                    var model = GetModel(7);
                    model.triggerWords = new List<string> { "horsefeathers" };
                    ArrangeReviewsForMovie(7, new List<Review> {
                            new Review { Comments="This movie is great!"}
                        });
                    var reviewToTest = model.Reviews.First();
                    var resultOfCleaning = model.Clean(reviewToTest);
                    Assert.AreEqual("This movie is great!", resultOfCleaning);
                }
            }
            [TestClass]
            public class GivenAReviewWithATriggerWord
            {
                [TestMethod]
                public void ReturnsACleanReview()
                {
                    var model = GetModel(8);
                    model.triggerWords = new List<string> { "horsefeathers", "movie" };
                    ArrangeReviewsForMovie(8, new List<Review> {
                            new Review { Comments="This movie is horsefeathers!"}
                        });
                    var reviewToTest = model.Reviews.First();
                    var resultOfCleaning = model.Clean(reviewToTest);
                    Assert.AreEqual("This ***** is *************!", resultOfCleaning);
                }
            }
        }

        private static MovieDetailsViewModel GetModel(int id)
        {
            api = A.Fake<IApi>();
            
            return new MovieDetailsViewModel(api, new Movie { ID = id });
        }

        private static void ArrangeReviewsForMovie(int id, List<Review> reviews)
        {
            A.CallTo(() => api.Reviews.GetWithHttpMessagesAsync(id,
                A<Dictionary<string, List<string>>>.Ignored,
                A<CancellationToken>.Ignored))
                    .Returns(new HttpOperationResponse<IList<Review>>
                    {
                        Body = reviews
                    });
        }
    }
}
