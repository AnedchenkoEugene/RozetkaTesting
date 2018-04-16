using AutomatedUIFramework.Utility.Web;
using AutomatedUIFrameworkTemplate.Pages.General.UAT1;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatedUIFramework.Pages.General.UAT1
{
   public class AccountsPage :WebPage
    {
        #region Locators
        private By GET_ACCOUNTS_FIELD = By.Id("ctl00_ctl00_cphMain_cphMainContent_txtSearch");
        private By SEARCH_BTN = By.Id("ctl00_ctl00_cphMain_cphMainContent_lbSearch");
        private By TAX_ACCOUNTS_TAB = By.LinkText("Tax Accounts"); 
        #endregion
        #region UI Elements
        private IWebElement GetAccountsField
        {
            get { return WebDriver.FindElement(GET_ACCOUNTS_FIELD); }
        }

        private IWebElement SearchBtn
        {
            get { return WebDriver.FindElement(SEARCH_BTN); }
        }

        private IWebElement TaxAccountsTab
        {
            get { return WebDriver.FindElement(TAX_ACCOUNTS_TAB); }
        }
        #endregion
        #region Methods
        public AccountsPage(IWebDriver webDriver) : base(webDriver)
        {
            PageTitle = "";
            RelativePageAddress = "";
        }

        public new AccountsPage GoTo()
        {
            base.GoTo();
            return this;
        }
        public AccountsPage SearchForAccount()
        {
            Thread.Sleep(500);
            GetAccountsField.Clear();
            GetAccountsField.SendKeys(ConfigurationManager.AppSettings["accountNumber"]);
            Thread.Sleep(500);
            SearchBtn.Click();
            return new AccountsPage(WebDriver);
        }
        public TaxAccountsPage OpenTaxAccountsTab()
        {
            Thread.Sleep(300);
            var taxAccountsPage = new TaxAccountsPage(WebDriver);
            Thread.Sleep(300);
            TaxAccountsTab.ClickAndWaitForPageToLoad(taxAccountsPage);
            TaxAccountsTab.ClickAndWaitForPageToLoad(taxAccountsPage);
            return taxAccountsPage;
        }


        #endregion
    }
}
