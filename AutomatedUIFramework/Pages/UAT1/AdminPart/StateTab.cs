using AutomatedUIFramework.Pages.General;
using AutomatedUIFramework.Utility.Web;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatedUIFrameworkTemplate.Pages.General.UAT1
{
   public class StateTab :WebPage
    {
        #region Locators
        private By EDIT_BTN = By.Id("ctl00_ctl00_cphMain_cphMainContent_CRUDControl1_btnEdit");
        private By BIS_TAX_CODE = By.XPath("//tr[@class= 'grid-row']");
        private By StateEIN = By.Id("ctl00_ctl00_cphMain_cphMainContent_txtStateEIN");
        private By SAVE_BTN = By.Id("ctl00_ctl00_cphMain_cphMainContent_CRUDControl1_btnSave");
        private By LOGIN_ID_FIELD = By.Id("ctl00_ctl00_cphMain_cphMainContent_txtLoginID");
        private By SAVE_SUCCESFUL_MESSAGE = By.Id("ctl00_ctl00_cphMain_cphMainContent_lblMessage"); 
        #endregion
        #region UI Elemets
        private IWebElement BisTaxCode
        {
            get { return WebDriver.FindElement(BIS_TAX_CODE); }
        }
        public IWebElement SaveSuccessulMessage
        {
            get { return WebDriver.FindElement(SAVE_SUCCESFUL_MESSAGE); }
        }
        private IWebElement LoginIDField
        {
            get { return WebDriver.FindElement(LOGIN_ID_FIELD); }
        }
        private IWebElement SaveBtn
        {
            get { return WebDriver.FindElement(SAVE_BTN); }
        }
        private IWebElement EditBtn
        {
            get { return WebDriver.FindElement(EDIT_BTN); }
        }
        private IWebElement StateEINField
        {
            get { return WebDriver.FindElement(StateEIN); }
        }

        #endregion
        #region Methods
        public StateTab(IWebDriver webDriver) : base(webDriver)
        {
            PageTitle = "";
            RelativePageAddress = "";
        }

        public StateTab SelectBisTaxCode()
        {
            var selectBisCode = new StateTab(WebDriver);
            Thread.Sleep(3500);
            BisTaxCode.ClickAndWaitForPageToLoad(selectBisCode);
            Thread.Sleep(3500);
            return new StateTab(WebDriver);
        }
        public StateTab EditStateTaxAccountCode()
        {
            var selectBisCode = new StateTab(WebDriver);
            Thread.Sleep(6000);
            EditBtn.ClickAndWaitForPageToLoad(selectBisCode);
            return new StateTab(WebDriver);
        }
        public StateTab EditEINField()
        {
            var editEINCode = new StateTab(WebDriver);
            Thread.Sleep(2100);
            StateEINField.Clear();
            Thread.Sleep(2100);
            StateEINField.SendKeys(ConfigurationManager.AppSettings["EINNumber"]);
            Thread.Sleep(2100);
            SaveBtn.ClickAndWaitForPageToLoad(editEINCode);
            Thread.Sleep(2100);
            return new StateTab(WebDriver);
        }
        public StateTab EditLoginIDField()
        {
            var editEINCode = new StateTab(WebDriver);
            Thread.Sleep(1200);
            LoginIDField.Clear();
            LoginIDField.SendKeys("autobot");
            Thread.Sleep(1200);
            SaveBtn.ClickAndWaitForPageToLoad(editEINCode);
            Thread.Sleep(1200);
            return new StateTab(WebDriver);
        }

        #endregion
    }
}
