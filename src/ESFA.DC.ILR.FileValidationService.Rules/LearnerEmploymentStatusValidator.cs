using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearnerEmploymentStatusValidator : AbstractValidator<ILooseLearnerEmploymentStatus>
    {
        private readonly IValidator<ILooseEmploymentStatusMonitoring> _employmentStatusMonitoringValidator;

        public LearnerEmploymentStatusValidator(IValidator<ILooseEmploymentStatusMonitoring> employmentStatusMonitoringValidator)
        {
            _employmentStatusMonitoringValidator = employmentStatusMonitoringValidator;

            RuleForEach(les => les.EmploymentStatusMonitorings).SetValidator(_employmentStatusMonitoringValidator);
        }
    }
}
