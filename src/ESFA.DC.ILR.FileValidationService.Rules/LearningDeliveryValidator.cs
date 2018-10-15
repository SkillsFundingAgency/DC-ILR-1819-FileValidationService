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
            IValidator<ILooseLearningDeliveryHE> learningDeliveryHEValidator)
        {
            RegexRules();
            MandatoryRules();

            RuleForEach(ld => ld.LearningDeliveryFAMs).SetValidator(learningDeliveryFAMValidator);
            RuleForEach(ld => ld.AppFinRecords).SetValidator(appFinRecordValidator);
            RuleForEach(ld => ld.ProviderSpecDeliveryMonitorings).SetValidator(providerSpecDeliveryMonitoringValidator);
            RuleForEach(ld => ld.LearningDeliveryHEs).SetValidator(learningDeliveryHEValidator);
        }

        private void RegexRules()
        {
            RuleFor(ld => ld.LearnAimRef).MatchesRestrictedString().WithErrorCode(RuleNames.FD_LearnAimRef_AP);
            RuleFor(ld => ld.DelLocPostCode).MatchesRestrictedString().WithErrorCode(RuleNames.FD_DelLocPostCode_AP);
            RuleFor(ld => ld.ConRefNumber).MatchesRestrictedString().WithErrorCode(RuleNames.FD_ConRefNumber_AP);
            RuleFor(ld => ld.EPAOrgID).MatchesRegex(Regexes.EpaOrgId).WithErrorCode(RuleNames.FD_EPAOrgID_AP);
            RuleFor(ld => ld.OutGrade).MatchesRestrictedString().WithErrorCode(RuleNames.FD_OutGrade_AP);
            RuleFor(ld => ld.SWSupAimId).MatchesRestrictedString().WithErrorCode(RuleNames.FD_SWSupAimId_AP);
        }

        private void MandatoryRules()
        {
            RuleFor(ld => ld.LearnAimRef).NotNull().WithErrorCode(RuleNames.FD_LearnAimRef_MA);
            RuleFor(ld => ld.AimTypeNullable).NotNull().WithErrorCode(RuleNames.FD_AimType_MA);
            RuleFor(ld => ld.AimSeqNumberNullable).NotNull().WithErrorCode(RuleNames.FD_AimSeqNumber_MA);
            RuleFor(ld => ld.LearnStartDateNullable).NotNull().WithErrorCode(RuleNames.FD_LearnStartDate_MA);
            RuleFor(ld => ld.LearnPlanEndDateNullable).NotNull().WithErrorCode(RuleNames.FD_LearnPlanEndDate_MA);
            RuleFor(ld => ld.FundModelNullable).NotNull().WithErrorCode(RuleNames.FD_FundModel_MA);
            RuleFor(ld => ld.DelLocPostCode).NotNull().WithErrorCode(RuleNames.FD_DelLocPostCode_MA);
            RuleFor(ld => ld.CompStatusNullable).NotNull().WithErrorCode(RuleNames.FD_CompStatus_MA);
        }
    }
}
