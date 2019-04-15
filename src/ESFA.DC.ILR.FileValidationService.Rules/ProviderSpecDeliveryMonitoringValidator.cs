using ESFA.DC.ILR.FileValidationService.Rules.Abstract;
using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class ProviderSpecDeliveryMonitoringValidator : AbstractFileValidationValidator<ILooseProviderSpecDeliveryMonitoring>
    {
        public override void RegexRules()
        {
            RuleFor(m => m.ProvSpecDelMonOccur).MatchesRestrictedString().WithErrorCode(RuleNames.FD_ProvSpecDelMonOccur_AP);
            RuleFor(m => m.ProvSpecDelMon).MatchesRestrictedString().WithErrorCode(RuleNames.FD_ProvSpecDelMon_AP);
        }

        public override void MandatoryAttributeRules()
        {
            RuleFor(m => m.ProvSpecDelMonOccur).NotNull().WithErrorCode(RuleNames.FD_ProvSpecDelMonOccur_MA);
            RuleFor(m => m.ProvSpecDelMon).NotNull().WithErrorCode(RuleNames.FD_ProvSpecDelMon_MA);
        }

        public override void LengthRules()
        {
            RuleFor(m => m.ProvSpecDelMonOccur).LengthTrim(1, 1).WithLengthError(RuleNames.FD_ProvSpecDelMonOccur_AL);
            RuleFor(m => m.ProvSpecDelMon).LengthTrim(1, 20).WithLengthError(RuleNames.FD_ProvSpecDelMon_AL);
        }
    }
}
