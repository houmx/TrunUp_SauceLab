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
    class TimenMaterialPage
    {
        IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//a[@class='btn btn-primary']")]
        IWebElement btnCreateNew { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='tmsGrid']/div[3]/table/tbody")]
        IWebElement table { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='tmsGrid']/div[4]/a[3]/span")]
        IWebElement btnNextPage { get; set; }


        public TimenMaterialPage(IWebDriver driver)
        {
            this.driver = driver;
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

        public void ClickCreateNew()
        {

            WaitForDisplay(By.XPath("//a[@class='btn btn-primary']"), 3);
            btnCreateNew.Click();

        }

        public bool FindCertainRow(string code)
        {
            WaitForDisplay(By.XPath(".//*[@id='tmsGrid']/div[3]/table"), 3);

            List<IWebElement> row = new List<IWebElement>();
            row = table.FindElements(By.TagName("tr")).ToList();

            int rowNum = row.Count;

            try
            {
                while (true)
                {
                    for (int i = 1; i <= rowNum; i++)
                    {
                        IWebElement txtCode = driver.FindElement(By.XPath(".//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i + "]/td[1]"));
                        if (txtCode.Text == code)
                        {
                            return true;

                        }

                    }

                    btnNextPage.Click();
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
