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

        public LearningDeliveryValidatorTests()
            : base(new LearningDeliveryValidator(LearningDeliveryFAMValidator, AppFinRecordValidator, ProviderSpecDeliveryMonitoringValidator, LearningDeliveryHEValidator))
        {
        }

        [Fact]
        public void FD_LearnAimRef_AP()
        {
            TestRuleFor(ld => ld.LearnAimRef, "FD_LearnAimRef_AP", "LearnAimRef", "`");
        }

        [Fact]
        public void FD_DelLocPostCode_AP()
        {
            TestRuleFor(ld => ld.DelLocPostCode, "FD_DelLocPostCode_AP", "DelLocPostCode", "`");
        }

        [Fact]
        public void FD_ConRefNumber_AP()
        {
            TestRuleFor(ld => ld.ConRefNumber, "FD_ConRefNumber_AP", "ConRefNumber", "`");
        }

        [Fact]
        public void FD_EPAOrgID_AP()
        {
            TestRuleFor(ld => ld.EPAOrgID, "FD_EPAOrgID_AP", "EPA1234", "ABC4");
        }

        [Fact]
        public void FD_OutGrade_AP()
        {
            TestRuleFor(ld => ld.OutGrade, "FD_OutGrade_AP", "OutGrade", "`");
        }

        [Fact]
        public void FD_SWSupAimId_AP()
        {
            TestRuleFor(ld => ld.SWSupAimId, "FD_SWSupAimId_AP", "SWSupAimId", "`");
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
    }
}
