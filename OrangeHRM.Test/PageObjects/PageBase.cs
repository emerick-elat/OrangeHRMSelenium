using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Test.PageObjects
{
    internal class PageBase
    {

        protected readonly IWebDriver _driver;
        public PageBase(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetCurrentUrl() => _driver.Url;
        public bool IsPageOpenned(string pageUrl) => GetCurrentUrl().Contains(pageUrl);
        public bool IsRecordInElement(IWebElement rootElement, string tag)
        {
            IList<IWebElement> elements = rootElement.FindElements(By.TagName(tag));
            foreach (var item in elements)
            {
                
            }
            return false;
        }

        public bool IsRecordInResults(string record)
        {
            var rows = _driver.FindElements(By.CssSelector(".oxd-table-body .oxd-table-row"));
            foreach (var row in rows)
            {
                var recordDescription = row.FindElement(By.XPath(".//div[@role='cell'][2]")).Text;
                if (recordDescription == record)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
