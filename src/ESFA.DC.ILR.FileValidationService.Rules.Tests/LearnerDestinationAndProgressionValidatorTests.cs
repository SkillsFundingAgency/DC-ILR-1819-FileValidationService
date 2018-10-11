using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class LearnerDestinationAndProgressionValidatorTests : AbstractValidatorTests<ILooseLearnerDestinationAndProgression>
    {
        public LearnerDestinationAndProgressionValidatorTests()
            : base(new LearnerDestinationAndProgressionValidator())
        {
        }

        [Fact]
        public void FD_DP_LearnRefNumber_AP()
        {
            TestRuleFor(ldp => ldp.LearnRefNumber, "FD_DP_LearnRefNumber_AP", "LearnRefNum", "");
        }
    }
}
