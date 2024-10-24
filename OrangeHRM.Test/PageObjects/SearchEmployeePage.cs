using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Test.PageObjects
{
    internal class SearchEmployeePage
    {
        private readonly IWebDriver _driver;
        public SearchEmployeePage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
