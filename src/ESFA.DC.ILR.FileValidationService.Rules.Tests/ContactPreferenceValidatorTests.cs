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
        public void ContPrefType()
        {
            TestRuleFor(cp => cp.ContPrefType, "FD_ContPrefType_AP", "ContPref", "`");
        }
    }
}
