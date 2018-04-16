using OpenQA.Selenium;

namespace AutomatedUIFramework.Pages.Interfaces
{
    public interface IWebPage
    {
        IWebDriver WebDriver { get; set; }
        string RelativePageAddress { get; set; }
        string FullPageAddress { get; }
        string PageTitle { get; set; }
        IWebPage GoTo();
    }
}
