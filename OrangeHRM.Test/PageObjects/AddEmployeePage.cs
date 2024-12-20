﻿using OpenQA.Selenium;
using OrangeHRM.Test.Data;

namespace OrangeHRM.Test.PageObjects
{
    internal class AddEmployeePage : PageBase
    {
        public AddEmployeePage(IWebDriver webDriver) : base(webDriver) { }

        public IWebElement FirstNameField => _driver.FindElement(By.Name("firstName"));
        public IWebElement MiddleNameField => _driver.FindElement(By.Name("middleName"));
        public IWebElement LastNameField => _driver.FindElement(By.Name("lastName"));
        public IWebElement EmployeeIdField => _driver.FindElement(By.Name("employeeId"));
        public IWebElement CreateLoginDetailsToggleButton => _driver.FindElement(By.CssSelector("input[type='checkbox']"));
        public IWebElement UserNameField => _driver.FindElement(By.Name("userName"));
        public IWebElement StatusField => _driver.FindElement(By.Name("status"));
        public IWebElement PasswordField => _driver.FindElement(By.Name("password"));
        public IWebElement ConfirmPasswordField => _driver.FindElement(By.Name("confirmPassword"));
        public IWebElement SaveButton => _driver.FindElement(By.XPath("//button[@type='submit']"));
        public IWebElement CancelButton => _driver.FindElement(By.CssSelector("button[type=\"button\"]"));
        public IWebElement EmployeeListButton => _driver.FindElement(By.LinkText("Employee List"));

        public void EnterEmployeeFirstName(string firstName)
        {
            FirstNameField.Clear();
            FirstNameField.SendKeys(firstName);
        }
        public void EnterEmployeeMiddleName(string MiddleName)
        {
            MiddleNameField.Clear();
            MiddleNameField.SendKeys(MiddleName);
        }
        public void EnterEmployeeLastName(string LastName)
        {
            LastNameField.Clear();
            LastNameField.SendKeys(LastName);
        }
        public void EnterEmployeeEmployeeId(string EmployeeId)
        {
            EmployeeIdField.Clear();
            EmployeeIdField.SendKeys(EmployeeId);
        }
        public void ClickCreateLoginDetails()
        {
            bool status;
            bool.TryParse(CreateLoginDetailsToggleButton.GetAttribute("value"), out status);
            CreateLoginDetailsToggleButton.SendKeys((!status).ToString());
        }
        public void EnterEmployeeUserName(string UserName)
        {
            UserNameField.Clear();
            UserNameField.SendKeys(UserName);
        }
        public void EnterEmployeePassword(string Password)
        {
            PasswordField.Clear();
            PasswordField.SendKeys(Password);
        }
        public void EnterEmployeeConfirmPassword(string ConfirmPassword)
        {
            ConfirmPasswordField.Clear();
            ConfirmPasswordField.SendKeys(ConfirmPassword);
        }
        public void ClickSaveButton()
        {
            SaveButton.Click();
        }
        public void ClickCancelButton()
        {
            CancelButton.Click();
        }
        
        public bool IsOnAddEmployeePage() => GetCurrentUrl().Contains("addEmployee");
        public bool IsOnEmployeeListPage() => GetCurrentUrl().Contains("viewEmployeeList");
        public void NavigateToEmployeeList()
        {
            EmployeeListButton.Click();
        }
        public bool IsEmployeeInResults(string EmployeeId, string name)
        {
            var rows = _driver.FindElements(By.CssSelector(".oxd-table-body .oxd-table-row"));
            bool recordFound = false;
            foreach (var row in rows)
            {
                var employeeId = row.FindElement(By.XPath(".//div[@role='cell'][2]")).Text;
                var employeeName = row.FindElement(By.XPath(".//div[@role='cell'][3]")).Text;
                if (employeeId == EmployeeId || employeeName == name)
                {
                    recordFound = true;
                    break;
                }
            }
            return recordFound;
        }
    }
}
