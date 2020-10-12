﻿using AutomatedUIFramework.Pages.General.UAT1;
using AutomatedUIFramework.Utility.Web.CustomAttributes;
using AutomatedUIFrameworkTemplate.Pages.General.UAT1;
using AutomatedUITests.SetUp;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Security.Cryptography.X509Certificates;

namespace AutomatedUITestsTemplate.Tests
{
    public class LoginTests : BasicTest
    {
        [Test]
        [Category("Login Tests")]
        [Description("Test verifies that user can login")]
        public void LoginWithValidCredsTest()
        {
            var logoutBtn = pages.LoginPage.GoTo().LoginToApp()
                                                  .SearchProduct("Iphone 11 Pro Max")
                                                  .ClickOnTheSearchButton()
                                                  .SelectFirstProduct()
                                                  //.SelectColorProduct()
                                                  .SelectSpecificationsProduct()
                                                  .BuyProduct()
                                                  .AddOneProduct()
                                                  .ExitTheBasket();


        }
        [Test]
        [RetryIfFailsAttribute]
        [Category("Login Tests")]
        [Description("Test verifies that user can not login")]
        public void LoginWithInvalidCredsTest()
        {
            var errorMessage = pages.LoginPage.GoTo().LoginWithInvalidCreds()
                                                  .ErrorMessage;



            Assert.That(errorMessage, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(errorMessage.Displayed, Is.True);
                Assert.AreEqual(errorMessage.Text, LoginPage.LoginError);
            });
        }
        [Test]
        [Category("Login Tests")]
        [Description("Test verifies that user can not login")]
        public void LoginWithEmptyPasswordTest()
        {
            var loginBtn = pages.LoginPage.GoTo().LoginWithEmptyPassword()
                                                  .LoginBtn;



            Assert.That(loginBtn, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(loginBtn.Displayed, Is.True);
            });
        }
        [Test]
        [Category("Login Tests")]
        [Description("Test verifies that user can not login")]
        public void LoginWithEmptyCredsTest()
        {
            var loginBtn = pages.LoginPage.GoTo().LoginWithEmptyCreds()
                                                  .LoginBtn;



            Assert.That(loginBtn, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(loginBtn.Displayed, Is.True);
            });
        }
        [Test]
        [Category("Login Tests")]
        [Description("Test verifies that user can not login")]
        public void LoginWithEmptyUserNameTest()
        {
            var loginBtn = pages.LoginPage.GoTo().LoginWithEmptyUserName()
                                                  .LoginBtn;



            Assert.That(loginBtn, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(loginBtn.Displayed, Is.True);
                Assert.That(loginBtn.Displayed, Is.True); Assert.That(loginBtn.Displayed, Is.True);
            });

        }
        [Test]
        [Category("Login Tests")]
        [Description("Test verifies that user can login")]
        public void CityWithValidDataTest()
        {
            string city = "Новая Каховка";
            var cityName = pages.HomePage.GoTo().SelectCity()
                                                  .SelectCityField(city)
                                                  .SelectApplyCity()
                                                  .FinalSelectApplyCity()
                                                  .GetCityName();

            Assert.IsTrue(cityName.Contains(city));

        }
        [Test]
        [Category("Login Tests")]
        [Description("Test verifies that user can login")]
        public void LoginWithAddingAndRemovingFromBasketTest()
        {
            string item = "Samsung Galaxy Watch 40mm";


            var basketFunctions = pages.LoginPage.GoTo().LoginToApp()
                                                         .SearchProduct(item)
                                                         .ClickOnTheSearchButton()
                                                         .SelectFirstProduct()
                                                         .BuyProduct()
                                                         .ExitTheBasket()
                                                         .SelectBasket()
                                                         .GetProductName();

            var basketStatus = pages.BasketPage.OpenBasketMenu()
                                               .EraseBasket()
                                               .ExitTheBasket()
                                               .SelectBasket()
                                               .GetBasketStatus();

            Assert.IsTrue(basketFunctions.Contains(item));
            Assert.IsTrue(basketStatus.Contains("Корзина пуста"));
        }
        [Test]
        [Category("Login Tests")]
        [Description("Test verifies that user can login")]
        
        public void PriceCheckTest()
        {
            string search = "Apple Magic Mouse 2 Bluetooth";
            int quantity = 10;
            


            var priceCheck = pages.HomePage.GoTo().SearchProduct(search)
                                                         .SelectFirstProduct()
                                                         .BuyProduct()
                                                         .GetProductPrice();

            var priceNewCheck = pages.BasketPage.ChangeProductQuantity(quantity)
                                                .GetProductPrice();

            Assert.AreEqual(priceCheck, priceNewCheck/quantity);
           



















        }
    }
}

