using OpenQA.Selenium;

namespace AutomationEmails
{
    public class InboxPage
    {
        private IWebDriver _driver;
        IWebElement _letterSubject;
        IWebElement _unreadMail;
        private readonly By _writeLetterButtonSelector = By.CssSelector("a[data-title-shortcut='N']");
        private readonly By _logoutButtonSelector = By.Id("PH_logoutLink");
        private readonly By _unreadMailSelector = By.CssSelector("span[class='ll-rs ll-rs_is-active']");
        private readonly By _letterSubjectSelector = By.CssSelector("span[class='llc__subject llc__subject_unread']");

        public CreateNewLetterPage ClickCreateNewLetterButton()
        {
            _driver.FindElement(_writeLetterButtonSelector).Click();

            return new CreateNewLetterPage(_driver);
        }

        public void Logout()
        {
            _driver.FindElement(_logoutButtonSelector).Click();
        }

        public ResponseTheLetterPage RespondTheLetter(string subject)
        {
            _letterSubject = _driver.FindElement(_letterSubjectSelector);
            _unreadMail = _driver.FindElement(_unreadMailSelector);

            if (_unreadMail != null && _letterSubject.Text == subject)
            {
                _letterSubject.Click();

                return new ResponseTheLetterPage(_driver);
            }

            return null;
        }

        public InboxPage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
