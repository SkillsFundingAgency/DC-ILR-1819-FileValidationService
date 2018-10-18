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
            LengthRules();

            RuleForEach(les => les.EmploymentStatusMonitorings).SetValidator(employmentStatusMonitoringValidator);
        }

        private void RegexRules()
        {
            RuleSet(RuleSetNames.Regex, () =>
            {
                RuleFor(les => les.AgreeId).MatchesRegex(Regexes.AgreeId).WithErrorCode(RuleNames.FD_AgreeId_AP);
            });
        }

        private void MandatoryAttributeRules()
        {
            RuleSet(RuleSetNames.MandatoryAttributes, () =>
            {
                RuleFor(les => les.EmpStatNullable).NotNull().WithErrorCode(RuleNames.FD_EmpStat_MA);
                RuleFor(les => les.DateEmpStatAppNullable).NotNull().WithErrorCode(RuleNames.FD_DateEmpStatApp_MA);
            });
        }

        private void LengthRules()
        {
            RuleSet(RuleSetNames.Length, () =>
            {
                RuleFor(les => les.EmpStatNullable).Length(1, 2).WithLengthError(RuleNames.FD_EmpStat_AL);
                RuleFor(les => les.EmpIdNullable).Length(1, 9).WithLengthError(RuleNames.FD_EmpId_AL);
                RuleFor(les => les.AgreeId).Length(1, 6).WithLengthError(RuleNames.FD_AgreeId_AL);
            });
        }
    }
}
