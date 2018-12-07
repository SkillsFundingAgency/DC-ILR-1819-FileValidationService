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
            RegexRules();
            MandatoryAttributeRules();
            LengthRules();
        }

        private void RegexRules()
        {
            RuleSet(RuleSetNames.Regex, () =>
            {
                RuleFor(fam => fam.LearnDelFAMCode).MatchesRestrictedString().WithErrorCode(RuleNames.FD_LearnDelFAMCode_AP);
                RuleFor(fam => fam.LearnDelFAMType).MatchesRestrictedString().WithErrorCode(RuleNames.FD_LearnDelFAMType_AP);
            });
        }

        private void MandatoryAttributeRules()
        {
            RuleSet(RuleSetNames.MandatoryAttributes, () =>
            {
                RuleFor(fam => fam.LearnDelFAMCode).NotNull().WithErrorCode(RuleNames.FD_LearnDelFAMCode_MA);
                RuleFor(fam => fam.LearnDelFAMType).NotNull().WithErrorCode(RuleNames.FD_LearnDelFAMType_MA);
            });
        }

        public void LengthRules()
        {
            RuleSet(RuleSetNames.Length, () =>
            {
                RuleFor(fam => fam.LearnDelFAMType).Length(1, 3).WithLengthError(RuleNames.FD_LearnDelFAMType_AL);
                RuleFor(fam => fam.LearnDelFAMCode).Length(1, 5).WithLengthError(RuleNames.FD_LearnDelFAMCode_AL);
            });
        }
    }
}
