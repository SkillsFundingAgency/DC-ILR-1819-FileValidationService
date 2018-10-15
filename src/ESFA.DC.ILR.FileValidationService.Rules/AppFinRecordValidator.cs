using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class AppFinRecordValidator : AbstractValidator<ILooseAppFinRecord>
    {
        public AppFinRecordValidator()
        {
            RegexRules();
            MandatoryAttributeRules();
        }

        private void RegexRules()
        {
            RuleFor(afr => afr.AFinType).MatchesRestrictedString().WithErrorCode(RuleNames.FD_AFinType_AP);
        }

        private void MandatoryAttributeRules()
        {
            RuleFor(afr => afr.AFinType).NotNull().WithErrorCode(RuleNames.FD_AFinType_MA);
            RuleFor(afr => afr.AFinCodeNullable).NotNull().WithErrorCode(RuleNames.FD_AFinCode_MA);
            RuleFor(afr => afr.AFinDateNullable).NotNull().WithErrorCode(RuleNames.FD_AFinDate_MA);
            RuleFor(afr => afr.AFinAmountNullable).NotNull().WithErrorCode(RuleNames.FD_AFinAmount_MA);
        }
    }
}
