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
    public class BasketPage : WebPage
    {
        #region Locators
        private By ONE_PRODUCT_BUTTON = By.XPath("//button[@aria-label='Добавить ещё один товар']");
        private By BASKET_MENU_BUTTON = By.XPath("//button[@class='button button--white button--small cart-actions__toggle']");
        private By ERASE_BASKET_BUTTON = By.XPath("//li[@class='cart-actions__item']");
        private By EXIT_BASKET_BUTTON = By.XPath("//button[@class='modal__close']");
        #endregion
        #region UI Elemets
        public IWebElement OneProductButton
        {
            get { return WebDriver.FindElement(ONE_PRODUCT_BUTTON); }
        }
        public IWebElement BasketMenuButton
        {
            get { return WebDriver.FindElement(BASKET_MENU_BUTTON); }
        }
        public IWebElement EraseBasketButton
        {
            get { return WebDriver.FindElement(ERASE_BASKET_BUTTON); }
        }
        public IWebElement ExitBasketButton
        {
            get { return WebDriver.FindElement(EXIT_BASKET_BUTTON); }
        }

        #endregion
        #region Methods
        public BasketPage(IWebDriver webDriver) : base(webDriver)
        {
            PageTitle = "";
            RelativePageAddress = "";
        }


        public BasketPage AddOneProduct()
        {
            Thread.Sleep(3000);
            OneProductButton.Click();
            Thread.Sleep(5000);
            var basketPage = new BasketPage(WebDriver);
            return basketPage; 

        }
        public BasketPage OpenBasketMenu()
        {
            Thread.Sleep(3000);
            BasketMenuButton.Click();
            Thread.Sleep(5000);
            var basketPage = new BasketPage(WebDriver);
            return basketPage;


        }
        public BasketPage EraseBasket()
        {
            Thread.Sleep(3000);
            EraseBasketButton.Click();
            Thread.Sleep(5000);
            var basketPage = new BasketPage(WebDriver);
            return basketPage;
        }
        public ProductPage ExitTheBasket()
        {
            Thread.Sleep(3000);
            ExitBasketButton.Click();
            Thread.Sleep(5000);
            var productPage = new ProductPage(WebDriver);   
            return productPage;
        }

        #endregion
    }
}

