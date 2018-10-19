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
            LengthRules();
        }

        private void RegexRules()
        {
            RuleSet(RuleSetNames.Regex, () =>
            {
                RuleFor(fam => fam.LearnFAMType).MatchesRestrictedString().WithErrorCode(RuleNames.FD_LearnFAMType_AP);
            });
        }

        private void MandatoryAttributeRules()
        {
            RuleSet(RuleSetNames.MandatoryAttributes, () =>
            {
                RuleFor(fam => fam.LearnFAMType).NotNull().WithErrorCode(RuleNames.FD_LearnFAMType_MA);
                RuleFor(fam => fam.LearnFAMCodeNullable).NotNull().WithErrorCode(RuleNames.FD_LearnFAMCode_MA);
            });
        }

        private void LengthRules()
        {
            RuleSet(RuleSetNames.Length, () =>
            {
                RuleFor(fam => fam.LearnFAMType).Length(1, 3).WithLengthError(RuleNames.FD_LearnFAMType_AL);
                RuleFor(fam => fam.LearnFAMCodeNullable).Length(1, 3).WithLengthError(RuleNames.FD_LearnFAMCode_AL);
            });
        }
    }
}
