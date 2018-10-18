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
            IValidator<ILooseLearnerHE> learnerHeValidator,
            IValidator<ILooseLLDDAndHealthProblem> llddAndHealthProblemValidator)
        {
            RegexRules();
            MandatoryAttributeRules();
            LengthRules();

            RuleForEach(l => l.ContactPreferences).SetValidator(contactPreferenceValidator);
            RuleForEach(l => l.LearnerFAMs).SetValidator(learnerFamValidator);
            RuleForEach(l => l.ProviderSpecLearnerMonitorings).SetValidator(providerSpecLearnerMonitoringValidator);
            RuleForEach(l => l.LearnerEmploymentStatuses).SetValidator(learnerEmploymentStatusValidator);
            RuleForEach(l => l.LearnerHEs).SetValidator(learnerHeValidator);
            RuleForEach(l => l.LLDDAndHealthProblems).SetValidator(llddAndHealthProblemValidator);
        }

        private void RegexRules()
        {
            RuleSet(RuleSetNames.Regex, () =>
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
            });
        }

        private void MandatoryAttributeRules()
        {
            RuleSet(RuleSetNames.MandatoryAttributes, () =>
            {
                RuleFor(l => l.LearnRefNumber).NotNull().WithErrorCode(RuleNames.FD_LearnRefNumber_MA);
                RuleFor(l => l.ULNNullable).NotNull().WithErrorCode(RuleNames.FD_ULN_MA);
                RuleFor(l => l.EthnicityNullable).NotNull().WithErrorCode(RuleNames.FD_Ethnicity_MA);
                RuleFor(l => l.Sex).NotNull().WithErrorCode(RuleNames.FD_Sex_MA);
                RuleFor(l => l.LLDDHealthProbNullable).NotNull().WithErrorCode(RuleNames.FD_LLDDHealthProb_MA);
                RuleFor(l => l.PostcodePrior).NotNull().WithErrorCode(RuleNames.FD_PostcodePrior_MA);
                RuleFor(l => l.Postcode).NotNull().WithErrorCode(RuleNames.FD_Postcode_MA);
            });
        }

        private void LengthRules()
        {
            RuleSet(RuleSetNames.Length, () =>
            { 
                RuleFor(l => l.LearnRefNumber).Length(1, 12).WithLengthError(RuleNames.FD_LearnRefNumber_AL);
                RuleFor(l => l.PrevLearnRefNumber).Length(1, 12).WithLengthError(RuleNames.FD_PrevLearnRefNumber_AL);
                RuleFor(l => l.PrevUKPRNNullable).Length(1, 8).WithLengthError(RuleNames.FD_PrevUKPRN_AL);
                RuleFor(l => l.PMUKPRNNullable).Length(1, 8).WithLengthError(RuleNames.FD_PMUKPRN_AL);
                RuleFor(l => l.ULNNullable).Length(1, 10).WithLengthError(RuleNames.FD_ULN_AL);
                RuleFor(l => l.FamilyName).Length(1, 100).WithLengthError(RuleNames.FD_FamilyName_AL);
                RuleFor(l => l.GivenNames).Length(1, 100).WithLengthError(RuleNames.FD_GivenNames_AL);
                RuleFor(l => l.EthnicityNullable).Length(1, 2).WithLengthError(RuleNames.FD_Ethnicity_AL);
                RuleFor(l => l.Sex).Length(1, 1).WithLengthError(RuleNames.FD_Sex_AL);
                RuleFor(l => l.LLDDHealthProbNullable).Length(1, 1).WithLengthError(RuleNames.FD_LLDDHealthProb_AL);
                RuleFor(l => l.NINumber).Length(1, 9).WithLengthError(RuleNames.FD_NINumber_AL);
                RuleFor(l => l.PriorAttainNullable).Length(1, 2).WithLengthError(RuleNames.FD_PriorAttain_AL);
                RuleFor(l => l.AccomNullable).Length(1, 1).WithLengthError(RuleNames.FD_Accom_AL);
                RuleFor(l => l.ALSCostNullable).Length(1, 6).WithLengthError(RuleNames.FD_ALSCost_AL);
                RuleFor(l => l.PlanLearnHoursNullable).Length(1, 4).WithLengthError(RuleNames.FD_PlanLearnHours_AL);
                RuleFor(l => l.PlanEEPHoursNullable).Length(1, 4).WithLengthError(RuleNames.FD_PlanEEPHours_AL);
                RuleFor(l => l.MathGrade).Length(1, 4).WithLengthError(RuleNames.FD_MathGrade_AL);
                RuleFor(l => l.EngGrade).Length(1, 4).WithLengthError(RuleNames.FD_EngGrade_AL);
                RuleFor(l => l.PostcodePrior).Length(1, 8).WithLengthError(RuleNames.FD_PostcodePrior_AL);
                RuleFor(l => l.Postcode).Length(1, 8).WithLengthError(RuleNames.FD_Postcode_AL);
                RuleFor(l => l.CampId).Length(0, 8).WithLengthError(RuleNames.FD_CampId_AL);
                RuleFor(l => l.OTJHoursNullable).Length(0, 4).WithLengthError(RuleNames.FD_OTJHours_AL);
                RuleFor(l => l.AddLine1).Length(1, 50).WithLengthError(RuleNames.FD_AddLine1_AL);
                RuleFor(l => l.AddLine2).Length(1, 50).WithLengthError(RuleNames.FD_AddLine2_AL);
                RuleFor(l => l.AddLine3).Length(1, 50).WithLengthError(RuleNames.FD_AddLine3_AL);
                RuleFor(l => l.AddLine4).Length(1, 50).WithLengthError(RuleNames.FD_AddLine4_AL);
                RuleFor(l => l.TelNo).Length(1, 18).WithLengthError(RuleNames.FD_TelNo_AL);
                RuleFor(l => l.Email).Length(1, 100).WithLengthError(RuleNames.FD_Email_AL);
            });
        }
    }
}
