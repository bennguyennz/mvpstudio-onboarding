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
using static Onboarding.Utilities.CommonDriver;


namespace Onboarding.Pages.ProfilePages
{

    public class Other
    {
        Other OtherObj;

        //Finding for elements
        private IWebElement welcomeText => driver.FindElement(By.XPath(e_wecomeText));

        //element for wait
        private string e_wecomeText = "/html/body/div[1]/div/div[1]/div[2]/div/span";

        public string getWecomeText()
        {

            WaitHelpers.WaitToBeVisible(driver, "XPath", e_wecomeText, 3);
            return welcomeText.Text;
        }
    }
}
