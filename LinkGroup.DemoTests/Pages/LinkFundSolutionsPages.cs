using LinkGroup.DemoTests.Helpers;
using LinkGroup.DemoTests.HooksFile;
using LinkGroup.DemoTests.ReusableFile;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkGroup.DemoTests.Pages
{
    public class LinkFundSolutionsPages
    {
   

        InputDataFile inputDataFile = InputDataFile.getInstance();

        IWebElement agreeBtn => CommonMethods.driver.FindElement(By.XPath("//a[text()='Agree']"));
        IWebElement fundsDrpDwn => CommonMethods.driver.FindElement(By.Id("navbarDropdown"));
        IWebElement unitedKingdomFundLink => CommonMethods.driver.FindElement(By.XPath("//a[contains(text(),'UK')]"));
        IWebElement switzerlandFundLink => CommonMethods.driver.FindElement(By.XPath("//a[contains(text(),'Swiss')]"));
        IWebElement fundsForUK => CommonMethods.driver.FindElement(By.XPath("//h1[contains(text(),'UK')]"));
        IWebElement fundsForSwiss => CommonMethods.driver.FindElement(By.XPath("//h1[contains(text(),'Swiss')]"));

        public void launchLinkFundSolutionsUrl(string url)
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
        public void clickUnitedKingdom()
        {
            CommonMethods.MouseHover(fundsDrpDwn);
            LogFile.LogInformation("Mouse over click on funds drop down");
            CommonMethods.ClickElement(unitedKingdomFundLink);
            LogFile.LogInformation("Clicked on United kingdom fund link");
        }
        public void clickSwitzerland()
        {
            CommonMethods.MouseHover(fundsDrpDwn);
            LogFile.LogInformation("Mouse over click on funds drop down");
            CommonMethods.ClickElement(switzerlandFundLink);
            LogFile.LogInformation("Clicked on Switzerland fund link");
        }
        public void verifyUKFunds()
        {
            string actualResult = CommonMethods.GetElementText(fundsForUK);
            string expectedResult = inputDataFile.expectedFundForUK;
            try
            {
                Assert.IsTrue(actualResult.Contains(expectedResult));
                LogFile.LogInformation("UK funds are verified successfully.");
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
        public void verifySwissFunds()
        {
            string actualResult = CommonMethods.GetElementText(fundsForSwiss);
            string expectedResult = inputDataFile.expectedFundForSwiss;
            try
            {
                Assert.IsTrue(actualResult.Contains(expectedResult));
                LogFile.LogInformation("Swiss funds are verified successfully.");
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
