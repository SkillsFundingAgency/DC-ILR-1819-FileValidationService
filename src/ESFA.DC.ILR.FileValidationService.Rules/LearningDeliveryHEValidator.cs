using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearningDeliveryHEValidator : AbstractValidator<ILooseLearningDeliveryHE>
    {
        public LearningDeliveryHEValidator()
        {
            RuleFor(he => he.NUMHUS).MatchesRestrictedString().WithErrorCode(RuleNames.FD_NUMHUS_AP);
            RuleFor(he => he.SSN).MatchesRestrictedString().WithErrorCode(RuleNames.FD_SSN_AP);
            RuleFor(he => he.QUALENT3).MatchesRestrictedString().WithErrorCode(RuleNames.FD_QUALENT3_AP);
            RuleFor(he => he.UCASAPPID).MatchesRegex(Regexes.UcasAppId).WithErrorCode(RuleNames.FD_UCASAPPID_AP);
            RuleFor(he => he.DOMICILE).MatchesRestrictedString().WithErrorCode(RuleNames.FD_DOMICILE_AP);
            RuleFor(he => he.HEPostCode).MatchesRestrictedString().WithErrorCode(RuleNames.FD_HEPostCode_AP);
        }
    }
}
