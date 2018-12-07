using ESFA.DC.ILR.FileValidationService.Rules.Abstract;
using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearnerHEFinancialSupportValidator : AbstractFileValidationValidator<ILooseLearnerHEFinancialSupport>
    {
        public override void MandatoryAttributeRules()
        {
            RuleFor(fs => fs.FINTYPENullable).NotNull().WithErrorCode(RuleNames.FD_FINTYPE_MA);
            RuleFor(fs => fs.FINAMOUNTNullable).NotNull().WithErrorCode(RuleNames.FD_FINAMOUNT_MA);
        }

        public override void LengthRules()
        {
            RuleFor(fs => fs.FINTYPENullable).Length(1, 1).WithLengthError(RuleNames.FD_FINTYPE_AL);
            RuleFor(fs => fs.FINAMOUNTNullable).Length(1, 6).WithLengthError(RuleNames.FD_FINAMOUNT_AL);
        }

        public override void RangeRules()
        {
            RuleFor(fs => fs.FINAMOUNTNullable).InclusiveBetween(0, 999999).WithRangeError(RuleNames.FD_FINAMOUNT_AR);
        }
    }
}
