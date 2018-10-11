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
            RuleFor(dpo => dpo.OutType).MatchesRestrictedString().WithErrorCode(RuleNames.FD_DP_OutType_AP);
        }
    }
}
