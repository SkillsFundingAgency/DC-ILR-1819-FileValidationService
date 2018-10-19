using System.Data;
using System.Data.Common;
using ESFA.DC.ILR.FileValidationService.Rules.Abstract;
using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class DPOutcomeValidator : AbstractFileValidationValidator<ILooseDPOutcome>
    {
        public override void RegexRules()
        {
            RuleFor(dpo => dpo.OutType).MatchesRestrictedString().WithErrorCode(RuleNames.FD_DP_OutType_AP);
        }

        public override void MandatoryAttributeRules()
        {
            RuleFor(dpo => dpo.OutType).NotNull().WithErrorCode(RuleNames.FD_DP_OutType_MA);
            RuleFor(dpo => dpo.OutCodeNullable).NotNull().WithErrorCode(RuleNames.FD_DP_OutCode_MA);
            RuleFor(dpo => dpo.OutStartDateNullable).NotNull().WithErrorCode(RuleNames.FD_DP_OutStartDate_MA);
            RuleFor(dpo => dpo.OutCollDateNullable).NotNull().WithErrorCode(RuleNames.FD_DP_OutCollDate_MA);
        }

        public override void LengthRules()
        {
            RuleFor(dpo => dpo.OutType).Length(1, 3).WithLengthError(RuleNames.FD_DP_OutType_AL);
            RuleFor(dpo => dpo.OutCodeNullable).Length(1, 3).WithLengthError(RuleNames.FD_DP_OutCode_AL);
        }
    }
}
