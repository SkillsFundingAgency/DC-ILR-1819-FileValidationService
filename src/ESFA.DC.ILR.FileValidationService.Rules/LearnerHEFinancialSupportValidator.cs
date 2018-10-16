using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearnerHEFinancialSupportValidator : AbstractValidator<ILooseLearnerHEFinancialSupport>
    {
        public LearnerHEFinancialSupportValidator()
        {
            MandatoryAttributeRules();
        }

        private void MandatoryAttributeRules()
        {
            RuleSet(RuleSetNames.MandatoryAttributes, () =>
            {
                RuleFor(fs => fs.FINTYPENullable).NotNull().WithErrorCode(RuleNames.FD_FINTYPE_MA);
                RuleFor(fs => fs.FINAMOUNTNullable).NotNull().WithErrorCode(RuleNames.FD_FINAMOUNT_MA);
            });
        }
    }
}
