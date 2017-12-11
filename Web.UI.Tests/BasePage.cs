using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Web.UI.Tests
{
    public class BasePage
    {

        public const int WAIT_SECONDS = 30;

        IWebDriver _Driver;

        public BasePage(IWebDriver driver)
        {
            this._Driver = driver;
        }

        public bool WaitUntilDisplayed(By locator, int maxWaitTime)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_Driver, System.TimeSpan.
FromSeconds(maxWaitTime));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return true;
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
                throw new Exception("The web driver waited " + maxWaitTime + " seconds to find " + locator + " and could not find it, on the following page: " + _Driver.Url);
            }
        }
    }
}
