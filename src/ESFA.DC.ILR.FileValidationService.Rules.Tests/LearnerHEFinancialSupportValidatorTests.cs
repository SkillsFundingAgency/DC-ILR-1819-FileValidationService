using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class LearnerHEFinancialSupportValidatorTests : AbstractValidatorTests<ILooseLearnerHEFinancialSupport>
    {
        public LearnerHEFinancialSupportValidatorTests()
            : base(new LearnerHEFinancialSupportValidator())
        {
        }

        [Fact]
        public void FD_FINTYPE_MA()
        {
            TestMandatoryLongAttributeRuleFor(fs => fs.FINTYPENullable, "FD_FINTYPE_MA");
        }

        [Fact]
        public void FD_FINAMOUNT_MA()
        {
            TestMandatoryLongAttributeRuleFor(fs => fs.FINAMOUNTNullable, "FD_FINAMOUNT_MA");
        }

        [Fact]
        public void FD_FINTYPE_AL()
        {
            TestLengthLongRuleFor(fs => fs.FINTYPENullable, "FD_FINTYPE_AL", "FINTYPE", 1, 1);
        }

        [Fact]
        public void FD_FINAMOUNT_AL()
        {
            TestLengthLongRuleFor(fs => fs.FINAMOUNTNullable, "FD_FINAMOUNT_AL", "FINAMOUNT", 1, 6);
        }
    }
}
