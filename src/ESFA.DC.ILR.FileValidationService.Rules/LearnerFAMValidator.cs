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
            RegexRules();
            MandatoryAttributeRules();
        }

        private void RegexRules()
        {
            RuleFor(fam => fam.LearnFAMType).MatchesRestrictedString().WithErrorCode(RuleNames.FD_LearnFAMType_AP);
        }

        private void MandatoryAttributeRules()
        {
            RuleFor(fam => fam.LearnFAMType).NotNull().WithErrorCode(RuleNames.FD_LearnFAMType_MA);
            RuleFor(fam => fam.LearnFAMCodeNullable).NotNull().WithErrorCode(RuleNames.FD_LearnFAMCode_MA);
        }
    }
}
