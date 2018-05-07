using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUp_SauceLab.TestCases
{
    [TestFixture("chrome", "46", "Windows 10")]
    [TestFixture("Safari", "11.0", "macOS 10.12")]
    class SauceNUnit_Test :Base
    {
        public SauceNUnit_Test(string browser, string version, string os) : base(browser, version, os)
        {
        }

        [Test,Property("Description","Search on Google")]
        public void googleTest()
        {
            driver.Navigate().GoToUrl("http://www.google.com");
            string title = driver.Title;
            Assert.That(title.Contains("Google"));

            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("Sauce Labs");
            query.Submit();
        }



    }
}
