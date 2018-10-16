using System.Data;
using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class DPOutcomeValidator : AbstractValidator<ILooseDPOutcome>
    {
        public DPOutcomeValidator()
        {
            RegexRules();
            MandatoryAttributeRules();
        }

        private void RegexRules()
        {
            RuleSet(RuleSetNames.Regex, () =>
            {
                RuleFor(dpo => dpo.OutType).MatchesRestrictedString().WithErrorCode(RuleNames.FD_DP_OutType_AP);
            });
        }

        private void MandatoryAttributeRules()
        {
            RuleSet(RuleSetNames.MandatoryAttributes, () =>
            {
                RuleFor(dpo => dpo.OutType).NotNull().WithErrorCode(RuleNames.FD_DP_OutType_MA);
                RuleFor(dpo => dpo.OutCodeNullable).NotNull().WithErrorCode(RuleNames.FD_DP_OutCode_MA);
                RuleFor(dpo => dpo.OutStartDateNullable).NotNull().WithErrorCode(RuleNames.FD_DP_OutStartDate_MA);
                RuleFor(dpo => dpo.OutCollDateNullable).NotNull().WithErrorCode(RuleNames.FD_DP_OutCollDate_MA);
            });
        }
    }
}
