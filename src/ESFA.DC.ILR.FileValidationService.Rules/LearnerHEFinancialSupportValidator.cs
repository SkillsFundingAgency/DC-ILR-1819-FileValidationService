using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearnerHEFinancialSupportValidator : AbstractValidator<ILooseLearnerHEFinancialSupport>
    {
        public LearnerHEFinancialSupportValidator()
        {
            MandatoryAttributeRules();
            LengthRules();
        }

        private void MandatoryAttributeRules()
        {
            RuleSet(RuleSetNames.MandatoryAttributes, () =>
            {
                RuleFor(fs => fs.FINTYPENullable).NotNull().WithErrorCode(RuleNames.FD_FINTYPE_MA);
                RuleFor(fs => fs.FINAMOUNTNullable).NotNull().WithErrorCode(RuleNames.FD_FINAMOUNT_MA);
            });
        }

        private void LengthRules()
        {
            RuleSet(RuleSetNames.Length, () =>
            {
                RuleFor(fs => fs.FINTYPENullable).Length(1, 1).WithErrorCode(RuleNames.FD_FINTYPE_AL).WithLengthState(PropertyNames.FINTYPE);
                RuleFor(fs => fs.FINAMOUNTNullable).Length(1, 6).WithErrorCode(RuleNames.FD_FINAMOUNT_AL).WithLengthState(PropertyNames.FINAMOUNT);
            });
        }
    }
}
