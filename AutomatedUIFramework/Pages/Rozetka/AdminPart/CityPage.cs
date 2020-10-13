using AutomatedUIFramework.Pages.General;
using AutomatedUIFramework.Pages.General.UAT1;
using AutomatedUIFramework.Utility.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
        private By CITY_FIELD = By.CssSelector("#cityinput > div > input"); 
        private By APPLY_CITY = By.CssSelector("#cityinput > div > ul > li");
        private By FINAL_CONFIRMATION = By.XPath("//button[text()=' Применить ']");
        #endregion
        #region UI Elemets

        public IWebElement CityField
        {
            get { return WebDriver.FindElement(CITY_FIELD); }
        }
        public IWebElement ApplyCity
        {
            get { return WebDriver.FindElement(APPLY_CITY); }
        }
        public IWebElement FinalConfirmation
        {
            get { return WebDriver.FindElement(FINAL_CONFIRMATION); }
        }



        #endregion
        #region Methods
        public CityPage(IWebDriver webDriver) : base(webDriver)
        {
            PageTitle = "";
            RelativePageAddress = "";
        }



        public CityPage SelectCityField(string city)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(CityField));
            CityField.Click();
            CityField.Clear();
            CityField.SendKeys(city);
            var cityPage = new CityPage(WebDriver);
            return cityPage;

        }
        public CityPage SelectApplyCity()
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(ApplyCity));
            ApplyCity.Click();
            var cityPage = new CityPage(WebDriver);
            return cityPage;
        }
        public HomePage FinalSelectApplyCity()
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(FinalConfirmation));
            FinalConfirmation.Click();
            var homePage = new HomePage(WebDriver);
            return homePage; 
        }

    }
}

        
        #endregion


