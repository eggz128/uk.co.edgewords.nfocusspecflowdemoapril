using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using static uk.co.edgewords.nfocusspecflowdemoapril.Hooks.Hooks;

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
            this.driver = (IWebDriver)_scenarioContext["webdriver"];
        }




        [Given(@"I am on the Google home page")]
        [Given(@"(?i)I am on Google (?-i)Search")]
        public void GivenIAmOnTheGoogleHomePage()
        {
            driver.Url = "https://www.google.co.uk/";
            driver.FindElement(By.CssSelector("#L2AGLb > div")).Click(); //Dismiss the cookie acceptance requirement
            string bodyText = driver.FindElement(By.TagName("body")).Text;
            _scenarioContext["mybodytext"]=bodyText;

        }

        



        [StepDefinition(@"I search for Edgewords")]
        public void WhenISearchForEdgewords()
        {
            WhenISearchFor("Edgewords");
        }

        [StepDefinition(@"Edgewords is on the first page of results")]
        public void ThenEdgewordsIsOnTheFirstPageOfResults()
        {
            ThenIsOnTheFirstPageOfResults("edgewords");

        }

        [When(@"I search for '(.*)'")]
        public void WhenISearchFor(string searchTerm)
        {
            string bodyText = (string)_scenarioContext["mybodytext"];
            Console.WriteLine(bodyText);
            driver.FindElement(By.Name("q")).SendKeys(searchTerm + Keys.Enter);
        }

        [Then(@"'([^']*)' is on the first page of results")]
        public void ThenIsOnTheFirstPageOfResults(string searchTerm)
        {
            string searchResultsText = driver.FindElement(By.Id("rso")).Text;
            //Nunit assertion
            Assert.That(searchResultsText,
                Does.Contain(searchTerm+".co.uk"),
                searchTerm+" is not in the results");
            //FluentAssertions example
            searchResultsText.Should().Contain(searchTerm+".co.uk");
        }

        [Then(@"I should see in the results")]
        public void ThenIShouldSeeInTheResults(Table table)
        {
            string searchResultsText = driver.FindElement(By.Id("rso")).Text;

            foreach(var row in table.Rows)
            {
                Assert.That(searchResultsText, Does.Contain(row["title"]), "title not found");
                Assert.That(searchResultsText, Does.Contain(row["url"]), "url not found");
            }
        }

    }
}