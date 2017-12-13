using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Web.UI.Tests.Step_Definitions
{
    [Binding]
    class ReviewsSteps : BaseSteps
    {
        IWebDriver driver;

        [Given(@"a review")]
        public void GivenAReview()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(_configuration.Get("UIBaseUrl"));
            driver.FindElement(By.ClassName("details-button")).Click();
        }

        [When(@"the user deletes a review")]
        public void WhenTheUserDeletesAReview()
        {
            driver.FindElement(By.ClassName("delete-button")).Click();
            driver.FindElement(By.ClassName("delete-confirm-button")).Click();
        }

        [Then(@"the app deletes the review")]
        public void ThenTheAppDeletesTheReview()
        {
            Assert.AreEqual(0, driver.FindElements(By.ClassName("delete-button")).Count);
        }

    }
}
