using AutomatedUIFramework.Utility.Web;
using OpenQA.Selenium;
using System.Configuration;

namespace AutomatedUIFramework.Pages.General.UAT1
{
  public class LoginPage :WebPage
    {
        #region Locators
        private By USER_NAME_FIELD = By.Id("ctl00_ctl00_cphMain_cphMainContent_txtLoginUsername");
        private By USER_FIELD = By.Id("ctl00_ctl00_cphMain_cphMainContent_txtLoginPassword");
        private By LOGIN_BTN = By.Id("ctl00_ctl00_cphMain_cphMainContent_btnLogin");
        private By ERROR_MESSAGE = By.Id("ctl00_ctl00_cphMain_cphMainContent_lblPageMessage");

        #endregion
        #region String Messages
        public static string LoginError = "Invalid username/password combination.";
        #endregion
        #region WebElements
      
        private IWebElement UserNameField
        {
            get { return WebDriver.FindElement(USER_NAME_FIELD); } 
        }
        public IWebElement ErrorMessage
        {
            get { return WebDriver.FindElement(ERROR_MESSAGE); }
        }
        private IWebElement UserPasswordField
        {
            get { return WebDriver.FindElement(USER_FIELD); }
        }
        public IWebElement LoginBtn
        {
            get { return WebDriver.FindElement(LOGIN_BTN); }
        }



        #endregion
        #region Methods
        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {
            PageTitle = "";
            RelativePageAddress = "";
        }


        public new LoginPage GoTo()
        {
            base.GoTo();
            return this;
        }

        public HomePage LoginToApp()
        {
            UserNameField.Clear();
            UserNameField.SendKeys(ConfigurationManager.AppSettings["user"]);
            UserPasswordField.Clear();
            UserPasswordField.SendKeys(ConfigurationManager.AppSettings["password"]);
            var homepage = new HomePage(WebDriver);
            LoginBtn.ClickAndWaitForPageToLoad(homepage);
            return homepage;
        }
        public LoginPage LoginWithInvalidCreds()
        {
            UserNameField.Clear();
            UserNameField.SendKeys(ConfigurationManager.AppSettings["password"]);
            UserPasswordField.Clear();
            UserPasswordField.SendKeys(ConfigurationManager.AppSettings["user"]);
            var loginPage = new LoginPage(WebDriver);
            LoginBtn.ClickAndWaitForPageToLoad(loginPage);
            return loginPage;
        }

        public LoginPage LoginWithEmptyPassword()
        {
            UserNameField.Clear();
            UserPasswordField.SendKeys(ConfigurationManager.AppSettings["user"]);
            UserPasswordField.Clear();
            var loginPage = new LoginPage(WebDriver);
            LoginBtn.ClickAndWaitForPageToLoad(loginPage);
            return loginPage;
        }

        public LoginPage LoginWithEmptyCreds()
        {
            UserNameField.Clear();
            UserPasswordField.Clear();
            var loginPage = new LoginPage(WebDriver);
            LoginBtn.ClickAndWaitForPageToLoad(loginPage);
            return loginPage;
        }
        public LoginPage LoginWithEmptyUserName()
        {
            UserNameField.Clear();
            UserPasswordField.Clear();
            UserPasswordField.SendKeys(ConfigurationManager.AppSettings["password"]);
            var loginPage = new LoginPage(WebDriver);
            LoginBtn.ClickAndWaitForPageToLoad(loginPage);
            return loginPage;
        }



        #endregion
    }
}
