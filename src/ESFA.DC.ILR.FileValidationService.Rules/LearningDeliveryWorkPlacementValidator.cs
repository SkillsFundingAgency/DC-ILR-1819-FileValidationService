using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearningDeliveryWorkPlacementValidator : AbstractValidator<ILooseLearningDeliveryWorkPlacement>
    {
        public LearningDeliveryWorkPlacementValidator()
        {
            MandatoryAttributeRules();
            LengthRules();
        }

        private void MandatoryAttributeRules()
        {
            RuleSet(RuleSetNames.MandatoryAttributes, () =>
            {
                RuleFor(wp => wp.WorkPlaceStartDateNullable).NotNull().WithErrorCode(RuleNames.FD_WorkPlaceStartDate_MA);
                RuleFor(wp => wp.WorkPlaceHoursNullable).NotNull().WithErrorCode(RuleNames.FD_WorkPlaceHours_MA);
                RuleFor(wp => wp.WorkPlaceModeNullable).NotNull().WithErrorCode(RuleNames.FD_WorkPlaceMode_MA);
            });
        }

        private void LengthRules()
        {
            RuleSet(RuleSetNames.Length, () =>
            {
                RuleFor(wp => wp.WorkPlaceHoursNullable).Length(1, 4).WithLengthError(RuleNames.FD_WorkPlaceHours_AL);
                RuleFor(wp => wp.WorkPlaceModeNullable).Length(1, 1).WithLengthError(RuleNames.FD_WorkPlaceMode_AL);
                RuleFor(wp => wp.WorkPlaceEmpIdNullable).Length(1, 9).WithLengthError(RuleNames.FD_WorkPlaceEmpId_AL);
            });
        }
    }
}
