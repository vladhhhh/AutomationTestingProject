using AutomationTestingProject.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationTestingProject
{
    [TestClass]
    public class BookstoreTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private ProfilePage profilePage;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/login");

            profilePage = loginPage.LoginApplication("user", "Password_1!");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            profilePage.NavigateToBookStorePage();
            // implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        [TestMethod]
        public void If_Book_Exists()
        {
            var bookstore = new BookStorePage(driver);
            var bookpage = bookstore.NavigateToBookPage("Learning JavaScript Design Patterns");
            
            Assert.IsTrue(bookpage.Is_This_The_Right_Book("Learning JavaScript Design Patterns"));

        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
