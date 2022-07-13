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
        //Define class with two objects
        public IWebDriver driver;
        Certification CertificationObj;

        //Form constructor 1
        public Certification(IWebDriver _driver)
        {
            //initial driver object
            this.driver = _driver;   
        }

        //Inintial object and link to constructor 1 by calling method
        public void CertificationStepDefinitions()
        {
            //initial object
            CertificationObj = new Certification(driver);
        }

        //Finding elements
        private IWebElement buttonAddNew => driver.FindElement(By.XPath(e_buttonAddNew));
        private IWebElement addedCertificate => driver.FindElement(By.Name("certificationName"));
        private IWebElement addedCertificationFrom => driver.FindElement(By.Name("certificationFrom"));
        private IWebElement dropdownYear => driver.FindElement(By.Name("certificationYear"));
        private IWebElement buttonCompleteAdd => driver.FindElement(By.XPath(e_CompleteAdd));
        private IWebElement certifcate => driver.FindElement(By.XPath(e_certificate));
        private IWebElement certificationFrom => driver.FindElement(By.XPath(e_certificateFrom));
        private IWebElement certificationYear => driver.FindElement(By.XPath(e_certificationYear));
        private IWebElement buttonStartUpdate => driver.FindElement(By.XPath(e_buttonStartUpdate));
        private IWebElement editedCertificate => driver.FindElement(By.Name("certificationName"));
        private IWebElement editedCertificationFrom => driver.FindElement(By.Name("certificationFrom"));
        private IWebElement buttonCompleteUpdate => driver.FindElement(By.XPath(e_buttonCompleteUpdate));
        private IWebElement buttonDelete => driver.FindElement(By.XPath(e_buttonDelete));
        private IWebElement message => driver.FindElement(By.XPath(e_message));
        private IWebElement tabOption => driver.FindElement(By.XPath("//div[@class = 'ui top attached tabular menu']/a[4]"));

        //wait elements
        private string e_buttonAddNew = "//div[@data-tab='fourth']//div[@class ='ui teal button ']";
        private string e_certificate = "//div[@data-tab='fourth']/div/div/div/table/tbody[last()]/tr/td[1]";
        private string e_certificateFrom = "//div[@data-tab='fourth']/div/div/div/table/tbody[last()]/tr/td[2]";
        private string e_certificationYear = "//div[@data-tab='fourth']/div/div/div/table/tbody[last()]/tr/td[3]";
        private string e_tab = "//div[@class='ui top attached tabular menu']";
        private string e_CompleteAdd = "//div[@class='five wide field']/input[1]";
        private string e_buttonStartUpdate = "//div[@data-tab='fourth']/div/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]";
        private string e_buttonCompleteUpdate = "//input[@value='Update']";
        private string e_buttonDelete = "//div[@data-tab='fourth']/div/div[2]/div/table/tbody[last()]/tr/td[4]/span[2]";
        private string e_message = "//div[@class='ns-box-inner']";


        public void AddCertificate(string certificate, string certificationFrom, string year)
        {
            //click on Add New
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_buttonAddNew, 5);
            buttonAddNew.Click();

            //Enter Certificate/Award
            addedCertificate.SendKeys(certificate);

            //Enter Certifier
            addedCertificationFrom.SendKeys(certificationFrom);

            //Select year
            var addedYear = new SelectElement(dropdownYear);
            addedYear.SelectByValue(year);

            //Click on Add
            WaitHelpers.WaitToBeClickable(driver, "XPath", e_CompleteAdd, 5);
            buttonCompleteAdd.Click();
        }
        public string GetCertificate()
        {
            try
            {
                //Get text from last record
                WaitHelpers.WaitToBeVisible(driver, "XPath", e_certificate, 5);
                return certifcate.Text;
            }
            catch (Exception)
            {
                return "Certificate element not found";
            }
        }

        public string GetCertificationFrom()
        {
            try
            {
                //Check on last record
                WaitHelpers.WaitToBeVisible(driver, "XPath", e_certificateFrom, 5);
                return certificationFrom.Text;
            }
            catch (Exception)
            {
                return "Certificate element not found";
            }
        }

        public string GetCertificationYear()
        {
            try
            {
                //Check on last record
                WaitHelpers.WaitToBeVisible(driver, "XPath", e_certificationYear, 5);
                return certificationYear.Text;
            }
            catch (Exception)
            {
                return "Certificate element not found";
            }
        }

        public void EditCertificate(string certificate, string certificationFrom, string year)
        {
            try
            {
                //click on update
                WaitHelpers.WaitToBeClickable(driver, "XPath", e_buttonStartUpdate, 5);
                buttonStartUpdate.Click();

                //Edit Certificate/Award
                editedCertificate.Clear();
                editedCertificate.SendKeys(certificate);

                //Edit Certifier
                editedCertificationFrom.Clear();
                editedCertificationFrom.SendKeys(certificationFrom);

                //Edit year
                var editedYear = new SelectElement(dropdownYear);
                editedYear.SelectByValue(year);

                //Click on Update
                WaitHelpers.WaitToBeClickable(driver, "XPath", e_buttonCompleteUpdate, 5);
                buttonCompleteUpdate.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("No certificate is found.", ex.Message);

            }
        }
        public void DeleteCertificate(string certificate)
        {
            try
            {
                //wait for button delete
                WaitHelpers.WaitToBeClickable(driver, "XPath", e_buttonDelete, 3);
                
                //Check if university is matching the university to be deleted
                string deletedCertificate = GetCertificate();
                if (deletedCertificate == certificate)
                {
                    //click on delete button
                    buttonDelete.Click();
                }
                else
                {
                    Assert.Fail("No matching certificate found.");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("No certificate is found.", ex.Message);
            }
        }

        public string GetMessage()
        {
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_message, 3);
            return message.Text;
        }
        public void ClickOnTabCertifications()
        {
            //Wait for tabs to be visible
            WaitHelpers.WaitToBeVisible(driver, "XPath", e_tab, 3);
            tabOption.Click();
        }

    }

}
