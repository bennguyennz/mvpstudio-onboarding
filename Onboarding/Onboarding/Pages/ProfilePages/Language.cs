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
    public class Language
    {
        Language LanguageObj;

        //Finding elements
        private IWebElement addNewLanguageButton => driver.FindElement(By.XPath("//div[@data-tab='first']//div[@class ='ui teal button ']"));
        private IWebElement addLanuage => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        private IWebElement dropdownLanguage => driver.FindElement(By.XPath("//div[@data-tab='first']//select[@class='ui dropdown']"));
        private IWebElement buttonAdd => driver.FindElement(By.XPath("//input[@value='Add']"));
        private IWebElement language => driver.FindElement(By.XPath(e_language));
        private IWebElement languageLevel => driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[last()]/tr/td[2]"));
        private IWebElement editLanguageButton => driver.FindElement(By.XPath(e_editLanguageButton));
        private IWebElement editLanuage => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        private IWebElement buttonUpdate => driver.FindElement(By.XPath("//input[@value='Update']"));
        private IWebElement buttonDelete => driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[last()]/tr/td[3]/span[2]/i"));
        private IWebElement message => driver.FindElement(By.XPath(e_message));
        private IWebElement tabOption => driver.FindElement(By.XPath("//div[@class = 'ui top attached tabular menu']/a[1]"));

        //Elements for wait
        private string e_language = "//div[@data-tab='first']//tbody[last()]/tr/td[1]";
        private string e_editLanguageButton = "//div[@data-tab='first']//tbody[last()]/tr/td[3]/span[1]/i";
        private string e_message = "//div[@class='ns-box-inner']";
        private string e_waitForTab = "//div[@class='ui top attached tabular menu']";


        public void AddALanguage(string language, string languagelevel)
        {
            //Click Add New
            addNewLanguageButton.Click();

            //Enter language
            addLanuage.SendKeys(language);

            //Choose Lanuage Level
            var selectLanguageDropdown = new SelectElement(dropdownLanguage);
            selectLanguageDropdown.SelectByValue(languagelevel);

            //Click Add
            buttonAdd.Click();
        }
        public string GetLanguage()
        {
            //Get last record language text
            try
            {
                WaitHelpers.WaitToBeVisible(driver, "XPath", e_language, 3);
                return language.Text;
            }
            catch (Exception)
            {
                return "locator not found";
            }
        }
        public string GetLanguageLevel()
        {
            //Get last record Language level
            return languageLevel.Text;
        }

        public void EditLanguage(string language, string languagelevel)
        {
            //Wait for edit button

            WaitHelpers.WaitToBeClickable(driver, "XPath", e_editLanguageButton, 3);

            //Click edit button
            editLanguageButton.Click();

            //Edit language
            editLanuage.Clear();
            editLanuage.SendKeys(language);

            //Edit Lanuage Level
            var selectLanguage = new SelectElement(dropdownLanguage);
            selectLanguage.SelectByValue(languagelevel);

            //Click Update
            buttonUpdate.Click();
        }

        public void DeleteLanguage(string language)
        {
            try
            {
                string strLanguage = GetLanguage();
                if (strLanguage == language)
                {
                    //Click delete
                    buttonDelete.Click();
                }
                else
                {
                    Assert.Fail("No matching language found.");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("No language is found", ex.Message);
            }
        }

        public string GetMessage()
        {
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_message, 3);
            return message.Text;
        }
        public void ClickAnyTab(string tab)
        {
            //Wait for tabs to be visible
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_waitForTab, 3);

            //Click on specified tab
            tabOption.Click();
        }

    }
}
