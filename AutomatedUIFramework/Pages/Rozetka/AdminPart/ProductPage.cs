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

namespace AutomatedUIFrameworkTemplate.Pages.General.UAT1
{
   public class ProductPage :WebPage
    {
        #region Locators

        #endregion
        #region UI Elemets
        

        #endregion
        #region Methods
        public ProductPage(IWebDriver webDriver) : base(webDriver)
        {
            PageTitle = "";
            RelativePageAddress = "";
        }



        #endregion
    }
}
