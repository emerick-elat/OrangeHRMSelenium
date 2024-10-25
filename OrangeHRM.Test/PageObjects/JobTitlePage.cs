using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Test.PageObjects
{
    internal class JobTitlePage : PageBase
    {
        public JobTitlePage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement JobTitleField => _driver.FindElement(By.TagName("input"));
        public IWebElement JobDescriptionField => _driver.FindElement(By.TagName("textarea"));
        public IWebElement JobSPecificationFileField => _driver.FindElement(By.CssSelector("input[type=file]"));
        public IWebElement JobNoteField => _driver.FindElement(By.XPath("//textarea[@placeholder=\"Add note\"]"));
        public IWebElement SaveButton => _driver.FindElement(By.XPath("//button[@type='submit']"));

        public void EnterJobTitle(string jobTitle)
        {
            JobTitleField.Clear();
            JobTitleField.SendKeys(jobTitle);
        }

        public void EnterJobDescription(string jobDescription)
        {
            JobDescriptionField.Clear();
            JobDescriptionField.SendKeys(jobDescription);
        }
        
        public void EnterJobNote(string note)
        {
            JobNoteField.Clear();
            JobNoteField.SendKeys(note);
        }

        public void BrowseJobSpecificationFile(string jobSpecificationFile)
        {
            JobSPecificationFileField.Clear();
            JobSPecificationFileField.SendKeys(jobSpecificationFile);
            _driver.FindElement(By.TagName("i")).Click();
        }

        public void ClickSave()
        {
            SaveButton.Click();
        }
    }
}
