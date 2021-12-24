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
    public class BookAppiointmentTest
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
        public void bookAppointmentTest()
        {
            KatolonLoginPage loginPage = new KatolonLoginPage(driver);
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("password"));

            MakeAppointmentPage makeAppointmentPage = new MakeAppointmentPage(driver);
            makeAppointmentPage.bookAppointment();
            
            Assert.IsTrue(AssertClass.IsElementPresent(driver, makeAppointmentPage.confirmationHeader), "Book Appointment Failed");
        }

    }
}
