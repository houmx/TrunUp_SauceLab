using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUp_SauceLab.TestCases
{
    [TestFixture]
    public class Base
    {
        protected IWebDriver driver;
        protected string browser;
        protected string version;
        protected string os;
        protected string username = "SammyHou";
        protected string accessKey = "6f1dc052-2ca6-4c3d-a42c-f79267b051c5";

        public Base(string browser,string version, string os)
        {
            this.browser = browser;
            this.version = version;
            this.os = os;

        }

        [SetUp]
        public void Init()
        {
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability("browserName", browser);
            caps.SetCapability("platform",os);
            caps.SetCapability("version", version);
            caps.SetCapability("name", TestContext.CurrentContext.Test.Name);

            caps.SetCapability("username",username);
            caps.SetCapability("accessKey", accessKey);

            driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"),caps);

        }


        [TearDown]
        public void CleanUp()
        {
            bool passed = TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed;
            try
            {
                // Logs the result to Sauce Labs
                ((IJavaScriptExecutor)driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            }
            finally
            {
                // Terminates the remote webdriver session
                driver.Quit();
            }
        }
    }
}
