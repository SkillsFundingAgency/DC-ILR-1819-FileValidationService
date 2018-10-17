using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class LearnerFAMValidatorTests : AbstractValidatorTests<ILooseLearnerFAM>
    {
        public LearnerFAMValidatorTests()
            : base(new LearnerFamValidator())
        {
        }

        [Fact]
        public void FD_LearnFAMType_AP()
        {
            TestRegexRuleFor(fam => fam.LearnFAMType, "FD_LearnFAMType_AP", "Learn Fam Type", "`");
        }

        [Fact]
        public void FD_LearnFAMType_MA()
        {
            TestMandatoryStringAttributeRuleFor(fam => fam.LearnFAMType, "FD_LearnFAMType_MA");
        }

        [Fact]
        public void FD_LearnFAMCode_MA()
        {
            TestMandatoryLongAttributeRuleFor(fam => fam.LearnFAMCodeNullable, "FD_LearnFAMCode_MA");
        }

        [Fact]
        public void FD_LearnFAMType_AL()
        {
            TestLengthStringRuleFor(fam => fam.LearnFAMType, "FD_LearnFAMType_AL", "LearnFAMType", 1, 3);
        }

        [Fact]
        public void FD_LearnFAMCode_AL()
        {
            TestLengthLongRuleFor(fam => fam.LearnFAMCodeNullable, "FD_LearnFAMCode_AL", "LearnFAMCode", 1, 3);
        }
    }
}
