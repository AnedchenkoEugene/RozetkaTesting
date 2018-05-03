using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedUITests.SetUp;
using NUnit.Framework;

namespace AutomatedUITestsTemplate.Tests
{
    public class ComplianceNoticesFFChangesTests : BasicTest
    {
        [Test]
        [Category("Compliance Notices FF Changes")]

        [Description("Test verifies that edited and added data is successfully saved")]
        public void ComplianceNoticesFFChangesTest()
        {
            var ffChangeSuccessful = pages.LoginPage.GoTo().LoginToApp()
                .GoToAccountsPage()
                .SearchForAccount(ConfigurationManager.AppSettings["AccountNumber"])
                .OpenTaxAccountsTab()
                .SelectStateTaxRatesTab()
                .MoveToBottomElement()
                .SelectVaSitBtn()
                .SelectEditTaxPaymentFrequencyBtn()
                .SelectStopDatePaymentFrequencyField()
                .SelectQuarterStopDateDropDown()
                .SelectSaveTaxPaymentFrequencyBtn()
                .SelectAddTaxPaymentFrequencyBtn()
                .SelectStateTaxAccountDropDown()
                .SelectTaxPaymentFrequencyDropDown()
                .SelectStartDatePaymentFrequencyField()
                .SelectQuarterStartDateDropDown()
                .SelectSaveTaxPaymentFrequencyBtn()
                //TearDown
                .SelectAddedVaSitBtn()
                .SelectDeleteTaxPaymentFrequencyBtn()
                .AcceptAllert()
                .SelectVaSitBtn()
                .SelectEditTaxPaymentFrequencyBtn()
                .ClearStopDate()
                .SelectSaveTaxPaymentFrequencyBtn()
                .SuccessfulMessage;

            Assert.That(ffChangeSuccessful, Is.Not.Null);

            



        }
    }
}
