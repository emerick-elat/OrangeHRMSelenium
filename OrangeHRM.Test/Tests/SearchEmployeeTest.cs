using OpenQA.Selenium;
using OrangeHRM.Test.Data;
using OrangeHRM.Test.PageObjects;

namespace OrangeHRM.Test.Tests
{
    [TestFixture]
    internal class SearchEmployeeTest
    {
        private IWebDriver _driver;
        private SearchEmployeePage _page;
        private LoginPage _loginPage;

        [SetUp]
        public void Setup()
        {
            _driver = BrowserFactory.CreateBrowser(BrowserType.Chrome);
            _driver.Manage().Window.Maximize();
            _loginPage = new LoginPage(_driver);
            _page = new SearchEmployeePage(_driver);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void SearchEmployee()
        {
            //1.Launch the application
            _driver.Navigate().GoToUrl(App.Url);
            //2.Enter valid username
            _loginPage.SetUsername(LoginData.Username);
            //3.Enter valid password
            _loginPage.SetPassword(LoginData.Password);
            //4.Click on login button
            _loginPage.ClickLoginButton();
            //5.Click on 'PIM' on the menu
            _driver.FindElement(By.LinkText("PIM")).Click();
            Assert.IsTrue(_driver.FindElement(By.XPath("//h6[text()='PIM']")).Displayed, "PIM title not showing.");
            //6.Click on 'Employee List'
            _driver.FindElement(By.LinkText("Employee List")).Click();
            //7.Enter a search parameter as an employee from preconditions
            //8.Click on 'Search'
            //8.Enter a search parameter as '1234567'
            //8.Click on 'Search'
            //9.Log out from the user profile dropdown
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }
    }
}
