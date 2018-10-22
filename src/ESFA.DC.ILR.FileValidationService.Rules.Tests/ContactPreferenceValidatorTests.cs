using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class ContactPreferenceValidatorTests : AbstractValidatorTests<ILooseContactPreference>
    {
        public ContactPreferenceValidatorTests() 
            : base(new ContactPreferenceValidator())
        {
        }

        [Fact]
        public void FD_ContPrefType_AP()
        {
            TestRegexRuleFor(cp => cp.ContPrefType, "FD_ContPrefType_AP", "ContPref", "`");
        }

        [Fact]
        public void FD_ContPrefType_MA()
        {
            TestMandatoryStringAttributeRuleFor(cp => cp.ContPrefType, "FD_ContPrefType_MA");
        }

        [Fact]
        public void FD_ContPrefCode_MA()
        {
            TestMandatoryLongAttributeRuleFor(cp => cp.ContPrefCodeNullable, "FD_ContPrefCode_MA");
        }

        [Fact]
        public void FD_ContPrefType_AL()
        { 
            TestLengthStringRuleFor(cp => cp.ContPrefType, "FD_ContPrefType_AL", "ContPrefType", 1, 3);
        }

        [Fact]
        public void FD_ContPrefCode_AL()
        {
            TestLengthLongRuleFor(cp => cp.ContPrefCodeNullable, "FD_ContPrefCode_AL", "ContPrefCode", 1, 1);
        }
    }
}
