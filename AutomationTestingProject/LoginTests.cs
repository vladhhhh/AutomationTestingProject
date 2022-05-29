using AutomationTestingProject.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
namespace AutomationTestingProject
{
    [TestClass]
    public class LoginTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/login");

            // implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        [TestMethod]
        public void User_Should_Login_Successfully()
        {
            loginPage.LoginApplication("user", "Password_1!");
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id=\"userName-value\"]")).Text.Equals("user"));
        }

        [TestMethod]
        public void User_Should_Fail_Login_With_Wrong_UserName()
        {
            loginPage.LoginApplication("wronguser", "Password_1!");

            Assert.AreEqual("Invalid username or password!", loginPage.ErrorMessage);
        }

        [TestMethod]
        public void User_Should_Fail_Login_With_Wrong_Password()
        {
            loginPage.LoginApplication("user", "wrongPassword_1!");

            Assert.AreEqual("Invalid username or password!", loginPage.ErrorMessage);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
