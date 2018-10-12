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
            RuleFor(ldp => ldp.LearnRefNumber).MatchesRegex(Regexes.LearnRefNumber).WithErrorCode(RuleNames.FD_DP_LearnRefNumber_AP);

            RuleForEach(ldp => ldp.DPOutcomes).SetValidator(dpOutcomeValidator);
        }
    }
}
