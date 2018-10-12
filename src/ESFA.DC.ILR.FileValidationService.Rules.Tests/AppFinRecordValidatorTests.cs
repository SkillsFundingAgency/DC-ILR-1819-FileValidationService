using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class AppFinRecordValidatorTests : AbstractValidatorTests<ILooseAppFinRecord>
    {
        public AppFinRecordValidatorTests()
            : base(new AppFinRecordValidator())
        {
        }

        [Fact]
        public void FD_AFinType_AP()
        {
            TestRuleFor(afr => afr.AFinType, "FD_AFinType_AP", "AFinType", "`");
        }
    }
}
