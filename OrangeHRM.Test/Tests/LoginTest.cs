using OpenQA.Selenium;
using OrangeHRM.Test.Data;
using OrangeHRM.Test.PageObjects;

namespace OrangeHRM.Test.Tests
{
    [TestFixture]
    internal class LoginTest
    {
        private LoginPage _loginPage;
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = BrowserFactory.CreateBrowser(BrowserType.Chrome);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Manage().Window.Maximize();
            _loginPage = new LoginPage(_driver);
            //Thread.Sleep(1000);
        }

        [Test]
        public void ValidateSuccesfullLogin()
        {
            _driver.Navigate().GoToUrl(App.Url);
            Assert.That(_driver.Title, Is.EqualTo("OrangeHRM"));
            Assert.IsTrue(_loginPage.LoginPageDoOpen());

            _loginPage.SetUsername(LoginData.Username);
            Assert.That(_loginPage.UsernameField.GetAttribute("value"), Is.EqualTo(LoginData.Username));

            _loginPage.SetPassword(LoginData.Password);
            Assert.That(_loginPage.PasswordField.GetAttribute("value"), Is.EqualTo(LoginData.Password));

            _loginPage.ClickLoginButton();

            Assert.IsTrue( _loginPage.IsLoggedIn());
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}
