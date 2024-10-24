using OpenQA.Selenium;

namespace OrangeHRM.Test.PageObjects
{
    internal class AddEmployeePage
    {
        private readonly IWebDriver _driver;
        public AddEmployeePage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

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
        public string GetCurrentUrl() => _driver.Url;
        public bool IsOnAddEmployeePage() => GetCurrentUrl().Contains("addEmployee");
        public bool IsOnEmployeeListPage() => GetCurrentUrl().Contains("viewEmployeeList");
        public void NavigateToEmployeeList()
        {
            EmployeeListButton.Click();
        }
        public bool IsEmployeeInResults(string username)
        {
            NavigateToEmployeeList();
            var rows = _driver.FindElements(By.ClassName("oxd-table-row"));
            foreach (var row in rows)
            {
                if (row.Text.Contains(username))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
