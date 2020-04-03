using AutomatedUIFramework.Utility.Web;
using AutomatedUIFrameworkTemplate.Pages.Section1;
using OpenQA.Selenium;
using System.Configuration;
using System.Threading;

namespace AutomatedUIFramework.Pages.General.UAT1
{
    public sealed class HomePage:WebPage
    {
        #region Locators
        private By SEARCH_FIELD_LOCATOR = By.Id("lst-ib");
        private By SEARCH_BUTTON_LOCATOR = By.Name("btnK");
        private By ACCOUNTS_TAB = By.LinkText("ACCOUNTS");
        private By PROSPECT_TAB = By.LinkText("PROSPECT");
        private By TAX_AGENCY_TAB = By.LinkText("TAX AGENCY");
        private By UTILITIES_TAB = By.LinkText("UTILITIES");
        private By LOGOUT_BTN = By.Id("ctl00_ctl00_cphMain_lnkLogout");
        #endregion
        #region UIElements
        public IWebElement SearchButton
        {
            get { return WebDriver.FindElement(SEARCH_BUTTON_LOCATOR); }
        }
        public IWebElement ProspectTab
        {
            get { return WebDriver.FindElement(PROSPECT_TAB); }
        }
        public IWebElement TaxAgencyTab
        {
            get { return WebDriver.FindElement(TAX_AGENCY_TAB); }
        }
        public IWebElement UtilitiesTab
        {
            get { return WebDriver.FindElement(UTILITIES_TAB); }
        }

        public IWebElement SearchField
        {
            get { return WebDriver.FindElement(SEARCH_FIELD_LOCATOR); }
        }
        public IWebElement AccountsBtn
        {
            get { return WebDriver.FindElement(ACCOUNTS_TAB); }
        }
        #endregion
        #region Methods
        public IWebElement LogOutBtn
        {
            get { return WebDriver.FindElement(LOGOUT_BTN); }
        }
        public HomePage(IWebDriver webDriver):base(webDriver)
        {
            PageTitle = "";
            RelativePageAddress = "";
        }


        public AccountsPage GoToAccountsPage()
        {
            var accountsPage = new AccountsPage(WebDriver);
            Thread.Sleep(500);
            AccountsBtn.ClickAndWaitForPageToLoad(accountsPage);
            return accountsPage;
        }
        public LoginPage CheckLogOutOption()
        {
            Thread.Sleep(900);
            var loginPage = new LoginPage(WebDriver);
            LogOutBtn.ClickAndWaitForPageToLoad(loginPage);
            return loginPage;
        }

        #endregion
    }
}
