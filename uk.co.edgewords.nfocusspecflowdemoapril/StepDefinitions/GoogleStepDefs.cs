using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace uk.co.edgewords.nfocusspecflowdemoapril.StepDefinitions
{
    [Binding]
    public class StepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"I am on the Google home page")]
        public void GivenIAmOnTheGoogleHomePage()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.co.uk/";
            driver.FindElement(By.CssSelector("#L2AGLb > div")).Click();
        }

        [When(@"I search for Edgewords")]
        public void WhenISearchForEdgewords()
        {
            driver.FindElement(By.Name("q")).SendKeys("edgewords" + Keys.Enter);
        }

        [Then(@"Edgewords is on the first page of results")]
        public void ThenEdgewordsIsOnTheFirstPageOfResults()
        {
            string searchResultsText = driver.FindElement(By.Id("rso")).Text;
            //Nunit assertion
            Assert.That(searchResultsText, 
                Does.Contain("edgewordstraining.co.uk"),
                "Edgewords not in the results");
            //FluentAssertions example
            searchResultsText.Should().Contain("bbc.co.uk");

        }
    }
}