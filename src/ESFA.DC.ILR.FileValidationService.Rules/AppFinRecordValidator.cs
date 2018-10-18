using System;
using ESFA.DC.ILR.FileValidationService.Rules.Abstract;
using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class AppFinRecordValidator : AbstractFileValidationValidator<ILooseAppFinRecord>
    {
        public override void RegexRules()
        { 
            RuleFor(afr => afr.AFinType).MatchesRestrictedString().WithErrorCode(RuleNames.FD_AFinType_AP);
        }

        public override void MandatoryAttributeRules()
        {
            RuleFor(afr => afr.AFinType).NotNull().WithErrorCode(RuleNames.FD_AFinType_MA);
            RuleFor(afr => afr.AFinCodeNullable).NotNull().WithErrorCode(RuleNames.FD_AFinCode_MA);
            RuleFor(afr => afr.AFinDateNullable).NotNull().WithErrorCode(RuleNames.FD_AFinDate_MA);
            RuleFor(afr => afr.AFinAmountNullable).NotNull().WithErrorCode(RuleNames.FD_AFinAmount_MA);
        }

        public override void LengthRules()
        {
            RuleFor(afr => afr.AFinType).Length(1, 3).WithLengthError(RuleNames.FD_AFinType_AL);
            RuleFor(afr => afr.AFinCodeNullable).Length(1, 2).WithLengthError(RuleNames.FD_AFinCode_AL);
            RuleFor(afr => afr.AFinAmountNullable).Length(1, 6).WithLengthError(RuleNames.FD_AFinAmount_AL);
        }
    }
}
