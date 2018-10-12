using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class DPOutcomeValidatorTests : AbstractValidatorTests<ILooseDPOutcome>
    {
        public DPOutcomeValidatorTests()
            : base(new DPOutcomeValidator())
        {
        }

        [Fact]
        public void FD_DP_OutType_AP()
        {
            TestRuleFor(dpo => dpo.OutType, "FD_DP_OutType_AP", "Out Type", "`");
        }
    }
}
