using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SauceDemo.Pages;
using saucedemo_automation.Pages;

namespace SauceDemo.Tests
{
    [TestFixture]
    public class CheckoutTests
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
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument($"--user-data-dir=/tmp/chrome-profile-{Guid.NewGuid()}");

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            var loginPage = new LoginPage(driver);
            loginPage.Login("standard_user", "secret_sauce");
        }

        [Test]
        public void TC21_CompleteCheckoutFlow()
        {
            var inventoryPage = new InventoryPage(driver);
            inventoryPage.AddToCartByName("Sauce Labs Backpack");
            inventoryPage.ClickCartIcon();

            var cartPage = new CartPage(driver);
            cartPage.ClickCheckout();

            var checkoutPage = new CheckoutPage(driver);
            checkoutPage.FillForm("John", "Doe", "12345");
            checkoutPage.ClickContinue();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(d => d.Url.Contains("checkout-step-two"));

            checkoutPage.ClickFinish();

            
            wait.Until(d => d.Url.Contains("checkout-complete"));

            Assert.That(driver.Url.Contains("checkout-complete"));
        }


        [Test]
        public void TC22_MissingFirstName()
        {
            var inventoryPage = new InventoryPage(driver);
            inventoryPage.AddToCartByName("Sauce Labs Backpack");
            inventoryPage.ClickCartIcon();

            var cartPage = new CartPage(driver);
            cartPage.ClickCheckout();

            var checkoutPage = new CheckoutPage(driver);
            checkoutPage.FillForm("", "Doe", "12345");
            checkoutPage.ClickContinue();

            Assert.That(checkoutPage.GetErrorMessage(), Does.Contain("First Name is required"));
        }

        [Test]
        public void TC23_MissingLastName()
        {
            var inventoryPage = new InventoryPage(driver);
            inventoryPage.AddToCartByName("Sauce Labs Backpack");
            inventoryPage.ClickCartIcon();

            var cartPage = new CartPage(driver);
            cartPage.ClickCheckout();

            var checkoutPage = new CheckoutPage(driver);
            checkoutPage.FillForm("John", "", "12345");
            checkoutPage.ClickContinue();

            Assert.That(checkoutPage.GetErrorMessage(), Does.Contain("Last Name is required"));
        }

        [Test]
        public void TC24_MissingPostalCode()
        {
            var inventoryPage = new InventoryPage(driver);
            inventoryPage.AddToCartByName("Sauce Labs Backpack");
            inventoryPage.ClickCartIcon();

            var cartPage = new CartPage(driver);
            cartPage.ClickCheckout();

            var checkoutPage = new CheckoutPage(driver);
            checkoutPage.FillForm("John", "Doe", "");
            checkoutPage.ClickContinue();

            Assert.That(checkoutPage.GetErrorMessage(), Does.Contain("Postal Code is required"));
        }

        [Test]
        public void TC25_CancelCheckout()
        {
            var inventoryPage = new InventoryPage(driver);
            inventoryPage.AddToCartByName("Sauce Labs Backpack");
            inventoryPage.ClickCartIcon();

            var cartPage = new CartPage(driver);
            cartPage.ClickCheckout();

            var checkoutPage = new CheckoutPage(driver);
            checkoutPage.ClickCancel();

            Assert.That(driver.Url.Contains("cart"));
        }

        [Test]
        public void TC26_LogoutFromMenu()
        {
            driver.FindElement(By.Id("react-burger-menu-btn")).Click();
            Thread.Sleep(500); // wait for menu to appear
            driver.FindElement(By.Id("logout_sidebar_link")).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.Id("login-button")).Displayed);

            Assert.That(driver.Url.Contains("saucedemo.com"));
            Assert.That(driver.FindElement(By.Id("login-button")).Displayed);
        }

        [Test]
        public void TC27_ResetAppState()
        {
            var inventoryPage = new InventoryPage(driver);
            inventoryPage.AddToCartByName("Sauce Labs Backpack");

            driver.FindElement(By.Id("react-burger-menu-btn")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.Id("reset_sidebar_link")).Click();
            Thread.Sleep(500);
            driver.Navigate().Refresh();

            Assert.That(inventoryPage.GetCartBadgeCount(), Is.EqualTo("0"));
        }

        [Test]
        public void TC28_BackToProductsButton()
        {
            var inventoryPage = new InventoryPage(driver);
            inventoryPage.AddToCartByName("Sauce Labs Backpack");
            inventoryPage.ClickCartIcon();

            driver.FindElement(By.Id("continue-shopping")).Click();
            Assert.That(driver.Url.Contains("inventory"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
