using System;
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

		public List<string> TriggerWords { get; set; }

		public string Clean(string comments)
		{
			return comments;
		}
	}
}