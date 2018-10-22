using System;
using System.Collections.Generic;
using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;
using FluentValidation.TestHelper;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class LearnerValidatorTests : AbstractValidatorTests<ILooseLearner>
    {
        private static readonly IValidator<ILooseContactPreference> ContactPreferenceValidator = new Mock<IValidator<ILooseContactPreference>>().Object;
        private static readonly IValidator<ILooseLearnerFAM> LearnerFamValidator = new Mock<IValidator<ILooseLearnerFAM>>().Object;
        private static readonly IValidator<ILooseProviderSpecLearnerMonitoring> ProviderSpeclearnerMonitor = new Mock<IValidator<ILooseProviderSpecLearnerMonitoring>>().Object;
        private static readonly IValidator<ILooseLearnerEmploymentStatus> LearnerEmploymenStatusValidator = new Mock<IValidator<ILooseLearnerEmploymentStatus>>().Object;
        private static readonly IValidator<ILooseLearnerHE> LearnerHEValidator = new Mock<IValidator<ILooseLearnerHE>>().Object;
        private static readonly IValidator<ILooseLLDDAndHealthProblem> LLDDAndHealthProblemValidator = new Mock<IValidator<ILooseLLDDAndHealthProblem>>().Object;

        public LearnerValidatorTests()
            : base(
                new LearnerValidator(
                    ContactPreferenceValidator,
                    LearnerFamValidator,
                    ProviderSpeclearnerMonitor,
                    LearnerEmploymenStatusValidator,
                    LearnerHEValidator,
                    LLDDAndHealthProblemValidator))
        {
        }

        [Fact]
        public void FD_LearnRefNumber_AP()
        {
            TestRegexRuleFor(l => l.LearnRefNumber, "FD_LearnRefNumber_AP", "LearnRefNum", "!");
        }

        [Fact]
        public void FD_PrevLearnRefNumber_AP()
        {
            TestRegexRuleFor(l => l.PrevLearnRefNumber, "FD_PrevLearnRefNumber_AP", "LearnRefNum", "!");
        }

        [Fact]
        public void FD_FamilyName_AP()
        {
            TestRegexRuleFor(l => l.FamilyName, "FD_FamilyName_AP", "FamilyName", "");
        }

        [Fact]
        public void FD_GivenNames_AP()
        {
            TestRegexRuleFor(l => l.GivenNames, "FD_GivenNames_AP", "Given Names", "");
        }

        [Fact]
        public void FD_Sex_AP()
        {
            TestRegexRuleFor(l => l.Sex, "FD_Sex_AP", @"\", @"`");
        }

        [Fact]
        public void FD_NINumber_AP()
        {
            TestRegexRuleFor(l => l.NINumber, "FD_NINumber_AP", "NINumber", "`");
        }

        [Fact]
        public void FD_MathGrade_AP()
        {
            TestRegexRuleFor(l => l.MathGrade, "FD_MathGrade_AP", "A", "`");
        }

        [Fact]
        public void FD_EngGrade_AP()
        {
            TestRegexRuleFor(l => l.EngGrade, "FD_EngGrade_AP", "A", "`");
        }

        [Fact]
        public void FD_PostcodePrior_AP()
        {
            TestRegexRuleFor(l => l.PostcodePrior, "FD_PostcodePrior_AP", "A12 3BC", "`");
        }

        [Fact]
        public void FD_Postcode_AP()
        {
            TestRegexRuleFor(l => l.Postcode, "FD_Postcode_AP", "A12 3BC", "`");
        }

        [Fact]
        public void FD_AddLine1_AP()
        {
            TestRegexRuleFor(l => l.AddLine1, "FD_AddLine1_AP", "Address Value", "`");
        }

        [Fact]
        public void FD_AddLine2_AP()
        {
            TestRegexRuleFor(l => l.AddLine2, "FD_AddLine2_AP", "Address Value", "`");
        }

        [Fact]
        public void FD_AddLine3_AP()
        {
            TestRegexRuleFor(l => l.AddLine3, "FD_AddLine3_AP", "Address Value", "`");
        }

        [Fact]
        public void FD_AddLine4_AP()
        {
            TestRegexRuleFor(l => l.AddLine4, "FD_AddLine4_AP", "Address Value", "`");
        }

        [Fact]
        public void FD_TelNo_AP()
        {
            TestRegexRuleFor(l => l.TelNo, "FD_TelNo_AP", "012345678910", "ABC");
        }

        [Fact]
        public void FD_Email_AP()
        {
            TestRegexRuleFor(l => l.Email, "FD_Email_AP", "test@test.co.uk", "noAtSign.co.uk");
        }

        [Fact]
        public void FD_CampId_AP()
        {
            TestRegexRuleFor(l => l.CampId, "FD_CampId_AP", "Camp1234", "!");
        }

        [Fact]
        public void FD_LearnRefNumber_MA()
        {
            TestMandatoryStringAttributeRuleFor(l => l.LearnRefNumber, "FD_LearnRefNumber_MA");
        }

        [Fact]
        public void FD_ULN_MA()
        {
            TestMandatoryLongAttributeRuleFor(l => l.ULNNullable, "FD_ULN_MA");
        }

        [Fact]
        public void FD_Ethnicity_MA()
        {
            TestMandatoryLongAttributeRuleFor(l => l.EthnicityNullable, "FD_Ethnicity_MA"); 
        }

        [Fact]
        public void FD_Sex_MA()
        {
            TestMandatoryStringAttributeRuleFor(l => l.Sex, "FD_Sex_MA");
        }

        [Fact]
        public void FD_LLDDHealthProb_MA()
        {
            TestMandatoryLongAttributeRuleFor(l => l.LLDDHealthProbNullable, "FD_LLDDHealthProb_MA");
        }

        [Fact]
        public void FD_PostcodePrior_MA()
        {
            TestMandatoryStringAttributeRuleFor(l => l.PostcodePrior, "FD_PostcodePrior_MA");
        }

        [Fact]
        public void FD_Postcode_MA()
        {
            TestMandatoryStringAttributeRuleFor(l => l.Postcode, "FD_Postcode_MA");
        }

        [Fact]
        public void FD_LearnRefNumber_AL()
        {
            TestLengthStringRuleFor(l => l.LearnRefNumber, "FD_LearnRefNumber_AL", "LearnRefNumber", 1, 12);
        }

        [Fact]
        public void FD_PrevLearnRefNumber_AL()
        {
            TestLengthStringRuleFor(l => l.PrevLearnRefNumber, "FD_PrevLearnRefNumber_AL", "PrevLearnRefNumber", 1, 12);
        }

        [Fact]
        public void FD_PrevUKPRN_AL()
        {
            TestLengthLongRuleFor(l => l.PrevUKPRNNullable, "FD_PrevUKPRN_AL", "PrevUKPRN", 1, 8);
        }

        [Fact]
        public void FD_PMUKPRN_AL()
        {
            TestLengthLongRuleFor(l => l.PMUKPRNNullable, "FD_PMUKPRN_AL", "PMUKPRN", 1, 8);
        }

        [Fact]
        public void FD_ULN_AL()
        {
            TestLengthLongRuleFor(l => l.ULNNullable, "FD_ULN_AL", "ULN", 1, 10);
        }

        [Fact]
        public void FD_FamilyName_AL()
        {
            TestLengthStringRuleFor(l => l.FamilyName, "FD_FamilyName_AL", "FamilyName", 1, 100);
        }

        [Fact]
        public void FD_GivenNames_AL()
        {
            TestLengthStringRuleFor(l => l.GivenNames, "FD_GivenNames_AL", "GivenNames", 1, 100);
        }

        [Fact]
        public void FD_Ethnicity_AL()
        {
            TestLengthLongRuleFor(l => l.EthnicityNullable, "FD_Ethnicity_AL", "Ethnicity" , 1, 2);
        }

        [Fact]
        public void FD_Sex_AL()
        {
            TestLengthStringRuleFor(l => l.Sex, "FD_Sex_AL", "Sex", 1, 1);
        }

        [Fact]
        public void FD_LLDDHealthProb_AL()
        {
            TestLengthLongRuleFor(l => l.LLDDHealthProbNullable, "FD_LLDDHealthProb_AL", "LLDDHealthProb", 1, 1);
        }

        [Fact]
        public void FD_NINumber_AL()
        {
            TestLengthStringRuleFor(l => l.NINumber, "FD_NINumber_AL", "NINumber", 1, 9);
        }

        [Fact]
        public void FD_PriorAttain_AL()
        {
            TestLengthLongRuleFor(l => l.PriorAttainNullable, "FD_PriorAttain_AL", "PriorAttain", 1, 2);
        }

        [Fact]
        public void FD_Accom_AL()
        {
            TestLengthLongRuleFor(l => l.AccomNullable, "FD_Accom_AL", "Accom", 1, 1);
        }

        [Fact]
        public void FD_ALSCost_AL()
        {
            TestLengthLongRuleFor(l => l.ALSCostNullable, "FD_ALSCost_AL", "ALSCost", 1, 6);
        }

        [Fact]
        public void FD_PlanLearnHours_AL()
        {
            TestLengthLongRuleFor(l => l.PlanLearnHoursNullable, "FD_PlanLearnHours_AL", "PlanLearnHours", 1, 4);
        }

        [Fact]
        public void FD_PlanEEPHours_AL()
        {
            TestLengthLongRuleFor(l => l.PlanEEPHoursNullable, "FD_PlanEEPHours_AL", "PlanEEPHours", 1, 4);
        }

        [Fact]
        public void FD_MathGrade_AL()
        {
            TestLengthStringRuleFor(l => l.MathGrade, "FD_MathGrade_AL", "MathGrade", 1, 4);
        }

        [Fact]
        public void FD_EngGrade_AL()
        {
            TestLengthStringRuleFor(l => l.EngGrade, "FD_EngGrade_AL", "EngGrade", 1, 4);
        }

        [Fact]
        public void FD_PostcodePrior_AL()
        {
            TestLengthStringRuleFor(l => l.PostcodePrior, "FD_PostcodePrior_AL", "PostcodePrior", 1, 8);
        }

        [Fact]
        public void FD_Postcode_AL()
        {
            TestLengthStringRuleFor(l => l.Postcode, "FD_Postcode_AL", "Postcode", 1, 8);
        }

        [Fact]
        public void FD_CampId_AL()
        {
            TestLengthStringRuleFor(l => l.CampId, "FD_CampId_AL", "CampId", 0, 8);
        }

        [Fact]
        public void FD_OTJHours_AL()
        {
            TestLengthLongRuleFor(l => l.OTJHoursNullable, "FD_OTJHours_AL", "OTJHours", 1, 4);
        }

        [Fact]
        public void FD_AddLine1_AL()
        {
            TestLengthStringRuleFor(l => l.AddLine1, "FD_AddLine1_AL", "AddLine1", 1, 50);
        }

        [Fact]
        public void FD_AddLine2_AL()
        {
            TestLengthStringRuleFor(l => l.AddLine2, "FD_AddLine2_AL", "AddLine2", 1, 50);
        }

        [Fact]
        public void FD_AddLine3_AL()
        {
            TestLengthStringRuleFor(l => l.AddLine3, "FD_AddLine3_AL", "AddLine3", 1, 50);
        }

        [Fact]
        public void FD_AddLine4_AL()
        {
            TestLengthStringRuleFor(l => l.AddLine4, "FD_AddLine4_AL", "AddLine4", 1, 50);
        }

        [Fact]
        public void FD_TelNo_AL()
        {
            TestLengthStringRuleFor(l => l.TelNo, "FD_TelNo_AL", "TelNo", 1, 18);
        }

        [Fact]

        public void FD_Email_AL()
        {
            TestLengthStringRuleFor(l => l.Email, "FD_Email_AL", "Email", 1, 100);
        }

        [Fact]
        public void FD_OTJHours_AR()
        {
            TestRangeFor(l => l.OTJHoursNullable, "FD_OTJHours_AR", "OTJHours", 0, 9999);
        }

        [Fact]
        public void FD_PrevUKPRN_AR()
        {
            TestRangeFor(l => l.PrevUKPRNNullable, "FD_PrevUKPRN_AR", "PrevUKPRN", 10000000, 99999999);
        }

        [Fact]
        public void FD_PMUKPRN_AR()
        {
            TestRangeFor(l => l.PMUKPRNNullable, "FD_PMUKPRN_AR", "PMUKPRN", 10000000, 99999999);
        }

        [Fact]
        public void FD_ULN_AR()
        {
            TestRangeFor(l => l.ULNNullable, "FD_ULN_AR", "ULN", 1000000000, 9999999999);
        }

        [Fact]
        public void FD_ALSCost_AR()
        {
            TestRangeFor(l => l.ALSCostNullable, "FD_ALSCost_AR", "ALSCost", 0, 999999);
        }

        [Fact]
        public void FD_PlanLearnHours_AR()
        {
            TestRangeFor(l => l.PlanLearnHoursNullable, "FD_PlanLearnHours_AR", "PlanLearnHours", 0, 9999);
        }

        [Fact]
        public void FD_PlanEEPHours_AR()
        {
            TestRangeFor(l => l.PlanEEPHoursNullable, "FD_PlanEEPHours_AR", "PlanEEPHours", 0, 9999);
        }

        [Fact]
        public void FD_ContactPreference_EO()
        {
            TestEntityMaximumOccurrenceFor(l => l.ContactPreferences, "FD_ContactPreference_EO", "ContactPreference", 5);
        }

        [Fact]
        public void FD_LLDDandHealthProblem_EO()
        {
            TestEntityMaximumOccurrenceFor(l => l.LLDDAndHealthProblems, "FD_LLDDandHealthProblem_EO", "LLDDandHealthProblem", 22);
        }

        [Fact]
        public void FD_LearnerFAM_EO()
        {
            TestEntityMaximumOccurrenceFor(l => l.LearnerFAMs, "FD_LearnerFAM_EO", "LearnerFAM", 17);
        }

        [Fact]
        public void FD_ProviderSpecLearnerMonitoring_EO()
        {
            TestEntityMaximumOccurrenceFor(l => l.ProviderSpecLearnerMonitorings, "FD_ProviderSpecLearnerMonitoring_EO", "ProviderSpecLearnerMonitoring", 2);
        }

        [Fact]
        public void FD_EmploymentStatusMonitoring_EO()
        {
            TestEntityMaximumOccurrenceFor(l => l.LearnerEmploymentStatuses, "FD_EmploymentStatusMonitoring_EO", "EmploymentStatusMonitoring", 7);
        }

        [Fact]
        public void FD_LearnerHE_EO()
        {
            TestEntityMaximumOccurrenceFor(l => l.LearnerHEs, "FD_LearnerHE_EO", "LearnerHE", 1);
        }

        [Fact]
        public void FD_LearningDelivery_EO()
        {
            TestEntityMinimumOccurrenceFor(l => l.LearningDeliveries, "FD_LearningDelivery_EO", "LearningDeliveries", 1);
        }

        [Fact]
        public void ContactPreference_ChildValidator()
        {
            _validator.ShouldHaveChildValidator(l => l.ContactPreferences, typeof(IValidator<ILooseContactPreference>));
        }

        [Fact]
        public void LearnerFam_ChildValidator()
        {
            _validator.ShouldHaveChildValidator(l => l.LearnerFAMs, typeof(IValidator<ILooseLearnerFAM>));
        }

        [Fact]
        public void ProviderSpecLearnerMonitoring_ChildValidator()
        {
            _validator.ShouldHaveChildValidator(l => l.ProviderSpecLearnerMonitorings, typeof(IValidator<ILooseProviderSpecLearnerMonitoring>));
        }

        [Fact]
        public void LearnerEmploymentStatus_ChildValidator()
        {
            _validator.ShouldHaveChildValidator(l => l.LearnerEmploymentStatuses, typeof(IValidator<ILooseLearnerEmploymentStatus>));
        }

        [Fact]
        public void LearnerHE_ChildValidator()
        {
            _validator.ShouldHaveChildValidator(l => l.LearnerHEs, typeof(IValidator<ILooseLearnerHE>));
        }

        [Fact]
        public void LLDDAndHealthProblem_ChildValidator()
        {
            _validator.ShouldHaveChildValidator(l => l.LLDDAndHealthProblems, typeof(IValidator<ILooseLLDDAndHealthProblem>));
        }
    }
}
