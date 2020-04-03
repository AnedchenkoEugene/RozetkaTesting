using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Drawing;
using System.Reflection;
using NLog;
using NLog.Fluent;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace AutomatedUIFramework.Pages.General
{
    public class Browser
    {
        private IWebDriver webDriver;
        private readonly ILogger Log = LogManager.GetCurrentClassLogger();

        #region Internal Methods and properties
        public string Title
        {
            get { return webDriver.Title; }
        }

        public string PageSource
        {
            get { return webDriver.PageSource; }
        }

        public IWebDriver getDriver
        {
            get { return webDriver; }
        }

        /// <summary>
        /// This method gets the inner html for the specified element
        /// </summary>
        /// <param name="element">The element to retrieve the inner html from</param>
        /// <returns>The inner html as string</returns>
        public string GetInnerHtml(IWebElement element)
        {
            var js = webDriver as IJavaScriptExecutor;
            var result = "";

            try
            {
                if (js != null)
                {
                    result = (string)js.ExecuteScript("return arguments[0].innerHTML;", element);
                }
            }
            catch (Exception e)
            {
                Log.Error("GetInnerHtml encountered an error: {0}",e.Message);
                throw;
            }

            return result;

        }



        /// <summary>
        /// Maximises the browser window
        /// </summary>
        public void MaximizeWindow()
        {
            webDriver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Set sixe of window
        /// </summary>
        public void SetSize(int width, int height)
        {
            webDriver.Manage().Window.Size = new Size(width, height);
        }
        #endregion
        
        public void Quit()
        {
            webDriver.Quit();
        }
        
        public void Open()
        {
            try
            {
                webDriver = (IWebDriver)Activator.CreateInstance("WebDriver", ConfigurationManager.AppSettings["Browser"]).Unwrap();
            }
            catch (ArgumentNullException e1)
            {
                Log.Error("Browser was not found. Check a browser has been chosen in the app.config file.{0}{1}", 
                    Environment.NewLine, e1.Message);
                throw;
            }
            catch (TargetInvocationException e2)
            {
                Log.Error("Browser.Open() encountered an error. Check Driver location.{0}{1}", 
                    Environment.NewLine, e2.Message);
                throw;
            }
            catch (Exception e3)
            {
                Log.Error("Browser.Open() encountered an error.{0}{1}", 
                    Environment.NewLine, e3.Message);
                throw;
            }

            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(int.Parse(ConfigurationManager.AppSettings["ImplicitWaitTimeout"]));
        }

        public bool HasNewWindow()
        {
            return webDriver.WindowHandles.Count > 1;
        }

        public IWebDriver GetNewWindow()
        {
            string parentWindow = webDriver.CurrentWindowHandle;


            string popupHandle = string.Empty;
            ReadOnlyCollection<string> windowHandles = webDriver.WindowHandles;

            foreach (string handle in windowHandles)
            {
                if (handle != parentWindow)
                {
                    popupHandle = handle;

                    return webDriver.SwitchTo().Window(popupHandle);
                }
            }

            return null;
        }

        public void GetCurrentWindow()
        {

            ReadOnlyCollection<string> windowHandles = webDriver.WindowHandles;
            webDriver.SwitchTo().Window(windowHandles[0]);
        }

        public IWebDriver GetIFrame(IWebDriver window)
        {
            return window.SwitchTo().Frame(0);
        }


        public void CloseNewWindow()
        {
            if (!HasNewWindow()) return;

        }

        public void CloseNewWindow(IWebDriver window)
        {
            window.Close();
        }

        /// <summary>
        /// In case browser session needs to be reused 
        /// </summary>
        public void ReturnBrowserToPreconditions()
        {
            //Clear cookies
            webDriver.Manage().Cookies.DeleteAllCookies();
            //Close excess browser tabs
            if (webDriver.WindowHandles.Count > 1)
            {
                string neededWindowHandle = webDriver.CurrentWindowHandle;
                foreach (var window in webDriver.WindowHandles)
                {
                    if (window != neededWindowHandle)
                    {
                        webDriver.SwitchTo().Window(window);
                        webDriver.Close();
                    }
                }
                webDriver.SwitchTo().Window(neededWindowHandle);
            }
        }
    }
}
