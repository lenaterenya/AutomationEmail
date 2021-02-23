using OpenQA.Selenium;

namespace AutomationEmails
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private string url = "http://mail.ru";

        private readonly By _usernameFieldSelector = By.Name("login");
        private readonly By _enterPasswordButtonSelector = By.CssSelector("button[data-testid='enter-password']");
        private readonly By _passwordFieldSelector = By.Name("password");
        private readonly By _loginButtonSelector = By.CssSelector("button[data-testid='login-to-mail']");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Navigate().GoToUrl(url);
        }

        public InboxPage LoginEmail(string username, string password)
        {
            _driver.FindElement(_usernameFieldSelector).SendKeys(username);
            _driver.FindElement(_enterPasswordButtonSelector).Click();

            _driver.FindElement(_passwordFieldSelector).SendKeys(password);
            _driver.FindElement(_loginButtonSelector).Click();

            return new InboxPage(_driver);
        }
    }
}