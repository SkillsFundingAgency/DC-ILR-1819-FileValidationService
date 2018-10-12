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
            TestRuleFor(cp => cp.LearnFAMType, "FD_LearnFAMType_AP", "Learn Fam Type", "`");
        }
    }
}
