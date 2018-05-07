using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SauceLab.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TurnUp_SauceLab.PageObjects
{
    class TimeMaterialCreatePage
    {
        IWebDriver driver;

        [FindsBy(How = How.XPath, Using = ".//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]")]
        IWebElement materialTypeCode { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='TypeCode_listbox']/li[2]")]
        IWebElement timeTypeCode { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='Code']")]
        IWebElement txtCode { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='Description']")]
        IWebElement txtDescrip { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")]
        IWebElement txtPricePerUnit { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='files']")]
        IWebElement uploadFile { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='SaveButton']")]
        IWebElement btnSave { get; set; }


        public TimeMaterialCreatePage(IWebDriver driver)
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

        public void CreateNewTimenMatirials(TimeMaterialData timematerialdata)
        {
            //Choose Time from the list
            if (timematerialdata.TypeCode == "T")
            {
                materialTypeCode.Click();
                WaitForDisplay(By.XPath(".//*[@id='TypeCode_listbox']/li[2]"), 2);

                timeTypeCode.Click();
            }

            txtCode.SendKeys(timematerialdata.Code);
            txtDescrip.SendKeys(timematerialdata.Description);

            //WaitForDisplay(By.XPath(".//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"), 3);
            Thread.Sleep(3000);
            txtPricePerUnit.SendKeys(timematerialdata.PricePerUnit);
            Thread.Sleep(3000);

            //Upload file
            string file = @timematerialdata.UploadFile;
            uploadFile.SendKeys(file);

            btnSave.Click();
        }


    }
}
