using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestProject1.PageObjects
{
    internal class KatolonLoginPage
    {

        IWebDriver driver;
        public KatolonLoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement makeAppointmentBtn => driver.FindElement(By.Id("btn-make-appointment"));
        public IWebElement usernameTextField => driver.FindElement(By.Name("username"));
        public IWebElement passwordTextField => driver.FindElement(By.Name("password"));
        public IWebElement loginButton => driver.FindElement(By.Id("btn-login"));
        public IWebElement invalidError => driver.FindElement(By.XPath("//*[@class='lead text-danger']"));
        public IWebElement menuToggle => driver.FindElement(By.Id("menu-toggle"));
        public IWebElement logoutButton => driver.FindElement(By.XPath("//a[text()='Logout']"));

        public void LoginApplication(string userName, string passWord)
        {
            try
            {
                usernameTextField.Clear();
                usernameTextField.SendKeys(userName.Trim());
                passwordTextField.Clear();
                passwordTextField.SendKeys(passWord.Trim());
                loginButton.Click();
            }
            catch (Exception E)
            {
                Console.WriteLine("Test Fail: did not enter username and password  : {0}", E.Message);
                throw;
            }
        }
    }
}
