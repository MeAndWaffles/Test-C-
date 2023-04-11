using OpenQA.Selenium;

namespace Test_C_.Pages
{
    internal class HomePage : BasePage
    {
        private readonly By searchInput = By.Name("q");

        public HomePage(IWebDriver driver) : base(driver)
        {
            driver.Navigate().GoToUrl("https://www.google.com/");
        }

        public SearchResultPage SearchFor(string query)
        {
            Type(searchInput, query + Keys.Enter);
            return new SearchResultPage(driver);
        }
    }
}