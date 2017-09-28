using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.UI.Tests.Page_Objects
{
    class AddPage : BasePage
    {

        public AddPage(IWebDriver Driver) : base(Driver) { }

        By titleField = By.Id("Title");

        internal void VerifyMovieScreen()
        {
            WaitUntilDisplayed(titleField, WAIT_SECONDS);
            Assert.IsTrue(IsDisplayed(titleField));
        }
    }
}
