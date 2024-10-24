using OpenQA.Selenium;
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

        [SetUp]
        public void Setup()
        {
            _driver = BrowserFactory.CreateBrowser(BrowserType.Chrome);
            _driver.Manage().Window.Maximize();
            _page = new JobTitlePage(_driver);
            _loginPage = new LoginPage(_driver);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void AddJobTitleTest()
        {
            //1.Launch the application
            _driver.Navigate().GoToUrl(App.Url);
            
            //2.Enter valid username
            _loginPage.SetUsername(LoginData.Username);
            //3.Enter valid password
            _loginPage.SetPassword(LoginData.Password);
            //4.Click on login button;
            _loginPage.LoginButtonClicked();

            //5.Navigate to 'Admin => Job' panel
            _driver.FindElement(By.LinkText("Admin")).Click();
            Thread.Sleep(100);
            _driver.FindElement(By.CssSelector("span.oxd-topbar-body-nav-tab-item[text()='Job']")).Click();


            //6.Click on 'Job Titles'
            _driver.FindElement(By.LinkText("Job Titles")).Click();
            
            //7.Click on 'Add' button and fill in the necessary details
            _driver.FindElement(By.TagName("button.oxd-button")).Click();

            _page.EnterJobTitle(JobTitle.Title);
            Assert.That(_page.JobTitleField.GetAttribute("value"), Is.EqualTo(JobTitle.Title));

            _page.EnterJobDescription(JobTitle.Description);
            Assert.That(_page.JobDescriptionField.GetAttribute("value"), Is.EqualTo(JobTitle.Description));

            _page.EnterJobNote(JobTitle.Note);
            Assert.That(_page.JobDescriptionField.GetAttribute("value"), Is.EqualTo(JobTitle.Note));
            //8.Click on 'Save'
            _page.ClickSave();


        }

        [TearDown]
        public void Teardown()
        {
            _driver.Dispose();
        }
    }
}
