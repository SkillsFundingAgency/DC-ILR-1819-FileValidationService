using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;
using FluentValidation.TestHelper;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class LearningDeliveryValidatorTests : AbstractValidatorTests<ILooseLearningDelivery>
    {
        private static IValidator<ILooseLearningDeliveryFAM> LearningDeliveryFAMValidator = new Mock<IValidator<ILooseLearningDeliveryFAM>>().Object;
        private static IValidator<ILooseAppFinRecord> AppFinRecordValidator = new Mock<IValidator<ILooseAppFinRecord>>().Object;
        private static IValidator<ILooseProviderSpecDeliveryMonitoring> ProviderSpecDeliveryMonitoringValidator = new Mock<IValidator<ILooseProviderSpecDeliveryMonitoring>>().Object;
        private static IValidator<ILooseLearningDeliveryHE> LearningDeliveryHEValidator = new Mock<IValidator<ILooseLearningDeliveryHE>>().Object;
        private static IValidator<ILooseLearningDeliveryWorkPlacement> LearningDeliveryWorkPlacementValidator = new Mock<IValidator<ILooseLearningDeliveryWorkPlacement>>().Object;

        public LearningDeliveryValidatorTests()
            : base(new LearningDeliveryValidator(LearningDeliveryFAMValidator, AppFinRecordValidator, ProviderSpecDeliveryMonitoringValidator, LearningDeliveryHEValidator, LearningDeliveryWorkPlacementValidator))
        {
        }

        [Fact]
        public void FD_LearnAimRef_AP()
        {
            TestRegexRuleFor(ld => ld.LearnAimRef, "FD_LearnAimRef_AP", "LearnAimRef", "`");
        }

        [Fact]
        public void FD_DelLocPostCode_AP()
        {
            TestRegexRuleFor(ld => ld.DelLocPostCode, "FD_DelLocPostCode_AP", "DelLocPostCode", "`");
        }

        [Fact]
        public void FD_ConRefNumber_AP()
        {
            TestRegexRuleFor(ld => ld.ConRefNumber, "FD_ConRefNumber_AP", "ConRefNumber", "`");
        }

        [Fact]
        public void FD_EPAOrgID_AP()
        {
            TestRegexRuleFor(ld => ld.EPAOrgID, "FD_EPAOrgID_AP", "EPA1234", "ABC4");
        }

        [Fact]
        public void FD_OutGrade_AP()
        {
            TestRegexRuleFor(ld => ld.OutGrade, "FD_OutGrade_AP", "OutGrade", "`");
        }

        [Fact]
        public void FD_SWSupAimId_AP()
        {
            TestRegexRuleFor(ld => ld.SWSupAimId, "FD_SWSupAimId_AP", "SWSupAimId", "`");
        }

        [Fact]
        public void FD_LearnAimRef_MA()
        {
            TestMandatoryStringAttributeRuleFor(ld => ld.LearnAimRef, "FD_LearnAimRef_MA");
        }

        [Fact]
        public void FD_AimType_MA()
        {
            TestMandatoryLongAttributeRuleFor(ld => ld.AimTypeNullable, "FD_AimType_MA");
        }

        [Fact]
        public void FD_AimSeqNumber_MA()
        {
            TestMandatoryLongAttributeRuleFor(ld => ld.AimSeqNumberNullable, "FD_AimSeqNumber_MA");
        }

        [Fact]
        public void FD_LearnStartDate_MA()
        {
            TestMandatoryDateTimeAttributeRuleFor(ld => ld.LearnStartDateNullable, "FD_LearnStartDate_MA");
        }

        [Fact]
        public void FD_LearnPlanEndDate_MA()
        {
            TestMandatoryDateTimeAttributeRuleFor(ld => ld.LearnPlanEndDateNullable, "FD_LearnPlanEndDate_MA");
        }

        [Fact]
        public void FD_FundModel_MA()
        {
            TestMandatoryLongAttributeRuleFor(ld => ld.FundModelNullable, "FD_FundModel_MA");
        }

        [Fact]
        public void FD_DelLocPostCode_MA()
        {
            TestMandatoryStringAttributeRuleFor(ld => ld.DelLocPostCode, "FD_DelLocPostCode_MA");
        }

        [Fact]
        public void FD_CompStatus_MA()
        {
             TestMandatoryLongAttributeRuleFor(ld => ld.CompStatusNullable, "FD_CompStatus_MA");
        }

        [Fact]
        public void FD_LearnAimRef_AL()
        {
            TestLengthStringRuleFor(ld => ld.LearnAimRef, "FD_LearnAimRef_AL", "LearnAimRef", 1, 8);
        }

        [Fact]
        public void FD_AimType_AL()
        {
            TestLengthLongRuleFor(ld => ld.AimTypeNullable, "FD_AimType_AL", "AimType", 1, 1);
        }

        [Fact]
        public void FD_AimSeqNumber_AL()
        {
            TestLengthLongRuleFor(ld => ld.AimSeqNumberNullable, "FD_AimSeqNumber_AL", "AimSeqNumber", 1, 2);
        }

        [Fact]
        public void FD_FundModel_AL()
        {
            TestLengthLongRuleFor(ld => ld.FundModelNullable, "FD_FundModel_AL", "FundModel", 1, 2);
        }

        [Fact]
        public void FD_ProgType_AL()
        {
            TestLengthLongRuleFor(ld => ld.ProgTypeNullable, "FD_ProgType_AL", "ProgType", 1, 2);
        }

        [Fact]
        public void FD_FworkCode_AL()
        {
            TestLengthLongRuleFor(ld => ld.FworkCodeNullable, "FD_FworkCode_AL", "FworkCode", 1, 3);
        }

        [Fact]
        public void FD_PwayCode_AL()
        {
            TestLengthLongRuleFor(ld => ld.PwayCodeNullable, "FD_PwayCode_AL", "PwayCode", 1, 3);
        }

        [Fact]
        public void FD_StdCode_AL()
        {
            TestLengthLongRuleFor(ld => ld.StdCodeNullable, "FD_StdCode_AL", "StdCode", 1, 5);
        }

        [Fact]
        public void FD_PartnerUKPRN_AL()
        {
            TestLengthLongRuleFor(ld => ld.PartnerUKPRNNullable, "FD_PartnerUKPRN_AL", "PartnerUKPRN", 1, 8);
        }

        [Fact]
        public void FD_DelLocPostCode_AL()
        {
            TestLengthStringRuleFor(ld => ld.DelLocPostCode, "FD_DelLocPostCode_AL", "DelLocPostCode", 1, 8);
        }

        [Fact]
        public void FD_AddHours_AL()
        {
            TestLengthLongRuleFor(ld => ld.AddHoursNullable, "FD_AddHours_AL", "AddHours", 1, 4);
        }

        [Fact]
        public void FD_PriorLearnFundAdj_AL()
        {
            TestLengthLongRuleFor(ld => ld.PriorLearnFundAdjNullable, "FD_PriorLearnFundAdj_AL", "PriorLearnFundAdj", 1, 2);
        }

        [Fact]
        public void FD_OtherFundAdj_AL()
        {
            TestLengthLongRuleFor(ld => ld.OtherFundAdjNullable, "FD_OtherFundAdj_AL", "OtherFundAdj", 1, 3);
        }

        [Fact]
        public void FD_ConRefNumber_AL()
        {
            TestLengthStringRuleFor(ld => ld.ConRefNumber, "FD_ConRefNumber_AL", "ConRefNumber", 1, 20);
        }

        [Fact]
        public void FD_EPAOrgID_AL()
        {
            TestLengthStringRuleFor(ld => ld.EPAOrgID, "FD_EPAOrgID_AL", "EPAOrgID", 1, 7);
        }

        [Fact]
        public void FD_EmpOutcome_AL()
        {
            TestLengthLongRuleFor(ld => ld.EmpOutcomeNullable, "FD_EmpOutcome_AL", "EmpOutcome", 1, 1);
        }

        [Fact]
        public void FD_CompStatus_AL()
        {
            TestLengthLongRuleFor(ld => ld.CompStatusNullable, "FD_CompStatus_AL", "CompStatus", 1, 1);
        }

        [Fact]
        public void FD_WithdrawReason_AL()
        {
            TestLengthLongRuleFor(ld => ld.WithdrawReasonNullable, "FD_WithdrawReason_AL", "WithdrawReason", 1, 2);
        }

        [Fact]
        public void FD_Outcome_AL()
        {
            TestLengthLongRuleFor(ld => ld.OutcomeNullable, "FD_Outcome_AL", "Outcome", 1, 1);
        }

        [Fact]
        public void FD_OutGrade_AL()
        {
            TestLengthStringRuleFor(ld => ld.OutGrade, "FD_OutGrade_AL", "OutGrade", 1, 6);
        }

        [Fact]
        public void FD_SWSupAimId_AL()
        {
            TestLengthStringRuleFor(ld => ld.SWSupAimId, "FD_SWSupAimId_AL", "SWSupAimId", 1, 36);
        }

        [Fact]
        public void FD_AimSeqNumber_AR()
        {
            TestRangeFor(ld => ld.AimSeqNumberNullable, "FD_AimSeqNumber_AR", "AimSeqNumber", 1, 98);
        }

        [Fact]
        public void FD_PartnerUKPRN_AR()
        {
            TestRangeFor(ld => ld.PartnerUKPRNNullable, "FD_PartnerUKPRN_AR", "PartnerUKPRN", 10000000, 99999999);
        }

        [Fact]
        public void FD_AddHours_AR()
        {
            TestRangeFor(ld => ld.AddHoursNullable, "FD_AddHours_AR", "AddHours", 0, 9999);
        }

        [Fact]
        public void FD_PriorLearnFundAdj_AR()
        {
            TestRangeFor(ld => ld.PriorLearnFundAdjNullable, "FD_PriorLearnFundAdj_AR", "PriorLearnFundAdj", 0, 99);
        }

        [Fact]
        public void FD_OtherFundAdj_AR()
        {
            TestRangeFor(ld => ld.OtherFundAdjNullable, "FD_OtherFundAdj_AR", "OtherFundAdj", 0, 999);
        }

        [Fact]
        public void FD_ProviderSpecDeliveryMonitoring_EO()
        {
            TestEntityMaximumOccurrenceFor(ld => ld.ProviderSpecDeliveryMonitorings, "FD_ProviderSpecDeliveryMonitoring_EO", "ProviderSpecDeliveryMonitoring", 4);
        }

        [Fact]
        public void FD_LearningDeliveryHE_EO()
        {
            TestEntityMaximumOccurrenceFor(ld => ld.LearningDeliveryHEs, "FD_LearningDeliveryHE_EO", "LearningDeliveryHE", 1);
        }

        [Fact]
        public void LearningDeliveryFAM_ChildValidator()
        {
            _validator.ShouldHaveChildValidator(ld => ld.LearningDeliveryFAMs, typeof(IValidator<ILooseLearningDeliveryFAM>));
        }

        [Fact]
        public void AppFinRecord_ChildValidator()
        {
            _validator.ShouldHaveChildValidator(ld => ld.AppFinRecords, typeof(IValidator<ILooseAppFinRecord>));
        }

        [Fact]
        public void ProviderSpecDeliveryMonitoring_ChildValidator()
        {
            _validator.ShouldHaveChildValidator(ld => ld.ProviderSpecDeliveryMonitorings, typeof(IValidator<ILooseProviderSpecDeliveryMonitoring>));
        }

        [Fact]
        public void LearningDeliveryHE_ChildValidator()
        {
            _validator.ShouldHaveChildValidator(ld => ld.LearningDeliveryHEs, typeof(IValidator<ILooseLearningDeliveryHE>));
        }

        [Fact]
        public void LearningDeliveryWorkPlacement_ChildValidator()
        {
            _validator.ShouldHaveChildValidator(ld => ld.LearningDeliveryWorkPlacements, typeof(IValidator<ILooseLearningDeliveryWorkPlacement>));
        }
    }
}
