using NUnit.Framework;
using Onboarding.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Pages.ProfilePages
{
    public class Skill
    {
        public string GetMessage(IWebDriver driver)
        {
            string messageXpath = "//div[@class='ns-box-inner']";
            WaitHelpers.WaitToBeVisible(driver, "XPath", messageXpath, 3);
            IWebElement message = driver.FindElement(By.XPath(messageXpath));
            return message.Text;
        }
        public void ClickAnyTab(IWebDriver driver, string tab)
        {
            //Wait for tabs to be visible
            WaitHelpers.WaitToBeVisible(driver, "XPath", "//div[@class='ui top attached tabular menu']", 3);

            //Specify a tab locator value
            string locatorValue = "";
            switch (tab)
            {
                case "Languages":
                    locatorValue = "//div[@class = 'ui top attached tabular menu']/a[1]";
                    break;
                case "Skills":
                    locatorValue = "//div[@class = 'ui top attached tabular menu']/a[2]";
                    break;
                case "Education":
                    locatorValue = "//div[@class = 'ui top attached tabular menu']/a[3]";
                    break;
                case "Certifications":
                    locatorValue = "//div[@class = 'ui top attached tabular menu']/a[4]";
                    break;
                default:
                    Assert.Fail("No matching tab found.");
                    break;
            }
            //Click on specified tab
            IWebElement tabOption = driver.FindElement(By.XPath(locatorValue));
            tabOption.Click();
        }


        public void AddSkill(IWebDriver driver, string skill, string skillLevel)
        {
            //Wait Add new button to be visible
            string xPathValue = "//div[@class='ui teal button']";
            WaitHelpers.WaitToBeClickable(driver, "XPath", xPathValue, 3);

            //Click Add new
            IWebElement buttonAddNew = driver.FindElement(By.XPath(xPathValue));
            buttonAddNew.Click();

            //Enter skill
            IWebElement addSkill = driver.FindElement(By.XPath("//input[@name='name']"));
            addSkill.SendKeys(skill);

            //Select skill level
            var selectDropdown = new SelectElement(driver.FindElement(By.XPath("//select[@name='level']")));
            selectDropdown.SelectByValue(skillLevel);

            //Click add
            IWebElement buttonAdd = driver.FindElement(By.XPath("//input[@value='Add']"));
            buttonAdd.Click();
        }
        public string GetSkill(IWebDriver driver)
        {
            //get last skill record 
            try
            {
                IWebElement skill = driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[1]"));
                return skill.Text;
            }
            catch (Exception)
            {
                return "locator not found";
            }
        }
        public string GetSkillLevel(IWebDriver driver)
        {
            //Get last skill level record
            IWebElement addedSkillLevel = driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[2]"));
            return addedSkillLevel.Text;
        }

        public void EditSkill(IWebDriver driver, string skill, string skillLevel)
        {
            //Wait
            string xpathValue = "//div[@data-tab='second']//table/tbody[last()]/tr/td[3]/span[1]";
            WaitHelpers.WaitToBeClickable(driver, "XPath", xpathValue, 3);

            //Click edit button
            IWebElement buttonUpdate = driver.FindElement(By.XPath(xpathValue));
            buttonUpdate.Click();

            //Edit Skills
            IWebElement editSkill = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            editSkill.Clear();
            editSkill.SendKeys(skill);

            //Edit Skill level
            var selectDropDown = new SelectElement(driver.FindElement(By.XPath("//select[@name='level']")));
            selectDropDown.SelectByValue(skillLevel);

            //Click Update
            IWebElement btnUpdate = driver.FindElement(By.XPath("//input[@value='Update']"));
            btnUpdate.Click();
        }

        public void DeleteSkill(IWebDriver driver, string skill)
        {
            //Wait for Skill loaded
            string xpValue = "//div[@data-tab='second']//table/tbody[last()]/tr/td[1]";
            WaitHelpers.WaitToBeClickable(driver, "XPath", xpValue, 3);

            //Check if skill is the one to be deleted
            IWebElement deletedSkill = driver.FindElement(By.XPath(xpValue));
            if (deletedSkill.Text == skill)
            {
                //Click Delete button
                IWebElement buttonDelete = driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[3]/span[2]"));
                buttonDelete.Click();
            }
            else
            {
                Assert.Fail("Skill is not found");
            }
        }

    }
}
