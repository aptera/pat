using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.UI.Tests.Page_Objects
{
    class BasePage
    {
        public IWebDriver _Driver;
        protected const int WAIT_SECONDS = 10;

        public BasePage(IWebDriver Driver)
        {
            this._Driver = Driver;
        }

        public bool WaitUntilDisplayed(By locator, int maxWaitTime)
        {
            WebDriverWait wait = new WebDriverWait(_Driver, TimeSpan.FromSeconds(maxWaitTime));
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return true;
            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {
                return false;
            }
        }

        public void Click(By locator)
        {
            Find(locator).Click();
        }

        public IWebElement Find(By locator)
        {
            return _Driver.FindElement(locator);
        }

        public bool IsDisplayed(By locator)
        {
            return Find(locator).Displayed;
        }

        public void Visit(string url)
        {
            _Driver.Navigate().GoToUrl(url);
        }
        protected string ReadElementText(IWebElement element)
        {
            return element.Text;
        }
    }
}
