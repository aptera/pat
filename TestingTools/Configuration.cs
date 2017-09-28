using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace TotallyNotRobots.Movies.TestingTools
{
    public class Configuration
    {
        readonly TestContext _context;

        public Configuration(TestContext context)
        {
            _context = context;
        }

        public string Get(string settingName)
        {
            return _context?.Properties[settingName]?.ToString() ??
                ConfigurationManager.AppSettings[settingName];
        }
    }
}
