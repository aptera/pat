using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using TotallyNotRobots.Movies.TestingTools;

namespace Web.UI.Tests.Step_Definitions
{
    class BaseSteps : Steps
    {
        protected Configuration _configuration;
        protected IWebDriver _driver;

        public BaseSteps()
        {
            _configuration = Context.GetConfiguration();
        }

        [BeforeScenario("Global")]
        public void BeforeScenario()
        {
            ChromeOptions option = new ChromeOptions();
            if (bool.Parse(_configuration.Get("IsHeadlessBrowser")))
            {
                option.AddArgument("--headless");
            }
            _driver = new ChromeDriver(option);
            _driver.Manage().Window.Maximize();
        }

        [AfterScenario("Global")]
        public void AfterScenario()
        {
            _driver.Quit();
        }
    }

}
