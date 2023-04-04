using FluentAssertions;
using OpenQA.Selenium;


namespace CodilityTestProject.PageObjectModel
{
   public abstract class PageOject
    {
        private const string webUrl = "https://cms.demo.katalon.com/";
        private readonly IWebDriver _driver;
        public PageOject(IWebDriver driver)
        {

            _driver = driver;
        }

        public void Navigate(string page = "")
        {
            _driver.Navigate().GoToUrl(webUrl+ page);
            _driver.Manage().Window.Maximize();
        }
    }
}
