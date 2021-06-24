using LinkGroup.DemoTests.Helpers;
using LinkGroup.DemoTests.HooksFile;
using LinkGroup.DemoTests.Pages;
using LinkGroup.DemoTests.ReusableFile;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace LinkGroup.DemoTests.StepFiles
{
    [Binding]
    public class LinkGroupSteps
    {
        //public IWebDriver driver;  
        LinkGroupPages linkGroupPages = new LinkGroupPages();

        InputDataFile inputDataFile = InputDataFile.getInstance();



        [Given(@"I have opened the home page")]
        [When(@"I open the home page")]
        public void OpenHomePage()
        {
            try
            {
                linkGroupPages.launchLinkGroupUrl(inputDataFile.linkGroupUrl);
                LogFile.LogInformation("Link group url is launched");
            }
            catch (Exception e)
            {
                CommonMethods.CaptureScreenshot();
                LogFile.LogErrorInformation(e.ToString());
                SetupFile._status = "Fail";
                SetupFile._statusMessage = e.ToString();
                throw new Exception(e.ToString());
            }
        }
        [Then(@"the page is displayed")]
        public void VerifyHomePage()
        {
            try
            {

                linkGroupPages.clickOnAgreeCookies();
                bool a = linkGroupPages.verifyHomePage();
                if (a == true)
                {
                    LogFile.LogInformation("Home page is verified successfully");
                }
                else
                {
                    Assert.Fail("Home page is not displayed");
                }
            }
            catch (Exception e)
            {
                CommonMethods.CaptureScreenshot();
                LogFile.LogErrorInformation(e.ToString());
                SetupFile._status = "Fail";
                SetupFile._statusMessage = e.ToString();
                throw new Exception(e.ToString());
            }
        }
        [Given(@"I have agreed to the cookie policy")]
        public void AgreeCookiePolicy()
        {
            try
            {
                linkGroupPages.clickOnAgreeCookies();
                LogFile.LogInformation("Agreed with cookie policy");
                bool a = linkGroupPages.verifyHomePage();
                if (a == true)
                {
                    LogFile.LogInformation("Home page is verified successfully");
                }
                else
                {
                    Assert.Fail("Home page is not displayed");
                }
            }
            catch (Exception e)
            {
                CommonMethods.CaptureScreenshot();
                LogFile.LogErrorInformation(e.ToString());
                SetupFile._status = "Fail";
                SetupFile._statusMessage = e.ToString();
                throw new Exception(e.ToString());
            }
        }
        [When(@"I search for ""(.*)""")]
        public void SearchValue(string searchValue)
        {
            try
            {
                linkGroupPages.searchForLeeds(searchValue);
                LogFile.LogInformation("Given value has been searched");
            }
            catch (Exception e)
            {
                CommonMethods.CaptureScreenshot();
                LogFile.LogErrorInformation(e.ToString());
                SetupFile._status = "Fail";
                SetupFile._statusMessage = e.ToString();
                throw new Exception(e.ToString());
            }
        }
        [Then(@"the search results are displayed")]
        public void VerifySearchResults()
        {
            try
            {
                linkGroupPages.verifySearchResults();
                LogFile.LogInformation("Search functionality is verified successfully");
            }
            catch (Exception e)
            {
                CommonMethods.CaptureScreenshot();
                LogFile.LogErrorInformation(e.ToString());
                SetupFile._status = "Fail";
                SetupFile._statusMessage = e.ToString();
                throw new Exception(e.ToString());
            }
        }
    }
}
