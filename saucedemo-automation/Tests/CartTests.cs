using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Pages;

namespace SauceDemo.Tests
{
    [TestFixture]
    public class CartTests
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
        public void TC15_AddSingleItemToCart()
        {
            var inventoryPage = new InventoryPage(driver);
            inventoryPage.AddToCartByName("Sauce Labs Backpack");

            Assert.That(inventoryPage.GetCartBadgeCount(), Is.EqualTo("1"));
        }

        [Test]
        public void TC16_AddMultipleItemsToCart()
        {
            var inventoryPage = new InventoryPage(driver);
            inventoryPage.AddToCartByName("Sauce Labs Backpack");
            inventoryPage.AddToCartByName("Sauce Labs Bike Light");
            inventoryPage.AddToCartByName("Sauce Labs Bolt T-Shirt");

            Assert.That(inventoryPage.GetCartBadgeCount(), Is.EqualTo("3"));
        }

        [Test]
        public void TC17_RemoveItemFromList()
        {
            var inventoryPage = new InventoryPage(driver);
            inventoryPage.AddToCartByName("Sauce Labs Backpack");
            inventoryPage.RemoveFromCartByName("Sauce Labs Backpack");

            Assert.That(inventoryPage.GetCartBadgeCount(), Is.EqualTo("0"));
        }

        [Test]
        public void TC18_ViewCart()
        {
            var inventoryPage = new InventoryPage(driver);
            inventoryPage.AddToCartByName("Sauce Labs Backpack");
            inventoryPage.ClickCartIcon();

            var cartPage = new CartPage(driver);
            Assert.That(cartPage.IsProductInCart("Sauce Labs Backpack"));
        }

        [Test]
        public void TC19_RemoveItemFromCartPage()
        {
            var inventoryPage = new InventoryPage(driver);
            inventoryPage.AddToCartByName("Sauce Labs Backpack");
            inventoryPage.ClickCartIcon();

            var cartPage = new CartPage(driver);
            cartPage.RemoveFromCart("Sauce Labs Backpack");
            Assert.That(cartPage.IsProductInCart("Sauce Labs Backpack"), Is.False);
        }

        [Test]
        public void TC20_CheckoutFromEmptyCart()
        {
            var inventoryPage = new InventoryPage(driver);
            inventoryPage.ClickCartIcon();
            Assert.That(driver.Url.Contains("cart"), "Not on cart page before clicking checkout");


            var cartPage = new CartPage(driver);
            cartPage.ClickCheckout();

            Assert.That(driver.Url.Contains("checkout-step-one"), "Checkout page not opened from empty cart");
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
