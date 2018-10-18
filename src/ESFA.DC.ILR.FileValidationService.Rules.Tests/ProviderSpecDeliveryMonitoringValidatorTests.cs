using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class ProviderSpecDeliveryMonitoringValidatorTests : AbstractValidatorTests<ILooseProviderSpecDeliveryMonitoring>
    {
        public ProviderSpecDeliveryMonitoringValidatorTests()
            : base(new ProviderSpecDeliveryMonitoringValidator())
        {
        }

        [Fact]
        public void FD_ProvSpecDelMonOccur_AP()
        {
            TestRegexRuleFor(m => m.ProvSpecDelMonOccur, "FD_ProvSpecDelMonOccur_AP", "Prov Spec Del Mon Occur", "`");
        }

        [Fact]
        public void FD_ProvSpecDelMon_AP()
        {
            TestRegexRuleFor(m => m.ProvSpecDelMon, "FD_ProvSpecDelMon_AP", "Prov Spec Del Mon", "`");
        }

        [Fact]
        public void FD_ProvSpecDelMonOccur_MA()
        {
            TestMandatoryStringAttributeRuleFor(m => m.ProvSpecDelMonOccur, "FD_ProvSpecDelMonOccur_MA");
        }

        [Fact]
        public void FD_ProvSpecDelMon_MA()
        {
            TestMandatoryStringAttributeRuleFor(m => m.ProvSpecDelMon, "FD_ProvSpecDelMon_MA");
        }

        [Fact]
        public void FD_ProvSpecDelMonOccur_AL()
        {
            TestLengthStringRuleFor(m => m.ProvSpecDelMonOccur, "FD_ProvSpecDelMonOccur_AL", "ProvSpecDelMonOccur", 1, 1);
        }

        [Fact]
        public void FD_ProvSpecDelMon_AL()
        {
            TestLengthStringRuleFor(m => m.ProvSpecDelMon, "FD_ProvSpecDelMon_AL", "ProvSpecDelMon", 1, 20);
        }
    }
}
