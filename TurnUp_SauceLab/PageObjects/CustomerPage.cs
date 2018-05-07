using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUp_SauceLab.PageObjects
{
    class CustomerPage
    {
        public void CreateCustomers(IWebDriver driver)
        {

            driver.FindElement(By.XPath("/html/body/div[4]/p/a")).Click();
            driver.FindElement(By.XPath("//input[@id='Code']")).SendKeys("4600");
            driver.FindElement(By.XPath("//input[@id='Description']")).SendKeys("this is from sammy");
            driver.FindElement(By.XPath("//html//span[@class='k-widget k-numerictextbox']//input[1]")).SendKeys("23");
            driver.FindElement(By.XPath("//input[@id='SaveButton']")).Click();
        }
    }
}