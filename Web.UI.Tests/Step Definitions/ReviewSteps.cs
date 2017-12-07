using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Web.UI.Tests.Step_Definitions
{
    [Binding]
    class ReviewSteps : BaseSteps
    {
        IWebDriver _driver;
        By _detailsButton = By.ClassName("details-button");

        [Given(@"a movie")]
        public void GivenAMovie()
        {
            ChromeOptions option = new ChromeOptions();
            if (bool.Parse(_configuration.Get("IsHeadlessBrowser")))
            {
                option.AddArgument("--headless");
            }
            option.AddArgument("--start-maximized");
            _driver = new ChromeDriver(option);
            _driver.Navigate().GoToUrl(_configuration.Get("UIBaseUrl"));

            Assert.IsTrue(_driver.FindElement(_detailsButton).Displayed);
        }

        [When(@"the user views the details page for a movie")]
        public void WhenTheUserViewsTheDetailsPageForAMovie()
        {
            _driver.FindElement(_detailsButton).Click();
        }

        [Then(@"the page shows a Reviews section that lists all of the review comments for that movie")]
        public void ThenThePageShowsAReviewsSectionThatListsAllOfTheReviewCommentsForThatMovie()
        {
            Assert.IsTrue(_driver.FindElement(By.ClassName("btn-warning")).Displayed);
            _driver.Quit();
        }

    }
}
