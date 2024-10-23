using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OrangeHRM.Test
{
    internal static class BrowserFactory
    {
        public static IWebDriver CreateBrowser(BrowserType browser)
        {
            switch (browser)
            {
                case BrowserType.Chrome:
                    return new ChromeDriver();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
