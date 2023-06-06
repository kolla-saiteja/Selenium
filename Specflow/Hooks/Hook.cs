using SeleniumFrameWork.Drivers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Configuration = SeleniumFrameWork.Config.Configuration;



namespace Specflow.Hooks
{
    [Binding]
    public class Hook
    {
        private readonly ScenarioContext scenarioContext;

        public Hook(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

       

        [BeforeScenario]
        public static void BeforeScenarioStartBrowser()
        {
            var config = new Configuration
            {
                SiteUrl = ConfigurationManager.AppSettings["SiteUrl"],
                Browser = ConfigurationManager.AppSettings["Browser"].ToString(),
                ImplicitWaitSeconds = Convert.ToInt32(ConfigurationManager.AppSettings["implicitWait"]),
                PageLoadWaitSeconds = Convert.ToInt32(ConfigurationManager.AppSettings["pageLoadWait"]),
                WaitUntilTimeoutSeconds = Convert.ToInt32(ConfigurationManager.AppSettings["WaitUntilTimeout"]),
                DownloadWaitSeconds = Convert.ToInt32(ConfigurationManager.AppSettings["DownloadWaitMilliseconds"]),
                RunInHeadlessMode = Convert.ToBoolean(ConfigurationManager.AppSettings["RunInHeadlessMode"]),
                HeadlessResolutionWidth = Convert.ToInt32(ConfigurationManager.AppSettings["HeadlessResolutionWidth"].ToString()),
                HeadlessResolutionHeight = Convert.ToInt32(ConfigurationManager.AppSettings["HeadlessResolutionHeight"].ToString())

            };

            Webdriver.SetAndOpenBrowser(config);
            Webdriver.Navigate(config.SiteUrl);
        }


        [Scope(Tag = "WithCloseBrowser")]
        [AfterScenario]
        public static void AfterScenarioSignOffAndCloseBrowser()
        {
            
            Webdriver.QuitBrowser();
        }



    }
}
