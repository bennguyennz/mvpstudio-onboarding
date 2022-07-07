using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Onboarding.Pages;
using Onboarding.Utilities;
using System;
using TechTalk.SpecFlow;

namespace Onboarding.StepDefinitions
{
    [Binding]
    public class SellerProfileStepDefinitions: CommonDriver
    {
        [After]
        public void Dispose()
        {
            if (driver != null)
            {
                driver.Close();
            }
        }

        ProfilePage ProfilePageObj = new ProfilePage();

        [Given(@"I logged into the TradeYourSkills portal successfully")]
        public void GivenILoggedIntoTheTradeYourSkillsPortalSuccessfully()
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

            string welcomeText = ProfilePageObj.getWecomeText(driver);
            Assert.That(welcomeText == "Hi Binh" | welcomeText == "Hi", "Actual welcome text and expected welcome text do not match");
        }

        [When(@"I add or edit a description")]
        public void WhenIAddOrEditADescription()
        {
            ProfilePageObj.addDescription(driver);
        }

        [Then(@"The description should be displayed texts same as I added")]
        public void ThenTheDescriptionShouldBeDisplayedTextsSameAsIAdded()
        {
            string message = ProfilePageObj.GetMessage(driver);
            Assert.That(message == "Description has been saved successfully", "Actual message and expected message do not match.");
            string addedDescription = ProfilePageObj.GetAddedDesription(driver);
            Assert.That(addedDescription == "I’m a motivated professional who is passionate about IT.", "Actual description and expected description does not match.");
        }

        [When(@"I click on tab Languages")]
        public void WhenIClickOnTabLanguages()
        {
            ProfilePageObj.ClickAnyTab(driver, "Languages");
        }

        [When(@"I add a '([^']*)' at a '([^']*)'")]
        public void WhenIAddLanguage(string language, string languageLevel)
        {
            ProfilePageObj.AddALanguage(driver, language, languageLevel);

        }

        [Then(@"The '([^']*)' with '([^']*)' should be added successfully")]
        public void ThenTheLanguageShouldBeAddedSuccessfully(string language, string languageLevel)
        {
            //Check success message
            string message = ProfilePageObj.GetMessage(driver);
            string assertMessage = language + " has been added to your languages";
            Assert.That(message == assertMessage, "Actual message and Expected message do not match");

            //check language and language level are created successfully
            string addedLanguage = ProfilePageObj.GetLanguage(driver);
            string addedLanguageLevel = ProfilePageObj.GetLanguageLevel(driver);
            Assert.That(addedLanguage == language, "Actual language and Expected language do not match");
            Assert.That(addedLanguageLevel == languageLevel, "Actual language level and Expected language level do not match");
        }

        [When(@"I edit the last '([^']*)' at a different '([^']*)'")]
        public void WhenIEditTheLastLanguage(string language, string languageLevel)
        {
            ProfilePageObj.EditLanguage(driver, language, languageLevel);
        }

        [Then(@"The '([^']*)' and '([^']*)' should be edited successfully")]
        public void ThenTheLanguageShouldBeEditedSuccessfully(string language, string languageLevel)
        {
            //Check message
            string message = ProfilePageObj.GetMessage(driver);
            string assertMessage = language + " has been updated to your languages";
            Assert.That(message == assertMessage, "Actual message and Expected message do not match");

            //check if language and language level are updated successfully
            string editedLanguage = ProfilePageObj.GetLanguage(driver);
            string editedLanguageLevel = ProfilePageObj.GetLanguageLevel(driver);
            Assert.That(editedLanguage == language, "Actual language and Expected language do not match");
            Assert.That(editedLanguageLevel == languageLevel, "Actual language level and Expected language level do not match");
        }

        [When(@"I delete the last '([^']*)'")]
        public void WhenIDeleteTheLastLanguage(string language)
        {
            ProfilePageObj.DeleteLanguage(driver, language);
        }

        [Then(@"The '([^']*)' should be deleted successfully")]
        public void ThenTheLanguageShouldBeDeletedSuccessfully(string language)
        {
            //Check message
            string message = ProfilePageObj.GetMessage(driver);
            string assertMessage = language + " has been deleted from your languages";
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //check if language is deleted successfully
            string lastLanguage = ProfilePageObj.GetLanguage(driver);
            Assert.That(lastLanguage != language, "Expected language has not been deleted.");
        }

        [When(@"I click on tab Skills")]
        public void WhenIClickOnTabSkills()
        {
            ProfilePageObj.ClickAnyTab(driver, "Skills");
        }

        [When(@"I add '([^']*)' at '([^']*)'")]
        public void WhenIAddAt(string skill, string skillLevel)
        {
            ProfilePageObj.AddSkill(driver, skill, skillLevel);
        }

