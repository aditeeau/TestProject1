using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

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
        
        public IWebElement addButton => driver.FindElement(By.XPath("//button[@type='submit']")); //for katolon demo page
    }
}
