using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using TestProject1.CustomMethods;

namespace TestProject1.PageObjects
{
    public class AddCustomer
    {
        IWebDriver driver;
        public AddCustomer(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement firstNameTextField => driver.FindElement(By.Name("fname"));
        public IWebElement lastNameTextField => driver.FindElement(By.Name("lname"));
        public IWebElement emailTextField => driver.FindElement(By.Name("email"));
        public IWebElement passwordTextField => driver.FindElement(By.Name("password"));
        public IWebElement mobileTextField => driver.FindElement(By.Name("mobile"));
        public IWebElement address1TextField => driver.FindElement(By.Name("address1"));
        public IWebElement address2TextField => driver.FindElement(By.Name("address2"));
        public IWebElement emailNewsLetterCheckBox => driver.FindElement(By.Name("newssub"));
        public IWebElement countryDropDown => driver.FindElement(By.XPath("//a[@class='select2-choice']"));
        public IWebElement selectCountry => driver.FindElement(By.XPath("//div[text()='India']"));
        public IWebElement submitButton => driver.FindElement(By.XPath("//button[text()='Submit']"));
        public IWebElement currencyDropDown => driver.FindElement(By.Name("currency"));
        public IWebElement balanceTxtField => driver.FindElement(By.Name("balance"));

        public void addCustomer()
        {
            try
            {
                firstNameTextField.SendKeys(TestContext.Parameters.Get("customerFirstName"));
                lastNameTextField.SendKeys(TestContext.Parameters.Get("customerLastName"));
                emailTextField.SendKeys(TestContext.Parameters.Get("customerEmail"));
                passwordTextField.SendKeys(TestContext.Parameters.Get("customerPassword"));
                mobileTextField.SendKeys("0123456789");
                countryDropDown.Click();
                selectCountry.Click();
                address1TextField.SendKeys("Bengluru");
                BaseClass baseClass = new BaseClass();
                BaseClass.SelectFromDropDownByText(currencyDropDown, "INR");
                balanceTxtField.SendKeys("1200");
                submitButton.Click();

            }
            catch (Exception e)
            {
                Assert.Fail("Not able to Submit Form");
                driver.Quit();

            }

        }
    }
}
