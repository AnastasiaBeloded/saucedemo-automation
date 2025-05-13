using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Pages;

namespace SauceDemo.Tests
{
    [TestFixture]
    public class LoginTests
    {
        private IWebDriver driver = null!;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument($"--user-data-dir=/tmp/chrome-profile-{Guid.NewGuid()}");


            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public void TC01_ValidLogin()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("standard_user", "secret_sauce");

            Assert.That(driver.Url.Contains("inventory"), "Login failed");
        }
        [Test]
        public void TC02_InValidLogin()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("user", "secret_sauce");

            var errorMessage = driver.FindElement(By.XPath("//h3[contains(text(), 'Epic sadface')]"));
            Assert.That(errorMessage.Displayed, "Error message not displayed after invalid login");
        }
        [Test]
        public void TC03_InvalidPassword()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("standard_user", "wrong_password");

            var errorMessage = driver.FindElement(By.XPath("//h3[@data-test='error']"));
            Assert.That(errorMessage.Displayed);
            Assert.That(errorMessage.Text, Does.Contain("Username and password do not match"));
        }
        [Test]
        public void TC04_EmptyUsername()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("", "secret_sauce");

            var errorMessage = driver.FindElement(By.XPath("//h3[@data-test='error']"));
            Assert.That(errorMessage.Displayed);
            Assert.That(errorMessage.Text, Does.Contain("Username is required"));
        }
        [Test]
        public void TC05_EmptyPassword()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("standard_user", "");

            var errorMessage = driver.FindElement(By.XPath("//h3[@data-test='error']"));
            Assert.That(errorMessage.Displayed);
            Assert.That(errorMessage.Text, Does.Contain("Password is required"));
        }
        [Test]
        public void TC06_EmptyFields()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("", "");

            var errorMessage = driver.FindElement(By.XPath("//h3[@data-test='error']"));
            Assert.That(errorMessage.Displayed);
            Assert.That(errorMessage.Text, Does.Contain("Username is required"));
        }
        [Test]
        public void TC07_LockedOutUserLogin()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("locked_out_user", "secret_sauce");

            var errorMessage = driver.FindElement(By.XPath("//h3[@data-test='error']"));
            Assert.That(errorMessage.Displayed);
            Assert.That(errorMessage.Text, Does.Contain("Sorry, this user has been locked out."));
        }
        [Test]
        public void TC08_ProblemUserLogin()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("problem_user", "secret_sauce");

            var images = driver.FindElements(By.ClassName("inventory_item_img"));
            Assert.That(images.Count, Is.GreaterThan(0), "No images found for problem_user");

            bool atLeastOneBroken = false;

            foreach (var image in images)
            {
                var src = image.GetAttribute("src");
                if (string.IsNullOrEmpty(src))
                {
                    atLeastOneBroken = true;
                    break;
                }
            }

            Assert.That(atLeastOneBroken, "Expected at least one broken image (missing src) for problem_user");
        }

        [Test]
        public void TC09_PerformanceGlitchUserLogin()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("performance_glitch_user", "secret_sauce");

            Assert.That(driver.Url.Contains("inventory"), "Login did not succeed");
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
