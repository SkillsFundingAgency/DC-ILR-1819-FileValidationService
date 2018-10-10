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
            RuleFor(cp => cp.ContPrefType).MatchesRegex(@"^[A-Za-z0-9 ~!@#$%&amp;'\(\)\*\+,\-\./:;&lt;=&gt;\?\[\\\]_\{\}\^&#xa3;&#x20ac;]*$").WithErrorCode(RuleNames.FD_ContPrefType_AP);
        }
    }
}
