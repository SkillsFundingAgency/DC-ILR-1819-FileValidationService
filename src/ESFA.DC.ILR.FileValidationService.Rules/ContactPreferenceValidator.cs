using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class ContactPreferenceValidator : AbstractValidator<ILooseContactPreference>
    {
        public ContactPreferenceValidator()
        {
            RegexRules();
            MandatoryAttributeRules();
        }

        private void RegexRules()
        {
            RuleSet(RuleSetNames.Regex, () =>
            {
                RuleFor(cp => cp.ContPrefType).MatchesRestrictedString().WithErrorCode(RuleNames.FD_ContPrefType_AP);
            });
        }

        private void MandatoryAttributeRules()
        {
            RuleSet(RuleSetNames.MandatoryAttributes, () =>
            {
                RuleFor(cp => cp.ContPrefType).NotNull().WithErrorCode(RuleNames.FD_ContPrefType_MA);
                RuleFor(cp => cp.ContPrefCodeNullable).NotNull().WithErrorCode(RuleNames.FD_ContPrefCode_MA);
            });
        }
    }
}
