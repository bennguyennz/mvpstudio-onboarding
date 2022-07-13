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
        
        [OneTimeSetUp]
        public void LoginActions()
        {
            //Open Chrome browser
            driver = new ChromeDriver();

            //Signin
            LoginPage loginPageObj = new LoginPage(driver);
            loginPageObj.LogInActions();
        }
        [OneTimeTearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }

    }
}
