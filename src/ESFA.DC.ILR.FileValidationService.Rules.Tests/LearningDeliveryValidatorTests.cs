using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class LearningDeliveryValidatorTests : AbstractValidatorTests<ILooseLearningDelivery>
    {
        public LearningDeliveryValidatorTests()
            : base(new LearningDeliveryValidator())
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
    }
}
