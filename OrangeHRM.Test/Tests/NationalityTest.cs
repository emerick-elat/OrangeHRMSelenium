using OpenQA.Selenium;
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

        [SetUp]
        public void Setup()
        {
            _driver = BrowserFactory.CreateBrowser(BrowserType.Chrome);
            _driver.Manage().Window.Maximize();
            _page = new EditNationalityPage(_driver);
            _loginPage = new LoginPage(_driver);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void EditNationalityTest()
        {
            //1.Launch the application
            _driver.Navigate().GoToUrl(App.Url);
            //2.Enter valid username
            _loginPage.SetUsername(LoginData.Username);
            //3.Enter valid password
            _loginPage.SetPassword(LoginData.Password);
            //4.Click on login button
            _loginPage.ClickLoginButton();

            //5.Navigate to the 'Admin => More => Nationalities' panel
            _driver.FindElement(By.LinkText("Admin")).Click();
            _driver.FindElement(By.LinkText("Nationalities")).Click();
            Assert.That(_driver.FindElement(By.XPath("//h6[text()='Nationalities']")).Displayed, "Nationalities not showing");
            //7.Click on 'Edit' button on any nationality and change the necessary details
            
            
            IWebElement element = _driver.FindElement(By.ClassName("oxd-table-body"));
            IList<IWebElement> nationalities = element.FindElements(By.TagName("div"));
            IWebElement nationality = nationalities[0];
            IList<IWebElement> options = nationality.FindElements(By.TagName("div"));
            IWebElement commandGroup = options[2];
            IWebElement commandNode = commandGroup.FindElement(By.TagName("div"));
            IList<IWebElement> commands = commandNode.FindElements(By.TagName("button"));
            //IWebElement editButton = commands[1];
            //editButton.Click();
            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //_page.EnterNationalityName(Nationality.Name);
            //Assert.That(Nationality.Name, Is.EqualTo(_page.NameField.GetAttribute("value")));

            //8.Click on 'Save'
            //_page.ClickSave();
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Dispose();
        }
    }
}
