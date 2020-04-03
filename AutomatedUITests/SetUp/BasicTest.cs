using System;
using System.Configuration;
using System.IO;
using AutomatedUIFramework.Pages.General;
using AutomatedUIFramework.Utility;
using AutomatedUIFramework.Utility.Web;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;


namespace AutomatedUITests.SetUp
{
    [TestFixture]
    public class BasicTest
    {
        protected Browser browser;
        protected Pages pages;
        private readonly ILogger Log = LogManager.GetCurrentClassLogger();


        public static string FullTestMethodName
        {
            get { return TestContext.CurrentContext.Test.FullName; }
        }

        public static string TestClassName
        {
            get { return TestContext.CurrentContext.Test.FullName.Split('.')[1]; }
        }

        public static string ScreenshotsFolder
        {
            get { return Path.Combine(ConfigurationManager.AppSettings["ScreenshotsFolder"]); }
        }

        [OneTimeSetUp]
        public void FixtureInit()
        {
            if (Directory.Exists(ScreenshotsFolder))
            FileSystemTools.DeleteDirectory(ScreenshotsFolder);
            Directory.CreateDirectory(ScreenshotsFolder);
        }

        [SetUp]
        protected void SetupTest()
        {
            browser = new Browser();
            browser.Open();
            browser.MaximizeWindow();
            pages = new Pages(browser);
        }

        [TearDown]
        protected void TestCleanup()
        {
            ScreenshotOnFailure();
            browser.Quit();
        }

        private void ScreenshotOnFailure()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status.ToString();
                if (status.Equals(TestStatus.Failed.ToString()))
                {
                    var fileName = FileSystemTools.ReplaceIllegalFilenameCharacters(FullTestMethodName) + "_" + DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt") + ".png";
                    var filePath = Path.Combine(ScreenshotsFolder, fileName);
                    new TakeScreenShot(browser.getDriver).TakeScreenshot(filePath);
                    Log.Error("{0}.{1} generated an error. {1}A Screenshot of the browser has been saved.: {2}", FullTestMethodName, Environment.NewLine,filePath);
                }
            }
            catch (Exception e)
            {
                Log.Error("Encountered error while saving screenshot {0}{1}", Environment.NewLine, e.Message);
            }
        }
    }
}
