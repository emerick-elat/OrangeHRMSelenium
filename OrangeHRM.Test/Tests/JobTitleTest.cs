using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeHRM.Test.Data;
using OrangeHRM.Test.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Test.Tests
{
    [TestFixture]
    internal class JobTitleTest
    {
        private IWebDriver _driver;
        private JobTitlePage _page;
        private LoginPage _loginPage;
        private WebDriverWait _wait;

        [SetUp]
        public void Setup()
        {
            _driver = BrowserFactory.CreateBrowser(BrowserType.Chrome);
            _driver.Manage().Window.Maximize();
            _page = new JobTitlePage(_driver);
            _loginPage = new LoginPage(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void AddJobTitleTest()
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
            //4.Click on login button;
            _loginPage.ClickLoginButton();
            Assert.IsTrue(_loginPage.IsLoggedIn());

            //5.Navigate to 'Admin => Job' panel
            _driver.FindElement(By.LinkText("Admin")).Click();
            _driver.FindElement(By.XPath("//span[text()=\"Job \"]")).Click();
            //6.Click on 'Job Titles'
            _driver.FindElement(By.LinkText("Job Titles")).Click();
            Assert.That(_driver.FindElement(By.XPath("//h6[text()='Job Titles']")).Displayed, "Job Titles not showing");

            //7.Click on 'Add' button and fill in the necessary details
            _driver.FindElement(By.XPath("//button[text()=\" Add \"]")).Click();
            
            _page.EnterJobTitle(JobTitle.Title);
            Assert.That(_page.JobTitleField.GetAttribute("value"), Is.EqualTo(JobTitle.Title));

            _page.EnterJobDescription(JobTitle.Description);
            Assert.That(_page.JobDescriptionField.GetAttribute("value"), Is.EqualTo(JobTitle.Description));

            _page.EnterJobNote(JobTitle.Note);
            Assert.That(_page.JobNoteField.GetAttribute("value"), Is.EqualTo(JobTitle.Note));

            //8.Click on 'Save'
            _page.ClickSave();
            _wait.Until(w => _page.IsPageOpenned("viewJobTitleList"));
            
            Assert.IsTrue(_page.IsJobTitleInResults(JobTitle.Title), "Job title not in the results");
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Dispose();
        }
    }
}
