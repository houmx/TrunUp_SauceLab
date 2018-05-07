using NUnit.Framework;
using SauceLab.PageObjects;
using SauceLab.TestData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUp_SauceLab.TestCases
{
    [TestFixture("chrome", "46", "Windows 10")]
    [TestFixture("Safari", "11.0", "macOS 10.12")]
    class TestCreateTimenMaterials : Base
    {
        public TestCreateTimenMaterials(string browser, string version, string os) : base(browser, version, os)
        {
        }

        [Test, TestCaseSource("ReadDataFromCsv")]
        public void TestCreateSucess(TimeMaterialData timematerialdata)
        {
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");

            LoginPage loginpage = new LoginPage(driver);
            loginpage.LoginWithValidData();

            HomePage homepage = new HomePage(driver);
            homepage.NavigateToTimenMaterialsPage();

            TimenMaterialPage timematerialpage = new TimenMaterialPage(driver);
            timematerialpage.ClickCreateNew();

            TimeMaterialCreatePage timematerialcreatepage = new TimeMaterialCreatePage(driver);
            timematerialcreatepage.CreateNewTimenMatirials(timematerialdata);


            Assert.IsTrue(timematerialpage.FindCertainRow(timematerialdata.Code));

        }

        //Read the csv file
        public static IEnumerable<TimeMaterialData> ReadDataFromCsv()
        {
            using (var reader = new StreamReader(File.OpenRead(@"C:\Users\gaofei88\Documents\Visual Studio 2015\Projects\CrossBrowserTesting\SauceLab\TestData\TimeMaterialData.csv")))
            {

                while (!reader.EndOfStream)
                {
                    TimeMaterialData data = new TimeMaterialData();
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    data.TypeCode = values[0];
                    data.Code = values[1];
                    data.Description = values[2];
                    data.PricePerUnit = values[3];
                    data.UploadFile = values[4];
                    yield return data;
                }
            }

        }

    }
}
