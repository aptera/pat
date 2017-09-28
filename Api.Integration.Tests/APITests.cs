using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TotallyNotRobots.Movies.TestingTools;

namespace TotallyNotRobots.Movies.Api.Integration.Tests
{
    [TestClass]
    public class APITests
    {
        protected static ApiClient.Api _api;
        protected static Configuration _configuration;

        [AssemblyInitialize]
        public static void BeforeAll(TestContext context)
        {
            _configuration = new Configuration(context);
        }

        [TestInitialize]
        public void BeforeEach()
        {
            _api = new ApiClient.Api(new Uri(_configuration.Get("apiBaseUrl")));
        }

    }
}
