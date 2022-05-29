using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestingProject.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By UserName = By.Id("userName");
        private IWebElement TxtUserName => driver.FindElement(UserName);

        private By Password = By.Id("password");
        private IWebElement TxtPassword => driver.FindElement(Password);

        private By Login = By.Id("login");
        private IWebElement BtnLogin => driver.FindElement(Login);

        public ProfilePage LoginApplication(string username, string password)
        {
            //WaitHelpers.WaitForElementToBeVisible(driver, Email);

            TxtUserName.SendKeys(username);
            TxtPassword.SendKeys(password);
            BtnLogin.Click();

            return new ProfilePage(driver);

        }

        private By ErrorMessageDisplayed = By.XPath("//*[@id=\"name\"]");
        private IWebElement LblErrorMessage => driver.FindElement(ErrorMessageDisplayed);

        public string ErrorMessage => LblErrorMessage.Text;
    }
}
