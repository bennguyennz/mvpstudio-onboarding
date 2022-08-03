using NUnit.Framework;
using Onboarding.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Onboarding.Utilities.CommonDriver;

namespace Onboarding.Pages.ProfilePages
{
    public class Skill
    {
        Skill SkillObj;

        //Finding for elements
        private IWebElement message => driver.FindElement(By.XPath(e_message));
        private IWebElement tabOption => driver.FindElement(By.XPath("//div[@class = 'ui top attached tabular menu']/a[2]"));
        private IWebElement buttonAddNew => driver.FindElement(By.XPath(e_buttonAddNew));
        private IWebElement addSkill => driver.FindElement(By.XPath("//input[@name='name']"));
        private IWebElement dropdownSkillLevel => driver.FindElement(By.XPath("//select[@name='level']"));
        private IWebElement buttonCompleteAdd => driver.FindElement(By.XPath("//input[@value='Add']"));
        private IWebElement skill => driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[1]"));
        private IWebElement addedSkillLevel => driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[2]"));
        private IWebElement buttonUpdate => driver.FindElement(By.XPath(e_buttonUpdate));
        private IWebElement editSkill => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        private IWebElement buttonCompleteUpdate => driver.FindElement(By.XPath("//input[@value='Update']"));
        private IWebElement deletedSkill => driver.FindElement(By.XPath(e_recordLastSkill));

        //Elements for wait
        private string e_message = "//div[@class='ns-box-inner']";
        private string e_tab = "//div[@class='ui top attached tabular menu']";
        private string e_buttonAddNew = "//div[@class='ui teal button']";
        private string e_buttonUpdate = "//div[@data-tab='second']//table/tbody[last()]/tr/td[3]/span[1]";
        private string e_recordLastSkill = "//div[@data-tab='second']//table/tbody[last()]/tr/td[1]";
        private IWebElement buttonDelete => driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[3]/span[2]"));


        public string GetMessage()
        {

            WaitHelpers.WaitToBeVisible(driver, "XPath", e_message, 3);
            return message.Text;
        }
        public void ClickAnyTab(string tab)
        {
            //Wait for tabs to be visible
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_tab, 3);

            //Click on specified tab
            tabOption.Click();
        }


        public void AddSkill(string skill, string skillLevel)
        {
            //Wait Add new button to be visible
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_buttonAddNew, 3);

            //Click Add new
            buttonAddNew.Click();

            //Enter skill
            addSkill.SendKeys(skill);

            //Select skill level
            var selectSkillLevel = new SelectElement(dropdownSkillLevel);
            selectSkillLevel.SelectByValue(skillLevel);

            //Click add
            buttonCompleteAdd.Click();
        }
        public string GetSkill()
        {
            //get last skill record 
            try
            {
                return skill.Text;
            }
            catch (Exception)
            {
                return "locator not found";
            }
        }
        public string GetSkillLevel()
        {
            //Get last skill level record
            return addedSkillLevel.Text;
        }

        public void EditSkill(string skill, string skillLevel)
        {
            //Wait
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_buttonUpdate, 3);

            //Click edit button
            buttonUpdate.Click();

            //Edit Skills
            editSkill.Clear();
            editSkill.SendKeys(skill);

            //Edit Skill level
            var selectSkillLevel = new SelectElement(dropdownSkillLevel);
            selectSkillLevel.SelectByValue(skillLevel);

            //Click Update
            buttonCompleteUpdate.Click();
        }

        public void DeleteSkill(string skill)
        {
            try
            {
                //Wait for Skill loaded
                WaitHelpers.WaitToBeVisible(driver, "XPath", e_recordLastSkill, 3);

                //Check if skill is the one to be deleted
                if (deletedSkill.Text == skill)
                {
                    //Click Delete button
                    buttonDelete.Click();
                }
                else
                {
                    Assert.Fail("No matching skill is not found.");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("No skill is found.",ex.Message);
            }
        }

    }
}
