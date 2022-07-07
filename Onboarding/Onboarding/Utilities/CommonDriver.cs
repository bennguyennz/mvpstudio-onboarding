using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onboarding.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace Onboarding.Utilities
{
    [TestFixture]
    public class CommonDriver
    {
        public IWebDriver driver;

        LoginPage loginPageObj = new LoginPage();
        [OneTimeSetUp]
        public void LoginActions()
        {
            //open chrome browser
            driver = new ChromeDriver();
            loginPageObj.LogInActions(driver);
        }
        [OneTimeTearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }

    }
}
