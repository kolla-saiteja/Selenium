using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumFrameWork.Config;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumFrameWork.Drivers
{
    public static class Webdriver
    {
        public static IWebDriver Driver;
        public static WebDriverWait webDriverWait;

        public static int PageLoadWaitMilliseconds { get; private set; }
        public static int DownloadWaitMilliseconds { get; private set; }


        public static void SetAndOpenBrowser(Configuration config)
        {
            PageLoadWaitMilliseconds = config.PageLoadWaitSeconds * 1000;           
            DownloadWaitMilliseconds = config.DownloadWaitSeconds * 1000;

            if (Driver == null)
            {
                switch (config.Browser)
                {
                    case "Chrome":
                        ChromeOptions chromeOptions = new ChromeOptions();

                        if (config.RunInHeadlessMode)
                        {
                            chromeOptions.AddArguments("headless");
                            chromeOptions.AddArguments($"window-size={config.HeadlessResolutionWidth}x{config.HeadlessResolutionHeight}");
                            chromeOptions.AddArguments("disable-gpu");
                            chromeOptions.AddUserProfilePreference("download.default_directory", @"%USERPROFILE%\Downloads");
                        }

                        chromeOptions.AddArguments("--lang=en-GB");
                        Driver = new ChromeDriver(chromeOptions);
                        break;

                    case "CHROMIUM EDGE":

                        if (config.RunInHeadlessMode)
                        {
                            // TODO: Set to run in headless mode and set resolution
                        }
                        Driver = new EdgeDriver();

                        break;

                    case "FIREFOX":
                        FirefoxOptions firefoxOptions = new FirefoxOptions();

                        if (config.RunInHeadlessMode)
                        {
                            firefoxOptions.AddArguments("-headless");
                            firefoxOptions.AddArgument($"--width={config.HeadlessResolutionWidth}");
                            firefoxOptions.AddArgument($"--height={config.HeadlessResolutionHeight}");
                        }
                        Driver = new FirefoxDriver(firefoxOptions);
                        break;

                    default:
                        throw new Exception("Unable to determine which browser to use for automated test.");

                }

                Driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, config.ImplicitWaitSeconds);
                Driver.Manage().Window.Maximize();
                webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(config.WaitUntilTimeoutSeconds));
            }


        }

        public static void Navigate(string siteUrl)
        {
            Driver.Navigate().GoToUrl(siteUrl);
        }

        public static void QuitBrowser()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }



    }
}
