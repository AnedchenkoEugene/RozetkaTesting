using AutomatedUIFramework.Pages.General;
using AutomatedUIFramework.Utility.Web;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutomatedUIFrameworkTemplate.Pages.UAT1;

namespace AutomatedUIFrameworkTemplate.Pages.General.UAT1
{
    public class TaxAccountsPage : WebPage
    {
        #region Locators
        private By STATE_BTN = By.LinkText("State");
        private By STATE_TAX_RATES_BTN = By.LinkText("State Tax Rates");
        #endregion
        #region UI Elements
        private IWebElement StateBtn
        {
            get { return WebDriver.FindElement(STATE_BTN); }
        }
        private IWebElement StateTaxRatesBtn
        {
            get { return WebDriver.FindElement(STATE_TAX_RATES_BTN); }
        }

        #endregion
        #region Methods
        public TaxAccountsPage(IWebDriver webDriver) : base(webDriver)
        {
            PageTitle = "";
            RelativePageAddress = "";
        }
        public StateTab SelectStateTab()
        {
            var stateTab = new StateTab(WebDriver);
            Thread.Sleep(1200);
            StateBtn.ClickAndWaitForPageToLoad(stateTab);
            return stateTab;
        }

        public StateTaxRatesTab SelectStateTaxRatesTab()
        {
            var selectStateTaxRatesTab = new StateTaxRatesTab(WebDriver);
            Thread.Sleep(1200);
            StateTaxRatesBtn.ClickAndWaitForPageToLoad(selectStateTaxRatesTab);
            return selectStateTaxRatesTab;
        }

        #endregion
        }

}
