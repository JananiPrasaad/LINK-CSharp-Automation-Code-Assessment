using LinkGroup.DemoTests.Helpers;
using LinkGroup.DemoTests.HooksFile;
using Microsoft.VisualBasic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace LinkGroup.DemoTests.ReusableFile
{
    public class CommonMethods
    {
        InputDataFile inputDataFile = InputDataFile.getInstance();
        public static IWebDriver driver = null;
        public static string BrowserdriverPath = ConfigurationManager.AppSettings["BrowserdriverPath"];
        // public static string BrowserdriverPath = ConfigHelper.GetConfigValue("BrowserdriverPath");

        public static WebDriverWait wait;


        public static void LaunchBrowser()
        {
            WebDriver _webDriver = new WebDriver();
            driver = _webDriver.Current;
        }

        public void LaunchGoogleChrome()
        {


            BrowserdriverPath = CommonMethods.BasePath + BrowserdriverPath;

            ChromeOptions option = new ChromeOptions();
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(BrowserdriverPath + @"\drivers\Chromedriver");
            service.SuppressInitialDiagnosticInformation = true;
            option.AddArgument("--disable-extensions");
            option.AddUserProfilePreference("profile.password_manager_enabled", false);
            option.AddUserProfilePreference("credentilas_enabled_service", false);
            option.AddArgument("--start-maximized");
            option.AddArgument("--allow-file-acces-from-file");
            option.AddArgument("--disable-popup-blocking");
            option.AddArgument("disable-infobars");
            option.AddArgument("test-type");
            option.AddUserProfilePreference("EnablePartialRendering", false);
            driver = new ChromeDriver(service, option);

        }
        public static string BasePath
        {
            get
            {
                var basePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                return basePath;
            }
        }
        public static string GetElementText(IWebElement element)
        {
            try { return element.Text; }
            catch (Exception e)
            {
                LogFile.LogInformation(e.ToString());
                CaptureScreenshot();
                SetupFile._status = "Fail";
                SetupFile._statusMessage = e.ToString();
                throw new Exception(e.ToString());
            }

        }
        public static void Closedriver()
        {
            //driver.Close();
            driver.Quit();
        }
        public static void launchUrl(string url)
        {

            driver.Navigate().GoToUrl(url);
        }
        public static void ScrollToTopOfPage()
        {
            try
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("scroll(0, -250);");
            }
            catch (Exception e)
            {
                CaptureScreenshot();
                SetupFile._status = "Fail";
                SetupFile._statusMessage = e.ToString();
                throw new Exception(e.ToString());
            }
        }
        public static void CaptureScreenshot()
        {
            try
            {
                ScrollToTopOfPage();
                string basePath = CommonMethods.BasePath;
                string path = basePath + @"\Screenshots\output";
                //string path = basePath + @"\Screenshots\output\"+name;
                var filename = string.Empty + DateTime.Now.ToString("ddmmyyyyHHmmss");
                filename = path + @"\" + filename;
                // Take Screenshot
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@filename, ScreenshotImageFormat.Jpeg);

                Console.WriteLine(@"Screenshot: {0}", new Uri(filename));
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }
        public static bool IsElementDisplayed(IWebElement ele)
        {
            bool actres;
            try
            {

                actres = ele.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
            return actres;
        }
        public static string GetUrl
        {
            get
            {
                return driver.Url;
            }
        }
        public static void WaitForPageToLoadComplete(int min)
        {
            try
            {
                int i = 0;
                do
                {
                    IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromMinutes(min));
                    IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                    executor.ExecuteScript("return document.readyState").Equals("complete");
                    i++;
                }
                while (i <= 2);
            }
            catch (Exception e)
            {
                LogFile.LogInformation(e.ToString());
                CaptureScreenshot();
                SetupFile._status = "Fail";
                SetupFile._statusMessage = e.ToString();
                throw new Exception(e.ToString());
            }
        }
        public static void ExplicitWait(int sec)
        {
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(sec));
        }

        public static string GetScreenShotPath()
        {
            return ConfigurationManager.AppSettings["Browser"];
        }

        public static string GetEnvironment()
        {
            return ConfigurationManager.AppSettings["Environment"];
        }
        public static void ClickElement(IWebElement ele)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            CommonMethods.ExplicitWait(3);
            executor.ExecuteScript("arguments[0].scrollIntoView(true);", new object[] { ele });
            ele.Click();
        }
        public static void MouseHover(IWebElement ele)
        {
            try
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                CommonMethods.ExplicitWait(3);
                executor.ExecuteScript("arguments[0].scrollIntoView(true);", ele);
                var action = new Actions(driver);
                action.MoveToElement(ele).Perform();
            }
            catch (Exception e)
            {
                CaptureScreenshot();
                LogFile.LogErrorInformation(e.ToString());
                SetupFile._status = "Fail";
                SetupFile._statusMessage = e.ToString();
                throw new Exception(e.ToString());
            }
        }
    }
}
