using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Pages;
using System.Linq;

namespace SauceDemo.Tests
{
    [TestFixture]
    public class InventoryTests
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
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            var loginPage = new LoginPage(driver);
            loginPage.Login("standard_user", "secret_sauce");
        }


        [Test]
        public void TC10_ViewProductList()
        {
            var inventoryPage = new InventoryPage(driver);
            var products = inventoryPage.GetProductNames();

            Assert.That(products.Count, Is.GreaterThan(0), "Product list is not displayed");
        }

        [Test]
        public void TC11_Sort_A_Z()
        {
            var inventoryPage = new InventoryPage(driver);
            inventoryPage.SelectSortOption("Name (A to Z)");
            var products = inventoryPage.GetProductNames();
            var sorted = products.OrderBy(name => name).ToList();

            Assert.That(products, Is.EqualTo(sorted), "Products are not sorted A-Z");
        }

        [Test]
        public void TC12_Sort_Z_A()
        {
            var inventoryPage = new InventoryPage(driver);
            inventoryPage.SelectSortOption("Name (Z to A)");
            var products = inventoryPage.GetProductNames();
            var sorted = products.OrderByDescending(name => name).ToList();

            Assert.That(products, Is.EqualTo(sorted), "Products are not sorted Z-A");
        }

        [Test]
        public void TC13_Sort_Price_Low_High()
        {
            var inventoryPage = new InventoryPage(driver);
            inventoryPage.SelectSortOption("Price (low to high)");
            var prices = inventoryPage.GetProductPrices();
            var sorted = prices.OrderBy(p => p).ToList();

            Assert.That(prices, Is.EqualTo(sorted), "Products are not sorted by price low to high");
        }

        [Test]
        public void TC14_Sort_Price_High_Low()
        {
            var inventoryPage = new InventoryPage(driver);
            inventoryPage.SelectSortOption("Price (high to low)");
            var prices = inventoryPage.GetProductPrices();
            var sorted = prices.OrderByDescending(p => p).ToList();

            Assert.That(prices, Is.EqualTo(sorted), "Products are not sorted by price high to low");
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
