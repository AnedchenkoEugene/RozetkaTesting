using System;
using System.Threading;
using AutomatedUIFramework.Pages.General;
using OpenQA.Selenium;

namespace AutomatedUIFramework.Utility.Web
{
    public static class ClickExtensions
    {
        public static void ClickAndWaitForPageToLoad(this IWebElement element, WebPage page)
        {
            element.Click();
            var wait = new Wait(page.WebDriver);
                wait.UntillDocumentReady(page);
                wait.UntillAjaxCompleted();
        }

        public static void ClickExplicitly(this IWebElement element)
        {
            bool isSuccessfullyClicked = false;
            int tryCount = 0;
            int maxTryCount = 30;
            do
            {
                try
                {
                    element.Click();
                    isSuccessfullyClicked = true;
                }
                catch (InvalidOperationException ex)
                {
                    if (tryCount <= maxTryCount)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                        tryCount++;
                    }
                    else
                    {
                        throw new Exception("Cannot click on element.", ex);
                    }
                }
            } while (!isSuccessfullyClicked);
        }
    }
}
