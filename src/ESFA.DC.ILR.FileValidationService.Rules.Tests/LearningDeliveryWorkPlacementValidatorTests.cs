using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class LearningDeliveryWorkPlacementValidatorTests : AbstractValidatorTests<ILooseLearningDeliveryWorkPlacement>
    {
        public LearningDeliveryWorkPlacementValidatorTests()
            : base(new LearningDeliveryWorkPlacementValidator())
        {
        }

        [Fact]
        public void FD_WorkPlaceStartDate_MA()
        {
            TestMandatoryDateTimeAttributeRuleFor(wp => wp.WorkPlaceStartDateNullable, "FD_WorkPlaceStartDate_MA");
        }

        [Fact]
        public void FD_WorkPlaceHours_MA()
        {
            TestMandatoryLongAttributeRuleFor(wp => wp.WorkPlaceHoursNullable, "FD_WorkPlaceHours_MA");
        }

        [Fact]
        public void FD_WorkPlaceMode_MA()
        {
            TestMandatoryLongAttributeRuleFor(wp => wp.WorkPlaceModeNullable, "FD_WorkPlaceMode_MA");
        }
    }
}
