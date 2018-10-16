using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class LLDDAndHealthProblemValidatorTests : AbstractValidatorTests<ILooseLLDDAndHealthProblem> 
    {
        public LLDDAndHealthProblemValidatorTests()
            : base(new LLDDAndHealthProblemValidator())
        {
        }

        [Fact]
        public void FD_LLDDCat_MA()
        {
            TestMandatoryLongAttributeRuleFor(p => p.LLDDCatNullable, "FD_LLDDCat_MA");
        }
    }
}
