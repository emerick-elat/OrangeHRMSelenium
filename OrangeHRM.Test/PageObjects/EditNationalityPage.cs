﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Test.PageObjects
{
    internal class EditNationalityPage : PageBase
    {   
        public EditNationalityPage(IWebDriver driver) : base(driver) { }

        public IWebElement NameField => GetNameField();
        public IWebElement SaveButton => _driver.FindElement(By.CssSelector("button[type='submit']"));
        public void EnterNationalityName(string name)
        {
            NameField.Clear();
            NameField.SendKeys(name);
        }

        public void ClickSave()
        {
            SaveButton.Click();
        }

        private IWebElement GetNameField()
        {
            IWebElement group = _driver.FindElement(By.CssSelector(".oxd-input-group"));
            return group.FindElement(By.TagName("input"));
        }
    }
}
