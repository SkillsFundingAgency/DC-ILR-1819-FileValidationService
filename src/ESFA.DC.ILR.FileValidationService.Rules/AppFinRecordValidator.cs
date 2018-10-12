using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class AppFinRecordValidator : AbstractValidator<ILooseAppFinRecord>
    {
        public AppFinRecordValidator()
        {
            RuleFor(afr => afr.AFinType).MatchesRestrictedString().WithErrorCode(RuleNames.FD_AFinType_AP);
        }
    }
}
