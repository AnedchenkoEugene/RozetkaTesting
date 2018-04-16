using AutomatedUIFramework.Pages.General;
using OpenQA.Selenium;

namespace AutomatedUIFrameworkTemplate.Pages.Section1
{
    public class SearchResultsPage:WebPage
    {
        #region Locators
        private By LOGO_IMAGE_SELECTOR = By.Id("logo");
        private By SEARCH_RESULTS_SELECTOR = By.Id("search");
        
        #endregion

        #region UI Elements
        public IWebElement LogoImage
        {
            get { return WebDriver.FindElement(LOGO_IMAGE_SELECTOR); }
        }

        public IWebElement SearchResults
        {
            get { return WebDriver.FindElement(SEARCH_RESULTS_SELECTOR); }
        }
        #endregion region

        #region Methods
        public SearchResultsPage(IWebDriver webDriver) : base(webDriver)
        {
            PageTitle = "";
            RelativePageAddress = "";
        }

        public bool IsTextInSearchResults(string search)
        {
            return SearchResults.Text.Contains(search);
        }

        #endregion
    }

}

