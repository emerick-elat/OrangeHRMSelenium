﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
        private WebDriverWait _wait;

        [SetUp]
        public void Setup()
        {
            _driver = BrowserFactory.CreateBrowser(BrowserType.Chrome);
            _driver.Manage().Window.Maximize();
            _loginPage = new LoginPage(_driver);
            _page = new SearchEmployeePage(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
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
            _page.EnterEmployeeName(Employee.FirstName);
            Assert.That(_page.EmployeeNameField.GetAttribute("value"), Is.EqualTo(Employee.FirstName));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            //8.Click on 'Search'
            _page.SearchButton.Click();
            Assert.IsTrue(_page.CompareSearchResult("Records Found"), "Search results are not displayed");
            
            //8.Enter a search parameter as '1234567'
            _page.EnterEmployeeName("1234567");
            Assert.IsTrue(_page.CompareSearchResult("No Records Found"), "Search results are not displayed");
            //8.Click on 'Search'
            _page.SearchButton.Click();
            Thread.Sleep(1000);
            //9.Log out from the user profile dropdown
            _driver.FindElement(By.ClassName("oxd-userdropdown-tab")).Click();
            _driver.FindElement(By.XPath("//a[text()='Logout']")).Click();
            _wait.Until(p => _loginPage.LoginPageDoOpen());
            Assert.IsTrue(_loginPage.LoginPageDoOpen());
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }
    }
}
