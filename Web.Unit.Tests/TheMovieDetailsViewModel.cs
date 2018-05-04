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
		private static IApi api;

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

		[TestClass]
		public class WhenCleaningAReview
		{
			[TestClass]
			public class EmptyReview
			{
				[TestMethod]
				public void EmptyString()
				{
					var model = GetModel(10);
					var cleaned = model.Clean("");
					Assert.AreEqual("", cleaned);
				}
			}

			[TestClass]
			public class GivenSomeTriggerWords
			{
				[TestClass]
				public class GivenAReviewWithNoTriggerWords
				{
					[TestMethod]
					public void ReturnsTheReviewUnharmed()
					{
						var model = GetModel(10);
						model.TriggerWords = new List<string>()
						{
							"HorseFeathers",
							"JiveTurkey"
						};

						var str = "This movie was meh.  Just meh.";
						var cleaned = model.Clean(str);
						Assert.AreEqual(str, cleaned);
					}
				}
			}
		}

        private static MovieDetailsViewModel GetModel(int id)
		{
			api = A.Fake<IApi>();
			List<Review> reviews = new List<Review> {
							new Review(),
							new Review()
						};
			arrangeReviews(id, reviews);
			return new MovieDetailsViewModel(api, new Movie { ID = id });
		}

		private static void arrangeReviews(int id, List<Review> reviews)
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
