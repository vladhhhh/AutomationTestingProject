using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestingProject.PageObjects
{
    class BookPage
    {
        private IWebDriver driver;
        public BookPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By Title => By.CssSelector("div[class=\"profile-wrapper\"]>div[id=\"title-wrapper\"]>div>label");
        private IWebElement TxtTitle => driver.FindElements(Title).ElementAt(1);
        private By AddBook => By.CssSelector("button[id=\"addNewRecordButton\"]");
        private IWebElement BtnAddBook => driver.FindElements(AddBook).ElementAt(1);

        private string LblBookAddedSuccessfully => "Book added to your collection.";
        private string LblBookAlreadyAdded => "Book already present in the your collection!";

        public bool Is_This_The_Right_Book(string title)
        {
            Helpers.WaitHelpers.WaitForElementToBeVisible(driver,Title);
            return title.Equals(TxtTitle.Text);
        }

        public bool Add_Book_Successfully()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,document.body.scrollHeight)");
            Helpers.WaitHelpers.WaitForElementToBeVisible(driver, AddBook);
            BtnAddBook.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            string message = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            return message.Equals(LblBookAddedSuccessfully);
        }

        public bool Book_Already_Added()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,document.body.scrollHeight)");
            Helpers.WaitHelpers.WaitForElementToBeVisible(driver, AddBook);

            BtnAddBook.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            string message = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            return message.Equals(LblBookAlreadyAdded);
        }

    }

}
