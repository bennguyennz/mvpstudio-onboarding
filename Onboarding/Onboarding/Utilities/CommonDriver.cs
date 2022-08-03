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
        [ThreadStatic]
        public static IWebDriver driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}
