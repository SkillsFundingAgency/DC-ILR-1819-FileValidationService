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
            LengthRules();

            RuleForEach(lhe => lhe.LearnerHEFinancialSupports).SetValidator(learnerHEFinancialSupportValidator);
        }

        private void RegexRules()
        {
            RuleSet(RuleSetNames.Regex, () =>
            {
                RuleFor(lhe => lhe.UCASPERID).MatchesRegex(Regexes.UcasPerId).WithErrorCode(RuleNames.FD_UCASPERID_AP);
            });
        }

        private void LengthRules()
        {
            RuleSet(RuleSetNames.Length, () =>
                {
                    RuleFor(lhe => lhe.UCASPERID).Length(1, 10).WithErrorCode(RuleNames.FD_UCASPERID_AL).WithLengthState(PropertyNames.UCASPERID);
                    RuleFor(lhe => lhe.TTACCOMNullable).Length(1, 1).WithErrorCode(RuleNames.FD_TTACCOM_AL).WithLengthState(PropertyNames.TTACCOM);
                });
        }
    }
}
