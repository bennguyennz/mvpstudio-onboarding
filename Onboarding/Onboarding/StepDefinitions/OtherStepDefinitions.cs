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
        Other OtherObj;
        LoginPage LoginPageObj;

        [Given(@"I signed into the portal successfully")]
        public void GivenISignedIntoThePortalSuccessfully()
        {
            //Open Chrome browser
            driver = new ChromeDriver();

            //Initiate objects
            OtherObj = new Other();
            LoginPageObj = new LoginPage();
            
            //signin
            LoginPageObj.LogInActions();
        }

        [Then(@"I am able to see my profile page")]
        public void ThenIAmAbleToSeeMyProfilePage()
        {
            string welcomeText = OtherObj.getWecomeText();
            Assert.That(welcomeText == "Hi Binh" | welcomeText == "Hi", "Actual welcome text and expected welcome text do not match");
            driver.Close();
        }
    }
}
