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
    }
}
