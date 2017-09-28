using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using TotallyNotRobots.Movies.TestingTools;
using Web.UI.Tests.Page_Objects;

namespace Web.UI.Tests.Step_Definitions
{
    [Binding]
    class AddSteps : BaseSteps
    {
        HomePage _homePage;
        AddPage _addPage;

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            _homePage = new HomePage(_driver);
            _homePage.VisitHomepage();
        }

        [When(@"I add a new movie")]
        public void WhenIAddANewMovie()
        {
            _homePage.ClickAddMovie();
        }

        [Then(@"I am taken to the add movie screen")]
        public void ThenIAmTakenToTheAddMovieScreen()
        {
            _addPage = new AddPage(_driver);
            _addPage.VerifyMovieScreen();
        }

    }
}
