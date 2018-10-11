using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class ProviderSpecLearnerMonitoringValidator : AbstractValidator<IProviderSpecLearnerMonitoring>
    {
        public ProviderSpecLearnerMonitoringValidator()
        {
            RuleFor(m => m.ProvSpecLearnMonOccur).MatchesRestrictedString().WithErrorCode(RuleNames.FD_ProvSpecLearnMonOccur_AP);
            RuleFor(m => m.ProvSpecLearnMon).MatchesRestrictedString().WithErrorCode(RuleNames.FD_ProvSpecLearnMon_AP);
        }
    }
}
