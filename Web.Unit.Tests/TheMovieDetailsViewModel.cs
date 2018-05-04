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
		static IApi _api;

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
					Assert.AreEqual("", model.Clean(""));
				}
			}

			[TestClass]
			public class GivenNoTriggerWords
			{
				[TestMethod]
				public void ReturnsTheReviewUnharmed()
				{
					var model = GetModel(11);
					var str = "This movie was meh.";
					var cleaned = model.Clean(str);
					Assert.AreEqual(str, cleaned);
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
						Assert.AreEqual("This movie was meh. Just meh.", 
							Clean("This movie was meh. Just meh."));
					}
				}

				[TestClass]
				public class GivenAReviewWithOneTriggerWord
				{
					[TestMethod]
					public void ReturnsTheCensoredReview()
					{
						Assert.AreEqual("Only a ********** would say that this movie was 'meh. Just meh.'", 
							Clean("Only a JiveTurkey would say that this movie was 'meh. Just meh.'"));
					}
				}

				[TestClass]
				public class GivenAReviewWithTriggerWords
				{
					[TestMethod]
					public void ReturnsTheCensoredReview()
					{
						Assert.AreEqual("Only a ********** would say that this movie was *************.", 
							Clean("Only a JiveTurkey would say that this movie was HorseFeathers."));
					}
				}

				static string Clean(string str)
				{
					var model = GetModel(12);
					model.TriggerWords.Add("HorseFeathers");
					model.TriggerWords.Add("JiveTurkey");
					return model.Clean(str);
				}
			}
		}

		private static MovieDetailsViewModel GetModel(int id)
		{
			_api = A.Fake<IApi>();
			ArrangeReviews(id, new List<Review> {
				new Review(),
				new Review()
			});
			return new MovieDetailsViewModel(_api, new Movie { ID = id });
		}

		private static void ArrangeReviews(int id, IList<Review> reviews)
		{
			A.CallTo(() => _api.Reviews.GetWithHttpMessagesAsync(id,
				A<Dictionary<string, List<string>>>.Ignored,
				A<CancellationToken>.Ignored))
					.Returns(new HttpOperationResponse<IList<Review>>
					{
						Body = reviews
					});
		}
	}
}
