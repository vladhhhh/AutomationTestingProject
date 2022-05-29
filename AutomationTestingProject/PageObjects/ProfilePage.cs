using AutomationTestingProject.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestingProject.PageObjects
{
    class ProfilePage
    {
        private IWebDriver driver;

        public ProfilePage (IWebDriver browser)
        {
            driver = browser;
        }

        private By BookStore = By.XPath("(//*[@id=\"item-2\"])[5]");
        private IWebElement BtnBookStore => driver.FindElement(BookStore);

        public BookStorePage NavigateToBookStorePage()
        {
            //driver.FindElement(By.XPath("(//*[@class=\"header-text\"])[6]")).Click();
            IWebElement elem = driver.FindElement(By.XPath("(//*[@class=\"element-group\"])[6]"));
            IWebElement dropdown = elem.FindElement(By.CssSelector("div"));
            WaitHelpers.WaitForElementToBeClickable(driver, BookStore);
            IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
            
            js.ExecuteScript("window.scrollBy(0,document.body.scrollHeight)");

            BtnBookStore.Click();

            return new BookStorePage(driver);
        }

    }
}
