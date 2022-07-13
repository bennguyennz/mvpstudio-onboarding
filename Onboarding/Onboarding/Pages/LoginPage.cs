using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Onboarding.Pages
{
    public class LoginPage
    {
        public IWebDriver driver;
        LoginPage LoginPageObj;
        public LoginPage(IWebDriver driver)
        {
            //initial driver object
            this.driver = driver;
        }
        public void LogInActions()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/");

            try
            {
                //click Sign In
                IWebElement signInButton = driver.FindElement(By.LinkText("Sign In"));
                signInButton.Click();

                //Enter email address
                IWebElement emailAddress = driver.FindElement(By.XPath("//input[@placeholder='Email address']"));
                emailAddress.SendKeys("binhnguyen130320@gmail.com");

                //Enter password
                IWebElement password = driver.FindElement(By.Name("password"));
                password.SendKeys("123456");

                //Click Login
                IWebElement loginButton = driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));
                loginButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Portal does not launch.", ex.Message);
            }

        }
    }
}
