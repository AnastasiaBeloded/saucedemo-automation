using NUnit.Framework;
/*using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Pages;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using Allure.NUnit;

namespace SauceDemo.Tests
{
    [AllureNUnit]
    [AllureSuite("Login")]
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
        [AllureTag("smoke")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Login")]
        [AllureStory("Valid credentials")]
        public void SuccessfulLogin()
        {
            AllureApi.Step("Login with valid user", () =>
            {
                var loginPage = new LoginPage(driver);
                loginPage.Login("standard_user", "secret_sauce");
            });

            AllureApi.Step("Verify redirection", () =>
            {
                Assert.That(driver.Url.Contains("inventory"), "Login failed");
            });

    }

    [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}*/


using NUnit.Framework;
using Allure.NUnit.Attributes;
using Allure.Net.Commons;
using Allure.NUnit;

namespace SauceDemo.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("🔥 DEBUG")]
    public class DebugTest
    {
        [Test]
        [AllureTag("check")]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.normal)]
        [AllureFeature("Validation")]
        [AllureStory("Minimal working test")]
        public void AllureSanityTest()
        {
            Assert.That(1 + 1, Is.EqualTo(2), "Sanity check");
        }
    }
}

