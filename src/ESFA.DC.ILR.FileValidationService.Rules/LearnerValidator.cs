using ESFA.DC.ILR.FileValidationService.Rules.Abstract;
using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;
using RuleNames = ESFA.DC.ILR.FileValidationService.Rules.Constants.RuleNames;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearnerValidator : AbstractFileValidationValidator<ILooseLearner>
    {
        public LearnerValidator(
            IValidator<ILooseContactPreference> contactPreferenceValidator,
            IValidator<ILooseLearnerFAM> learnerFamValidator,
            IValidator<ILooseProviderSpecLearnerMonitoring> providerSpecLearnerMonitoringValidator,
            IValidator<ILooseLearnerEmploymentStatus> learnerEmploymentStatusValidator,
            IValidator<ILooseLearnerHE> learnerHeValidator,
            IValidator<ILooseLLDDAndHealthProblem> llddAndHealthProblemValidator)
        {
            RuleForEach(l => l.ContactPreferences).SetValidator(contactPreferenceValidator);
            RuleForEach(l => l.LearnerFAMs).SetValidator(learnerFamValidator);
            RuleForEach(l => l.ProviderSpecLearnerMonitorings).SetValidator(providerSpecLearnerMonitoringValidator);
            RuleForEach(l => l.LearnerEmploymentStatuses).SetValidator(learnerEmploymentStatusValidator);
            RuleForEach(l => l.LearnerHEs).SetValidator(learnerHeValidator);
            RuleForEach(l => l.LLDDAndHealthProblems).SetValidator(llddAndHealthProblemValidator);
        }

        public override void RegexRules()
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
        }

        public override void MandatoryAttributeRules()
        {
            RuleFor(l => l.LearnRefNumber).NotNull().WithErrorCode(RuleNames.FD_LearnRefNumber_MA);
            RuleFor(l => l.ULNNullable).NotNull().WithErrorCode(RuleNames.FD_ULN_MA);
            RuleFor(l => l.EthnicityNullable).NotNull().WithErrorCode(RuleNames.FD_Ethnicity_MA);
            RuleFor(l => l.Sex).NotNull().WithErrorCode(RuleNames.FD_Sex_MA);
            RuleFor(l => l.LLDDHealthProbNullable).NotNull().WithErrorCode(RuleNames.FD_LLDDHealthProb_MA);
            RuleFor(l => l.PostcodePrior).NotNull().WithErrorCode(RuleNames.FD_PostcodePrior_MA);
            RuleFor(l => l.Postcode).NotNull().WithErrorCode(RuleNames.FD_Postcode_MA);
        }

        public override void LengthRules()
        {
            RuleFor(l => l.LearnRefNumber).LengthTrim(1, 12).WithLengthError(RuleNames.FD_LearnRefNumber_AL);
            RuleFor(l => l.PrevLearnRefNumber).LengthTrim(1, 12).WithLengthError(RuleNames.FD_PrevLearnRefNumber_AL);
            RuleFor(l => l.PrevUKPRNNullable).Length(1, 8).WithLengthError(RuleNames.FD_PrevUKPRN_AL);
            RuleFor(l => l.PMUKPRNNullable).Length(1, 8).WithLengthError(RuleNames.FD_PMUKPRN_AL);
            RuleFor(l => l.ULNNullable).Length(1, 10).WithLengthError(RuleNames.FD_ULN_AL);
            RuleFor(l => l.FamilyName).LengthTrim(1, 100).WithLengthError(RuleNames.FD_FamilyName_AL);
            RuleFor(l => l.GivenNames).LengthTrim(1, 100).WithLengthError(RuleNames.FD_GivenNames_AL);
            RuleFor(l => l.EthnicityNullable).Length(1, 2).WithLengthError(RuleNames.FD_Ethnicity_AL);
            RuleFor(l => l.Sex).LengthTrim(1, 1).WithLengthError(RuleNames.FD_Sex_AL);
            RuleFor(l => l.LLDDHealthProbNullable).Length(1, 1).WithLengthError(RuleNames.FD_LLDDHealthProb_AL);
            RuleFor(l => l.NINumber).LengthTrim(1, 9).WithLengthError(RuleNames.FD_NINumber_AL);
            RuleFor(l => l.PriorAttainNullable).Length(1, 2).WithLengthError(RuleNames.FD_PriorAttain_AL);
            RuleFor(l => l.AccomNullable).Length(1, 1).WithLengthError(RuleNames.FD_Accom_AL);
            RuleFor(l => l.ALSCostNullable).Length(1, 6).WithLengthError(RuleNames.FD_ALSCost_AL);
            RuleFor(l => l.PlanLearnHoursNullable).Length(1, 4).WithLengthError(RuleNames.FD_PlanLearnHours_AL);
            RuleFor(l => l.PlanEEPHoursNullable).Length(1, 4).WithLengthError(RuleNames.FD_PlanEEPHours_AL);
            RuleFor(l => l.MathGrade).LengthTrim(1, 4).WithLengthError(RuleNames.FD_MathGrade_AL);
            RuleFor(l => l.EngGrade).LengthTrim(1, 4).WithLengthError(RuleNames.FD_EngGrade_AL);
            RuleFor(l => l.PostcodePrior).LengthTrim(1, 8).WithLengthError(RuleNames.FD_PostcodePrior_AL);
            RuleFor(l => l.Postcode).LengthTrim(1, 8).WithLengthError(RuleNames.FD_Postcode_AL);
            RuleFor(l => l.CampId).LengthTrim(0, 8).WithLengthError(RuleNames.FD_CampId_AL);
            RuleFor(l => l.OTJHoursNullable).Length(0, 4).WithLengthError(RuleNames.FD_OTJHours_AL);
            RuleFor(l => l.AddLine1).LengthTrim(1, 50).WithLengthError(RuleNames.FD_AddLine1_AL);
            RuleFor(l => l.AddLine2).LengthTrim(1, 50).WithLengthError(RuleNames.FD_AddLine2_AL);
            RuleFor(l => l.AddLine3).LengthTrim(1, 50).WithLengthError(RuleNames.FD_AddLine3_AL);
            RuleFor(l => l.AddLine4).LengthTrim(1, 50).WithLengthError(RuleNames.FD_AddLine4_AL);
            RuleFor(l => l.TelNo).LengthTrim(1, 18).WithLengthError(RuleNames.FD_TelNo_AL);
            RuleFor(l => l.Email).LengthTrim(1, 100).WithLengthError(RuleNames.FD_Email_AL);
        }

        public override void RangeRules()
        {
            RuleFor(l => l.OTJHoursNullable).InclusiveBetween(0, 9999).WithRangeError(RuleNames.FD_OTJHours_AR);
            RuleFor(l => l.PrevUKPRNNullable).InclusiveBetween(10000000, 99999999).WithRangeError(RuleNames.FD_PrevUKPRN_AR);
            RuleFor(l => l.PMUKPRNNullable).InclusiveBetween(10000000, 99999999).WithRangeError(RuleNames.FD_PMUKPRN_AR);
            RuleFor(l => l.ULNNullable).InclusiveBetween(1000000000, 9999999999).WithRangeError(RuleNames.FD_ULN_AR);
            RuleFor(l => l.ALSCostNullable).InclusiveBetween(0, 999999).WithRangeError(RuleNames.FD_ALSCost_AR);
            RuleFor(l => l.PlanLearnHoursNullable).InclusiveBetween(0, 9999).WithRangeError(RuleNames.FD_PlanLearnHours_AR);
            RuleFor(l => l.PlanEEPHoursNullable).InclusiveBetween(0, 9999).WithRangeError(RuleNames.FD_PlanEEPHours_AR);
        }

        public override void EntityOccurenceRules()
        {
            RuleFor(l => l.ContactPreferences).CountLessThanOrEqualTo(5).WithEntityOccurrenceError(RuleNames.FD_ContactPreference_EO);
            RuleFor(l => l.LLDDAndHealthProblems).CountLessThanOrEqualTo(22).WithEntityOccurrenceError(RuleNames.FD_LLDDandHealthProblem_EO);
            RuleFor(l => l.LearnerFAMs).CountLessThanOrEqualTo(17).WithEntityOccurrenceError(RuleNames.FD_LearnerFAM_EO);
            RuleFor(l => l.ProviderSpecLearnerMonitorings).CountLessThanOrEqualTo(2).WithEntityOccurrenceError(RuleNames.FD_ProviderSpecLearnerMonitoring_EO);
            RuleFor(l => l.LearnerHEs).CountLessThanOrEqualTo(1).WithEntityOccurrenceError(RuleNames.FD_LearnerHE_EO);
            RuleFor(l => l.LearningDeliveries).CountGreaterThanOrEqualTo(1).WithEntityOccurrenceError(RuleNames.FD_LearningDelivery_EO);

        }
    }
}
