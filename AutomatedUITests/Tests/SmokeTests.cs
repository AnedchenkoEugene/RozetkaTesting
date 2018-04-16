using AutomatedUITests.SetUp;
using NUnit.Framework;


namespace AutomatedUITestsTemplate.Tests
{
    [TestFixture]
   public class SmokeTests:BasicTest
    {
        [Test]
        [Category("Validate Navigation menu")]
        [Description("Test verifies that all tabs are shown")]
        public void ValidateUtilitiesTabIsOpenedTest()
        {
            var utilitiesTab = pages.LoginPage.GoTo().LoginToApp()
                                                     .UtilitiesTab;




            Assert.That(utilitiesTab, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(utilitiesTab.Displayed, Is.True);

            });
        }

        [Test]
        [Category("Validate Navigation menu")]
        [Description("Test verifies that all tabs are shown")]
        public void ValidateTaxAgencyTabIsOpenedTest()
        {
            var taxAgencytab = pages.LoginPage.GoTo().LoginToApp()
                                                     .TaxAgencyTab;




            Assert.That(taxAgencytab, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(taxAgencytab.Displayed, Is.True);

            });
        }
        [Test]
        [Category("Validate Navigation menu")]
        [Description("Test verifies that all tabs are shown")]
        public void ValidateProspectTabIsOpenedTest()
        {
            var prospectTab = pages.LoginPage.GoTo().LoginToApp()
                                                     .ProspectTab;




            Assert.That(prospectTab, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(prospectTab.Displayed, Is.True);

            });
        }
    }
}
