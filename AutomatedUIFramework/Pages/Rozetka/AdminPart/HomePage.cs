using AutomatedUIFramework.Utility.Web;
using AutomatedUIFrameworkTemplate.Pages.General.UAT1;
using AutomatedUIFrameworkTemplate.Pages.Section1;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
        private By SEARCH_BUTTON = By.XPath("//button[@class='button button_color_green button_size_medium search-form__submit']");
        private By FIRST_PRODUCT = By.XPath("//a[@class='goods-tile__picture']"); /// //li[@class='var-options__item'][4]
        private By CITY_BUTTON = By.XPath("//a[@class='header-cities__link link-dashed']");
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
        private IWebElement CityButton
        {
            get { return WebDriver.FindElement(CITY_BUTTON); }
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

        public new HomePage GoTo()
        {
            base.GoTo();
            return this;
        }

        public AccountsPage GoToAccountsPage()
        {
            var accountsPage = new AccountsPage(WebDriver);
            ////Thread.Sleep(500);
            AccountsBtn.ClickAndWaitForPageToLoad(accountsPage);
            return accountsPage;
        }
        public LoginPage CheckLogOutOption()
        {
           ///// Thread.Sleep(900);
            var loginPage = new LoginPage(WebDriver);
            LogOutBtn.ClickAndWaitForPageToLoad(loginPage);
            return loginPage;
        }
        public HomePage SearchProduct(string product)
        {
            SearchField.SendKeys(product);
            var homePage = new HomePage(WebDriver);
            return homePage;
        }
        public HomePage ClickOnTheSearchButton()
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='button button_color_green button_size_medium search-form__submit']")));
            SearchButton.Click();
            var homePage = new HomePage(WebDriver);
            return homePage;
            
        }
        public ProductPage SelectFirstProduct()
        {
            var productPage = new ProductPage(WebDriver);
            WebDriverWait wait = new WebDriverWait(WebDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='goods-tile__picture']")));
            FirstProduct.Click();
            return productPage;

            
        }
        public CityPage SelectCity()
        {
           //// Thread.Sleep(5000);
            CityButton.Click();
           //// Thread.Sleep(5000);
            var cityPage = new CityPage(WebDriver);
            CityButton.ClickAndWaitForPageToLoad(cityPage);
            return cityPage;

        }
        public string GetCityName()
        {
            string cityName = CityButton.Text;
            return cityName;
        }

        #endregion
    }
}
