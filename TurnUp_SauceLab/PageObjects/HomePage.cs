using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUp_SauceLab.PageObjects
{
    class HomePage
    {
        IWebDriver driver;

        [FindsBy(How = How.XPath, Using = ".//*[@id='logoutForm']/ul/li/a")]
        IWebElement userInfo { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Administration ')]")]
        IWebElement linkAdminstration { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/TimeMaterial']")]
        IWebElement linkTimenMaterials { get; set; }


        public HomePage(IWebDriver Driver)
        {
            driver = Driver;
            PageFactory.InitElements(driver, this);
        }

        private bool WaitForDisplay(By locator, int maxWaitTime)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(maxWaitTime));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return true;

            }
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
                return false;
            }
        }

        public bool ValidateHomePage()
        {
            WaitForDisplay(By.XPath(".//*[@id='logoutForm']/ul/li/a"), 3);

            if (userInfo.Displayed)
                return true;
            else
                return false;
        }

        public void NavigateToCustomerPage()
        {
            driver.FindElement(By.ClassName("dropdown-toggle")).Click();
            driver.FindElement(By.XPath("//li[@class='dropdown open']//li[3]")).Click();
        }

        public void NavigateToTimenMaterialsPage()
        {
            linkAdminstration.Click();

            WaitForDisplay(By.XPath("//a[@href='/TimeMaterial']"), 2);

            linkTimenMaterials.Click();
        }


    }
}
