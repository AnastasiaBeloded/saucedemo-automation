using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Pages;

namespace SauceDemo.Tests
{
    [TestFixture]
    public class LoginTests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
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
            driver.Quit();
        }
    }
}
