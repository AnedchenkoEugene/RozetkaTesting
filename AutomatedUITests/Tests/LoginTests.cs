using AutomatedUIFramework.Pages.General.UAT1;
using AutomatedUIFramework.Utility.Web.CustomAttributes;
using AutomatedUITests.SetUp;
using NUnit.Framework;


namespace AutomatedUITestsTemplate.Tests
{
    public class LoginTests :BasicTest
    {
        [Test]
        [Category("Login Tests")]
        [Description("Test verifies that user can login")]
        public void LoginWithValidCredsTest()
        {
            var logoutBtn = pages.LoginPage.GoTo().LoginToApp()
                                                  .SearchProduct("Iphone 11 Pro Max")
                                                  .SelectFirstProduct()
                                                  .SelectColorProduct()
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
            var cityName = pages.HomePage.GoTo().SelectCity()
                                                  .SelectCityField()
                                                  .SelectApplyCity()
                                                  .FinalSelectApplyCity();

            ///Assert.IsTrue(verifyTextPresent("Новая Каховка"));

        }
        [Test]
        [Category("Login Tests")]
        [Description("Test verifies that user can login")]
        public void LoginWithAddingAndRemovingFromBasketTest()
        {
            var basketFunctions = pages.LoginPage.GoTo().LoginToApp()
                                                        .SearchProduct("Samsung Galaxy Watch 40mm")
                                                        .SelectFirstProduct()
                                                        .BuyProduct()
                                                        .ExitTheBasket()
                                                        .SelectBasket()
                                                        .OpenBasketMenu()
                                                        .EraseBasket()
                                                        .ExitTheBasket()
                                                        .SelectBasket();
                                                        
                                                        
                                                  

            

        }
    }
}

