using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestingProject.PageObjects
{
    class BookStorePage
    {
        private IWebDriver driver;

        public BookStorePage(IWebDriver browser)
        {
            driver = browser;
        }

        //private By UserName = By.Id("userName");
        //private IWebElement TxtUserName => driver.FindElement(UserName);

        //private By Password = By.Id("password");
        //private IWebElement TxtPassword => driver.FindElement(Password);

        //private By Login = By.Id("login");
        //private IWebElement BtnLogin => driver.FindElement(Login);

        private By Books = By.CssSelector("div[class=\"action-buttons\"]");
        private IList<IWebElement> LinkBooks => driver.FindElements(Books);

        public BookPage FindBook(string bookNameToAdd)
        {
            Helpers.WaitHelpers.WaitForElementToBeClickable(driver, Books,5);
            string bookName;
            foreach (var bookLink in LinkBooks)
            {
                bookName = bookLink.FindElement(By.TagName("a")).Text;
                if (bookName == bookNameToAdd)
                {
                    bookLink.FindElement(By.TagName("a")).Click();
                    return new BookPage(driver);
                }
            }
        }
    }
}
