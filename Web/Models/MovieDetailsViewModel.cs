using System;
using System.Collections;
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
			this.Blacklist = new List<string> { "horsefeathers", "gherkin" }; // TODO: Make a real list
		}

        public Movie Movie => _movie;

        public IEnumerable<Review> Reviews => _api.Reviews.Get(_movie.ID ?? 0);

		public List<string> Blacklist { get; set; }

		public string Clean(string reviewComments)
		{
			foreach (string s in Blacklist)
			{
				reviewComments = reviewComments.Replace(s, new String('*', s.Length));
			}
			return reviewComments;
		}
	}
}