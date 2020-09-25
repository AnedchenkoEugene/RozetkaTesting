using AutomatedUIFramework.Pages.General;
using AutomatedUIFramework.Pages.General.UAT1;
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
    public class TownPage : WebPage
    {
        #region Locators
        private By TOWN_BUTTON = By.XPath("//input[@class='autocomplete__input ng-untouched ng-pristine ng-valid']");
        private By TOWN_FIELD = By.XPath("");
        private By APPLY_TOWN = By.XPath("//li[@class='autocomplete__item dialog_list']");
        #endregion
        #region UI Elemets
        public IWebElement TownButton
        {
            get { return WebDriver.FindElement(TOWN_BUTTON); }
        }
        public IWebElement TownField
        {
            get { return WebDriver.FindElement(TOWN_FIELD); }
        }
        public IWebElement ApplyTown
        {
            get { return WebDriver.FindElement(APPLY_TOWN); }
        }



        #endregion
        #region Methods
        public TownPage(IWebDriver webDriver) : base(webDriver)
        {
            PageTitle = "";
            RelativePageAddress = "";
        }



        public TownPage SelectTownField()
        {
            Thread.Sleep(3000);
            TownField.Click();
            TownField.Clear();
            TownField.SendKeys("Новая Каховка");
            Thread.Sleep(5000);
            var townPage = new TownPage(WebDriver);
            return townPage;

        }
        public HomePage SelectApplyTown()
        {
            Thread.Sleep(3000);
            ApplyTown.Click();
            Thread.Sleep(3000);
            var homePage = new HomePage(WebDriver);
            return homePage;
        }



    }
}

        
        #endregion


