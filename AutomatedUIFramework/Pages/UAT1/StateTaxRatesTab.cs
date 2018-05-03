using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutomatedUIFramework.Pages.General;
using AutomatedUIFramework.Utility.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomatedUIFrameworkTemplate.Pages.UAT1
{
    public class StateTaxRatesTab : WebPage
    {

        #region Locators
        private By VA_SIT_BTN = By.XPath("//form[@id='aspnetForm']/div[3]/div/span/div/div/fieldset[2]/div[1]/table/tbody/tr[7]/td[.='VA SIT']");
        private By ADDED_VA_SIT_BTN = By.XPath("//form[@id='aspnetForm']/div[3]/div/span/div/div/fieldset[2]/div[1]/table/tbody/tr[8]/td[.='VA SIT']");
        private By ADD_TAX_PAYMENT_FREQUENCY_BTN = By.Id("ctl00_ctl00_cphMain_cphMainContent_CRUDControl2_btnAdd");
        private By EDIT_TAX_PAYMENT_FREQUENCY_BTN = By.Id("ctl00_ctl00_cphMain_cphMainContent_CRUDControl2_btnEdit");
        private By DELETE_TAX_PAYMENT_FREQUENCY_BTN = By.Id("ctl00_ctl00_cphMain_cphMainContent_CRUDControl2_btnDelete");
        private By SAVE_TAX_PAYMENT_FREQUENCY_BTN = By.Id("ctl00_ctl00_cphMain_cphMainContent_CRUDControl2_btnSave");
        private By STOP_DATE_PAYMENT_FREQUENCY_FIELD = By.Id("ctl00_ctl00_cphMain_cphMainContent_dtStop_uiDateYearTxt");
        private By START_DATE_PAYMENT_FREQUENCY_FIELD = By.Id("ctl00_ctl00_cphMain_cphMainContent_dtStart_uiDateYearTxt");
        private By QUARTER_STOP_DATE_DROP_DOWN = By.XPath("//form[@id='aspnetForm']/div[3]/div/span/div/div[@class='page_container']/fieldset[2]/div[3]/table[@class='dataTable']/tbody/tr[4]/td[2]/div/table//select[@name='ctl00$ctl00$cphMain$cphMainContent$dtStop$uiDateQtrList']/option[@value='1']");
        private By CLEAR_QUARTER_STOP_DATE_DROP_DOWN = By.XPath("//form[@id='aspnetForm']/div[3]/div/span/div/div[@class='page_container']/fieldset[2]/div[3]/table[@class='dataTable']/tbody/tr[4]/td[2]/div/table//select[@name='ctl00$ctl00$cphMain$cphMainContent$dtStop$uiDateQtrList']/option[@value='0']");
        private By QUARTER_START_DATE_DROP_DOWN = By.XPath("//form[@id='aspnetForm']/div[3]/div/span/div/div[@class='page_container']/fieldset[2]/div[3]/table[@class='dataTable']/tbody/tr[3]/td[2]/div/table//select[@name='ctl00$ctl00$cphMain$cphMainContent$dtStart$uiDateQtrList']/option[@value='4']");
        private By STATE_TAX_ACCOUNT_DROP_DOWN = By.XPath("//form[@id='aspnetForm']/div[3]/div/span/div/div/fieldset[2]/div[3]/table[@class='dataTable']//select[@name='ctl00$ctl00$cphMain$cphMainContent$ddlAccountStateTaxAccount2']/option[@value='1424']");
        private By TAX_PAYMENT_FREQUENCY_DROP_DOWN = By.XPath("//form[@id='aspnetForm']/div[3]/div/span/div/div/fieldset[2]/div[3]/table[@class='dataTable']//select[@name='ctl00$ctl00$cphMain$cphMainContent$ddlTaxPaymentFrequency']/option[@value='5']");
        private By BOTTOM_ELEMENT = By.XPath("//form[@id='aspnetForm']/div[3]/div/span/div/div/fieldset[2]/div[3]");
        private By SUCCESFUL_MESSAGE = By.XPath("//form[@id='aspnetForm']/div[3]/div/span/div/div/fieldset[2]/div[3]//span[@class='page_message']");


        #endregion
        #region UI Elemets
        private IWebElement VaSitBtn
        {
            get { return WebDriver.FindElement(VA_SIT_BTN); }
        }
        public IWebElement SuccessfulMessage
        {
            get { return WebDriver.FindElement(SUCCESFUL_MESSAGE); }
        }
        private IWebElement AddedVaSitBtn
        {
            get { return WebDriver.FindElement(ADDED_VA_SIT_BTN); }
        }
        private IWebElement AddTaxPaymentFrequencyBtn
        {
            get { return WebDriver.FindElement(ADD_TAX_PAYMENT_FREQUENCY_BTN); }
        }
        private IWebElement EditTaxPaymentFrequencyBtn
        {
            get { return WebDriver.FindElement(EDIT_TAX_PAYMENT_FREQUENCY_BTN); }
        }
        private IWebElement DeleteTaxPaymentFrequencyBtn
        {
            get { return WebDriver.FindElement(DELETE_TAX_PAYMENT_FREQUENCY_BTN); }
        }
        private IWebElement SaveTaxPaymentFrequencyBtn
        {
            get { return WebDriver.FindElement(SAVE_TAX_PAYMENT_FREQUENCY_BTN); }
        }
        private IWebElement StopDatePaymentFrequencyField
        {
            get { return WebDriver.FindElement(STOP_DATE_PAYMENT_FREQUENCY_FIELD); }
        }
        private IWebElement StartDatePaymentFrequencyField
        {
            get { return WebDriver.FindElement(START_DATE_PAYMENT_FREQUENCY_FIELD); }
        }
        private IWebElement QuarterStopDateDropDown
        {
            get { return WebDriver.FindElement(QUARTER_STOP_DATE_DROP_DOWN); }
        }
        private IWebElement ClearQuarterStopDateDropDown
        {
            get { return WebDriver.FindElement(CLEAR_QUARTER_STOP_DATE_DROP_DOWN); }
        }
        private IWebElement QuarterStartDateDropDown
        {
            get { return WebDriver.FindElement(QUARTER_START_DATE_DROP_DOWN); }
        }
        private IWebElement StateTaxAccountDropDown
        {
            get { return WebDriver.FindElement(STATE_TAX_ACCOUNT_DROP_DOWN); }
        }
        private IWebElement TaxPaymentFrequencyDropDown
        {
            get { return WebDriver.FindElement(TAX_PAYMENT_FREQUENCY_DROP_DOWN); }
        }
        private IWebElement BottomElement
        {
            get { return WebDriver.FindElement(BOTTOM_ELEMENT); }
        }

        #endregion
        #region Methods
        public StateTaxRatesTab(IWebDriver webDriver) : base(webDriver)
        {
            PageTitle = "";
            RelativePageAddress = "";
        }
        public StateTaxRatesTab SelectVaSitBtn()
        {
            var selectVaSitBtn = new StateTaxRatesTab(WebDriver);
            Thread.Sleep(1000);
            VaSitBtn.ClickAndWaitForPageToLoad(selectVaSitBtn);
            return new StateTaxRatesTab(WebDriver);
        }
        public StateTaxRatesTab SelectAddedVaSitBtn()
        {
            var selectAddedVaSitBtn = new StateTaxRatesTab(WebDriver);
            Thread.Sleep(2000);
            AddedVaSitBtn.ClickAndWaitForPageToLoad(selectAddedVaSitBtn);
            return new StateTaxRatesTab(WebDriver);
        }
        public StateTaxRatesTab SelectAddTaxPaymentFrequencyBtn()
        {
            var selectAddTaxPaymentFrequencyBtn = new StateTaxRatesTab(WebDriver);
            Thread.Sleep(2000);
            AddTaxPaymentFrequencyBtn.Click();
            return new StateTaxRatesTab(WebDriver);
        }
        public StateTaxRatesTab SelectEditTaxPaymentFrequencyBtn()
        {
            var selectEditTaxPaymentFrequencyBtn = new StateTaxRatesTab(WebDriver);
            Thread.Sleep(4000);
            EditTaxPaymentFrequencyBtn.ClickAndWaitForPageToLoad(selectEditTaxPaymentFrequencyBtn);
            return new StateTaxRatesTab(WebDriver);
        }
        public StateTaxRatesTab SelectDeleteTaxPaymentFrequencyBtn()
        {
            var selectDeleteTaxPaymentFrequencyBtn = new StateTaxRatesTab(WebDriver);
            Thread.Sleep(2000);
            DeleteTaxPaymentFrequencyBtn.Click();
            return new StateTaxRatesTab(WebDriver);
        }
        public StateTaxRatesTab SelectSaveTaxPaymentFrequencyBtn()
        {
            var selectSaveTaxPaymentFrequencyBtn = new StateTaxRatesTab(WebDriver);
            Thread.Sleep(1000);
            SaveTaxPaymentFrequencyBtn.ClickAndWaitForPageToLoad(selectSaveTaxPaymentFrequencyBtn);
            return new StateTaxRatesTab(WebDriver);
        }
        public StateTaxRatesTab SelectStopDatePaymentFrequencyField()
        {
            var selectStopDatePaymentFrequencyField = new StateTaxRatesTab(WebDriver);
            Thread.Sleep(3000);
            StopDatePaymentFrequencyField.Clear();
            StopDatePaymentFrequencyField.SendKeys("2012");
            return new StateTaxRatesTab(WebDriver);
        }
        public StateTaxRatesTab SelectStartDatePaymentFrequencyField()
        {
            var selectStartDatePaymentFrequencyField = new StateTaxRatesTab(WebDriver);
            Thread.Sleep(1000);
            StartDatePaymentFrequencyField.Clear();
            StartDatePaymentFrequencyField.SendKeys("2012");
            return new StateTaxRatesTab(WebDriver);
        }
        public StateTaxRatesTab SelectQuarterStopDateDropDown()
        {
            var selectQuarterStopDateDropDown = new StateTaxRatesTab(WebDriver);
            Thread.Sleep(1000);
            QuarterStopDateDropDown.ClickAndWaitForPageToLoad(selectQuarterStopDateDropDown);
            return new StateTaxRatesTab(WebDriver);
        }
        public StateTaxRatesTab ClearStopDate()
        {
            var clearQuarterStopDate = new StateTaxRatesTab(WebDriver);
            Thread.Sleep(2000);
            ClearQuarterStopDateDropDown.ClickAndWaitForPageToLoad(clearQuarterStopDate);
            StopDatePaymentFrequencyField.Clear();
            return new StateTaxRatesTab(WebDriver);
        }
        public StateTaxRatesTab SelectQuarterStartDateDropDown()
        {
            var selectQuarterStartDateDropDown = new StateTaxRatesTab(WebDriver);
            Thread.Sleep(1000);
            QuarterStartDateDropDown.ClickAndWaitForPageToLoad(selectQuarterStartDateDropDown);
            return new StateTaxRatesTab(WebDriver);
        }
        public StateTaxRatesTab SelectStateTaxAccountDropDown()
        {
            var selectStateTaxAccountDropDown = new StateTaxRatesTab(WebDriver);
            Thread.Sleep(1000);
            StateTaxAccountDropDown.ClickAndWaitForPageToLoad(selectStateTaxAccountDropDown);
            return new StateTaxRatesTab(WebDriver);
        }
        public StateTaxRatesTab SelectTaxPaymentFrequencyDropDown()
        {
            var selectTaxPaymentFrequencyDropDown = new StateTaxRatesTab(WebDriver);
            Thread.Sleep(1000);
            TaxPaymentFrequencyDropDown.ClickAndWaitForPageToLoad(selectTaxPaymentFrequencyDropDown);
            return new StateTaxRatesTab(WebDriver);
        }
        public StateTaxRatesTab MoveToBottomElement()
        {
            var moveToBottomElement = new StateTaxRatesTab(WebDriver);
            Thread.Sleep(1000);
            BottomElement.Click();
            return new StateTaxRatesTab(WebDriver);
        }
        public StateTaxRatesTab AcceptAllert()
        {
            Thread.Sleep(1000);
            var alert = WebDriver.SwitchTo().Alert();
            alert.Accept();
            return new StateTaxRatesTab(WebDriver);
        }

        #endregion
    }

}
