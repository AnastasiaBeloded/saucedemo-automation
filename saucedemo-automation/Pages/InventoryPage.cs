using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SauceDemo.Pages
{
    public class InventoryPage
    {
        private readonly IWebDriver driver;

        public InventoryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By productNames => By.ClassName("inventory_item_name");
        private By productPrices => By.ClassName("inventory_item_price");
        private By sortDropdown => By.ClassName("product_sort_container");

        public List<string> GetProductNames()
        {
            return driver.FindElements(productNames).Select(e => e.Text).ToList();
        }

        public List<decimal> GetProductPrices()
        {
            return driver.FindElements(productPrices)
                         .Select(e => decimal.Parse(e.Text.Replace("$", "")))
                         .ToList();
        }

        public void SelectSortOption(string visibleText)
        {
            var select = new OpenQA.Selenium.Support.UI.SelectElement(driver.FindElement(sortDropdown));
            select.SelectByText(visibleText);
        }
    }
}
