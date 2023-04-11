using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Test_C_.Pages;


namespace Test_C_.Tests
{
    public class GoogleSearchTest : TestInit
    {
        private HomePage homePage;

        [SetUp]
        public void Setup()
        {
            homePage = new HomePage(driver);
        }

        [Test]
        public void SearchForCat_ReturnsResults()
        {
            // Arrange
            string expectedTitle = "cat - Пошук Google";
            string query = "cat";

            // Act
            var searchResultPage = homePage.SearchFor(query);

            // Assert
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));
            Assert.That(searchResultPage.GetSearchResultStats(), Does.Contain("результатів"));
        }
    }
}