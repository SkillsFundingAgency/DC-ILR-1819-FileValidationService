using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearningDeliveryFAMValidator : AbstractValidator<ILooseLearningDeliveryFAM>
    {
        public LearningDeliveryFAMValidator()
        {
            RuleFor(fam => fam.LearnDelFAMCode).MatchesRestrictedString().WithErrorCode(RuleNames.FD_LearnDelFAMCode_AP);
            RuleFor(fam => fam.LearnDelFAMType).MatchesRestrictedString().WithErrorCode(RuleNames.FD_LearnDelFAMType_AP);
        }
    }
}
