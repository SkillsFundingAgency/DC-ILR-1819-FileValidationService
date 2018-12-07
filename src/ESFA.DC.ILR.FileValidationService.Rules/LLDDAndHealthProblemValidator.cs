using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LLDDAndHealthProblemValidator : AbstractValidator<ILooseLLDDAndHealthProblem>
    {
        public LLDDAndHealthProblemValidator()
        {
            MandatoryRules();
            LengthRules();
        }

        private void MandatoryRules()
        {
            RuleSet(RuleSetNames.MandatoryAttributes, () =>
            {
                RuleFor(p => p.LLDDCatNullable).NotNull().WithErrorCode(RuleNames.FD_LLDDCat_MA);
            });
        }

        private void LengthRules()
        {
            RuleSet(RuleSetNames.Length, () =>
            {
                RuleFor(p => p.LLDDCatNullable).Length(1, 2).WithLengthError(RuleNames.FD_LLDDCat_AL);
                RuleFor(p => p.PrimaryLLDDNullable).Length(1, 1).WithLengthError(RuleNames.FD_PrimaryLLDD_AL);
            });
        }
    }
}
