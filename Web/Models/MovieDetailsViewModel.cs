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
        public List<string> triggerWords { get; set; }

        public MovieDetailsViewModel(IApi api, Movie movie)
        {
            _api = api;
            _movie = movie;
        }

        public Movie Movie => _movie;

        public IEnumerable<Review> Reviews => _api.Reviews.Get(_movie.ID ?? 0);

        public string Clean(Review reviewToTest)
        {
            string cleanedReview = reviewToTest.Comments;
            foreach(string Word in triggerWords)
            {
                cleanedReview = cleanedReview.Replace(Word, GetTriggerWordReplacement(Word));
            }
            return cleanedReview;
        }

        private static string GetTriggerWordReplacement(string Word)
        {
            return new string('*', Word.Length);
        }
    }
}