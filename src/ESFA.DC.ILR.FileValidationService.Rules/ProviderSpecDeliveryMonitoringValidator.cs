using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class ProviderSpecDeliveryMonitoringValidator : AbstractValidator<ILooseProviderSpecDeliveryMonitoring>
    {
        public ProviderSpecDeliveryMonitoringValidator()
        {
            RegexRules();
            MandatoryAttributeRules();
        }

        private void RegexRules()
        {
            RuleFor(m => m.ProvSpecDelMonOccur).MatchesRestrictedString().WithErrorCode(RuleNames.FD_ProvSpecDelMonOccur_AP);
            RuleFor(m => m.ProvSpecDelMon).MatchesRestrictedString().WithErrorCode(RuleNames.FD_ProvSpecDelMon_AP);
        }

        private void MandatoryAttributeRules()
        {
            RuleFor(m => m.ProvSpecDelMonOccur).NotNull().WithErrorCode(RuleNames.FD_ProvSpecDelMonOccur_MA);
            RuleFor(m => m.ProvSpecDelMon).NotNull().WithErrorCode(RuleNames.FD_ProvSpecDelMon_MA);
        }
    }
}