        [Then(@"The '([^']*)' with '([^']*)'should be added successfully")]
        public void ThenTheSkillAndSkillLevelShouldBeAddedSuccessfully(string skill, string skillLevel)
        {
            //assert message skill added successfully
            string assertMessage = skill + " has been added to your skills";
            string addedMessage = ProfilePageObj.GetMessage(driver);
            Assert.That(addedMessage == assertMessage, "Actual message and Expected message do not match.");

            //assert if skill and skill level has been added accordingly
            string addedSkill = ProfilePageObj.GetSkill(driver);
            string addedSkillLevel = ProfilePageObj.GetSkillLevel(driver);

            Assert.That(addedSkill == skill, "Actual skill and Expected skill do not match");
            Assert.That(addedSkillLevel == skillLevel, "Actual skill level and Expected skill level do not match");
        }

        [When(@"I edit last skill into '([^']*)' with '([^']*)'")]
        public void WhenIEditLasSkill(string skill, string skillLevel)
        {
            ProfilePageObj.EditSkill(driver, skill, skillLevel);
        }

        [Then(@"'([^']*)' with '([^']*)' should be edited successfully")]
        public void ThenTheSkillShouldBeEditedSuccessfully(string skill, string skillLevel)
        {
            //Check if popup message is correct
            string assertMessage = skill + " has been updated to your skills";
            string message = ProfilePageObj.GetMessage(driver);
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Check if skill and skill level have been updated successfully
            string editedSkill = ProfilePageObj.GetSkill(driver);
            string editedSkillLevel = ProfilePageObj.GetSkillLevel(driver);

            Assert.That(editedSkill == skill, "Actual skill and Expected skill do not match.");
            Assert.That(editedSkillLevel == skillLevel, "Actual skill level and Expected skill level do not match.");
        }

        [When(@"I delete a '([^']*)'")]
        public void WhenIDeleteSkill(string skill)
        {
            ProfilePageObj.DeleteSkill(driver, skill);
        }

        [Then(@"The '([^']*)' should be deleted accordingly")]
        public void ThenTheSkillShouldBeDeletedAccordingly(string skill)
        {
            //Check if popup message is correct
            string assertMessage = skill + " has been deleted";
            string message = ProfilePageObj.GetMessage(driver);
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Check if skill has been deleted
            string lastSkill = ProfilePageObj.GetSkill(driver);
            Assert.That(lastSkill != skill, "Expected Skill has not been deleted successfully");
        }

        [When(@"I click on tab Education")]
        public void WhenIClickOnTabEducation()
        {
            ProfilePageObj.ClickAnyTab(driver, "Education");
        }

