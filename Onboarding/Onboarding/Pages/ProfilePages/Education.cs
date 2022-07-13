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
        public IWebDriver driver;
        Education EducationObj;
        public Education(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        public void EducationStepDefinitions()
        {
            EducationObj = new Education(driver);
        }

        //Finding elements
        private IWebElement buttonAddEducation => driver.FindElement(By.XPath(e_buttonAdd));
        private IWebElement textboxUniversity => driver.FindElement(By.XPath("//input[@name='instituteName']"));
        private IWebElement dropdownCountry => driver.FindElement(By.XPath("//select[@name='country']"));
        private IWebElement dropdownTitle => driver.FindElement(By.XPath("//select[@name='title']"));
        private IWebElement textboxDegree => driver.FindElement(By.XPath("//input[@name='degree']"));
        private IWebElement dropdownYear => driver.FindElement(By.XPath("//select[@name='yearOfGraduation']"));
        private IWebElement buttonSave => driver.FindElement(By.XPath("//input[@value='Add']"));
        private IWebElement country => driver.FindElement(By.XPath("//div[@data-tab='third']//table/tbody[last()]/tr/td[1]"));
        private IWebElement university => driver.FindElement(By.XPath("//div[@data-tab='third']//table/tbody[last()]/tr/td[2]"));
        private IWebElement title => driver.FindElement(By.XPath("//div[@data-tab='third']//table/tbody[last()]/tr/td[3]"));
        private IWebElement degree => driver.FindElement(By.XPath("//div[@data-tab='third']//table/tbody[last()]/tr/td[4]"));
        private IWebElement graduationYear => driver.FindElement(By.XPath("//div[@data-tab='third']//table/tbody[last()]/tr/td[5]"));
        private IWebElement buttonEdit => driver.FindElement(By.XPath(e_buttonEdit));
        private IWebElement editedUniversity => driver.FindElement(By.XPath("//input[@placeholder='College/University Name']"));
        private IWebElement editedDegree => driver.FindElement(By.XPath("//input[@placeholder='Degree']"));
        private IWebElement buttonUpdate => driver.FindElement(By.XPath("//input[@value='Update']"));
        private IWebElement buttonDelete => driver.FindElement(By.XPath(e_buttonDelete));
        private IWebElement message => driver.FindElement(By.XPath(e_message));
        private IWebElement tabOption => driver.FindElement(By.XPath("//div[@class = 'ui top attached tabular menu']/a[3]"));

        //Element for waits
        private string e_buttonAdd = "//div[@data-tab='third']//div[@class ='ui teal button ']";
        private string e_buttonEdit = "//div[@data-tab='third']//table/tbody[last()]/tr/td[6]/span[1]";
        private string e_buttonDelete = "//div[@data-tab='third']//table/tbody[last()]/tr/td[6]/span[2]";
        private string e_message = "//div[@class='ns-box-inner']";
        private string e_waitForTab = "//div[@class='ui top attached tabular menu']";


        public void AddEducation(string country, string university, string title, string degree, string graduationYear)
        {
            //Wait for add new button to be visible
            WaitHelpers.WaitToBeClickable(driver, "Xpath", e_buttonAdd, 3);

            //Click add new
            buttonAddEducation.Click();

            //Enter college/university name
            textboxUniversity.SendKeys(university);

            //select country
            var selectCountry = new SelectElement(dropdownCountry);
            selectCountry.SelectByValue(country);

            //Select title
            var selectTitle = new SelectElement(dropdownTitle);
            selectTitle.SelectByValue(title);

            //Enter Degree
            textboxDegree.SendKeys(degree);

            //Select Year of graduation
            var selectYear = new SelectElement(dropdownYear);
            selectYear.SelectByValue(graduationYear);

            //Click save
            buttonSave.Click();
        }

        public string GetCountry()
        {
            try
            {
                //Go to last record and get details
                return country.Text;
            }
            catch (Exception)
            {
                return "Country element not found";
            }
        }
        public string GetUniversity()
        {
            try
            {
                //Go to last record and get details
                return university.Text;
            }
            catch (Exception)
            {
                return "University element not found";
            }
        }
        public string GetTitle()
        {
            try
            {
                //Go to last record and get details
                return title.Text;
            }
            catch (Exception)
            {
                return "Title element not found";
            }
        }
        public string GetDegree()
        {
            try
            {
                //Go to last record and get details
                return degree.Text;
            }
            catch (Exception)
            {
                return "Degree element not found";
            }
        }

        public string GetGraduationYear()
        {
            try
            {
                //Go to last record and get details
                return graduationYear.Text;
            }
            catch (Exception)
            {
                return "Graduation Year element not found";
            }
        }
        public void EditEducation(string country, string university, string title, string degree, string graduationYear)
        {
            try
            {
                //go to last record and click on edit button
                WaitHelpers.WaitToBeClickable(driver, "XPath", e_buttonEdit, 3);
                buttonEdit.Click();

                //I edit university
                editedUniversity.Clear();
                editedUniversity.SendKeys(university);

                //I edit country
                var selectCountry = new SelectElement(dropdownCountry);
                selectCountry.SelectByValue(country);

                //I edit title
                var selectTitle = new SelectElement(dropdownTitle);
                selectTitle.SelectByValue(title);

                //edit degree
                editedDegree.Clear();
                editedDegree.SendKeys(degree);

                //edit graduation year
                var selectGraduationYear = new SelectElement(dropdownYear);
                selectGraduationYear.SelectByValue(graduationYear);

                //Click update button
                buttonUpdate.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("No education is found.", ex.Message);
            }
        }

        public void DeleteEducation(string university)
        {
            try
            {
                //wait for button delete
                WaitHelpers.WaitToBeClickable(driver, "XPath", e_buttonDelete, 3);

                //Check if university is matching the university to be deleted
                string deletedUniversity = GetUniversity();
                if (deletedUniversity == university)
                {
                    //click on delete button
                    buttonDelete.Click();
                }
                else
                {
                    Assert.Fail("No matching country found.");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("No country is found.", ex.Message);
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
