using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Test.PageObjects
{
    internal class SearchEmployeePage : PageBase
    {
        public SearchEmployeePage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement EmployeeNameField => _driver.FindElement(By.XPath("//input[@placeholder='Type for hints...']"));
        public IWebElement EmployeeNumberField => _driver.FindElement(By.Name("employeeNumber"));
        public IWebElement SearchButton => _driver.FindElement(By.XPath("//button[@type='submit']"));

        public void EnterEmployeeName(string name)
        {
            EmployeeNameField.Clear();
            EmployeeNameField.SendKeys(name);
        }

        public void EnterEmployeeNumber(string number)
        {
            EmployeeNumberField.Clear();
            EmployeeNumberField.SendKeys(number);
        }

        public void ClickSearchButton()
        {
            SearchButton.Click();
        }
    }
}
