using OpenQA.Selenium;
using OpenQA.Selenium.Support;

namespace CodilityTestProject.PageObjectModel
{
    public class CartPage : PageOject
    {
        private IWebDriver driver;

        private IWebElement lowestPriceElementToRemove;

        public CartPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IList<IWebElement> _cartItems => driver.FindElements(By.CssSelector(".woocommerce-cart-form__cart-item"));

        public IList<IWebElement> prices => driver.FindElements(By.CssSelector(".product-subtotal .woocommerce-Price-amount"));
        public IList<IWebElement> removeElements => driver.FindElements(By.CssSelector(".product-remove .remove"));

        public void SearchForLowestPriceItem()
        {

            // Find the lowest priced item
            var lowestPriceElement = prices[0];
            lowestPriceElementToRemove  = removeElements[0];
            decimal lowestPrice = decimal.Parse(lowestPriceElement.Text.Trim('$'));
            int i = 0;
            foreach (var price in prices)
            {
                decimal currentPrice = decimal.Parse(price.Text.Trim('$'));

                if (currentPrice < lowestPrice)
                {
                    lowestPriceElementToRemove = removeElements[i];
                    lowestPrice = currentPrice;
                }
                i++;
            }
        }
        public int GetNumberOfItemsInCart()
        {
            return _cartItems.Count;
        }

        public void RemoveLowestPriceItemToCart()
        {
            lowestPriceElementToRemove.Click();
            Thread.Sleep(1000);
        }
    }
}
