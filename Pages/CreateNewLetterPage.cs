using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using OpenQA.Selenium;

namespace AutomationEmails
{
    public class CreateNewLetterPage
    {
        private readonly IWebDriver _driver;

        private readonly By _addresseeFieldSelector =
            By.CssSelector("input[class ='container--H9L5q size_s_compressed--2c-eV']");

        private readonly By _subjectFieldSelector = By.CssSelector("input[name='Subject']");

        private readonly By _letterTextAreaSelector =
            By.XPath("/html/body/div[15]/div[2]/div/div[1]/div[2]/div[3]/div[5]/div/div/div[2]/div[1]");

        private readonly By _sendButtonSelector = By.XPath("/html/body/div[15]/div[2]/div/div[2]/div[1]/span[1]");

        private readonly By _closeWindowButtonSelector =
            By.XPath("/html/body/div[9]/div/div/div[2]/div[2]/div/div/div[1]/span");

        public CreateNewLetterPage CreateNewLetter(string addressee, string subject)
        {
            _driver.FindElement(_addresseeFieldSelector).SendKeys(addressee);
            _driver.FindElement(_subjectFieldSelector).SendKeys(subject);

            return this;
        }

        public InboxPage SendNewLetter(string letterText)
        {
            _driver.FindElement(_letterTextAreaSelector).SendKeys(letterText);

            _driver.FindElement(_sendButtonSelector).Click();
            _driver.FindElement(_closeWindowButtonSelector).Click();

            return new InboxPage(_driver);
        }

        public CreateNewLetterPage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
