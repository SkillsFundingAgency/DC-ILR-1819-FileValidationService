using ESFA.DC.ILR.FileValidationService.Rules.Abstract;
using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearnerHEValidator : AbstractFileValidationValidator<ILooseLearnerHE>
    {
        public LearnerHEValidator(IValidator<ILooseLearnerHEFinancialSupport> learnerHEFinancialSupportValidator)
        {
            RuleForEach(lhe => lhe.LearnerHEFinancialSupports).SetValidator(learnerHEFinancialSupportValidator);
        }

        public override void RegexRules()
        {
            RuleFor(lhe => lhe.UCASPERID).MatchesRegex(Regexes.UcasPerId).WithErrorCode(RuleNames.FD_UCASPERID_AP);
        
        }

        public override void LengthRules()
        {
            RuleFor(lhe => lhe.UCASPERID).Length(1, 10).WithLengthError(RuleNames.FD_UCASPERID_AL);
            RuleFor(lhe => lhe.TTACCOMNullable).Length(1, 1).WithLengthError(RuleNames.FD_TTACCOM_AL);
        }

        public override void RangeRules()
        {
            RuleFor(lhe => lhe.UCASPERID).Must(u =>
            {
                if (u != null && long.TryParse(u, out long ucasPerIdLong))
                {
                    return ucasPerIdLong >= 1 && ucasPerIdLong <= 9999999999;
                }

                return false;
            }).WithRangeError(RuleNames.FD_UCASPERID_AR);
        }
    }
}
