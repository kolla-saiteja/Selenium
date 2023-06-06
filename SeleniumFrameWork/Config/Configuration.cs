using SeleniumFrameWork.Drivers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumFrameWork.Config
{
    public class Configuration
    {
        public Configuration()
        {

        }
        public string Browser { get; set; }
        public int ImplicitWaitSeconds { get; set; }
        public int WaitUntilTimeoutSeconds { get; set; }
        public  string SiteUrl { get; set; }
        public int PageLoadWaitSeconds { get; set; }
        public int DownloadWaitSeconds { get; set; }
        public bool RunInHeadlessMode { get; set; }
        public int HeadlessResolutionWidth { get; set; }
        public int HeadlessResolutionHeight { get; set; }


    }
}
