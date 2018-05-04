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
	class ReviewsSteps
	{
		IWebDriver webDriver;
		[Given(@"A review")]
		public void GivenAReview()
		{
			webDriver = new ChromeDriver();
			webDriver.Navigate().GoToUrl("http://localhost:1235");
			webDriver.FindElement(By.ClassName("details-button")).Click();
		}


		[When(@"the user deletes a review")]
		public void WhenTheUserDeletesAReview()
		{
			webDriver.FindElement(By.ClassName("delete-button")).Click();
			webDriver.FindElement(By.ClassName("delete-confirm-button")).Click();
		}

		[Then(@"the app removes the review")]
		public void ThenTheAppRemovesTheReview()
		{
			Assert.AreEqual(1, webDriver.FindElements(By.ClassName("delete-button")).Count);
			webDriver.Quit();
		}
	}
}
