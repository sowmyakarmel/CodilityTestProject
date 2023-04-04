using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;


namespace CodilityTestProject.PageObjectModel
{
    public class ProductsPage:PageOject
    {
        private readonly IWebDriver _driver;

        public ProductsPage(IWebDriver driver):base(driver)
        {
            _driver = driver;
        }

        public void AddRandomItemsToCart(int itemCount)
        {
            var productLinks = _driver.FindElements(By.CssSelector(".products .product"));
            var random = new Random();
            var selectedProducts = new List<int>();

            // Select random products and add them to cart
            for (var i = 0; i < itemCount; i++)
            {
                int index;
                do
                {
                    index = random.Next(productLinks.Count);
                } while (selectedProducts.Contains(index) || index==4);

                selectedProducts.Add(index);
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", productLinks[index]);
                Thread.Sleep(1000);
                productLinks[index].Click();
                var selectElement = _driver.FindElements(By.CssSelector("span[role='combobox']"));
                if (selectElement.Count > 0)
                {
                    selectElement[0].Click();

                    // Find the first option in the list using its CSS selector
                    var firstOption = _driver.FindElements(By.CssSelector("li[role='treeitem']"));

                    // Click on the first option to select it
                    firstOption[1].Click();
                }
                _driver.FindElement(By.CssSelector("button.single_add_to_cart_button")).Click();
                _driver.Navigate().Back();
                _driver.Navigate().Back();
                Thread.Sleep(1000);
            }
        }
    }
}
