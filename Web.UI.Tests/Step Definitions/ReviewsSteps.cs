using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Web.UI.Tests.Step_Definitions
{
    [Binding]
    class ReviewsSteps : BaseSteps
    {
        [Given(@"A movie")]
        public void GivenAMovie()
        {
            _driver.Navigate().GoToUrl(_configuration.Get("UIBaseUrl"));
            _driver.FindElement(By.ClassName("Movie-details"));
        }

        [When(@"the user views the details page for a movie,")]
        public void WhenTheUserViewsTheDetailsPageForAMovie()
        {
            _driver.FindElement(By.ClassName("Movie-details")).Click();
        }

        [Then(@"the page shows a Reviews section that lists all of the review comments for that movie\.")]
        public void ThenThePageShowsAReviewsSectionThatListsAllOfTheReviewCommentsForThatMovie_()
        {
            Assert.IsTrue(_driver.FindElement(By.Id("reviews")).Displayed);
        }

    }
}
