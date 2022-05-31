using AutomationTestingProject.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTestingProject
{
    [TestClass]
    public class BookTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private ProfilePage profilePage;
        private BookPage bookPage;
        private BookStorePage bookStore;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/login");

            profilePage = loginPage.LoginApplication("user", "Password_1!");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            bookStore = profilePage.NavigateToBookStorePage();
            // implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            bookPage = bookStore.NavigateToBookPage("Learning JavaScript Design Patterns");
            //Helpers.WaitHelpers.WaitForElementToBeClickable(driver, bookPage.AddBook,5);
        }

        [TestMethod]
        public void User_Should_Add_A_Book_Successfully()
        {
            Assert.IsTrue(bookPage.Add_Book_Successfully());
        }

        [TestMethod]
        public void User_Tries_To_Add_A_Book_Already_Added()
        {
            Assert.IsTrue(bookPage.Book_Already_Added());
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
