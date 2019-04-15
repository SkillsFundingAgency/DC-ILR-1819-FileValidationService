using ESFA.DC.ILR.FileValidationService.Rules.Abstract;
using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class ContactPreferenceValidator : AbstractFileValidationValidator<ILooseContactPreference>
    {
        public override void RegexRules()
        {
            RuleFor(cp => cp.ContPrefType).MatchesRestrictedString().WithErrorCode(RuleNames.FD_ContPrefType_AP);
        }

        public override void MandatoryAttributeRules()
        {
            RuleFor(cp => cp.ContPrefType).NotNull().WithErrorCode(RuleNames.FD_ContPrefType_MA);
            RuleFor(cp => cp.ContPrefCodeNullable).NotNull().WithErrorCode(RuleNames.FD_ContPrefCode_MA);
        }

        public override void LengthRules()
        {
            RuleFor(cp => cp.ContPrefType).LengthTrim(1, 3).WithLengthError(RuleNames.FD_ContPrefType_AL);
            RuleFor(cp => cp.ContPrefCodeNullable).Length(1, 1).WithLengthError(RuleNames.FD_ContPrefCode_AL);
        }
    }
}
