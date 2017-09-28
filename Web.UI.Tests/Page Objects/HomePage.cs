using OpenQA.Selenium;
using TotallyNotRobots.Movies.TestingTools;

namespace Web.UI.Tests.Page_Objects
{

    class HomePage : BasePage
    {
        public HomePage(IWebDriver Driver) : base(Driver)
        {
        }

        public Configuration _configuration;
        By addMovieButton = By.LinkText("Add New");


        internal void VisitHomepage()
        {
            _configuration = Context.GetConfiguration();
            _Driver.Navigate().GoToUrl(_configuration.Get("UIBaseUrl"));
        }

        internal void ClickAddMovie()
        {
            WaitUntilDisplayed(addMovieButton, WAIT_SECONDS);
            Click(addMovieButton);
        }
    }
}