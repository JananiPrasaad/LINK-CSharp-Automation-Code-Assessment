using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading;

namespace LinkGroup.DemoTests.ReusableFile
{
    class WebDriver
    {
        public IWebDriver _currentWebDriver;
        public static string BrowserDriverPath = ConfigurationManager.AppSettings["BrowserDriverPath"];
        //private Local browserStackLocal;
        public IWebDriver Current
        {

            get
            {

                if (_currentWebDriver != null)
                    return _currentWebDriver;
                BrowserDriverPath = CommonMethods.BasePath + BrowserDriverPath;



                //_currentWebDriver = new ChromeDriver() { Url = SeleniumBaseUrl };
                ChromeOptions option = new ChromeOptions();
                ChromeDriverService service = ChromeDriverService.CreateDefaultService(CommonMethods.BasePath + @"\Drivers\ChromeDriver");
                service.SuppressInitialDiagnosticInformation = true;
                option.AddArgument("--disable-extensions");
                option.AddUserProfilePreference("profile.password_manager_enabled", false);
                option.AddUserProfilePreference("credentilas_enabled_service", false);
                option.AddArgument("--start-maximized");
                option.AddArgument("--allow-file-acces-from-file");
                option.AddArgument("--disable-popup-blocking");
                option.AddUserProfilePreference("download.default_directory", CommonMethods.BasePath + @"\Downloads\");
                //option.AddUserProfilePreference("intl.accept_languages", "nl");
                option.AddUserProfilePreference("disable-popup-blocking", "true");
                int threadId = Thread.CurrentThread.ManagedThreadId;
                string downloadDirPath = CommonMethods.BasePath + @"\Downloads" + @"\Downloads" + "_" + threadId + @"\";

                System.IO.Directory.CreateDirectory(downloadDirPath);
                option.AddUserProfilePreference("download.default_directory", downloadDirPath);
                option.AddUserProfilePreference("plugins.always_open_pdf_externally", true);

                option.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
                //option.AddArgument("--headless");
                //user agent
                //option.AddArgument("--user-agent=Mozilla/5.0 (iPhone; CPU iPhone OS 6_0 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5376e Safari/8536.25");
                _currentWebDriver = new ChromeDriver(service, option);
                return _currentWebDriver;
            }

        }
        private WebDriverWait _wait;
        public WebDriverWait Wait
        {
            get
            {
                if (_wait == null)
                {
                    this._wait = new WebDriverWait(Current, TimeSpan.FromSeconds(10));
                }
                return _wait;
            }
        }

        protected string BrowserConfig => ConfigurationManager.AppSettings["browser"];

        protected string SeleniumBaseUrl => ConfigurationManager.AppSettings["seleniumBaseUrl"];

        public void Quit()
        {
            _currentWebDriver?.Quit();
        }
    }
}
