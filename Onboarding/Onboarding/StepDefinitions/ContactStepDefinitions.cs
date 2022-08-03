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
    public class ContactStepDefinitions : CommonDriver
    {
        Contact ContactObj;
        LoginPage LoginPageObj;

        [Given(@"I logged into the web portal successfully")]
        public void GivenILoggedIntoTheWebPortalSuccessfully()
        {
            //Open Chrome browser
            driver = new ChromeDriver();
            
            //initiate obj
            ContactObj = new Contact();
            LoginPageObj = new LoginPage();

            //signin
            LoginPageObj.LogInActions();
        }

        [When(@"I add or edit a description")]
        public void WhenIAddOrEditADescription()
        {
            ContactObj.addDescription();
        }

        [Then(@"The description should be displayed texts same as I added")]
        public void ThenTheDescriptionShouldBeDisplayedTextsSameAsIAdded()
        {
            string message = ContactObj.GetMessage();
            Assert.That(message == "Description has been saved successfully", "Actual message and expected message do not match.");
            string addedDescription = ContactObj.GetAddedDesription();
            Assert.That(addedDescription == "I’m a motivated professional who is passionate about IT.", "Actual description and expected description does not match.");
            driver.Close();
        }

        [When(@"I edit my contact details '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenIEditMyContactDetails(string firstName, string lastName, string availability, string hours, string earnTarget)
        {
            ContactObj.EditMyContactDetails(firstName, lastName, availability, hours, earnTarget);
        }

        [Then(@"My contact details should be edited as '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void ThenMyContactDetailsShouldBeEditedAs(string firstName, string lastName, string availabilityType, string hour, string earnTarget)
        {
            //Check message
            string assertMessage = "Availability updated";
            string message = ContactObj.GetMessage();
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Check Full Name
            string assertFullName = firstName + " " + lastName;
            string editedFullName = ContactObj.GetFullName();
            Assert.That(editedFullName == assertFullName, "Actual full name and Expected full name do not match");

            //Check availability
            string editedAvailibilityType = ContactObj.GetAvailabilityType();
            Assert.That(editedAvailibilityType == availabilityType, "Actual availability type and Expected availability type do not match.");

            //Check Hours
            string editedHour = ContactObj.GetAvailityHour();
            Assert.That(editedHour == hour, "Actual availability hour and expected availability hour do not match.");

            //Check Earn Targe
            string editedEarnTarget = ContactObj.GetAvailityTarget();
            Assert.That(editedEarnTarget == earnTarget, "Actual earn target and Expected earn target do not match.");

            driver.Close();
        }
    }
}
