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
            RegexRules();
            MandatoryAttributeRules();

            RuleForEach(les => les.EmploymentStatusMonitorings).SetValidator(employmentStatusMonitoringValidator);
        }

        private void RegexRules()
        {
            RuleFor(les => les.AgreeId).MatchesRegex(Regexes.AgreeId).WithErrorCode(RuleNames.FD_AgreeId_AP);
        }

        private void MandatoryAttributeRules()
        {
            RuleFor(les => les.EmpStatNullable).NotNull().WithErrorCode(RuleNames.FD_EmpStat_MA);
            RuleFor(les => les.DateEmpStatAppNullable).NotNull().WithErrorCode(RuleNames.FD_DateEmpStatApp_MA);
        }
    }
}
