using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Onboarding.Pages;
using Onboarding.Utilities;
using TechTalk.SpecFlow;
using Onboarding.Pages.ProfilePages;

namespace Onboarding.StepDefinitions
{
    [Binding]
    public class EducationStepDefinitions : CommonDriver
    {

        [After]
        public void Dispose()
        {
            if (driver != null)
            {
                driver.Close();
            }
        }

        Education EducationObj = new Education();

        [Given(@"I logged into the portal")]
        public void GivenILoggedIntoThePortal()
        {
            //Open Chrome browser
            driver = new ChromeDriver();

            //signin
            LoginPage LoginPageObj = new LoginPage();
            LoginPageObj.LogInActions(driver);
        }


        [When(@"I click on tab Education")]
        public void WhenIClickOnTabEducation()
        {
            EducationObj.ClickAnyTab(driver, "Education");
        }

        [When(@"I add my education including '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenIAddMyEducationIncluding(string country, string university, string title, string degree, string graduationYear)
        {
            EducationObj.AddEducation(driver, country, university, title, degree, graduationYear);
        }

        [Then(@"I am able to see my education details including '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenIAmAbleToSeeMyEducationDetailsIncluding(string country, string university, string title, string degree, string graduationYear)
        {
            //Check if popup message is correct
            string assertMessage = "Education has been added";
            string message = EducationObj.GetMessage(driver);
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Assert country
            string addedCountry = EducationObj.GetCountry(driver);
            Assert.That(addedCountry == country, "Actual country and Expected country do not match.");

            //Check university
            string addedUniversity = EducationObj.GetUniversity(driver);
            Assert.That(addedUniversity == university, "Actual university and Expected university do not match.");

            //Check title
            string addedTitle = EducationObj.GetTitle(driver);
            Assert.That(addedTitle == title, "Actual title and Expected title do not match.");

            //check degree
            string addedDegree = EducationObj.GetDegree(driver);
            Assert.That(addedDegree == degree, "Actual degree and Expected degree do not match.");

            //Check graduationYear
            string addedGraduationYear = EducationObj.GetGraduationYear(driver);
            Assert.That(addedGraduationYear == graduationYear, "Actual graduation year and Expected graduation year do not match.");
        }

        [When(@"I edit education including '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenIEditEducationIncluding(string country, string university, string title, string degree, string graduationYear)
        {
            EducationObj.EditEducation(driver, country, university, title, degree, graduationYear);
        }

        [Then(@"The education should be displayed as '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenTheEducationShouldBeDisplayedAs(string country, string university, string title, string degree, string graduationYear)
        {
            //Check if popup message is correct
            string assertMessage = "Education as been updated";
            string message = EducationObj.GetMessage(driver);
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Assert country
            string updatedCountry = EducationObj.GetCountry(driver);
            Assert.That(updatedCountry == country, "Actual country and Expected country do not match.");

            //Check university
            string updatedUniversity = EducationObj.GetUniversity(driver);
            Assert.That(updatedUniversity == university, "Actual university and Expected university do not match.");

            //Check title
            string updatedTitle = EducationObj.GetTitle(driver);
            Assert.That(updatedTitle == title, "Actual title and Expected title do not match.");

            //check degree
            string updatedDegree = EducationObj.GetDegree(driver);
            Assert.That(updatedDegree == degree, "Actual degree and Expected degree do not match.");

            //Check graduationYear
            string updatedGraduationYear = EducationObj.GetGraduationYear(driver);
            Assert.That(updatedGraduationYear == graduationYear, "Actual graduation year and Expected graduation year do not match.");
        }

        [When(@"I delete education by '([^']*)'")]
        public void WhenIDeleteEducationByUniversity(string university)
        {
            EducationObj.DeleteEducation(driver, university);
        }

        [Then(@"The education by that '([^']*)' should be deleted successfully")]
        public void ThenTheEducationByThatShouldBeDeletedSuccessfully(string university)
        {
            //Check if popup message is correct
            string assertMessage = "Education entry successfully removed";
            string message = EducationObj.GetMessage(driver);
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Check university is deleted successfully
            string deletedUniversity = EducationObj.GetUniversity(driver);
            Assert.That(deletedUniversity != university, "University has not been deleted successfully");
        }
    }
}
