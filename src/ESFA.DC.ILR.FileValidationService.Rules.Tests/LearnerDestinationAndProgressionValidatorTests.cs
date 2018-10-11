using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class LearnerDestinationAndProgressionValidatorTests : AbstractValidatorTests<ILooseLearnerDestinationAndProgression>
    {
        private static readonly IValidator<ILooseDPOutcome> DPOutcomeValidator = new Mock<IValidator<ILooseDPOutcome>>().Object;

        public LearnerDestinationAndProgressionValidatorTests()
            : base(new LearnerDestinationAndProgressionValidator(DPOutcomeValidator))
        {
        }

        [Fact]
        public void FD_DP_LearnRefNumber_AP()
        {
            TestRuleFor(ldp => ldp.LearnRefNumber, "FD_DP_LearnRefNumber_AP", "LearnRefNum", "");
        }
    }
}
