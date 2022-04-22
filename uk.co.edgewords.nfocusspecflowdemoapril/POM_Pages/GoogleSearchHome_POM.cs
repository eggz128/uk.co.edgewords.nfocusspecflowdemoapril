using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.edgewords.nfocusspecflowdemoapril.POM_Pages
{
    public class GoogleSearchHome_POM
    {
        IWebDriver driver;

        public GoogleSearchHome_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Locators
        IWebElement AcceptCookieButton => driver.FindElement(By.CssSelector("#L2AGLb > div"));
        IWebElement SearchField => driver.FindElement(By.Name("q"));


        //Service Methods
        public void AcceptCookies()
        {
            AcceptCookieButton.Click();
        }

        public void Search(string searchTerm)
        {
            SearchField.SendKeys(searchTerm + Keys.Enter);
        }

     }
}
