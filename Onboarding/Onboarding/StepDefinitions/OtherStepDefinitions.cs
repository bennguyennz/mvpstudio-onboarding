using NUnit.Framework;
using Onboarding.Pages;
using Onboarding.Pages.ProfilePages;
using Onboarding.Utilities;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Onboarding.StepDefinitions
{
    [Binding]
    public class OtherStepDefinitions : CommonDriver
    {
        [After]
        public void Dispose()
        {
            if (driver != null)
            {
                driver.Close();
            }
        }

        Other OtherObj = new Other();

        [Given(@"I signed into the portal successfully")]
        public void GivenISignedIntoThePortalSuccessfully()
        {
            //Open Chrome browser
            driver = new ChromeDriver();

            //signin
            LoginPage LoginPageObj = new LoginPage();
            LoginPageObj.LogInActions(driver);
        }

        [Then(@"I am able to see my profile page")]
        public void ThenIAmAbleToSeeMyProfilePage()
        {
            string welcomeText = OtherObj.getWecomeText(driver);
            Assert.That(welcomeText == "Hi Binh" | welcomeText == "Hi", "Actual welcome text and expected welcome text do not match");
        }

    }
}
