using AutomatedUIFramework.Pages.General;
using AutomatedUIFramework.Utility.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
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
    public class ProductPage : WebPage
    {
        #region Locators
        private By PRODUCT_COLOR = By.XPath("//span[@style='background-color: rgb(102, 102, 102);']");
        private By PRODUCT_SPECIFICATIONS = By.XPath("//a[@class='tabs__link']");
        private By BUY_BUTTON = By.XPath("//span[@class='buy-button__label']");
        private By OPEN_BASKET_BUTTON = By.XPath("//a[@_ngcontent-c11]");
        #endregion
        #region WebElemets
        public IWebElement ProductColor
        {
            get { return WebDriver.FindElement(PRODUCT_COLOR); }
        }
        public IWebElement ProductSpecifications
        {
            get { return WebDriver.FindElement(PRODUCT_SPECIFICATIONS); }
        }
        private IWebElement BuyButton
        {
            get { return WebDriver.FindElement(BUY_BUTTON); }
        }
        private IWebElement OpenBasketButton
        {
            get { return WebDriver.FindElement(OPEN_BASKET_BUTTON); }
        }

        #endregion
        #region Methods
        public ProductPage(IWebDriver webDriver) : base(webDriver)
        {
            PageTitle = "";
            RelativePageAddress = "";
        }


        public ProductPage SelectColorProduct()
        {
            var productPage = new ProductPage(WebDriver);
            WebDriverWait wait = new WebDriverWait(WebDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(ProductColor));
            ProductColor.Click();
            return productPage;
        }

        public ProductPage SelectSpecificationsProduct()
        {
            var productPage = new ProductPage(WebDriver);
            WebDriverWait wait = new WebDriverWait(WebDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='tabs__link']")));
            ProductSpecifications.Click();
            return productPage;
        }
        public BasketPage BuyProduct()
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(BuyButton));
            BuyButton.Click();
            var basketPage = new BasketPage(WebDriver);
            return basketPage;
        }
        public BasketPage OpenBasket()
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(OpenBasketButton));
            OpenBasketButton.Click();
            var basketPage = new BasketPage(WebDriver);
            return basketPage;
        }
        
        #endregion
    }
}



