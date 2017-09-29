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

        [TestMethod]
        public void HasAMovie()
        {
            Assert.AreEqual(5, GetModel(5).Movie.ID);
        }

        [TestMethod]
        public void LoadsTheReviewsFromTheAPI()
        {
            var model = GetModel(5);
            Assert.AreEqual(2, model.Reviews.Count());
        }

        private static MovieDetailsViewModel GetModel(int id)
        {
            var api = A.Fake<IApi>();
            A.CallTo(() => api.Reviews.GetWithHttpMessagesAsync(id,
                A<Dictionary<string, List<string>>>.Ignored,
                A<CancellationToken>.Ignored))
                    .Returns(new HttpOperationResponse<IList<Review>>
                    {
                        Body = new List<Review> {
                            new Review(),
                            new Review()
                        }
                    });
            return new MovieDetailsViewModel(api, new Movie { ID = id });
        }
    }
}
