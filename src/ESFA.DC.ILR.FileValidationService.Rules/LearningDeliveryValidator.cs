using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearningDeliveryValidator : AbstractValidator<ILooseLearningDelivery>
    {
        public LearningDeliveryValidator(IValidator<ILooseLearningDeliveryFAM> learningDeliveryValidator)
        {
            RuleFor(ld => ld.LearnAimRef).MatchesRestrictedString().WithErrorCode(RuleNames.FD_LearnAimRef_AP);
            RuleFor(ld => ld.DelLocPostCode).MatchesRestrictedString().WithErrorCode(RuleNames.FD_DelLocPostCode_AP);
            RuleFor(ld => ld.ConRefNumber).MatchesRestrictedString().WithErrorCode(RuleNames.FD_ConRefNumber_AP);
            RuleFor(ld => ld.EPAOrgID).MatchesRegex(Regexes.EpaOrgId).WithErrorCode(RuleNames.FD_EPAOrgID_AP);
            RuleFor(ld => ld.OutGrade).MatchesRestrictedString().WithErrorCode(RuleNames.FD_OutGrade_AP);
            RuleFor(ld => ld.SWSupAimId).MatchesRestrictedString().WithErrorCode(RuleNames.FD_SWSupAimId_AP);

            RuleForEach(ld => ld.LearningDeliveryFAMs).SetValidator(learningDeliveryValidator);
        }
    }
}
