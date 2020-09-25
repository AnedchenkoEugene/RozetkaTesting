using AutomatedUIFramework.Pages.General.UAT1;
using AutomatedUIFrameworkTemplate.Pages.Section1;
using OpenQA.Selenium;

namespace AutomatedUIFramework.Pages.General
{
    public class Pages
    {
        private readonly IWebDriver webDriver;

        public Pages(Browser browser)
        {
            webDriver = browser.getDriver;
        }


        public LoginPage LoginPage
        {
            get
            {
                return new LoginPage(webDriver);
            }
        }
        public HomePage HomePage
        {
            get
            {
                return new HomePage(webDriver);
            }
        }
        public SearchResultsPage SearchResultsPage
        {
            get
            {
                return new SearchResultsPage(webDriver);
            }
        }
    }
}
