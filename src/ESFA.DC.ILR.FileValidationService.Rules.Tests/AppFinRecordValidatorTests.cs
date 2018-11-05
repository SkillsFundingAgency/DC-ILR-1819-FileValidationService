using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentAssertions;
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
            TestRegexRuleFor(afr => afr.AFinType, "FD_AFinType_AP", "AFinType", "`");
        }

        [Fact]
        public void FD_AFinType_MA()
        {
            TestMandatoryStringAttributeRuleFor(afr => afr.AFinType, "FD_AFinType_MA");
        }

        [Fact]
        public void FD_AFinCode_MA()
        {
            TestMandatoryLongAttributeRuleFor(afr => afr.AFinCodeNullable, "FD_AFinCode_MA");
        }

        [Fact]
        public void FD_AFinDate_MA()
        {
            TestMandatoryDateTimeAttributeRuleFor(afr => afr.AFinDateNullable, "FD_AFinDate_MA");
        }

        [Fact]
        public void FD_AFinAmount_MA()
        {
            TestMandatoryLongAttributeRuleFor(afr => afr.AFinAmountNullable, "FD_AFinAmount_MA");
        }

        [Fact]
        public void FD_AFinType_AL()
        {
            TestLengthStringRuleFor(afr => afr.AFinType, "FD_AFinType_AL", "AFinType", 1, 3);
        }

        [Fact]
        public void FD_AFinCode_AL()
        {
            TestLengthLongRuleFor(afr => afr.AFinCodeNullable, "FD_AFinCode_AL", "AFinCode", 1, 2);
        }

        [Fact]
        public void FD_AFinAmount_AL()
        {
            TestLengthLongRuleFor(afr => afr.AFinAmountNullable, "FD_AFinAmount_AL", "AFinAmount", 1, 6);
        }

        [Fact]
        public void FD_AFinAmount_AR()
        {
            TestRangeFor(afr => afr.AFinAmountNullable, "FD_AFinAmount_AR", "AFinAmount", 0, 999999);
        }
    }
}
