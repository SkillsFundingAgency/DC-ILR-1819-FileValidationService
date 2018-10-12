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
            RuleFor(m => m.ProvSpecDelMonOccur).MatchesRestrictedString().WithErrorCode(RuleNames.FD_ProvSpecDelMonOccur_AP);
            RuleFor(m => m.ProvSpecDelMon).MatchesRestrictedString().WithErrorCode(RuleNames.FD_ProvSpecDelMon_AP);
        }
    }
}
