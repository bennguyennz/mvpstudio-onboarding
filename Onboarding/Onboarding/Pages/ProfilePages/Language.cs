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
    public class Language
    {
        public void AddALanguage(IWebDriver driver, string language, string languagelevel)
        {
            //Click Add New
            IWebElement addNewLanguageButton = driver.FindElement(By.XPath("//div[@data-tab='first']//div[@class ='ui teal button ']"));
            addNewLanguageButton.Click();

            //Enter language
            IWebElement addLanuage = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
            addLanuage.SendKeys(language);

            //Choose Lanuage Level
            var selectLanguageDropdown = new SelectElement(driver.FindElement(By.XPath("//div[@data-tab='first']//select[@class='ui dropdown']")));
            selectLanguageDropdown.SelectByValue(languagelevel);

            //Click Add
            IWebElement buttonAdd = driver.FindElement(By.XPath("//input[@value='Add']"));
            buttonAdd.Click();
        }
        public string GetLanguage(IWebDriver driver)
        {
            //Get last record language text
            try
            {
                string xpValue = "//div[@data-tab='first']//tbody[last()]/tr/td[1]";
                WaitHelpers.WaitToBeVisible(driver, "XPath", xpValue, 3);

                IWebElement language = driver.FindElement(By.XPath(xpValue));
                return language.Text;
            }
            catch (Exception)
            {
                return "locator not found";
            }
        }
        public string GetLanguageLevel(IWebDriver driver)
        {
            //Get last record Language level
            IWebElement languageLevel = driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[last()]/tr/td[2]"));
            return languageLevel.Text;
        }

        public void EditLanguage(IWebDriver driver, string language, string languagelevel)
        {
            //Wait for edit button
            string xpValue = "//div[@data-tab='first']//tbody[last()]/tr/td[3]/span[1]/i";
            WaitHelpers.WaitToBeClickable(driver, "XPath", xpValue, 3);

            //Click edit button
            IWebElement editLanguageButton = driver.FindElement(By.XPath(xpValue));
            editLanguageButton.Click();

            //Edit language
            IWebElement editLanuage = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
            editLanuage.Clear();
            editLanuage.SendKeys(language);

            //Edit Lanuage Level
            var selectLanguageDropdown = new SelectElement(driver.FindElement(By.XPath("//div[@data-tab='first']//select[@class='ui dropdown']")));
            selectLanguageDropdown.SelectByValue(languagelevel);

            //Click Update
            IWebElement buttonUpdate = driver.FindElement(By.XPath("//input[@value='Update']"));
            buttonUpdate.Click();
        }

        public void DeleteLanguage(IWebDriver driver, string language)
        {
            string strLanguage = GetLanguage(driver);
            if (strLanguage == language)
            {
                //Click delete
                IWebElement deleteButon = driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[last()]/tr/td[3]/span[2]/i"));
                deleteButon.Click();
            }
            else
            {
                Assert.Fail("There's no language to be deleted");
            }
        }

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

    }
}
