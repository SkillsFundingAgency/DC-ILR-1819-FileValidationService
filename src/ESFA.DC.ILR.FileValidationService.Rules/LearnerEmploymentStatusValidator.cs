using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearnerEmploymentStatusValidator : AbstractValidator<ILooseLearnerEmploymentStatus>
    {
        public LearnerEmploymentStatusValidator(IValidator<ILooseEmploymentStatusMonitoring> employmentStatusMonitoringValidator)
        {
            RuleFor(les => les.AgreeId).MatchesRegex(Regexes.AgreeId).WithErrorCode(RuleNames.FD_AgreeId_AP);

            RuleForEach(les => les.EmploymentStatusMonitorings).SetValidator(employmentStatusMonitoringValidator);
        }
    }
}
