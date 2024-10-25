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

            Assert.IsTrue( _loginPage.IsLoggedIn());
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}
