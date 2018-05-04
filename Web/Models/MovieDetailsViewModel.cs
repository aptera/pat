using System.Collections.Generic;
using TotallyNotRobots.Movies.Web.ApiClient;
using TotallyNotRobots.Movies.Web.ApiClient.Models;

namespace TotallyNotRobots.Movies.Web.Models
{
	public class MovieDetailsViewModel
	{
		readonly IApi _api;
		readonly Movie _movie;

		public MovieDetailsViewModel(IApi api, Movie movie)
		{
			_api = api;
			_movie = movie;
		}

		public Movie Movie => _movie;

		public IEnumerable<Review> Reviews => _api.Reviews.Get(_movie.ID ?? 0);

		public ICollection<string> TriggerWords { get; set; } = new List<string>();

		public string Clean(string comments)
		{
			foreach (var word in TriggerWords)
				comments = Censor(comments, word);

			return comments;
		}

		static string Censor(string content, string word)
		{
			return content.Replace(word, new string('*', word.Length));
		}
	}
}