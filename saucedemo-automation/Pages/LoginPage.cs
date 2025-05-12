using OpenQA.Selenium;

namespace SauceDemo.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly By usernameField = By.Id("user-name");
        private readonly By passwordField = By.Id("password");
        private readonly By loginButton = By.Id("login-button");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Login(string username, string password)
        {
            _driver.FindElement(usernameField).SendKeys(username);
            _driver.FindElement(passwordField).SendKeys(password);
            _driver.FindElement(loginButton).Click();
        }
    }
}
