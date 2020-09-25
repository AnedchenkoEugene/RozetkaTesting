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
    public class CityPage : WebPage
    {
        #region Locators
        private By CITY_BUTTON = By.XPath("//input[@class='autocomplete__input ng-untouched ng-pristine ng-valid']");
        private By CITY_FIELD = By.XPath("//div[@class='autocomplete']"); //input[@class='autocomplete__input ng-pristine ng-valid ng-touched']
        private By APPLY_CITY = By.XPath("//li[@class='autocomplete__item dialog_list']");
        #endregion
        #region UI Elemets
        public IWebElement CityButton
        {
            get { return WebDriver.FindElement(CITY_BUTTON); }
        }
        public IWebElement CityField
        {
            get { return WebDriver.FindElement(CITY_FIELD); }
        }
        public IWebElement ApplyCity
        {
            get { return WebDriver.FindElement(APPLY_CITY); }
        }



        #endregion
        #region Methods
        public CityPage(IWebDriver webDriver) : base(webDriver)
        {
            PageTitle = "";
            RelativePageAddress = "";
        }



        public CityPage SelectCityField()
        {
            Thread.Sleep(5000);
            CityField.Click();
            CityField.Clear();
            CityField.SendKeys("Новая Каховка");
            Thread.Sleep(5000);
            var cityPage = new CityPage(WebDriver);
            return cityPage;

        }
        public HomePage SelectApplyCity()
        {
            Thread.Sleep(3000);
            ApplyCity.Click();
            Thread.Sleep(3000);
            var homePage = new HomePage(WebDriver);
            return homePage;
        }



    }
}

        
        #endregion


