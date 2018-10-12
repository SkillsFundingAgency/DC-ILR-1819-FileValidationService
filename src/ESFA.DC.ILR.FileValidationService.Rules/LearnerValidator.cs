using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearnerValidator : AbstractValidator<ILooseLearner>
    {
        public LearnerValidator(
            IValidator<ILooseContactPreference> contactPreferenceValidator,
            IValidator<ILooseLearnerFAM> learnerFamValidator,
            IValidator<ILooseProviderSpecLearnerMonitoring> providerSpecLearnerMonitoringValidator,
            IValidator<ILooseLearnerEmploymentStatus> learnerEmploymentStatusValidator,
            IValidator<ILooseLearnerHE> learnerHeValidator)
        {
            RuleFor(l => l.LearnRefNumber).MatchesRegex(Regexes.LearnRefNumber).WithErrorCode(RuleNames.FD_LearnRefNumber_AP);
            RuleFor(l => l.PrevLearnRefNumber).MatchesRegex(Regexes.LearnRefNumber).WithErrorCode(RuleNames.FD_PrevLearnRefNumber_AP);
            RuleFor(l => l.FamilyName).MatchesRegex(Regexes.Name).WithErrorCode(RuleNames.FD_FamilyName_AP);
            RuleFor(l => l.GivenNames).MatchesRegex(Regexes.Name).WithErrorCode(RuleNames.FD_GivenNames_AP);
            RuleFor(l => l.Sex).MatchesRestrictedString().WithErrorCode(RuleNames.FD_Sex_AP);
            RuleFor(l => l.NINumber).MatchesRestrictedString().WithErrorCode(RuleNames.FD_NINumber_AP);
            RuleFor(l => l.MathGrade).MatchesRestrictedString().WithErrorCode(RuleNames.FD_MathGrade_AP);
            RuleFor(l => l.EngGrade).MatchesRestrictedString().WithErrorCode(RuleNames.FD_EngGrade_AP);
            RuleFor(l => l.PostcodePrior).MatchesRestrictedString().WithErrorCode(RuleNames.FD_PostcodePrior_AP);
            RuleFor(l => l.Postcode).MatchesRestrictedString().WithErrorCode(RuleNames.FD_Postcode_AP);
            RuleFor(l => l.AddLine1).MatchesRegex(Regexes.Address).WithErrorCode(RuleNames.FD_AddLine1_AP);
            RuleFor(l => l.AddLine2).MatchesRegex(Regexes.Address).WithErrorCode(RuleNames.FD_AddLine2_AP);
            RuleFor(l => l.AddLine3).MatchesRegex(Regexes.Address).WithErrorCode(RuleNames.FD_AddLine3_AP);
            RuleFor(l => l.AddLine4).MatchesRegex(Regexes.Address).WithErrorCode(RuleNames.FD_AddLine4_AP);
            RuleFor(l => l.TelNo).MatchesRegex(Regexes.TelephoneNumber).WithErrorCode(RuleNames.FD_TelNo_AP);
            RuleFor(l => l.Email).MatchesRegex(Regexes.EmailAddress).WithErrorCode(RuleNames.FD_Email_AP);
            RuleFor(l => l.CampId).MatchesRegex(Regexes.CampId).WithErrorCode(RuleNames.FD_CampId_AP);

            RuleForEach(l => l.ContactPreferences).SetValidator(contactPreferenceValidator);
            RuleForEach(l => l.LearnerFAMs).SetValidator(learnerFamValidator);
            RuleForEach(l => l.ProviderSpecLearnerMonitorings).SetValidator(providerSpecLearnerMonitoringValidator);
            RuleForEach(l => l.LearnerEmploymentStatuses).SetValidator(learnerEmploymentStatusValidator);
            RuleForEach(l => l.LearnerHEs).SetValidator(learnerHeValidator);
        }
    }
}
