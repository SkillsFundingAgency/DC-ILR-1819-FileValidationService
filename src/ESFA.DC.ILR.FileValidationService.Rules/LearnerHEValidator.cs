using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearnerHEValidator : AbstractValidator<ILooseLearnerHE>
    {
        public LearnerHEValidator()
        {
            RuleFor(lhe => lhe.UCASPERID).MatchesRegex(Regexes.UcasPerId).WithErrorCode(RuleNames.FD_UCASPERID_AP);
        }
    }
}
