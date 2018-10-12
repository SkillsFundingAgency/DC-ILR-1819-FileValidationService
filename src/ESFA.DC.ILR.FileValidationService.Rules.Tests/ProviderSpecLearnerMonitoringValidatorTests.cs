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
            TestRuleFor(m => m.ProvSpecLearnMonOccur, "FD_ProvSpecLearnMonOccur_AP", "ProvSpecLearnMonOccur", "`");
        }

        [Fact]
        public void FD_ProvSpecLearnMon_AP()
        {
            TestRuleFor(m => m.ProvSpecLearnMon, "FD_ProvSpecLearnMon_AP", "ProvSpecLearnMon", "`");
        }
    }
}
