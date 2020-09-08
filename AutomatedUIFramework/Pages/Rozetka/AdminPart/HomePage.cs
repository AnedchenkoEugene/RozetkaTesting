using AutomatedUIFramework.Utility.Web;
using AutomatedUIFrameworkTemplate.Pages.General.UAT1;
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
        private By SEARCH_FIELD = By.Name("search");
        private By SEARCH_BUTTON = By.XPath("//button[contains(@class, 'button button_color_green button_size_medium search-form__submit')]");
        private By FIRST_PRODUCT = By.XPath("//li[@class='catalog-grid__cell catalog-grid__cell_type_slim'][1]");
        private By BUY_PRODUCT_BUTTON = By.ClassName("buy-button button button_with_icon button_color_green button_size_large");
        private By BUY_PRODUCT_BUTTON2 = By.ClassName("buy-button button button_with_icon button_color_green button_size_large");
        #endregion
        #region WebElements
        public IWebElement SearchButtonLocator
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

        public IWebElement SearchFieldLocator
        {
            get { return WebDriver.FindElement(SEARCH_FIELD_LOCATOR); }
        }
        public IWebElement AccountsBtn
        {
            get { return WebDriver.FindElement(ACCOUNTS_TAB); }
        }
        private IWebElement SearchField
        {
            get { return WebDriver.FindElement(SEARCH_FIELD); }
        }
        private IWebElement SearchButton
        {
            get { return WebDriver.FindElement(SEARCH_BUTTON); }
        }
        private IWebElement FirstProduct
        {
            get { return WebDriver.FindElement(FIRST_PRODUCT); }
        }
        private IWebElement BuyProductButton
        {
            get { return WebDriver.FindElement(BUY_PRODUCT_BUTTON); }
        }
        private IWebElement BuyProductButton2
        {
            get { return WebDriver.FindElement(BUY_PRODUCT_BUTTON2); }
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
        public HomePage SearchProduct(string product)
        {
            Thread.Sleep(3000);
            SearchField.SendKeys(product);
            Thread.Sleep(2000);
            SearchButton.Click();
            var homepage = new HomePage(WebDriver);
            return homepage;
        }
        public ProductPage SelectFirstProduct()
        {
            Thread.Sleep(8000);
            FirstProduct.Click();
            Thread.Sleep(3000);
            var productPage = new ProductPage(WebDriver);
            return productPage;
            
        }



        #endregion
    }
}
