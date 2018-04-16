using System;
using System.Configuration;
using AutomatedUIFramework.Pages.Interfaces;
using AutomatedUIFramework.Utility.Web;
using OpenQA.Selenium;

namespace AutomatedUIFramework.Pages.General
{
    /// <summary>
    /// Holding state for all pages
    /// </summary>
    public abstract class WebPage : IWebPage
    {
        public static string BaseUrl
        {
            get { return ConfigurationManager.AppSettings["ProdEnviroment"]; }
        }

        public WebPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
            Wait = new Wait(WebDriver);
        }

        public IWebDriver WebDriver { get; set; }
        public Wait Wait { get; set; }
        public string RelativePageAddress { get; set; }
        public string PageTitle { get; set; }

        public string FullPageAddress {
            get {
                return string.Concat(BaseUrl, RelativePageAddress);
            }
        }
        
        #region Methods regarding state of all pages
        public IWebPage GoTo()
        {
            WebDriver.Navigate().GoToUrl(new Uri(FullPageAddress));
            return this;
        }

        public string GetDisplayedPageTitle()
        {
            return WebDriver.Title;
        }

        #endregion
        #region Methods regarding elements on the page

       
        public bool IsPageTitleCorrect()
        {
            return GetDisplayedPageTitle().Equals(PageTitle);
        }

        public bool IsElementPresent(By locator)
        {
            try
            {
                WebDriver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        #endregion

    }
}
