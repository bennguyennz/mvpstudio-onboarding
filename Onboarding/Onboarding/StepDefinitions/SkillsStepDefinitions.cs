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
    public class SkillsStepDefinitions: CommonDriver
    {
        Skill SkillObj;
        LoginPage LoginPageObj;

        public SkillsStepDefinitions()
        {
            SkillObj = new Skill(driver);
            LoginPageObj = new LoginPage(driver);
        }

        [Given(@"I logged into the portal successfully")]
        public void GivenILoggedIntoThePortalSuccessfully()
        {
            //Open Chrome browser
            driver = new ChromeDriver();

            //Initiate objects
            SkillObj = new Skill(driver);
            LoginPageObj = new LoginPage(driver);

            //signin
            LoginPageObj.LogInActions();
        }

        [When(@"I click on tab Skills")]
        public void WhenIClickOnTabSkills()
        {
            SkillObj.ClickAnyTab("Skills");
        }

        [When(@"I add '([^']*)' at '([^']*)'")]
        public void WhenIAddAt(string skill, string skillLevel)
        {
            SkillObj.AddSkill(skill, skillLevel);
        }

        [Then(@"The '([^']*)' with '([^']*)'should be added successfully")]
        public void ThenTheSkillAndSkillLevelShouldBeAddedSuccessfully(string skill, string skillLevel)
        {
            //assert message skill added successfully
            string assertMessage = skill + " has been added to your skills";
            string addedMessage = SkillObj.GetMessage();
            Assert.That(addedMessage == assertMessage, "Actual message and Expected message do not match.");

            //assert if skill and skill level has been added accordingly
            string addedSkill = SkillObj.GetSkill();
            string addedSkillLevel = SkillObj.GetSkillLevel();

            Assert.That(addedSkill == skill, "Actual skill and Expected skill do not match");
            Assert.That(addedSkillLevel == skillLevel, "Actual skill level and Expected skill level do not match");
            driver.Close();
        }

        [When(@"I edit last skill into '([^']*)' with '([^']*)'")]
        public void WhenIEditLasSkill(string skill, string skillLevel)
        {
            SkillObj.EditSkill(skill, skillLevel);
        }

        [Then(@"'([^']*)' with '([^']*)' should be edited successfully")]
        public void ThenTheSkillShouldBeEditedSuccessfully(string skill, string skillLevel)
        {
            //Check if popup message is correct
            string assertMessage = skill + " has been updated to your skills";
            string message = SkillObj.GetMessage();
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Check if skill and skill level have been updated successfully
            string editedSkill = SkillObj.GetSkill();
            string editedSkillLevel = SkillObj.GetSkillLevel();

            Assert.That(editedSkill == skill, "Actual skill and Expected skill do not match.");
            Assert.That(editedSkillLevel == skillLevel, "Actual skill level and Expected skill level do not match.");
            driver.Close();
        }

        [When(@"I delete a '([^']*)'")]
        public void WhenIDeleteSkill(string skill)
        {
            SkillObj.DeleteSkill(skill);
        }

        [Then(@"The '([^']*)' should be deleted accordingly")]
        public void ThenTheSkillShouldBeDeletedAccordingly(string skill)
        {
            //Check if popup message is correct
            string assertMessage = skill + " has been deleted";
            string message = SkillObj.GetMessage();
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Check if skill has been deleted
            string lastSkill = SkillObj.GetSkill();
            Assert.That(lastSkill != skill, "Expected Skill has not been deleted successfully");
            driver.Close();
        }
    }
 }
