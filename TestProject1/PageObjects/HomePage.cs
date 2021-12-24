using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestProject1.PageObjects
{
    internal class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        //public IWebElement accountsButton => driver.FindElement(By.XPath("(//a[@role='button'])[2])"));
        public IWebElement customersLink => driver.FindElement(By.XPath("//a[text()='Customers']"));

        public IWebElement accountsLink => driver.FindElement(By.XPath("//*[contains(text(),'Accounts')]"));
    }
}
