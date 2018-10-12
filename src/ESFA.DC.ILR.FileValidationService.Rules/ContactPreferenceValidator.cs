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
            RuleFor(cp => cp.ContPrefType).MatchesRestrictedString().WithErrorCode(RuleNames.FD_ContPrefType_AP);
        }
    }
}
