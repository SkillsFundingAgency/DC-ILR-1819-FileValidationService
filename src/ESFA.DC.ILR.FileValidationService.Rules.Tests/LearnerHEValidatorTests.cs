using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;
using FluentValidation.TestHelper;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class LearnerHEValidatorTests : AbstractValidatorTests<ILooseLearnerHE>
    {
        private static readonly IValidator<ILooseLearnerHEFinancialSupport> LearnerHEFinancialSupportValidator = new Mock<IValidator<ILooseLearnerHEFinancialSupport>>().Object;

        public LearnerHEValidatorTests()
            : base(new LearnerHEValidator(LearnerHEFinancialSupportValidator))
        {
        }

        [Fact]
        public void FD_UCASPERID_AP()
        {
            TestRuleFor(lhe => lhe.UCASPERID, "FD_UCASPERID_AP", "1234567890", "A");
        }

        [Fact]
        public void LearnerHEFinancialSupport_ChildValidator()
        {
            _validator.ShouldHaveChildValidator(lhe => lhe.LearnerHEFinancialSupports, typeof(IValidator<ILooseLearnerHEFinancialSupport>));
        }
    }
}
