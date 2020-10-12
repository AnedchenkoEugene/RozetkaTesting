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
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;

namespace AutomatedUIFrameworkTemplate.Pages.General.UAT1
{
    public class BasketPage : WebPage
    {
        #region Locators
        private By ONE_PRODUCT_BUTTON = By.XPath("//button[@aria-label='Добавить ещё один товар']");
        private By BASKET_MENU_BUTTON = By.XPath("//button[@class='button button--white button--small cart-actions__toggle']");
        private By ERASE_BASKET_BUTTON = By.XPath("//li[@class='cart-actions__item']");
        private By EXIT_BASKET_BUTTON = By.XPath("//button[@class='modal__close']");
        private By BASKET_PRODUCT = By.XPath("//a[@class='cart-product__title']");
        private By EMPTY_BASKET = By.XPath("//h4[@class='cart-dummy__heading']");
        private By PRODUCT_QUANTITY = By.CssSelector("body > app-root > single-modal-window > div.modal__holder.modal__holder_show_animation.modal__holder_size_large > div.modal__content > rz-shopping-cart > div > ul > li > rz-cart-product > div > div.cart-product__footer > rz-cart-counter > div > input");
        private By PRODUCT_PRICE = By.XPath("//div[@class='cart-receipt__sum-price']");
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
        public IWebElement BasketProduct
        {
            get { return WebDriver.FindElement(BASKET_PRODUCT); }
        }
        public IWebElement EmptyBasket
        {
            get { return WebDriver.FindElement(EMPTY_BASKET); }
        }
        public IWebElement ProductQuantity
        {
            get { return WebDriver.FindElement(PRODUCT_QUANTITY); }
        }
        public IWebElement ProductPrice
        {
            get { return WebDriver.FindElement(PRODUCT_PRICE); }
        }
        

        #endregion
        #region Methods
        public BasketPage(IWebDriver webDriver) : base(webDriver)
        {
            PageTitle = "";
            RelativePageAddress = "";
        }
        public new BasketPage GoTo()
        {
            base.GoTo();
            return this;
        }


        public BasketPage AddOneProduct()
        {
            var basketPage = new BasketPage(WebDriver);
            WebDriverWait wait = new WebDriverWait(WebDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(OneProductButton));
            OneProductButton.Click();
            return basketPage;

        }
        public BasketPage OpenBasketMenu()
        {
            var basketPage = new BasketPage(WebDriver);
            WebDriverWait wait = new WebDriverWait(WebDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(BasketMenuButton));
            BasketMenuButton.Click();
            return basketPage;


        }
        public BasketPage EraseBasket()
        {
            var basketPage = new BasketPage(WebDriver);
            WebDriverWait wait = new WebDriverWait(WebDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(EraseBasketButton));
            EraseBasketButton.Click();
            return basketPage;
        }
        public ProductPage ExitTheBasket()
        {
            var productPage = new ProductPage(WebDriver);
            WebDriverWait wait = new WebDriverWait(WebDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(ExitBasketButton));
            ExitBasketButton.Click();
            return productPage;
        }
        public string GetProductName()
        {
            string item = BasketProduct.Text;
            return item;
        }
        public string GetBasketStatus()
        {
            string items = EmptyBasket.Text;
            return items;
        }
        public BasketPage ChangeProductQuantity(int quantity)
        {
           //// Thread.Sleep(3000);
           
            ProductQuantity.Click();
            ProductQuantity.Clear();
            ProductQuantity.SendKeys(quantity.ToString());
            ProductQuantity.SendKeys(Keys.Enter);
            var basketPage = new BasketPage(WebDriver);
            ProductQuantity.ClickAndWaitForPageToLoad(basketPage);
            

            return basketPage;
        }
        public int GetProductPrice()
        {
            string prodPrice = ProductPrice.Text;
            string data = Regex.Match(prodPrice, @"/(\d)(?= \d) /g").Value;
            return Convert.ToInt32(data);
        }
        
        #endregion
    }
}


