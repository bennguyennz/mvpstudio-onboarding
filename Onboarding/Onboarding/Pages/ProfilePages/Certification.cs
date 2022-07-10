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
    public class Certification
    {
        public void AddCertificate(IWebDriver driver, string certificate, string certificationFrom, string year)
        {
            //Wait
            string xpValue = "//div[@data-tab='fourth']//div[@class ='ui teal button ']";
            WaitHelpers.WaitToBeClickable(driver, "XPath", xpValue, 5);

            //click on Add New
            IWebElement buttonAddNew = driver.FindElement(By.XPath(xpValue));
            buttonAddNew.Click();

            //Enter Certificate/Award
            IWebElement addedCertificate = driver.FindElement(By.Name("certificationName"));
            addedCertificate.SendKeys(certificate);

            //Enter Certifier
            IWebElement addedCertificationFrom = driver.FindElement(By.Name("certificationFrom"));
            addedCertificationFrom.SendKeys(certificationFrom);

            //Select year
            var addedYear = new SelectElement(driver.FindElement(By.Name("certificationYear")));
            addedYear.SelectByValue(year);

            //Click on Add
            string xpAddValue = "//div[@class='five wide field']/input[1]";
            WaitHelpers.WaitToBeClickable(driver, "XPath", xpAddValue, 5);
            IWebElement buttonAdd = driver.FindElement(By.XPath(xpAddValue));
            buttonAdd.Click();
        }
        public string GetCertificate(IWebDriver driver)
        {
            try
            {
                //Check on last record
                string xpValue = "//div[@data-tab='fourth']/div/div/div/table/tbody[last()]/tr/td[1]";
                IWebElement certifcate = driver.FindElement(By.XPath(xpValue));
                WaitHelpers.WaitToBeVisible(driver, "XPath", xpValue, 5);

                return certifcate.Text;
            }
            catch (Exception)
            {
                return "Certificate not found";
            }
        }

        public string GetCertificationFrom(IWebDriver driver)
        {
            try
            {
                //Check on last record
                string xpValue = "//div[@data-tab='fourth']/div/div/div/table/tbody[last()]/tr/td[2]";
                IWebElement certificationFrom = driver.FindElement(By.XPath(xpValue));
                WaitHelpers.WaitToBeVisible(driver, "XPath", xpValue, 5);

                return certificationFrom.Text;
            }
            catch (Exception)
            {
                return "Locator not found";
            }
        }

        public string GetCertificationYear(IWebDriver driver)
        {
            try
            {
                //Check on last record
                string xpValue = "//div[@data-tab='fourth']/div/div/div/table/tbody[last()]/tr/td[3]";
                IWebElement certificationYear = driver.FindElement(By.XPath(xpValue));
                WaitHelpers.WaitToBeVisible(driver, "XPath", xpValue, 5);

                return certificationYear.Text;
            }
            catch (Exception)
            {
                return "Locator not found";
            }
        }

        public void EditCertificate(IWebDriver driver, string certificate, string certificationFrom, string year)
        {
            try
            {
                //Wait
                string xpValue = "//div[@data-tab='fourth']/div/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]";
                WaitHelpers.WaitToBeClickable(driver, "XPath", xpValue, 5);

                //click on update
                IWebElement buttonUpdate = driver.FindElement(By.XPath(xpValue));
                buttonUpdate.Click();

                //Edit Certificate/Award
                IWebElement editedCertificate = driver.FindElement(By.Name("certificationName"));
                editedCertificate.Clear();
                editedCertificate.SendKeys(certificate);

                //Edit Certifier
                IWebElement editedCertificationFrom = driver.FindElement(By.Name("certificationFrom"));
                editedCertificationFrom.Clear();
                editedCertificationFrom.SendKeys(certificationFrom);

                //Edit year
                var editedYear = new SelectElement(driver.FindElement(By.Name("certificationYear")));
                editedYear.SelectByValue(year);

                //Click on Update
                string xpUpdateValue = "//input[@value='Update']";
                WaitHelpers.WaitToBeClickable(driver, "XPath", xpUpdateValue, 5);
                IWebElement buttonUpdate2 = driver.FindElement(By.XPath(xpUpdateValue));
                buttonUpdate2.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("No certificate is found.", ex.Message);

            }
        }
        public void DeleteCertificate(IWebDriver driver, string certificate)
        {
            try
            {
                //wait for delete button
                string xpValue = "//div[@data-tab='fourth']/div/div[2]/div/table/tbody[last()]/tr/td[4]/span[2]";
                WaitHelpers.WaitToBeClickable(driver, "XPath", xpValue, 3);

                //Check if university is matching the university to be deleted
                string deletedCertificate = GetCertificate(driver);
                if (deletedCertificate == certificate)
                {
                    //click on delete button
                    IWebElement buttonDelete = driver.FindElement(By.XPath(xpValue));
                    buttonDelete.Click();
                }
                else
                {
                    Assert.Fail("Certificate is not matching certificate to be deleted");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("No certificate is found", ex.Message);
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
