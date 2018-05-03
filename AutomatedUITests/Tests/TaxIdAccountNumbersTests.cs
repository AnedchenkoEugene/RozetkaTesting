
using AutomatedUITests.SetUp;
using NUnit.Framework;

namespace AutomatedUITests.Tests
{
    [TestFixture]
    public class TaxIdAccountNumbersTests  : BasicTest
    {
        [Test]
        [Category("Tax Id Account Numbers Test")]
        
        [Description("Test verifies that edited data is successfully saved")]
        public void TaxIdAccountNumbersTest()
        {
            var saveSuccessful = pages.LoginPage.GoTo().LoginToApp()
                                                  .GoToAccountsPage()
                                                  .SearchForAccount("")
                                                  .OpenTaxAccountsTab()
                                                  .SelectStateTab()
                                                  .SelectBisTaxCode()
                                                  .EditStateTaxAccountCode()
                                                  .EditEINField()
                                                  .SelectBisTaxCode()
                                                  .EditStateTaxAccountCode()
                                                  .EditLoginIDField()
                                                  .SaveSuccessulMessage;
                                                  
                                                  
            Assert.That(saveSuccessful, Is.Not.Null);
            
            Assert.Multiple(() =>
            {
                Assert.That(saveSuccessful.Displayed, Is.True);
            });
            
        }
    }
}
