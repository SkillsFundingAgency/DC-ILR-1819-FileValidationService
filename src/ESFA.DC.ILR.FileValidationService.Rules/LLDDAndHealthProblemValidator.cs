using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LLDDAndHealthProblemValidator : AbstractValidator<ILooseLLDDAndHealthProblem>
    {
        public LLDDAndHealthProblemValidator()
        {
            MandatoryRules();
        }

        private void MandatoryRules()
        {
            RuleSet(RuleSetNames.MandatoryAttributes, () =>
            {
                RuleFor(p => p.LLDDCatNullable).NotNull().WithErrorCode(RuleNames.FD_LLDDCat_MA);
            });
        }
    }
}
