using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class LearningDeliveryFAMValidatorTests : AbstractValidatorTests<ILooseLearningDeliveryFAM>
    {
        public LearningDeliveryFAMValidatorTests()
            : base(new LearningDeliveryFAMValidator())
        {
        }

        [Fact]
        public void FD_LearnDelFAMType_AP()
        {
            TestRuleFor(fam => fam.LearnDelFAMType, "FD_LearnDelFAMType_AP", "Learn Del Fam Type", "`");
        }

        [Fact]
        public void FD_LearnDelFAMCode_AP()
        {
            TestRuleFor(fam => fam.LearnDelFAMCode, "FD_LearnDelFAMCode_AP", "Learn Del Fam Code", "`");
        }

        [Fact]
        public void FD_LearnDelFAMType_MA()
        {
            TestMandatoryStringAttributeRuleFor(ld => ld.LearnDelFAMType, "FD_LearnDelFAMType_MA");
        }

        [Fact]
        public void FD_LearnDelFAMCode_MA()
        {
            TestMandatoryStringAttributeRuleFor(ld => ld.LearnDelFAMCode, "FD_LearnDelFAMCode_MA");
        }
    }
}
