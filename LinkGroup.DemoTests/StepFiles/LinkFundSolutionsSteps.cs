using LinkGroup.DemoTests.Helpers;
using LinkGroup.DemoTests.HooksFile;
using LinkGroup.DemoTests.Pages;
using LinkGroup.DemoTests.ReusableFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace LinkGroup.DemoTests.StepFiles
{
    [Binding]
    public class LinkFundSolutionsSteps
    {

        LinkFundSolutionsPages linkFundSolutionsPages = new LinkFundSolutionsPages();


        InputDataFile inputDataFile = InputDataFile.getInstance();

        [When("I open the Fund Solutions page")]
        public void launchUrlForFundSolutions()
        {
            try
            {
                linkFundSolutionsPages.launchLinkFundSolutionsUrl(inputDataFile.linkFundSolutionsUrl);
                LogFile.LogInformation("Fund solutions url is launched successfully");
                linkFundSolutionsPages.clickOnAgreeCookies();
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
        [Then("I can select the (.*) jurisdiction")]
        public void selectJurisdiction(string value)
        {
            try
            {
                switch (value)
                {
                    case "UK":
                        linkFundSolutionsPages.clickUnitedKingdom();
                        linkFundSolutionsPages.verifyUKFunds();
                        LogFile.LogInformation("UK funds are verified successfully");
                        break;
                    case "Swiss":
                        linkFundSolutionsPages.clickSwitzerland();
                        linkFundSolutionsPages.verifySwissFunds();
                        LogFile.LogInformation("Swiss funds are verified successfully");
                        break;
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
    }
}
