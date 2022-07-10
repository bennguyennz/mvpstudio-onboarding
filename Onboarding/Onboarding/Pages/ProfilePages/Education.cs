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
    public class Education
    {
        public void AddEducation(IWebDriver driver, string country, string university, string title, string degree, string graduationYear)
        {
            //Wait for add new button to be visible
            string xpValue = "//div[@data-tab='third']//div[@class ='ui teal button ']";
            WaitHelpers.WaitToBeClickable(driver, "Xpath", xpValue, 3);

            //Click add new
            IWebElement buttonAddEducation = driver.FindElement(By.XPath(xpValue));
            buttonAddEducation.Click();

            //Enter college/university name
            IWebElement universityTextbox = driver.FindElement(By.XPath("//input[@name='instituteName']"));
            universityTextbox.SendKeys(university);

            //select country
            var countryDropdown = new SelectElement(driver.FindElement(By.XPath("//select[@name='country']")));
            countryDropdown.SelectByValue(country);

            //Select title
            var titleDropdown = new SelectElement(driver.FindElement(By.XPath("//select[@name='title']")));
            titleDropdown.SelectByValue(title);

            //Enter Degree
            IWebElement degreeTextbox = driver.FindElement(By.XPath("//input[@name='degree']"));
            degreeTextbox.SendKeys(degree);

            //Select Year of graduation
            var yearDropdown = new SelectElement(driver.FindElement(By.XPath("//select[@name='yearOfGraduation']")));
            yearDropdown.SelectByValue(graduationYear);

            //Click save
            IWebElement buttonSave = driver.FindElement(By.XPath("//input[@value='Add']"));
            buttonSave.Click();
        }

        public string GetCountry(IWebDriver driver)
        {
            try
            {
                //Go to last record and get details
                IWebElement country = driver.FindElement(By.XPath("//div[@data-tab='third']//table/tbody[last()]/tr/td[1]"));
                return country.Text;
            }
            catch (Exception)
            {
                return "locator not found";
            }
        }
        public string GetUniversity(IWebDriver driver)
        {
            try
            {
                //Go to last record and get details
                IWebElement university = driver.FindElement(By.XPath("//div[@data-tab='third']//table/tbody[last()]/tr/td[2]"));
                return university.Text;
            }
            catch (Exception)
            {
                return "locator not found";
            }
        }
        public string GetTitle(IWebDriver driver)
        {
            try
            {
                //Go to last record and get details
                IWebElement title = driver.FindElement(By.XPath("//div[@data-tab='third']//table/tbody[last()]/tr/td[3]"));
                return title.Text;
            }
            catch (Exception)
            {
                return "locator not found";
            }
        }
        public string GetDegree(IWebDriver driver)
        {
            try
            {
                //Go to last record and get details
                IWebElement degree = driver.FindElement(By.XPath("//div[@data-tab='third']//table/tbody[last()]/tr/td[4]"));
                return degree.Text;
            }
            catch (Exception)
            {
                return "locator not found";
            }
        }

        public string GetGraduationYear(IWebDriver driver)
        {
            try
            {
                //Go to last record and get details
                IWebElement graduationYear = driver.FindElement(By.XPath("//div[@data-tab='third']//table/tbody[last()]/tr/td[5]"));
                return graduationYear.Text;
            }
            catch (Exception)
            {
                return "locator not found";
            }
        }
        public void EditEducation(IWebDriver driver, string country, string university, string title, string degree, string graduationYear)
        {
            try
            {
                //go to last record and click on edit button
                string xpValue = "//div[@data-tab='third']//table/tbody[last()]/tr/td[6]/span[1]";
                WaitHelpers.WaitToBeClickable(driver, "XPath", xpValue, 3);
                IWebElement buttonEdit = driver.FindElement(By.XPath(xpValue));
                buttonEdit.Click();

                //I edit university
                IWebElement editedUniversity = driver.FindElement(By.XPath("//input[@placeholder='College/University Name']"));
                editedUniversity.Clear();
                editedUniversity.SendKeys(university);

                //I edit country
                var editedCountry = new SelectElement(driver.FindElement(By.XPath("//select[@name='country']")));
                editedCountry.SelectByValue(country);

                //I edit title
                var editedTitle = new SelectElement(driver.FindElement(By.XPath("//select[@name='title']")));
                editedTitle.SelectByValue(title);

                //edit degree
                IWebElement editedDegree = driver.FindElement(By.XPath("//input[@placeholder='Degree']"));
                editedDegree.Clear();
                editedDegree.SendKeys(degree);

                //edit graduation year
                var editedGraduationYear = new SelectElement(driver.FindElement(By.XPath("//select[@name='yearOfGraduation']")));
                editedGraduationYear.SelectByValue(graduationYear);

                //Click update button
                IWebElement buttonUpdate = driver.FindElement(By.XPath("//input[@value='Update']"));
                buttonUpdate.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("No education is found.", ex.Message);
            }
        }

        public void DeleteEducation(IWebDriver driver, string university)
        {
            try
            {
                //wait for button delete
                string xpValue = "//div[@data-tab='third']//table/tbody[last()]/tr/td[6]/span[2]";
                WaitHelpers.WaitToBeClickable(driver, "XPath", xpValue, 3);

                //Check if university is matching the university to be deleted
                string deletedUniversity = GetUniversity(driver);
                if (deletedUniversity == university)
                {
                    //click on delete button
                    IWebElement buttonDelete = driver.FindElement(By.XPath(xpValue));
                    buttonDelete.Click();
                }
                else
                {
                    Assert.Fail("Country is not matching country to be deleted");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("No country is found", ex.Message);
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