        [When(@"I add my education including '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenIAddMyEducationIncluding(string country, string university, string title, string degree, string graduationYear)
        {
            ProfilePageObj.AddEducation(driver, country, university, title, degree, graduationYear);
        }

        [Then(@"I am able to see my education details including '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenIAmAbleToSeeMyEducationDetailsIncluding(string country, string university, string title, string degree, string graduationYear)
        {
            //Check if popup message is correct
            string assertMessage = "Education has been added";
            string message = ProfilePageObj.GetMessage(driver);
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Assert country
            string addedCountry = ProfilePageObj.GetCountry(driver);
            Assert.That(addedCountry == country, "Actual country and Expected country do not match.");

            //Check university
            string addedUniversity = ProfilePageObj.GetUniversity(driver);
            Assert.That(addedUniversity == university, "Actual university and Expected university do not match.");

            //Check title
            string addedTitle = ProfilePageObj.GetTitle(driver);
            Assert.That(addedTitle == title, "Actual title and Expected title do not match.");

            //check degree
            string addedDegree = ProfilePageObj.GetDegree(driver);
            Assert.That(addedDegree == degree, "Actual degree and Expected degree do not match.");

            //Check graduationYear
            string addedGraduationYear = ProfilePageObj.GetGraduationYear(driver);
            Assert.That(addedGraduationYear == graduationYear, "Actual graduation year and Expected graduation year do not match.");
        }


        [When(@"I edit education including '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenIEditEducationIncluding(string country, string university, string title, string degree, string graduationYear)
        {
            ProfilePageObj.EditEducation(driver, country, university, title, degree, graduationYear);
        }

        [Then(@"The education should be displayed as '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenTheEducationShouldBeDisplayedAs(string country, string university, string title, string degree, string graduationYear)
        {
            //Check if popup message is correct
            string assertMessage = "Education as been updated";
            string message = ProfilePageObj.GetMessage(driver);
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Assert country
            string updatedCountry = ProfilePageObj.GetCountry(driver);
            Assert.That(updatedCountry == country, "Actual country and Expected country do not match.");

            //Check university
            string updatedUniversity = ProfilePageObj.GetUniversity(driver);
            Assert.That(updatedUniversity == university, "Actual university and Expected university do not match.");

            //Check title
            string updatedTitle = ProfilePageObj.GetTitle(driver);
            Assert.That(updatedTitle == title, "Actual title and Expected title do not match.");

            //check degree
            string updatedDegree = ProfilePageObj.GetDegree(driver);
            Assert.That(updatedDegree == degree, "Actual degree and Expected degree do not match.");

            //Check graduationYear
            string updatedGraduationYear = ProfilePageObj.GetGraduationYear(driver);
            Assert.That(updatedGraduationYear == graduationYear, "Actual graduation year and Expected graduation year do not match.");
        }

        [When(@"I delete education by '([^']*)'")]
        public void WhenIDeleteEducationByUniversity(string university)
        {
            ProfilePageObj.DeleteEducation(driver, university);
        }

        [Then(@"The education by that '([^']*)' should be deleted successfully")]
        public void ThenTheEducationByThatShouldBeDeletedSuccessfully(string university)
        {
            //Check if popup message is correct
            string assertMessage = "Education entry successfully removed";
            string message = ProfilePageObj.GetMessage(driver);
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Check university is deleted successfully
            string deletedUniversity = ProfilePageObj.GetUniversity(driver);
            Assert.That(deletedUniversity != university, "University has not been deleted successfully");
        }

        [When(@"I click on tab Certifications")]
        public void WhenIClickOnTabCertifications()
        {
            ProfilePageObj.ClickAnyTab(driver, "Certifications");
        }

        [When(@"I add a '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenIAddA(string certificate, string from, string year)
        {
            ProfilePageObj.AddCertificate(driver, certificate, from, year);
        }

        [Then(@"I am able to see my '([^']*)' '([^']*)' '([^']*)' in my Certifications tab")]
        public void ThenIAmAbleToSeeMyInMyCertificationsTab(string certificate, string from, string year)
        {
            //Check message
            string assertMessage = certificate + " has been added to your certification";
            string message = ProfilePageObj.GetMessage(driver);
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Check certificate
            string addedCertificate = ProfilePageObj.GetCertificate(driver);
            Assert.That(addedCertificate == certificate, "Actual certificate and Expected certificate do not match.");

            //Check certifcation from
            string addedCertificationFrom = ProfilePageObj.GetCertificationFrom(driver);
            Assert.That(addedCertificationFrom == from, "Actual certification from and Expected certification from do not match.");

            //Check year
            string addedYear = ProfilePageObj.GetCertificationYear(driver);
            Assert.That(addedYear == year, "Actual certification year and Expected certification year do not match.");
        }

        [When(@"I edit a '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenIEditCertificate(string certificate, string from, string year)
        {
            ProfilePageObj.EditCertificate(driver, certificate, from, year);
        }

        [Then(@"The existing certificate is edited as '([^']*)' '([^']*)' '([^']*)'")]
        public void ThenTheExistingCertificateIsEditedAs(string certificate, string from, string year)
        {
            //Check message
            string assertMessage = certificate + " has been updated to your certification";
            string message = ProfilePageObj.GetMessage(driver);
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Check certifcate
            string editedCertificate = ProfilePageObj.GetCertificate(driver);
            Assert.That(editedCertificate == certificate, "Actual certificate and Expected certificate do not match.");

            //check certification form
            string editedCertificationFrom = ProfilePageObj.GetCertificationFrom(driver);
            Assert.That(editedCertificationFrom == from, "Actual certifier and Expected certifier do not match.");

            //check certification year
            string editedYear = ProfilePageObj.GetCertificationYear(driver);
            Assert.That(editedYear == year, "Actual certification year and Expected certification year do not match.");
        }

        [When(@"I delete '([^']*)'")]
        public void WhenIDeleteCertificate(string certificate)
        {
            ProfilePageObj.DeleteCertificate(driver, certificate);
        }

        [Then(@"The existing '([^']*)' should be deleted accordingly")]
        public void ThenTheExistingCertificateShouldBeDeletedAccordingly(string certificate)
        {
            //check message
            string assertMessage = certificate + " has been deleted from your certification";
            string message = ProfilePageObj.GetMessage(driver);
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //check certificate has been deleted successfully
            string deletedCertificate = ProfilePageObj.GetCertificate(driver);
            Assert.That(deletedCertificate != certificate, "Certificate hasn't been deleted.");
        }

        [When(@"I edit my contact details '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenIEditMyContactDetails(string firstName, string lastName, string availability, string hours, string earnTarget)
        {
            ProfilePageObj.EditMyContactDetails(driver, firstName, lastName, availability, hours, earnTarget);
        }

        [Then(@"My contact details should be edited as '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void ThenMyContactDetailsShouldBeEditedAs(string firstName, string lastName, string availabilityType, string hour, string earnTarget)
        {
            //Check Full Name
            string assertFullName = firstName + " " + lastName;
            string editedFullName = ProfilePageObj.GetFullName(driver);
            Assert.That(editedFullName == assertFullName, "Actual full name and Expected full name do not match");

            //Check availability
            string editedAvailibilityType = ProfilePageObj.GetAvailabilityType(driver);
            Assert.That(editedAvailibilityType == availabilityType, "Actual availability type and Expected availability type do not match.");

            //Check Hours
            string editedHour = ProfilePageObj.GetAvailityHour(driver);
            Assert.That(editedHour == hour, "Actual availability hour and expected availability hour do not match.");

            //Check Earn Targe
            string editedEarnTarget = ProfilePageObj.GetAvailityTarget(driver);
            Assert.That(editedEarnTarget == earnTarget, "Actual earn target and Expected earn target do not match.");
        }
    }
}
