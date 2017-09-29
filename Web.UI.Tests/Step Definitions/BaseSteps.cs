using TotallyNotRobots.Movies.TestingTools;

namespace Web.UI.Tests.Step_Definitions
{
    class BaseSteps
    {
        protected Configuration _configuration;

        public BaseSteps()
        {
            _configuration = Context.GetConfiguration();
        }
    }

}
