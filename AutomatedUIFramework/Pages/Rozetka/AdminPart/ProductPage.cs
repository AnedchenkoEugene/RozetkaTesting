using AutomatedUIFramework.Pages.General;
using AutomatedUIFramework.Utility.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
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
        private By PRODUCT_SPECIFICATIONS = By.XPath("/html/body/app-root/div/div[1]/app-rz-product/div/rz-product-navbar/rz-tabs/div/div/ul/li[2]/a");
        private By BUY_BUTTON = By.XPath("//span[@class='buy-button__label']");
        private By BASKET_BUTTON = By.XPath("//a[@_ngcontent-c11]");
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
        private IWebElement BasketButton
        {
            get { return WebDriver.FindElement(BASKET_BUTTON); }
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
            Thread.Sleep(7000);
            ProductColor.Click();
            Thread.Sleep(5000);
            var productPage = new ProductPage(WebDriver);
            return productPage;
        }

        public ProductPage SelectSpecificationsProduct()
        {
            Thread.Sleep(7000);
            ProductSpecifications.Click();
            Thread.Sleep(5000);
            var productPage = new ProductPage(WebDriver);
            return productPage;
        }
        public BasketPage BuyProduct()
        {
            Thread.Sleep(5000);
            BuyButton.Click();
            Thread.Sleep(5000);
            var basketPage = new BasketPage(WebDriver);
            return basketPage;
        }
        public BasketPage SelectBasket()
        {
            Thread.Sleep(5000);
            BasketButton.Click();
            Thread.Sleep(5000);
            var basketPage = new BasketPage(WebDriver);
            return basketPage;
        }
        
        #endregion
    }
}



