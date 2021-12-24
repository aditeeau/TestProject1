using OpenQA.Selenium;

namespace TestProject1.Tests
{
    internal class DashboardPage
    {
        private IWebDriver driver;

        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}