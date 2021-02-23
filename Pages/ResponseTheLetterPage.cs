using OpenQA.Selenium;

namespace AutomationEmails
{
    public class ResponseTheLetterPage
    {
        public static IWebDriver _driver;
        private readonly string _addressee;
        private readonly string _subject;
        private readonly string _letterText;

        private readonly By _respondButtonSelector =
            By.CssSelector(
                "span[class='button2 button2_has-ico button2_reply button2_clean button2_hover-support js-shortcut']");

        IWebElement _writeLetterButton;
        IWebElement _incomingLetter;
        IWebElement _respondButton;

        public ResponseTheLetterPage(IWebDriver driver)
        {
            _driver = driver;

        }

        public CreateNewLetterPage ClickRespondButton()
        {
            _respondButton = _driver.FindElement(_respondButtonSelector);
            _respondButton.Click();

            return new CreateNewLetterPage(_driver);
        }

        public void GetNewLetterSubject(out string subjectText)
        {
            subjectText = _driver.FindElement(By.CssSelector("h2[class='thread__subject thread__subject_pony-mode']")).Text;

        }




    }
}