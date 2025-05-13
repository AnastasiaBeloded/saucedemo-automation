using OpenQA.Selenium;

namespace SauceDemo.Pages
{
    public class CartPage
    {
        private readonly IWebDriver driver;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool IsProductInCart(string productName)
        {
            return driver.FindElements(By.XPath($"//div[@class='inventory_item_name' and text()='{productName}']")).Any();
        }

        public void RemoveFromCart(string productName)
        {
            var removeBtn = driver.FindElement(By.XPath($"//div[text()='{productName}']/ancestor::div[@class='cart_item']//button"));
            removeBtn.Click();
        }

        public void ClickCheckout()
        {
            driver.FindElement(By.Id("checkout")).Click();
        }

        public bool IsCheckoutBlocked()
        {
            return driver.Url.Contains("cart"); // if still on cart, likely blocked
        }
    }
}
