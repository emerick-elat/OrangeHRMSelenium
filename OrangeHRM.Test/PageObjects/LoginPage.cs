﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Test.PageObjects
{
    internal class LoginPage
    {
        private readonly IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement UsernameField => _driver.FindElement(By.Name("username"));
        public IWebElement PasswordField => _driver.FindElement(By.Name("password"));
        public IWebElement LoginButton => _driver.FindElement(By.TagName("button"));

        public void SetUsername(string username)
        {
            UsernameField.Clear();
            UsernameField.SendKeys(username);
        }

        public void SetPassword(string password)
        {
            UsernameField.Clear();
            PasswordField.SendKeys(password);
        }

        public void LoginButtonClicked()
        {
            LoginButton.Click();
        }

        public string GetCurrentUrl()
        {
            return _driver.Url.ToString();
        }

        public bool LoginPageDoOpen()
        {
            return GetCurrentUrl().Contains("login");
        }

        public bool IsLoggedIn()
        {
            return GetCurrentUrl().Contains("dashboard");
        }
    }
}
