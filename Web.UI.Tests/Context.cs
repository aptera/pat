using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotallyNotRobots.Movies.TestingTools;

namespace Web.UI.Tests
{
    [TestClass]
    public class Context
    {
        static TestContext _context;
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            _context = context;
        }

        public static Configuration GetConfiguration()
        {
            return new Configuration(_context);
        }
    }
}
