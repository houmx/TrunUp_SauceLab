using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace TurnUp_SauceLab.PageObjects
{
    class LoginPage
    {

        IWebDriver driver;

        [FindsBy(How = How.Id, Using = "UserName")]
        IWebElement userName { get; set; }
        [FindsBy(How = How.Id, Using = "Password")]
        IWebElement Password { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        IWebElement loginBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//li[contains(text(),'Invalid username or password.')]")]
        IWebElement errMessage { get; set; }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        public void LoginWithValidData()
        {
            userName.SendKeys("ray");
            Password.SendKeys("123123");
            loginBtn.Click();
        }

        public void LoginWithInvalidData()
        {
            userName.SendKeys("ray");
            Password.SendKeys("456456");
            loginBtn.Click();
        }

        public bool DisplayErrorMessage()
        {
            if (errMessage.Displayed)
                return true;
            else
                return false;
        }
    }
}
