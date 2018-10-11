using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class LearnerHEValidatorTests : AbstractValidatorTests<ILooseLearnerHE>
    {
        public LearnerHEValidatorTests()
            : base(new LearnerHEValidator())
        {
        }

        [Fact]
        public void FD_UCASPERID_AP()
        {
            TestRuleFor(lhe => lhe.UCASPERID, "FD_UCASPERID_AP", "1234567890", "A");
        }
    }
}
