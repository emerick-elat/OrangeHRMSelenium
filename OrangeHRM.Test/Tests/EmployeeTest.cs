using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeHRM.Test.Data;
using OrangeHRM.Test.PageObjects;

namespace OrangeHRM.Test.Tests
{
    [TestFixture]
    internal class EmployeeTest
    {
        private IWebDriver _driver;
        private AddEmployeePage _page;
        private LoginPage _loginPage;

        [SetUp]
        public void Setup()
        {
            _driver = BrowserFactory.CreateBrowser(BrowserType.Chrome);
            _driver.Manage().Window.Maximize();
            _page = new AddEmployeePage(_driver);
            _loginPage = new LoginPage(_driver);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void AddEmployee()
        {
            //1.Launch the application
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _driver.Navigate().GoToUrl(App.Url);

            //2.Enter valid username
            _loginPage.SetUsername(LoginData.Username);
            Assert.That(_loginPage.UsernameField.GetAttribute("value"), Is.EqualTo(LoginData.Username));
            //3.Enter valid password
            _loginPage.SetPassword(LoginData.Password);
            Assert.That(_loginPage.PasswordField.GetAttribute("value"), Is.EqualTo(LoginData.Password));
            //4.Click on login button
            _loginPage.ClickLoginButton();
            wait.Until(d => _loginPage.IsLoggedIn());
            Assert.IsTrue(_loginPage.IsLoggedIn());
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //5.Navigate to PIM from the menu
            _driver.FindElement(By.LinkText("PIM")).Click();
            Assert.IsTrue(_driver.FindElement(By.XPath("//h6[text()='PIM']")).Displayed, "PIM title not showing.");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //6.Click on the 'Add Employee' tab
            _driver.FindElement(By.LinkText("Add Employee")).Click();
            Assert.IsTrue(_page.IsOnAddEmployeePage());

            //7.Fill in the necessary details
            _page.EnterEmployeeFirstName(Employee.FirstName);
            Assert.That(_page.FirstNameField.GetAttribute("value"), Is.EqualTo(Employee.FirstName));

            _page.EnterEmployeeLastName(Employee.LastName);
            Assert.That(_page.LastNameField.GetAttribute("value"), Is.EqualTo(Employee.LastName));

            _page.EnterEmployeeMiddleName(Employee.MiddleName);
            Assert.That(_page.MiddleNameField.GetAttribute("value"), Is.EqualTo(Employee.MiddleName));

            #region
            //_page.EnterEmployeeEmployeeId(Employee.EmployeeId);
            //Assert.That(_page.EmployeeIdField.GetAttribute("value"), Is.EqualTo(Employee.EmployeeId));

            //_page.ClickCreateLoginDetails();

            //_page.EnterEmployeeUserName(Employee.Username);
            //Assert.That(_page.UserNameField.GetAttribute("value"), Is.EqualTo(Employee.Username));

            //_page.EnterEmployeePassword(Employee.Password);
            //Assert.That(_page.PasswordField.GetAttribute("value"), Is.EqualTo(Employee.Password));

            //_page.EnterEmployeeConfirmPassword(Employee.ConfirmPassword);
            //Assert.That(_page.ConfirmPasswordField.GetAttribute("value"), Is.EqualTo(Employee.ConfirmPassword));
            #endregion

            //8.Click on 'Save' button
            _page.ClickSaveButton();

            //9.Validate that the employee is shown in the Employee List
            _page.NavigateToEmployeeList();
            //Assert.IsTrue(_page.IsEmployeeInResults(Employee.FirstName), "New employee not found in the Employee List.");
        }

        [TearDown]
        public void Teardown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}
