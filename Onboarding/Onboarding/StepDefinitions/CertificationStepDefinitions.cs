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
    public class CertificationStepDefinitions : CommonDriver
    {
        [After]
        public void Dispose()
        {
            if (driver != null)
            {
                driver.Close();
            }
        }

        Certification CertificationObj = new Certification();
        [Given(@"I signed into the portal")]
        public void GivenISignedIntoThePortal()
        {
            //Open Chrome browser
            driver = new ChromeDriver();

            //signin
            LoginPage LoginPageObj = new LoginPage();
            LoginPageObj.LogInActions(driver);
        }
        [When(@"I click on tab Certifications")]
        public void WhenIClickOnTabCertifications()
        {
            CertificationObj.ClickAnyTab(driver, "Certifications");
        }

        [When(@"I add a '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenIAddA(string certificate, string from, string year)
        {
            CertificationObj.AddCertificate(driver, certificate, from, year);
        }

        [Then(@"I am able to see my '([^']*)' '([^']*)' '([^']*)' in my Certifications tab")]
        public void ThenIAmAbleToSeeMyInMyCertificationsTab(string certificate, string from, string year)
        {
            //Check message
            string assertMessage = certificate + " has been added to your certification";
            string message = CertificationObj.GetMessage(driver);
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Check certificate
            string addedCertificate = CertificationObj.GetCertificate(driver);
            Assert.That(addedCertificate == certificate, "Actual certificate and Expected certificate do not match.");

            //Check certifcation from
            string addedCertificationFrom = CertificationObj.GetCertificationFrom(driver);
            Assert.That(addedCertificationFrom == from, "Actual certification from and Expected certification from do not match.");

            //Check year
            string addedYear = CertificationObj.GetCertificationYear(driver);
            Assert.That(addedYear == year, "Actual certification year and Expected certification year do not match.");
        }

        [When(@"I edit a '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenIEditCertificate(string certificate, string from, string year)
        {
            CertificationObj.EditCertificate(driver, certificate, from, year);
        }

        [Then(@"The existing certificate is edited as '([^']*)' '([^']*)' '([^']*)'")]
        public void ThenTheExistingCertificateIsEditedAs(string certificate, string from, string year)
        {
            //Check message
            string assertMessage = certificate + " has been updated to your certification";
            string message = CertificationObj.GetMessage(driver);
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Check certifcate
            string editedCertificate = CertificationObj.GetCertificate(driver);
            Assert.That(editedCertificate == certificate, "Actual certificate and Expected certificate do not match.");

            //check certification form
            string editedCertificationFrom = CertificationObj.GetCertificationFrom(driver);
            Assert.That(editedCertificationFrom == from, "Actual certifier and Expected certifier do not match.");

            //check certification year
            string editedYear = CertificationObj.GetCertificationYear(driver);
            Assert.That(editedYear == year, "Actual certification year and Expected certification year do not match.");
        }

        [When(@"I delete '([^']*)'")]
        public void WhenIDeleteCertificate(string certificate)
        {
            CertificationObj.DeleteCertificate(driver, certificate);
        }

        [Then(@"The existing '([^']*)' should be deleted accordingly")]
        public void ThenTheExistingCertificateShouldBeDeletedAccordingly(string certificate)
        {
            //check message
            string assertMessage = certificate + " has been deleted from your certification";
            string message = CertificationObj.GetMessage(driver);
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //check certificate has been deleted successfully
            string deletedCertificate = CertificationObj.GetCertificate(driver);
            Assert.That(deletedCertificate != certificate, "Certificate hasn't been deleted.");
        }


    }
}
