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
    public class MakeAppointmentPage
    {
        IWebDriver driver;
        public TestContext TestContext { get; set; }
        string dates = TestContext.Parameters.Get("day");
        public MakeAppointmentPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement facilityDropDown => driver.FindElement(By.Id("combo_facility"));
        public IWebElement applyReadmissionCheckBox => driver.FindElement(By.Id("chk_hospotal_readmission"));
        public IWebElement healthcareProgramMedicareRadionBtn => driver.FindElement(By.Id("radio_program_medicare"));
        public IWebElement healthcareProgramMedicaidRadionBtn => driver.FindElement(By.Id("radio_program_medicaid"));
        public IWebElement healthcareProgramNoneRadionBtn => driver.FindElement(By.Id("radio_program_none"));
        public IWebElement visitDate => driver.FindElement(By.Id("txt_visit_date"));
        public IWebElement commentTextArea => driver.FindElement(By.Id("txt_comment"));
        public IWebElement bookAppointmentBtn => driver.FindElement(By.Id("btn-book-appointment"));
        public IWebElement confirmationHeader => driver.FindElement(By.XPath("//h2[text()='Appointment Confirmation']"));
        public IWebElement anyDate => driver.FindElement(By.Id("//th[text()='"+ DateTime.Today.ToString("MMMM yyyy")+"']/ancestor::table[@class='table - condensed']/descendant::tbody/tr/td[text()='"+ dates+"']"));

        public void bookAppointment()
        {
            try
            {
                //facilityDropDown.Click();
                BaseClass.SelectFromDropDownByValue(facilityDropDown, TestContext.Parameters.Get("Tokyo CURA Healthcare Center"));
                applyReadmissionCheckBox.Click();
                healthcareProgramMedicareRadionBtn.Click();
                visitDate.Click();
                anyDate.Click();
                commentTextArea.SendKeys("book appointment");
                bookAppointmentBtn.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Test Fail: Something Went Wrong", ex.Message);
                throw;
            }
        }
    }   
}
