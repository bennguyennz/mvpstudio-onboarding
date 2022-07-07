using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Onboarding.Utilities;

namespace Onboarding.Pages
{
    public class ProfilePage
    {
        public string getWecomeText(IWebDriver driver)
        {
            string wecomeTextXPath = "/html/body/div[1]/div/div[1]/div[2]/div/span";
            WaitHelpers.WaitToBeVisible(driver, "XPath", wecomeTextXPath, 3);
            IWebElement welcomeText = driver.FindElement(By.XPath(wecomeTextXPath));
            return welcomeText.Text;
        }
        public void addDescription(IWebDriver driver)
        {
            //Click Decription
            string XPathDescriptionButton = "//div[@class='content']/div/h3/span";
            WaitHelpers.WaitToBeClickable(driver, "XPath", XPathDescriptionButton, 5);
            IWebElement descriptionButton = driver.FindElement(By.XPath(XPathDescriptionButton));
            descriptionButton.Click();

            //Enter description
            IWebElement descriptionTextBox = driver.FindElement(By.XPath("//div[@class='field  ']/textarea"));
            descriptionTextBox.Click();
            descriptionTextBox.Clear();
            descriptionTextBox.SendKeys("I’m a motivated professional who is passionate about IT.");

            //Click SaveButton
            IWebElement saveButton = driver.FindElement(By.XPath("//button[@type='button']"));
            saveButton.Click();
        }
        public string GetAddedDesription(IWebDriver driver)
        {
            string addedDescriptionXPath = "//div[@class='ui fluid card']/div/div[1]/span";
            WaitHelpers.WaitToBeVisible(driver, "XPath", addedDescriptionXPath, 3);
            IWebElement addedDescription = driver.FindElement(By.XPath(addedDescriptionXPath));
            return addedDescription.Text;
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

        public void EditMyContactDetails(IWebDriver driver, string strFirstName, string strLastName, string availability, string hour, string earnTarget)
        {
            //wait for dropdown icon to be clickable
            string xpValue = "//div[@class='title']/i[@class='dropdown icon']";
            WaitHelpers.WaitToBeClickable(driver, "XPath", xpValue, 3);

            //Click on dropdown icon before Full name
            IWebElement dropdownIcon = driver.FindElement(By.XPath(xpValue));
            dropdownIcon.Click();

            //Edit first name
            string xpNameValue = "firstName";
            WaitHelpers.WaitToBeClickable(driver, "Name", xpNameValue, 3);
            IWebElement firstName = driver.FindElement(By.Name(xpNameValue));

            firstName.Clear();
            firstName.SendKeys(strFirstName);


            //last name
            IWebElement lastName = driver.FindElement(By.Name("lastName"));
            firstName.Click();
            lastName.Clear();
            lastName.SendKeys(strLastName);

            //click Save
            IWebElement buttonSave = driver.FindElement(By.XPath("//button[@class='ui teal button']"));
            buttonSave.Click();


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            //Click on dit Availability
            string elementButtonAvailabilityType = "//div[@class='ui list']/div[2]/div/span/i";
            driver.FindElement(By.XPath(elementButtonAvailabilityType)).Click();

            string elementAvailabilityType = "availabiltyType";
            WaitHelpers.WaiToBeExistent(driver, "Name", elementAvailabilityType, 3);
            var availabilityType = new SelectElement(driver.FindElement(By.Name(elementAvailabilityType)));
            availabilityType.SelectByText(availability);

            //Click on edit Hours
            IWebElement editAvailabilityHour = driver.FindElement(By.XPath("//div[@class='ui list']/div[3]/div/span/i"));
            editAvailabilityHour.Click();

            string elementAvailibilityHour = "availabiltyHour";
            WaitHelpers.WaiToBeExistent(driver, "Name", elementAvailibilityHour, 3);

            var availabilityHour = new SelectElement(driver.FindElement(By.Name(elementAvailibilityHour)));
            availabilityHour.SelectByText(hour);

            //Click on Edit Earn Targe
            IWebElement editEarnTarget = driver.FindElement(By.XPath("//div[@class='ui list']/div[4]/div/span/i"));
            editEarnTarget.Click();

            string elementAvailabilityTarget = "availabiltyTarget";
            WaitHelpers.WaiToBeExistent(driver, "Name", elementAvailabilityTarget, 3);

            var availabiltyTarget = new SelectElement(driver.FindElement(By.Name(elementAvailabilityTarget)));
            availabiltyTarget.SelectByText(earnTarget);
        }

        public string GetFullName(IWebDriver driver)
        {
            IWebElement fullName = driver.FindElement(By.XPath("//div[@class='title']"));
            return fullName.Text;
        }

        public string GetAvailabilityType(IWebDriver driver)
        {
            IWebElement availabiltyType = driver.FindElement(By.XPath("//div[@class='ui list']/div[2]/div/span"));
            return availabiltyType.Text;
        }

        public string GetAvailityHour(IWebDriver driver)
        {
            IWebElement availabiltyHour = driver.FindElement(By.XPath("//div[@class='ui list']/div[3]/div/span"));
            return availabiltyHour.Text;
        }

        public string GetAvailityTarget(IWebDriver driver)
        {
            IWebElement availabiltyTarget = driver.FindElement(By.XPath("//div[@class='ui list']/div[4]/div/span"));
            return availabiltyTarget.Text;
        }
    }
}
