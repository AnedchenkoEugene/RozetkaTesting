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
        private By OPEN_BASKET_MENU_BUTTON = By.XPath("//div[@class='cart-actions']");
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
        public IWebElement OpenBasketMenuButton
        {
            get { return WebDriver.FindElement(OPEN_BASKET_MENU_BUTTON); }
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
            WebDriverWait wait = new WebDriverWait(WebDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(OneProductButton));
            OneProductButton.Click();
            var basketPage = new BasketPage(WebDriver);
            return basketPage;

        }
        public BasketPage OpenBasketMenu()
        { 
            WebDriverWait wait = new WebDriverWait(WebDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(OpenBasketMenuButton));
            OpenBasketMenuButton.Click();
            var basketPage = new BasketPage(WebDriver);
            return basketPage;


        }
        public BasketPage EraseBasket()
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(EraseBasketButton));
            EraseBasketButton.Click();
            var basketPage = new BasketPage(WebDriver);
            return basketPage;
        }
        public ProductPage ExitTheBasket()
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='modal__close']")));
            ExitBasketButton.Click();
            var productPage = new ProductPage(WebDriver);
            return productPage;
        }
        public string GetProductName()
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='cart-product__title']")));
            string item = BasketProduct.Text;
            return item;
        }
        public string GetBasketStatus()
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h4[@class='cart-dummy__heading']")));
            string items = EmptyBasket.Text;
            return items;
        }
        public BasketPage ChangeProductQuantity(int quantity)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(ProductQuantity));
            ProductQuantity.Click();
            ProductQuantity.Clear();
            ProductQuantity.SendKeys(quantity.ToString());
            ProductQuantity.SendKeys(Keys.Enter);
            var basketPage = new BasketPage(WebDriver);
            return basketPage;
        }
        public int GetProductPrice()
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='cart-receipt__sum-price']")));
            string prodPrice = ProductPrice.Text;
            string data = Regex.Match(prodPrice, @"\s[0-9]\d").Value;
            return Convert.ToInt32(data);
        }
        
        #endregion
    }
}


