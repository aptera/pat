using System;
using System.Configuration;

namespace TotallyNotRobots.Movies.Web.ApiClient
{
    public class ConfiguredApiClient : Api
    {
        public ConfiguredApiClient()
            : base(new Uri(ConfigurationManager.AppSettings["web:ApiBaseUrl"]))
        { }
    }
}