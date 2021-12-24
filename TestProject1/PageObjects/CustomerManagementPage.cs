using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestProject1.PageObjects
{
    internal class CustomerManagementPage
    {
        IWebDriver driver;
        public CustomerManagementPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement addCustomerButton => driver.FindElement(By.XPath("//button[text()=' Add']"));
        public IWebElement selectAllCheckBox => driver.FindElement(By.Id("select_all"));
        public IWebElement editButton => driver.FindElement(By.XPath("//a[@title='Edit']"));
        public IWebElement deleteButton => driver.FindElement(By.XPath("//a[@title='DELETE']"));

        
        public IWebElement addButton => driver.FindElement(By.XPath("//button[@type='submit']"));
        public IWebElement specificCustomerCheckbox => driver.FindElement(By.XPath("//td[text()='Aditee']//preceding-sibling::td//input"));
        public IWebElement deleteCustomerButton => driver.FindElement(By.Id("deleteAll"));

    }
}
