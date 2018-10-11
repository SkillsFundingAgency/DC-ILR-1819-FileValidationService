using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearnerFamValidator : AbstractValidator<ILooseLearnerFAM>
    {
        public LearnerFamValidator()
        {
            RuleFor(fam => fam.LearnFAMType).MatchesRestrictedString().WithErrorCode(RuleNames.FD_LearnFAMType_AP);
        }
    }
}
