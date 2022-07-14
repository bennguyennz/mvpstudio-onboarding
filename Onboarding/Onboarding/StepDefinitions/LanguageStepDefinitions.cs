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
    public class LanguageStepDefinitions: CommonDriver
    {
        Language LanguageObj;
        LoginPage LoginPageObj;

        public LanguageStepDefinitions()
        {
            LanguageObj = new Language(driver);
            LoginPageObj = new LoginPage(driver);
        }

        [Given(@"I signed in the portal")]
        public void GivenISignedInThePortal()
        {
            //Open Chrome browser
            driver = new ChromeDriver();

            //Initiate objects
            LanguageObj = new Language(driver);
            LoginPageObj = new LoginPage(driver);

            //signin
            LoginPageObj.LogInActions();
        }

        [When(@"I click on tab Languages")]
        public void WhenIClickOnTabLanguages()
        {
            LanguageObj.ClickAnyTab("Languages");
        }

        [When(@"I add a '([^']*)' at a '([^']*)'")]
        public void WhenIAddLanguage(string language, string languageLevel)
        {
            LanguageObj.AddALanguage(language, languageLevel);

        }

        [Then(@"The '([^']*)' with '([^']*)' should be added successfully")]
        public void ThenTheLanguageShouldBeAddedSuccessfully(string language, string languageLevel)
        {
            //Check success message
            string message = LanguageObj.GetMessage();
            string assertMessage = language + " has been added to your languages";
            Assert.That(message == assertMessage, "Actual message and Expected message do not match");

            //check language and language level are created successfully
            string addedLanguage = LanguageObj.GetLanguage();
            string addedLanguageLevel = LanguageObj.GetLanguageLevel();
            Assert.That(addedLanguage == language, "Actual language and Expected language do not match");
            Assert.That(addedLanguageLevel == languageLevel, "Actual language level and Expected language level do not match");
            driver.Close();
        }

        [When(@"I edit the last '([^']*)' at a different '([^']*)'")]
        public void WhenIEditTheLastLanguage(string language, string languageLevel)
        {
            LanguageObj.EditLanguage(language, languageLevel);
        }

        [Then(@"The '([^']*)' and '([^']*)' should be edited successfully")]
        public void ThenTheLanguageShouldBeEditedSuccessfully(string language, string languageLevel)
        {
            //Check message
            string message = LanguageObj.GetMessage();
            string assertMessage = language + " has been updated to your languages";
            Assert.That(message == assertMessage, "Actual message and Expected message do not match");

            //check if language and language level are updated successfully
            string editedLanguage = LanguageObj.GetLanguage();
            string editedLanguageLevel = LanguageObj.GetLanguageLevel();
            Assert.That(editedLanguage == language, "Actual language and Expected language do not match");
            Assert.That(editedLanguageLevel == languageLevel, "Actual language level and Expected language level do not match");
            driver.Close();
        }

        [When(@"I delete the last '([^']*)'")]
        public void WhenIDeleteTheLastLanguage(string language)
        {
            LanguageObj.DeleteLanguage(language);
        }

        [Then(@"The '([^']*)' should be deleted successfully")]
        public void ThenTheLanguageShouldBeDeletedSuccessfully(string language)
        {
            //Check message
            string message = LanguageObj.GetMessage();
            string assertMessage = language + " has been deleted from your languages";
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //check if language is deleted successfully
            string lastLanguage = LanguageObj.GetLanguage();
            Assert.That(lastLanguage != language, "Expected language has not been deleted.");
            driver.Close();
        }
    }
}
