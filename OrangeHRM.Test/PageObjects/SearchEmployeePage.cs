using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
        public IWebElement EmployeeNumberField => _driver.FindElement(By.CssSelector(".oxd-grid-item:nth-child(2) .oxd-input"));
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

        public bool CompareSearchResult(string searchresult)
        {   
            var recordsFoundElement = _driver.FindElement(By.XPath("//span[text()[contains(., 'Records Found')]]"));
            string recordsFoundText = recordsFoundElement.Text;
            return recordsFoundText.Contains(searchresult);
        }
    }
}
