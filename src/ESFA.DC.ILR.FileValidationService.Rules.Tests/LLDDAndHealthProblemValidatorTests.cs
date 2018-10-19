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

        [Fact]
        public void FD_LLDDCat_AL()
        {
            TestLengthLongRuleFor(p => p.LLDDCatNullable, "FD_LLDDCat_AL", "LLDDCat", 1, 2);
        }

        [Fact]
        public void FD_PrimaryLLDD_AL()
        {
            TestLengthLongRuleFor(p => p.PrimaryLLDDNullable, "FD_PrimaryLLDD_AL", "PrimaryLLDD", 1, 1);
        }
    }
}
