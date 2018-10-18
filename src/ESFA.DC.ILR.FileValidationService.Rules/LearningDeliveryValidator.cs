using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearningDeliveryValidator : AbstractValidator<ILooseLearningDelivery>
    {
        public LearningDeliveryValidator(
            IValidator<ILooseLearningDeliveryFAM> learningDeliveryFAMValidator,
            IValidator<ILooseAppFinRecord> appFinRecordValidator,
            IValidator<ILooseProviderSpecDeliveryMonitoring> providerSpecDeliveryMonitoringValidator,
            IValidator<ILooseLearningDeliveryHE> learningDeliveryHEValidator,
            IValidator<ILooseLearningDeliveryWorkPlacement> learningDeliveryWorkPlacementValidator)
        {
            RegexRules();
            MandatoryRules();
            LengthRules();

            RuleForEach(ld => ld.LearningDeliveryFAMs).SetValidator(learningDeliveryFAMValidator);
            RuleForEach(ld => ld.AppFinRecords).SetValidator(appFinRecordValidator);
            RuleForEach(ld => ld.ProviderSpecDeliveryMonitorings).SetValidator(providerSpecDeliveryMonitoringValidator);
            RuleForEach(ld => ld.LearningDeliveryHEs).SetValidator(learningDeliveryHEValidator);
            RuleForEach(ld => ld.LearningDeliveryWorkPlacements).SetValidator(learningDeliveryWorkPlacementValidator);
        }

        private void RegexRules()
        {
            RuleSet(RuleSetNames.Regex, () =>
            {
                RuleFor(ld => ld.LearnAimRef).MatchesRestrictedString().WithErrorCode(RuleNames.FD_LearnAimRef_AP);
                RuleFor(ld => ld.DelLocPostCode).MatchesRestrictedString().WithErrorCode(RuleNames.FD_DelLocPostCode_AP);
                RuleFor(ld => ld.ConRefNumber).MatchesRestrictedString().WithErrorCode(RuleNames.FD_ConRefNumber_AP);
                RuleFor(ld => ld.EPAOrgID).MatchesRegex(Regexes.EpaOrgId).WithErrorCode(RuleNames.FD_EPAOrgID_AP);
                RuleFor(ld => ld.OutGrade).MatchesRestrictedString().WithErrorCode(RuleNames.FD_OutGrade_AP);
                RuleFor(ld => ld.SWSupAimId).MatchesRestrictedString().WithErrorCode(RuleNames.FD_SWSupAimId_AP);
            });
        }

        private void MandatoryRules()
        {
            RuleSet(RuleSetNames.MandatoryAttributes, () =>
            {
                RuleFor(ld => ld.LearnAimRef).NotNull().WithErrorCode(RuleNames.FD_LearnAimRef_MA);
                RuleFor(ld => ld.AimTypeNullable).NotNull().WithErrorCode(RuleNames.FD_AimType_MA);
                RuleFor(ld => ld.AimSeqNumberNullable).NotNull().WithErrorCode(RuleNames.FD_AimSeqNumber_MA);
                RuleFor(ld => ld.LearnStartDateNullable).NotNull().WithErrorCode(RuleNames.FD_LearnStartDate_MA);
                RuleFor(ld => ld.LearnPlanEndDateNullable).NotNull().WithErrorCode(RuleNames.FD_LearnPlanEndDate_MA);
                RuleFor(ld => ld.FundModelNullable).NotNull().WithErrorCode(RuleNames.FD_FundModel_MA);
                RuleFor(ld => ld.DelLocPostCode).NotNull().WithErrorCode(RuleNames.FD_DelLocPostCode_MA);
                RuleFor(ld => ld.CompStatusNullable).NotNull().WithErrorCode(RuleNames.FD_CompStatus_MA);
            });
        }

        private void LengthRules()
        {
            RuleSet(RuleSetNames.Length, () =>
            {
                RuleFor(ld => ld.LearnAimRef).Length(1, 8).WithLengthError(RuleNames.FD_LearnAimRef_AL);
                RuleFor(ld => ld.AimTypeNullable).Length(1, 1).WithLengthError(RuleNames.FD_AimType_AL);
                RuleFor(ld => ld.AimSeqNumberNullable).Length(1, 2).WithLengthError(RuleNames.FD_AimSeqNumber_AL);
                RuleFor(ld => ld.FundModelNullable).Length(1, 2).WithLengthError(RuleNames.FD_FundModel_AL);
                RuleFor(ld => ld.ProgTypeNullable).Length(1, 2).WithLengthError(RuleNames.FD_ProgType_AL);
                RuleFor(ld => ld.FworkCodeNullable).Length(1, 3).WithLengthError(RuleNames.FD_FworkCode_AL);
                RuleFor(ld => ld.PwayCodeNullable).Length(1, 3).WithLengthError(RuleNames.FD_PwayCode_AL);
                RuleFor(ld => ld.StdCodeNullable).Length(1, 5).WithLengthError(RuleNames.FD_StdCode_AL);
                RuleFor(ld => ld.PartnerUKPRNNullable).Length(1, 8).WithLengthError(RuleNames.FD_PartnerUKPRN_AL);
                RuleFor(ld => ld.DelLocPostCode).Length(1, 8).WithLengthError(RuleNames.FD_DelLocPostCode_AL);
                RuleFor(ld => ld.AddHoursNullable).Length(1, 4).WithLengthError(RuleNames.FD_AddHours_AL);
                RuleFor(ld => ld.PriorLearnFundAdjNullable).Length(1, 2).WithLengthError(RuleNames.FD_PriorLearnFundAdj_AL);
                RuleFor(ld => ld.OtherFundAdjNullable).Length(1, 3).WithLengthError(RuleNames.FD_OtherFundAdj_AL);
                RuleFor(ld => ld.ConRefNumber).Length(1, 20).WithLengthError(RuleNames.FD_ConRefNumber_AL);
                RuleFor(ld => ld.EPAOrgID).Length(1, 7).WithLengthError(RuleNames.FD_EPAOrgID_AL);
                RuleFor(ld => ld.EmpOutcomeNullable).Length(1, 1).WithLengthError(RuleNames.FD_EmpOutcome_AL);
                RuleFor(ld => ld.CompStatusNullable).Length(1, 1).WithLengthError(RuleNames.FD_CompStatus_AL);
                RuleFor(ld => ld.WithdrawReasonNullable).Length(1, 2).WithLengthError(RuleNames.FD_WithdrawReason_AL);
                RuleFor(ld => ld.OutcomeNullable).Length(1, 1).WithLengthError(RuleNames.FD_Outcome_AL);
                RuleFor(ld => ld.OutGrade).Length(1, 6).WithLengthError(RuleNames.FD_OutGrade_AL);
                RuleFor(ld => ld.SWSupAimId).Length(1, 36).WithLengthError(RuleNames.FD_SWSupAimId_AL);
            });
        }
    }
}
