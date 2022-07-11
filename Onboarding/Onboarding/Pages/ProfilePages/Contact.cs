using NUnit.Framework;
using Onboarding.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Pages.ProfilePages
{
    public class Contact
    {
        public string GetMessage(IWebDriver driver)
        {
            string messageXpath = "//div[@class='ns-box-inner']";
            WaitHelpers.WaitToBeVisible(driver, "XPath", messageXpath, 3);
            IWebElement message = driver.FindElement(By.XPath(messageXpath));
            return message.Text;
        }

        public void EditMyContactDetails(IWebDriver driver, string strFirstName, string strLastName, string availability, string hour, string earnTarget)
        {
            switch (availability)
            {
                case "Part Time":
                    availability = "0";
                    break;
                case "Full Time":
                    availability = "1";
                    break;
                default:
                    Assert.Fail("Availability Type is not matching");
                    break;
            }
            switch (hour)
            {
                case "Less than 30hours a week":
                    hour = "0";
                    break;
                case "More than 30hours a week":
                    hour = "1";
                    break;
                case "As needed":
                    hour = "2";
                    break;
                default:
                    Assert.Fail("Hour is not matching");
                    break;
            }
            switch (earnTarget)
            {
                case "Less than $500 per month":
                    earnTarget = "0";
                    break;
                case "Between $500 and $1000 per month":
                    earnTarget = "1";
                    break;
                case "More than $1000 per month":
                    earnTarget = "2";
                    break;
                default:
                    Assert.Fail("Earn Target is not matching");
                    break;
            }

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
            firstName.Click();
            firstName.Clear();
            firstName.SendKeys(strFirstName);

            //edit last name
            IWebElement lastName = driver.FindElement(By.Name("lastName"));
            lastName.Click();
            lastName.Clear();
            lastName.SendKeys(strLastName);

            //click Save
            IWebElement buttonSave = driver.FindElement(By.XPath("//button[@class='ui teal button']"));
            buttonSave.Click();

            //Wait for Save completed and Name appears.
            WaitHelpers.WaitToBeVisible(driver, "XPath", "//div[@class = 'title']", 3);

            //Click edit Availibility Type
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath("//div[@class='ui list']/div[2]/div/span/i"))).Click().Build().Perform();

            //Select type
            string elementAvailabilityType = "//select[@name='availabiltyType']";
            WaitHelpers.WaitToBeVisible(driver, "XPath", elementAvailabilityType, 3);
            var availabilityType = new SelectElement(driver.FindElement(By.XPath(elementAvailabilityType)));
            availabilityType.SelectByValue(availability);

            //Click on edit Hours
            IWebElement editAvailabilityHour = driver.FindElement(By.XPath("//div[@class='ui list']/div[3]/div/span/i"));
            editAvailabilityHour.Click();

            //Select hours
            string elementAvailibilityHour = "//select[@name='availabiltyHour']";
            WaitHelpers.WaitToBeVisible(driver, "XPath", elementAvailibilityHour, 3);
            var availabilityHour = new SelectElement(driver.FindElement(By.XPath(elementAvailibilityHour)));
            availabilityHour.SelectByValue(hour);

            //Click on Edit Earn Targe
            IWebElement editEarnTarget = driver.FindElement(By.XPath("//div[@class='ui list']/div[4]/div/span/i"));
            editEarnTarget.Click();

            //Select Earn Target
            string elementAvailabilityTarget = "//select[@name='availabiltyTarget']";
            WaitHelpers.WaitToBeVisible(driver, "XPath", elementAvailabilityTarget, 3);
            var availabiltyTarget = new SelectElement(driver.FindElement(By.XPath(elementAvailabilityTarget)));
            availabiltyTarget.SelectByValue(earnTarget);
        }

        public string GetFullName(IWebDriver driver)
        {
            string xpValue = "//div[@class='title']";
            WaitHelpers.WaitToBeVisible(driver, "XPath", xpValue, 3);
            IWebElement fullName = driver.FindElement(By.XPath(xpValue));
            return fullName.Text;
        }

        public string GetAvailabilityType(IWebDriver driver)
        {
            string xpValue = "//div[@class='ui list']/div[2]/div/span";
            WaitHelpers.WaitToBeVisible(driver, "XPath", xpValue, 3);
            IWebElement availabiltyType = driver.FindElement(By.XPath(xpValue));
            return availabiltyType.Text;
        }

        public string GetAvailityHour(IWebDriver driver)
        {
            string xpValue = "//div[@class='ui list']/div[3]/div/span";
            WaitHelpers.WaitToBeVisible(driver, "XPath", xpValue, 3);
            IWebElement availabiltyHour = driver.FindElement(By.XPath(xpValue));
            return availabiltyHour.Text;
        }

        public string GetAvailityTarget(IWebDriver driver)
        {
            string xpValue = "//div[@class='ui list']/div[4]/div/span";
            WaitHelpers.WaitToBeVisible(driver, "XPath", xpValue, 3);
            IWebElement availabiltyTarget = driver.FindElement(By.XPath(xpValue));
            return availabiltyTarget.Text;
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
    }
}
