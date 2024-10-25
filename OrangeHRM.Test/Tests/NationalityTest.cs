using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeHRM.Test.Data;
using OrangeHRM.Test.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrangeHRM.Test.Tests
{
    [TestFixture]
    internal class NationalityTest
    {
        private IWebDriver _driver;
        private EditNationalityPage _page;
        private LoginPage _loginPage;
        private WebDriverWait _waitingStrategy;

        [SetUp]
        public void Setup()
        {
            _driver = BrowserFactory.CreateBrowser(BrowserType.Chrome);
            _driver.Manage().Window.Maximize();
            _waitingStrategy = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _page = new EditNationalityPage(_driver);
            _loginPage = new LoginPage(_driver);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void EditNationalityTest()
        {
            //1.Launch the application
            _driver.Navigate().GoToUrl(App.Url);
            Assert.That(_driver.Title, Is.EqualTo("OrangeHRM"));
            Assert.IsTrue(_loginPage.LoginPageDoOpen());
            //2.Enter valid username
            _loginPage.SetUsername(LoginData.Username);
            Assert.That(_loginPage.UsernameField.GetAttribute("value"), Is.EqualTo(LoginData.Username));
            //3.Enter valid password
            _loginPage.SetPassword(LoginData.Password);
            Assert.That(_loginPage.PasswordField.GetAttribute("value"), Is.EqualTo(LoginData.Password));
            //4.Click on login button
            _loginPage.ClickLoginButton();
            Assert.IsTrue(_loginPage.IsLoggedIn());

            //5.Navigate to the 'Admin => More => Nationalities' panel
            _driver.FindElement(By.LinkText("Admin")).Click();
            _driver.FindElement(By.LinkText("Nationalities")).Click();
            Assert.That(_driver.FindElement(By.XPath("//h6[text()='Nationalities']")).Displayed, "Nationalities not showing");
            
            //7.Click on 'Edit' button on any nationality and change the necessary details
            IWebElement editButton = _driver.FindElement(By.CssSelector(".oxd-table-cell-actions button:nth-of-type(2)"));
            editButton.Click();
            Assert.IsTrue(_page.IsPageOpenned("saveNationality"));

            _page.EnterNationalityName(Nationality.Name);
            Assert.That(_page.NameField.GetAttribute("value"), Is.EqualTo(Nationality.Name));
            Thread.Sleep(5000);
            //8.Click on 'Save'
            _page.ClickSave();
            _waitingStrategy.Until(s => _page.IsPageOpenned("admin/nationality"));
            Assert.IsTrue(_page.IsPageOpenned("admin/nationality"));
            Assert.IsTrue(_page.IsRecordInResults(Nationality.Name), "Updated record not found in results");
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Dispose();
        }
    }
}
