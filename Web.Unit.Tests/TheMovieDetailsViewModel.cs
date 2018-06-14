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
            Assert.AreEqual(2, model.Reviews.Count());
        }

		[TestMethod]
		public void HasAListOfDirtyWords()
		{
			var model = GetModel(4);
			CollectionAssert.AreEqual(new List<string> { "horsefeathers", "gherkin" }, model.Blacklist);

		}

		[TestClass]
		public class WhenCleaningAReview
		{
			[TestMethod]
			public void GivenAReviewWithAnEmptyString_ReturnsAnEmptyString()
			{
				AssertCleanReview("", "");
			}

			[TestMethod]
			public void GivenAReviewWithNoDirtyWords_ReturnsReview()
			{
				AssertCleanReview("good movie", "good movie");
			}

			[TestMethod]
			public void GivenAReviewWithOneDirtyWord_ReturnsACensoredReview()
			{
				AssertCleanReview("******* movie", "gherkin movie");
			}

			[TestMethod]
			public void GivenAReviewWithTwoDirtyWords_ReturnsACensoredReview()
			{
				AssertCleanReview("******* ************* hello", "gherkin horsefeathers hello");
			}

			private static void AssertCleanReview(string Expected, string ReviewComments)
			{
				var model = GetModel(3);
				Assert.AreEqual(Expected, model.Clean(ReviewComments));
			}
		}

        private static MovieDetailsViewModel GetModel(int id)
		{
			api = A.Fake<IApi>();
			ArrangeAListOfReviews(id, new List<Review> {
							new Review(),
							new Review()
						});

			return new MovieDetailsViewModel(api, new Movie { ID = id });
		}

		private static void ArrangeAListOfReviews(int movieId, List<Review> list)
		{
			A.CallTo(() => api.Reviews.GetWithHttpMessagesAsync(movieId,
							A<Dictionary<string, List<string>>>.Ignored,
							A<CancellationToken>.Ignored))
								.Returns(new HttpOperationResponse<IList<Review>>
								{
									Body = list
								});
		}
	}
}
