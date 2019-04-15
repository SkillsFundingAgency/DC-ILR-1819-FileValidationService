using ESFA.DC.ILR.FileValidationService.Rules.Abstract;
using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearnerDestinationAndProgressionValidator : AbstractFileValidationValidator<ILooseLearnerDestinationAndProgression>
    {
        public LearnerDestinationAndProgressionValidator(IValidator<ILooseDPOutcome> dpOutcomeValidator)
        {
            RuleForEach(ldp => ldp.DPOutcomes).SetValidator(dpOutcomeValidator);
        }

        public override void RegexRules()
        {
            RuleFor(ldp => ldp.LearnRefNumber).MatchesRegex(Regexes.LearnRefNumber).WithErrorCode(RuleNames.FD_DP_LearnRefNumber_AP);
        }

        public override void MandatoryAttributeRules()
        {
            RuleFor(ldp => ldp.LearnRefNumber).NotNull().WithErrorCode(RuleNames.FD_DP_LearnRefNumber_MA);
            RuleFor(ldp => ldp.ULNNullable).NotNull().WithErrorCode(RuleNames.FD_DP_ULN_MA);
        }

        public override void LengthRules()
        {
            RuleFor(ldp => ldp.LearnRefNumber).LengthTrim(1, 12).WithLengthError(RuleNames.FD_DP_LearnRefNumber_AL);
            RuleFor(ldp => ldp.ULNNullable).Length(1, 10).WithLengthError(RuleNames.FD_DP_ULN_AL);
        }

        public override void RangeRules()
        {
            RuleFor(ldp => ldp.ULNNullable).InclusiveBetween(1000000000, 9999999999).WithRangeError(RuleNames.FD_DP_ULN_AR);
        }

        public override void EntityOccurenceRules()
        {
            RuleFor(ldp => ldp.DPOutcomes).CountGreaterThanOrEqualTo(1).WithEntityOccurrenceError(RuleNames.FD_DP_DPOutcome_EO);
        }
    }
}
