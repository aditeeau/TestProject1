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
    public class CustomersTest
    {

        IWebDriver driver;
        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(TestContext.Parameters.Get("url"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

        }
        [Test]
        public void AddNewCustomerTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("password"));
            //Navigate To Customer Management Page
            HomePage homePage = new HomePage(driver);
            //BaseClass baseClass = new BaseClass();
            BaseClass.ActionHoverAndClick(driver, homePage.accountsLink, homePage.customersLink);
            //Click Add Customer Button
            CustomerManagementPage customerManagementPage = new CustomerManagementPage(driver);
            customerManagementPage.addButton.Click();
            //Add Customer
            AddCustomer addCustomerPage = new AddCustomer(driver);
            addCustomerPage.addCustomer();
            //Verify Customer Created
            IWebElement verifyCustomer = driver.FindElement(By.XPath("//td[text()=" + "'" + TestContext.Parameters.Get("customerFirstName") + "']"));
            Assert.IsTrue(AssertClass.IsElementPresent(driver, verifyCustomer), "Customer not created or found on customer management page");
        }
        [Test]
        public void DeleteCustomerTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("password"));
            //Navigate To Customer Management Page
            HomePage homePage = new HomePage(driver);
            //BaseClass baseClass = new BaseClass();
            BaseClass.ActionHoverAndClick(driver, homePage.accountsLink, homePage.customersLink);
            //Delete Customer
            CustomerManagementPage customerManagementPage = new CustomerManagementPage(driver);
            customerManagementPage.specificCustomerCheckbox.Click();
            customerManagementPage.deleteCustomerButton.Click();
            Assert.IsFalse(AssertClass.IsElementPresent(driver, customerManagementPage.specificCustomerCheckbox), "Customer present page");
        }

    }
}
