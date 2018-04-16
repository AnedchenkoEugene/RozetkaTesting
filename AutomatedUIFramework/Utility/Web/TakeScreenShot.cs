using System;
using NLog;
using OpenQA.Selenium;
using NLog.Fluent;

namespace AutomatedUIFramework.Utility.Web
{
  public class TakeScreenShot
    {
        private IWebDriver webDriver;
        
        public TakeScreenShot(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void TakeScreenshot(string filepath)
        {
            var screenshot = ((ITakesScreenshot)this.webDriver).GetScreenshot();
            screenshot.SaveAsFile(filepath, ScreenshotImageFormat.Png);
        }
    }
}
