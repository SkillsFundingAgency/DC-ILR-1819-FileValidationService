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
            TestRegexRuleFor(lhe => lhe.UCASPERID, "FD_UCASPERID_AP", "1234567890", "A");
        }

        [Fact]
        public void FD_UCASPERID_AL()
        {
            TestLengthStringRuleFor(lhe => lhe.UCASPERID, "FD_UCASPERID_AL", "UCASPERID", 1, 10);
        }

        [Fact]
        public void FD_TTACCOM_AL()
        {
            TestLengthLongRuleFor(lhe => lhe.TTACCOMNullable, "FD_TTACCOM_AL", "TTACCOM", 1, 1);
        }

        [Fact]
        public void FD_UCASPERID_AR()
        {
            TestRangeForStringAsLong(lhe => lhe.UCASPERID, "FD_UCASPERID_AR", "UCASPERID", 1, 9999999999);
        }

        [Fact]
        public void FD_LearnerHEFinancialSupport_EO()
        {
            TestEntityMaximumOccurrenceFor(lhe => lhe.LearnerHEFinancialSupports, "FD_LearnerHEFinancialSupport_EO", "LearnerHEFinancialSupport", 4);
        }

        [Fact]
        public void LearnerHEFinancialSupport_ChildValidator()
        {
            _validator.ShouldHaveChildValidator(lhe => lhe.LearnerHEFinancialSupports, typeof(IValidator<ILooseLearnerHEFinancialSupport>));
        }
    }
}
