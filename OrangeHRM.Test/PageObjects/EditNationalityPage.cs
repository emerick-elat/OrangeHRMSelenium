﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Test.PageObjects
{
    internal class EditNationalityPage
    {
        private readonly IWebDriver _driver;

        public EditNationalityPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement NameField => _driver.FindElement(By.TagName("input"));
        public IWebElement SaveButton => _driver.FindElement(By.CssSelector("button[type=submit]"));
        public void EnterNationalityName(string name)
        {
            NameField.Clear();
            NameField.SendKeys(name);
        }

        public void ClickSave()
        {
            SaveButton.Click();
        }
    }
}
