using NUnit.Framework;
using Onboarding.Pages;
using Onboarding.Pages.ProfilePages;
using Onboarding.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Onboarding.StepDefinitions
{
    [Binding]
    public class CertificationStepDefinitions : CommonDriver
    {
        //Define Pages and Objects
        Certification CertificationObj;
        LoginPage LoginPageObj;

        [Given(@"I signed into the portal")]
        public void GivenISignedIntoThePortal()
        {
            //Open Chrome browser
            driver = new ChromeDriver();
            CertificationObj = new Certification(driver);

            //signin
            LoginPageObj = new LoginPage(driver);
            LoginPageObj.LogInActions();
        }


        [When(@"I click on tab Certifications")]
        public void WhenIClickOnTabCertifications()
        {
            CertificationObj.ClickOnTabCertifications();
        }

        [When(@"I add a '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenIAddA(string certificate, string from, string year)
        {
            CertificationObj.AddCertificate(certificate, from, year);
        }

        [Then(@"I am able to see my '([^']*)' '([^']*)' '([^']*)' in my Certifications tab")]
        public void ThenIAmAbleToSeeMyInMyCertificationsTab(string certificate, string from, string year)
        {
            //Check message
            string assertMessage = certificate + " has been added to your certification";
            string message = CertificationObj.GetMessage();
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Check certificate
            string addedCertificate = CertificationObj.GetCertificate();
            Assert.That(addedCertificate == certificate, "Actual certificate and Expected certificate do not match.");

            //Check certifcation from
            string addedCertificationFrom = CertificationObj.GetCertificationFrom();
            Assert.That(addedCertificationFrom == from, "Actual certification from and Expected certification from do not match.");

            //Check year
            string addedYear = CertificationObj.GetCertificationYear();
            Assert.That(addedYear == year, "Actual certification year and Expected certification year do not match.");
        }

        [When(@"I edit a '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenIEditCertificate(string certificate, string from, string year)
        {
            CertificationObj.EditCertificate(certificate, from, year);
        }

        [Then(@"The existing certificate is edited as '([^']*)' '([^']*)' '([^']*)'")]
        public void ThenTheExistingCertificateIsEditedAs(string certificate, string from, string year)
        {
            //Check message
            string assertMessage = certificate + " has been updated to your certification";
            string message = CertificationObj.GetMessage();
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Check certifcate
            string editedCertificate = CertificationObj.GetCertificate();
            Assert.That(editedCertificate == certificate, "Actual certificate and Expected certificate do not match.");

            //check certification form
            string editedCertificationFrom = CertificationObj.GetCertificationFrom();
            Assert.That(editedCertificationFrom == from, "Actual certifier and Expected certifier do not match.");

            //check certification year
            string editedYear = CertificationObj.GetCertificationYear();
            Assert.That(editedYear == year, "Actual certification year and Expected certification year do not match.");
        }

        [When(@"I delete '([^']*)'")]
        public void WhenIDeleteCertificate(string certificate)
        {
            CertificationObj.DeleteCertificate(certificate);
        }

        [Then(@"The existing '([^']*)' should be deleted accordingly")]
        public void ThenTheExistingCertificateShouldBeDeletedAccordingly(string certificate)
        {
            //check message
            string assertMessage = certificate + " has been deleted from your certification";
            string message = CertificationObj.GetMessage();
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //check certificate has been deleted successfully
            string deletedCertificate = CertificationObj.GetCertificate();
            Assert.That(deletedCertificate != certificate, "Certificate hasn't been deleted.");
        }

        [After]
        public void Dispose()
        {
            if (driver != null)
            {
                driver.Close();
            }
        }
    }
}
