using ESFA.DC.ILR.FileValidationService.Rules.Abstract;
using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearnerEmploymentStatusValidator : AbstractFileValidationValidator<ILooseLearnerEmploymentStatus>
    {
        public LearnerEmploymentStatusValidator(IValidator<ILooseEmploymentStatusMonitoring> employmentStatusMonitoringValidator)
        {
            RuleForEach(les => les.EmploymentStatusMonitorings).SetValidator(employmentStatusMonitoringValidator);
        }

        public override void RegexRules()
        {
            RuleSet(RuleSetNames.Regex, () =>
            {
                RuleFor(les => les.AgreeId).MatchesRegex(Regexes.AgreeId).WithErrorCode(RuleNames.FD_AgreeId_AP);
            });
        }

        public override void MandatoryAttributeRules()
        {
            RuleSet(RuleSetNames.MandatoryAttributes, () =>
            {
                RuleFor(les => les.EmpStatNullable).NotNull().WithErrorCode(RuleNames.FD_EmpStat_MA);
                RuleFor(les => les.DateEmpStatAppNullable).NotNull().WithErrorCode(RuleNames.FD_DateEmpStatApp_MA);
            });
        }

        public override void LengthRules()
        {
            RuleSet(RuleSetNames.Length, () =>
            {
                RuleFor(les => les.EmpStatNullable).Length(1, 2).WithLengthError(RuleNames.FD_EmpStat_AL);
                RuleFor(les => les.EmpIdNullable).Length(1, 9).WithLengthError(RuleNames.FD_EmpId_AL);
                RuleFor(les => les.AgreeId).LengthTrim(1, 6).WithLengthError(RuleNames.FD_AgreeId_AL);
            });
        }

        public override void EntityOccurenceRules()
        {
            RuleSet(RuleSetNames.EntityOccurrence, () =>
            {
                RuleFor(l => l.EmploymentStatusMonitorings).CountLessThanOrEqualTo(7).WithEntityOccurrenceError(RuleNames.FD_EmploymentStatusMonitoring_EO);
            });
        }
    }
}
