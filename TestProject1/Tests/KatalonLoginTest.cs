using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject1.CustomMethods;
using TestProject1.PageObjects;

namespace TestProject1.Tests
{
    public class KatalonLoginTest
    {
        IWebDriver driver;
        public TestContext TestContext { get; set; }
        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(TestContext.Parameters.Get("url"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

        }
        [Test]
        public void VerifyValidLoginToApplication()
        {
            KatolonLoginPage loginPage = new KatolonLoginPage(driver);
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("password"));
            Assert.IsTrue(AssertClass.IsElementPresent(driver, loginPage.logoutButton), "User not on home page");

        }
        [Test]
        public void VerifyInValidLoginToApplication()
        {
            KatolonLoginPage loginPage = new KatolonLoginPage(driver);
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("wrongPassword"));
            Assert.IsTrue(AssertClass.IsElementPresent(driver, loginPage.invalidError), "No Error Found");

        }

        [Test]
        public void VerifyLogOutToApplication()
        {
            KatolonLoginPage loginPage = new KatolonLoginPage(driver);
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("password"));
            //System.Threading.Thread.Sleep(1000);
            //IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            //executor.ExecuteScript("document.body.style.zoom = '0.8'");
            loginPage.logoutButton.Click();
            Assert.IsTrue(AssertClass.IsElementPresent(driver, loginPage.makeAppointmentBtn), "User not redirected to Login page");

        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
