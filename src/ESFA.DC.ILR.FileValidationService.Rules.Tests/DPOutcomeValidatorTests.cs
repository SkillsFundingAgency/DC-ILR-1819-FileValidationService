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
            TestRegexRuleFor(dpo => dpo.OutType, "FD_DP_OutType_AP", "Out Type", "`");
        }

        [Fact]
        public void FD_DP_OutType_MA()
        {
            TestMandatoryStringAttributeRuleFor(dpo => dpo.OutType, "FD_DP_OutType_MA");
        }

        [Fact]
        public void FD_DP_OutCode_MA()
        {
            TestMandatoryLongAttributeRuleFor(dpo => dpo.OutCodeNullable, "FD_DP_OutCode_MA");
        }

        [Fact]
        public void FD_DP_OutStartDate_MA()
        {
            TestMandatoryDateTimeAttributeRuleFor(dpo => dpo.OutStartDateNullable, "FD_DP_OutStartDate_MA");
        }

        [Fact]
        public void FD_DP_OutCollDate_MA()
        {
            TestMandatoryDateTimeAttributeRuleFor(dpo => dpo.OutCollDateNullable, "FD_DP_OutCollDate_MA");
        }
    }
}
