using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace saucedemo_automation.Pages
{
    public class CheckoutPage
    {
        private readonly IWebDriver driver;

        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By firstNameInput => By.Id("first-name");
        private By lastNameInput => By.Id("last-name");
        private By postalCodeInput => By.Id("postal-code");
        private By continueButton => By.Id("continue");
        private By finishButton => By.Id("finish");
        private By cancelButton => By.Id("cancel");
        private By errorMessage => By.ClassName("error-message-container");

        public void FillForm(string firstName, string lastName, string postalCode)
        {
            driver.FindElement(firstNameInput).SendKeys(firstName);
            driver.FindElement(lastNameInput).SendKeys(lastName);
            driver.FindElement(postalCodeInput).SendKeys(postalCode);
        }

        public void ClickContinue()
        {
            driver.FindElement(continueButton).Click();
        }
        public void ClickCheckout()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var checkoutBtn = wait.Until(d => d.FindElement(By.Id("checkout")));
            checkoutBtn.Click();
        }


        public void ClickFinish()
        {
            driver.FindElement(finishButton).Click();
        }

        public void ClickCancel()
        {
            driver.FindElement(cancelButton).Click();
        }

        private By errorText => By.CssSelector("h3[data-test='error']");

        public string GetErrorMessage()
        {
            try
            {
                return driver.FindElement(errorText).Text;
            }
            catch (NoSuchElementException)
            {
                return "";
            }
        }

    }
}
