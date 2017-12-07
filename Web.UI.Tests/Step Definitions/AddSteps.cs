using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TotallyNotRobots.Movies.TestingTools;

namespace Web.UI.Tests.Step_Definitions
{
    [Binding]
    class AddSteps : BaseSteps
    {
        IWebDriver _Driver;


        [BeforeScenario("Add")]
        public void BeforeAddScenario()
        {
            ChromeOptions option = new ChromeOptions();
            if (bool.Parse(_configuration.Get("IsHeadlessBrowser")))
            {
                option.AddArgument("--headless");
            }
            option.AddArgument("--start-maximized");
            _Driver = new ChromeDriver(option);
        }

        [AfterScenario("Add")]
        public void AfterAddScenario()
        {
            _Driver.Quit();
        }

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            _Driver.Navigate().GoToUrl(_configuration.Get("UIBaseUrl"));
        }

        [When(@"I add a new movie")]
        public void WhenIAddANewMovie()
        {
            _Driver.FindElement(By.ClassName("btn-warning")).Click();
        }

        [Then(@"I am taken to the add movie screen")]
        public void ThenIAmTakenToTheAddMovieScreen()
        {
            By titleField = By.Id("Title");
            Assert.IsTrue(_Driver.FindElement(titleField).Displayed);
        }

    }
}
