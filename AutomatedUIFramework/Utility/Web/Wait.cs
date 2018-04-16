using System;
using AutomatedUIFramework.Pages.General;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomatedUIFramework.Utility.Web
{
    public class Wait
    {
        private IWebDriver WebDriver;

        public Wait(IWebDriver webdriver)
        {
            WebDriver = webdriver;
        }

        public TResult Untill<TResult>(Func<IWebDriver, TResult> condition,
            string errorMessage = "", double timeoutInSeconds = 50)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            if (!string.IsNullOrEmpty(errorMessage))
            {
                wait.Message = errorMessage;
            }
            return wait.Until(condition);
        }

        public void UntillElementVisibile(By selector)
        {
            try
            {
                Untill(ExpectedConditions.ElementExists(selector), timeoutInSeconds: 3);
            }
            catch (NoSuchElementException)
            {
            }
            catch (WebDriverTimeoutException)
            {
            }
        }

        public void UntillDocumentReady(WebPage page)
        {
            Untill(driver => (driver as IJavaScriptExecutor).ExecuteScript("return document.readyState").Equals("complete"),
                string.Format("Page {0} wasn't loaded", page.PageTitle), 10);
        }

        public void UntillAjaxCompleted()
        {
            Untill(driver => (bool)(driver as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0"));
        }

    }
}
