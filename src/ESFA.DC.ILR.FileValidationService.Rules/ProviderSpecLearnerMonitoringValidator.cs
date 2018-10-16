﻿using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class ProviderSpecLearnerMonitoringValidator : AbstractValidator<ILooseProviderSpecLearnerMonitoring>
    {
        public ProviderSpecLearnerMonitoringValidator()
        {
            RegexRules();
            MandatoryAttributeRules();
        }

        private void RegexRules()
        {
            RuleSet(RuleSetNames.Regex, () =>
            {
                RuleFor(m => m.ProvSpecLearnMonOccur).MatchesRestrictedString().WithErrorCode(RuleNames.FD_ProvSpecLearnMonOccur_AP);
                RuleFor(m => m.ProvSpecLearnMon).MatchesRestrictedString().WithErrorCode(RuleNames.FD_ProvSpecLearnMon_AP);
            });
        }

        private void MandatoryAttributeRules()
        {
            RuleSet(RuleSetNames.MandatoryAttributes, () =>
            {
                RuleFor(m => m.ProvSpecLearnMonOccur).NotNull().WithErrorCode(RuleNames.FD_ProvSpecLearnMonOccur_MA);
                RuleFor(m => m.ProvSpecLearnMon).NotNull().WithErrorCode(RuleNames.FD_ProvSpecLearnMon_MA);
            });
        }
    }
}
