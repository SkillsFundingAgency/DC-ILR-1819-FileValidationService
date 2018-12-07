using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class ProviderSpecLearnerMonitoringValidatorTests : AbstractValidatorTests<ILooseProviderSpecLearnerMonitoring>
    {
        public ProviderSpecLearnerMonitoringValidatorTests()
            : base(new ProviderSpecLearnerMonitoringValidator())
        {
        }

        [Fact]
        public void FD_ProvSpecLearnMonOccur_AP()
        {
            TestRegexRuleFor(m => m.ProvSpecLearnMonOccur, "FD_ProvSpecLearnMonOccur_AP", "ProvSpecLearnMonOccur", "`");
        }

        [Fact]
        public void FD_ProvSpecLearnMon_AP()
        {
            TestRegexRuleFor(m => m.ProvSpecLearnMon, "FD_ProvSpecLearnMon_AP", "ProvSpecLearnMon", "`");
        }

        [Fact]
        public void FD_ProvSpecLearnMonOccur_MA()
        {
            TestMandatoryStringAttributeRuleFor(m => m.ProvSpecLearnMonOccur, "FD_ProvSpecLearnMonOccur_MA");
        }

        [Fact]
        public void FD_ProvSpecLearnMon_MA()
        {
            TestMandatoryStringAttributeRuleFor(m => m.ProvSpecLearnMon, "FD_ProvSpecLearnMon_MA");
        }

        [Fact]
        public void FD_ProvSpecLearnMonOccur_AL()
        {
            TestLengthStringRuleFor(m => m.ProvSpecLearnMonOccur, "FD_ProvSpecLearnMonOccur_AL", "ProvSpecLearnMonOccur", 1, 1);
        }

        [Fact]
        public void FD_ProvSpecLearnMon_AL()
        {
            TestLengthStringRuleFor(m => m.ProvSpecLearnMon, "FD_ProvSpecLearnMon_AL", "ProvSpecLearnMon", 1, 20);
        }
    }
}
