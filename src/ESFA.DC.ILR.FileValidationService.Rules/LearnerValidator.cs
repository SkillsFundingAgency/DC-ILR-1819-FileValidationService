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
                RuleFor(l => l.LearnRefNumber).Length(1, 12).WithErrorCode(RuleNames.FD_LearnRefNumber_AL).WithLengthState(PropertyNames.LearnRefNumber);
                RuleFor(l => l.PrevLearnRefNumber).Length(1, 12).WithErrorCode(RuleNames.FD_PrevLearnRefNumber_AL).WithLengthState(PropertyNames.PrevLearnRefNumber);
                RuleFor(l => l.PrevUKPRNNullable).Length(1, 8).WithErrorCode(RuleNames.FD_PrevUKPRN_AL).WithLengthState(PropertyNames.PrevUKPRN);
                RuleFor(l => l.PMUKPRNNullable).Length(1, 8).WithErrorCode(RuleNames.FD_PMUKPRN_AL).WithLengthState(PropertyNames.PMUKPRN);
                RuleFor(l => l.ULNNullable).Length(1, 10).WithErrorCode(RuleNames.FD_ULN_AL).WithLengthState(PropertyNames.ULN);
                RuleFor(l => l.FamilyName).Length(1, 100).WithErrorCode(RuleNames.FD_FamilyName_AL).WithLengthState(PropertyNames.FamilyName);
                RuleFor(l => l.GivenNames).Length(1, 100).WithErrorCode(RuleNames.FD_GivenNames_AL).WithLengthState(PropertyNames.GivenNames);
                RuleFor(l => l.EthnicityNullable).Length(1, 2).WithErrorCode(RuleNames.FD_Ethnicity_AL).WithLengthState(PropertyNames.Ethnicity);
                RuleFor(l => l.Sex).Length(1, 1).WithErrorCode(RuleNames.FD_Sex_AL).WithLengthState(PropertyNames.Sex);
                RuleFor(l => l.LLDDHealthProbNullable).Length(1, 1).WithErrorCode(RuleNames.FD_LLDDHealthProb_AL).WithLengthState(PropertyNames.LLDDHealthProb);
                RuleFor(l => l.NINumber).Length(1, 9).WithErrorCode(RuleNames.FD_NINumber_AL).WithLengthState(PropertyNames.NINumber);
                RuleFor(l => l.PriorAttainNullable).Length(1, 2).WithErrorCode(RuleNames.FD_PriorAttain_AL).WithLengthState(PropertyNames.PriorAttain);
                RuleFor(l => l.AccomNullable).Length(1, 1).WithErrorCode(RuleNames.FD_Accom_AL).WithLengthState(PropertyNames.Accom);
                RuleFor(l => l.ALSCostNullable).Length(1, 6).WithErrorCode(RuleNames.FD_ALSCost_AL).WithLengthState(PropertyNames.ALSCost);
                RuleFor(l => l.PlanLearnHoursNullable).Length(1, 4).WithErrorCode(RuleNames.FD_PlanLearnHours_AL).WithLengthState(PropertyNames.PlanLearnHours);
                RuleFor(l => l.PlanEEPHoursNullable).Length(1, 4).WithErrorCode(RuleNames.FD_PlanEEPHours_AL).WithLengthState(PropertyNames.PlanEEPHours);
                RuleFor(l => l.MathGrade).Length(1, 4).WithErrorCode(RuleNames.FD_MathGrade_AL).WithLengthState(PropertyNames.MathGrade);
                RuleFor(l => l.EngGrade).Length(1, 4).WithErrorCode(RuleNames.FD_EngGrade_AL).WithLengthState(PropertyNames.EngGrade);
                RuleFor(l => l.PostcodePrior).Length(1, 8).WithErrorCode(RuleNames.FD_PostcodePrior_AL).WithLengthState(PropertyNames.PostcodePrior);
                RuleFor(l => l.Postcode).Length(1, 8).WithErrorCode(RuleNames.FD_Postcode_AL).WithLengthState(PropertyNames.Postcode);
                RuleFor(l => l.CampId).Length(0, 8).WithErrorCode(RuleNames.FD_CampId_AL).WithLengthState(PropertyNames.CampId);
                RuleFor(l => l.OTJHoursNullable).Length(0, 4).WithErrorCode(RuleNames.FD_OTJHours_AL).WithLengthState(PropertyNames.OTJHours);
                RuleFor(l => l.AddLine1).Length(1, 50).WithErrorCode(RuleNames.FD_AddLine1_AL).WithLengthState(PropertyNames.AddLine1);
                RuleFor(l => l.AddLine2).Length(1, 50).WithErrorCode(RuleNames.FD_AddLine2_AL).WithLengthState(PropertyNames.AddLine2);
                RuleFor(l => l.AddLine3).Length(1, 50).WithErrorCode(RuleNames.FD_AddLine3_AL).WithLengthState(PropertyNames.AddLine3);
                RuleFor(l => l.AddLine4).Length(1, 50).WithErrorCode(RuleNames.FD_AddLine4_AL).WithLengthState(PropertyNames.AddLine4);
                RuleFor(l => l.TelNo).Length(1, 18).WithErrorCode(RuleNames.FD_TelNo_AL).WithLengthState(PropertyNames.TelNo);
                RuleFor(l => l.Email).Length(1, 100).WithErrorCode(RuleNames.FD_Email_AL).WithLengthState(PropertyNames.Email);
            });
        }
    }
}
