using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationEmails
{
    [TestClass()]
    public class WebDriverTests
    {
        private IWebDriver _driver;
        const string username1 = "test_auto2020";
        const string password1 = "Training1919";
        const string username2 = "secondmail20";
        const string password2 = "Training2020";
        const string addressee = "secondmail20@mail.ru";
        const string subject = "This is me";
        const string letterText = "Check Mail";
        const string letterText2 = "Got it";

        [TestInitialize]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
        }

        [TestMethod()]
        public void LoginFirstEmailTest()
        {
            var loginPage = new LoginPage(_driver);

            loginPage
                .LoginEmail(username1, password1)
                .ClickCreateNewLetterButton()
                .CreateNewLetter(addressee, subject)
                .SendNewLetter(letterText)
                .Logout();    
            
            loginPage
                .LoginEmail(username2, password2)
                .RespondTheLetter(subject)
                .ClickRespondButton()
                .SendNewLetter(letterText2)
                .Logout();

            loginPage
                .LoginEmail(username1, password1)
                .RespondTheLetter(subject)
                .GetNewLetterSubject(out string subjectText);

            Assert.AreEqual(subject, subjectText);
        }

        [TestCleanup]
        public void CleanUp()
        {
           _driver.Close();     
        }
    }
}
