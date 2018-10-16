using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class EmploymentStatusMonitoringValidator : AbstractValidator<ILooseEmploymentStatusMonitoring>
    {
        public EmploymentStatusMonitoringValidator()
        {
            RegexRules();
            MandatoryAttributeRules();
        }

        private void RegexRules()
        {
            RuleSet(RuleSetNames.Regex, () =>
            {
                RuleFor(esm => esm.ESMType).MatchesRestrictedString().WithErrorCode(RuleNames.FD_ESMType_AP);
            });
        }

        private void MandatoryAttributeRules()
        {
            RuleSet(RuleSetNames.MandatoryAttributes, () =>
            {
                RuleFor(esm => esm.ESMType).NotNull().WithErrorCode(RuleNames.FD_ESMType_MA);
                RuleFor(esm => esm.ESMCodeNullable).NotNull().WithErrorCode(RuleNames.FD_ESMCode_MA);
            });
        }
    }
}
