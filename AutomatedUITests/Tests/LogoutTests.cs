using AutomatedUITests.SetUp;
using NUnit.Framework;


namespace AutomatedUITestsTemplate.Tests
{
    [TestFixture]
    public  class LogoutTests :BasicTest
    {
        [Test]
        [Category("Logout Tests")]
        [Description("Test verifies that user can not logout")]
        public void LogOutTest()
        {
            var loginBtn = pages.LoginPage.GoTo().LoginToApp()
                                                     .CheckLogOutOption()
                                                     .LoginBtn;




            Assert.That(loginBtn, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(loginBtn.Displayed, Is.True);
               
            });
        }
    }
}
