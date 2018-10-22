using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;
using FluentValidation.TestHelper;
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
            TestRegexRuleFor(ldp => ldp.LearnRefNumber, "FD_DP_LearnRefNumber_AP", "LearnRefNum", "");
        }

        [Fact]
        public void FD_DP_LearnRefNumber_MA()
        {
            TestMandatoryStringAttributeRuleFor(ldp => ldp.LearnRefNumber, "FD_DP_LearnRefNumber_MA");
        }

        [Fact]
        public void FD_DP_ULN_MA()
        {
            TestMandatoryLongAttributeRuleFor(ldp => ldp.ULNNullable, "FD_DP_ULN_MA");
        }

        [Fact]
        public void FD_DP_LearnRefNumber_AL()
        {
            TestLengthStringRuleFor(ldp => ldp.LearnRefNumber, "FD_DP_LearnRefNumber_AL", "LearnRefNumber", 1, 12);
        }

        [Fact]
        public void FD_DP_ULN_AL()
        {
            TestLengthLongRuleFor(ldp => ldp.ULNNullable, "FD_DP_ULN_AL", "ULN", 1, 10);
        }

        [Fact]
        public void FD_DP_ULN_AR()
        {
            TestRangeFor(ldp => ldp.ULNNullable, "FD_DP_ULN_AR", "ULN", 1000000000, 9999999999);
        }

        [Fact]
        public void FD_DP_DPOutcome_EO()
        {
            TestEntityMinimumOccurrenceFor(ldp => ldp.DPOutcomes, "FD_DP_DPOutcome_EO", "DPOutcome", 1);
        }

        [Fact]
        public void DPOutcome_ChildValidator()
        {
            _validator.ShouldHaveChildValidator(ldp => ldp.DPOutcomes, typeof(IValidator<ILooseDPOutcome>));
        }

    }
}
