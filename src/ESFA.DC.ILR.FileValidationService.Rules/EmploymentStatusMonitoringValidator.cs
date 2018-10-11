using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class EmploymentStatusMonitoringValidator : AbstractValidator<ILooseEmploymentStatusMonitoring>
    {
        public EmploymentStatusMonitoringValidator()
        {
            RuleFor(esm => esm.ESMType).MatchesRestrictedString().WithErrorCode(RuleNames.FD_ESMType_AP);
        }
    }
}
