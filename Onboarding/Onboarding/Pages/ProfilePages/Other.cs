using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Onboarding.Utilities;
using OpenQA.Selenium.Interactions;


namespace Onboarding.Pages.ProfilePages
{
    public class Other
    {
        public string getWecomeText(IWebDriver driver)
        {
            string wecomeTextXPath = "/html/body/div[1]/div/div[1]/div[2]/div/span";
            WaitHelpers.WaitToBeVisible(driver, "XPath", wecomeTextXPath, 3);
            IWebElement welcomeText = driver.FindElement(By.XPath(wecomeTextXPath));
            return welcomeText.Text;
        }
    }
}
