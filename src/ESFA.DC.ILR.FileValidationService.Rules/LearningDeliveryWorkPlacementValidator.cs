using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearningDeliveryWorkPlacementValidator : AbstractValidator<ILooseLearningDeliveryWorkPlacement>
    {
        public LearningDeliveryWorkPlacementValidator()
        {
            MandatoryAttributeRules();
        }

        private void MandatoryAttributeRules()
        {
            RuleFor(wp => wp.WorkPlaceStartDateNullable).NotNull().WithErrorCode(RuleNames.FD_WorkPlaceStartDate_MA);
            RuleFor(wp => wp.WorkPlaceHoursNullable).NotNull().WithErrorCode(RuleNames.FD_WorkPlaceHours_MA);
            RuleFor(wp => wp.WorkPlaceModeNullable).NotNull().WithErrorCode(RuleNames.FD_WorkPlaceMode_MA);
        }
    }
}
