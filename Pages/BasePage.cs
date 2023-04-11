using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using Test_C_.Tests;

namespace Test_C_.Pages
{
    internal class BasePage : TestInit
    {
        public readonly IWebDriver driver;
        public readonly WebDriverWait wait;

        public void WaitForElementToBeVisible(By locator, int timeoutSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        public WebElement waitElement(string locator , int timeoutSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return (WebElement)wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
        }

        public WebElement findElement(string locator)
        {
            return waitElement(locator);
        }

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void WaitForElementToBeVisible(By locator)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitForElementToBeClickable(By locator)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public void Click(By locator)
        {
            WaitForElementToBeClickable(locator);
            driver.FindElement(locator).Click();
        }

        public void Type(By locator, string text)
        {
            WaitForElementToBeVisible(locator);
            driver.FindElement(locator).SendKeys(text);
        }

        public bool IsElementDisplayed(By locator)
        {
            try
            {
                WaitForElementToBeVisible(locator);
                return driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void WaitForPageToLoad()
        {
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void WaitForAjax()
        {
            wait.Until(driver => (bool)((IJavaScriptExecutor)driver).ExecuteScript("return jQuery.active == 0"));
        }


    }
}
