using LinkGroup.DemoTests.Helpers;
using LinkGroup.DemoTests.HooksFile;
using LinkGroup.DemoTests.ReusableFile;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LinkGroup.DemoTests.Pages
{
    public class LinkGroupPages
    {
        //IWebDriver driver;
        //public LinkGroupPages()
        //{
        //    driver = CommonMethods.driver;
        //}
        InputDataFile inputDataFile = InputDataFile.getInstance();


        IWebElement agreeBtn => CommonMethods.driver.FindElement(By.XPath("//a[text()='Agree']"));
        IWebElement homePageHeading => CommonMethods.driver.FindElement(By.Id("las-logo"));
        IWebElement searchDrpDwn => CommonMethods.driver.FindElement(By.Id("TN-search"));
        IWebElement searchTxtBx => CommonMethods.driver.FindElement(By.Name("searchTerm"));
        IWebElement searchBtn => CommonMethods.driver.FindElement(By.XPath("//button[text()='Search']"));
        IWebElement searchResults => CommonMethods.driver.FindElement(By.XPath("//h4[contains(text(),'Leeds')]"));


        public void launchLinkGroupUrl(string url)
        {
            CommonMethods.launchUrl(url);
            LogFile.LogInformation("Url is launched successfully");
            CommonMethods.WaitForPageToLoadComplete(10);
        }
        public void clickOnAgreeCookies()
        {
            bool a = CommonMethods.IsElementDisplayed(agreeBtn);
            if (a == true)
            {
                CommonMethods.ClickElement(agreeBtn);
                LogFile.LogInformation("Clicked on Agree button");
            }
            else
            {
                LogFile.LogInformation("Agree button is not displayed");
            }
        }

        public bool verifyHomePage()
        {
            bool element = CommonMethods.IsElementDisplayed(homePageHeading);
            return element;
        }
        public void searchForLeeds(String searchValue)
        {
            CommonMethods.MouseHover(searchDrpDwn);
            LogFile.LogInformation("Clicked on search drop down");
            searchTxtBx.SendKeys(searchValue);
            LogFile.LogInformation("Search value is entered");
            CommonMethods.ExplicitWait(2);
            searchTxtBx.SendKeys(Keys.Enter);
            CommonMethods.ExplicitWait(4);
        }
        public void verifySearchResults()
        {
            string actualResult = CommonMethods.GetElementText(searchResults);
            string expectedResult = inputDataFile.expectedSearchResults;
            try
            {
                Assert.IsTrue(actualResult.Contains(expectedResult));
                LogFile.LogInformation("Search results are verified successfully.");
            }
            catch (Exception)
            {
                CommonMethods.CaptureScreenshot();
                LogFile.LogErrorInformation("Failed due to expected and actual value differs::" + "Expected value is: " + expectedResult + "Actual value is:" + actualResult);
                SetupFile._status = "Fail";
                SetupFile._statusMessage = "Failed due to expected and actual value differs::" + "Expected value is: " + expectedResult + "Actual value is:" + actualResult;
                throw new Exception("Failed due to expected and actual value differs::" + "Expected value is: " + expectedResult + "Actual value is:" + actualResult);
            }
        }
    }
}
