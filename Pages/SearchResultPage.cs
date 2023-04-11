using OpenQA.Selenium;

namespace Test_C_.Pages
{
    internal class SearchResultPage : BasePage
    {
        private readonly By searchResultStats = By.Id("result-stats");

        public SearchResultPage(IWebDriver driver) : base(driver)
        {
            WaitForPageToLoad();
            WaitForElementToBeVisible(searchResultStats);
        }

        public string GetSearchResultStats()
        {
            return driver.FindElement(searchResultStats).Text;
        }
    }
}