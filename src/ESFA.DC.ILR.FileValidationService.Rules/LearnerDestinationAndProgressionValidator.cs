using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearnerDestinationAndProgressionValidator : AbstractValidator<ILooseLearnerDestinationAndProgression>
    {
        public LearnerDestinationAndProgressionValidator(IValidator<ILooseDPOutcome> dpOutcomeValidator)
        {
            RegexRules();
            MandatoryAttributeRules();

            RuleForEach(ldp => ldp.DPOutcomes).SetValidator(dpOutcomeValidator);
        }

        public void RegexRules()
        {
            RuleSet(RuleSetNames.Regex, () =>
            {
                RuleFor(ldp => ldp.LearnRefNumber).MatchesRegex(Regexes.LearnRefNumber).WithErrorCode(RuleNames.FD_DP_LearnRefNumber_AP);
            });
        }

        public void MandatoryAttributeRules()
        {
            RuleSet(RuleSetNames.MandatoryAttributes, () =>
            {
                RuleFor(ldp => ldp.LearnRefNumber).NotNull().WithErrorCode(RuleNames.FD_DP_LearnRefNumber_MA);
                RuleFor(ldp => ldp.ULNNullable).NotNull().WithErrorCode(RuleNames.FD_DP_ULN_MA);
            });
            
        }
    }
}
