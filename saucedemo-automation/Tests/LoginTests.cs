using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Pages;

namespace SauceDemo.Tests
{
    [TestFixture]
    public class LoginTests
    {
        private IWebDriver? driver;


        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--remote-debugging-port=9222"); // helps on GitHub Actions
            options.AddArgument($"--user-data-dir=/tmp/profile-{Guid.NewGuid()}"); // unique per run

            driver = new ChromeDriver(options);

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public void SuccessfulLogin()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("standard_user", "secret_sauce");

            Assert.That(driver.Url.Contains("inventory"), "Login failed – inventory page not reached");
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }

    }
}
