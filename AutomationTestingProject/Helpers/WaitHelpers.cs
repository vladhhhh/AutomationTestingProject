using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace AutomationTestingProject.Helpers
{
    public static class WaitHelpers
    {
        public static void WaitForElementToBeVisible(IWebDriver driver, By by, int timeSpan = 2)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpan));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
            
        }

        public static void WaitForElementToBeClickable(IWebDriver driver, By by, int timeSpan = 2)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpan));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));

        }

        public static void WaitForElementToBeVisibleCustom(IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(webDriver => webDriver.FindElement(by).Displayed && webDriver.FindElement(by).Enabled);
        }
    }
}
