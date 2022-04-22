using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.edgewords.nfocusspecflowdemoapril.POM_Pages
{
    public class GoogleSearchResults_POM
    {
        IWebDriver driver;

        public GoogleSearchResults_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Locators
        IWebElement SearchResults => driver.FindElement(By.Id("rso"));

        //Service Methods
        public string GetSearchResults()
        {
            return SearchResults.Text;
        }

     }
}
