using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearnerHEValidator : AbstractValidator<ILooseLearnerHE>
    {
        public LearnerHEValidator(IValidator<ILooseLearnerHEFinancialSupport> learnerHEFinancialSupportValidator)
        {
            RegexRules();

            RuleForEach(lhe => lhe.LearnerHEFinancialSupports).SetValidator(learnerHEFinancialSupportValidator);
        }

        private void RegexRules()
        {
            RuleSet(RuleSetNames.Regex, () =>
            {
                RuleFor(lhe => lhe.UCASPERID).MatchesRegex(Regexes.UcasPerId).WithErrorCode(RuleNames.FD_UCASPERID_AP);
            });
        }
    }
}
