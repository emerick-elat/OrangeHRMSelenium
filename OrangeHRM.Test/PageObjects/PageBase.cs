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
    }
}
