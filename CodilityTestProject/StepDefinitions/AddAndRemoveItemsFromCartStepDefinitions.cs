using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using CodilityTestProject.PageObjectModel;

namespace CodilityTestProject.StepDefinitions
{
    [Binding]
    public class AddAndRemoveItemsFromCartStepDefinitions
    {
        private IWebDriver driver;
        private ProductsPage _productsPage;
        private CartPage _cartPage;

        public AddAndRemoveItemsFromCartStepDefinitions()
        {
            driver = new ChromeDriver();
            _productsPage = new ProductsPage(driver);
            _cartPage = new CartPage(driver);
        }

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            _productsPage.Navigate();
        }

        [When(@"I add four random items to my cart")]
        public void WhenIAddFourRandomItemsToMyCart()
        {
            _productsPage.AddRandomItemsToCart(4);
        }

        [Then(@"I should see four items in my cart")]
        public void ThenIShouldSeeFourItemsInMyCart()
        {
            _cartPage.Navigate("cart");
            var count = _cartPage.GetNumberOfItemsInCart();
            Assert.AreEqual(4, count, "Expected to see 4 items in the cart ");
        }

        [When(@"I search for the lowest priced item")]
        public void WhenISearchForTheLowestPricedItem()
        {
            _cartPage.Navigate("cart");
            _cartPage.SearchForLowestPriceItem();
        }

        [When(@"I remove the lowest priced item from my cart")]
        public void WhenIRemoveTheLowestPricedItemFromMyCart()
        {
            _cartPage.RemoveLowestPriceItemToCart();
        }

        [Then(@"I should see three items in my cart")]
        public void ThenIShouldSeeThreeItemsInMyCart()
        {
            var count = _cartPage.GetNumberOfItemsInCart();
            Assert.AreEqual(3, count, "Expected to see 3 items in the cart ");
            driver.Quit();
        }
    }
}
