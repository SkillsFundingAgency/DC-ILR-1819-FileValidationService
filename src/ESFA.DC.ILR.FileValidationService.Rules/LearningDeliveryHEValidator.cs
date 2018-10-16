using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearningDeliveryHEValidator : AbstractValidator<ILooseLearningDeliveryHE>
    {
        public LearningDeliveryHEValidator()
        {
            RegexRules();
            MandatoryAttributeRules();
        }

        private void RegexRules()
        {
            RuleFor(he => he.NUMHUS).MatchesRestrictedString().WithErrorCode(RuleNames.FD_NUMHUS_AP);
            RuleFor(he => he.SSN).MatchesRestrictedString().WithErrorCode(RuleNames.FD_SSN_AP);
            RuleFor(he => he.QUALENT3).MatchesRestrictedString().WithErrorCode(RuleNames.FD_QUALENT3_AP);
            RuleFor(he => he.UCASAPPID).MatchesRegex(Regexes.UcasAppId).WithErrorCode(RuleNames.FD_UCASAPPID_AP);
            RuleFor(he => he.DOMICILE).MatchesRestrictedString().WithErrorCode(RuleNames.FD_DOMICILE_AP);
            RuleFor(he => he.HEPostCode).MatchesRestrictedString().WithErrorCode(RuleNames.FD_HEPostCode_AP);
        }

        private void MandatoryAttributeRules()
        {      
            RuleFor(he => he.TYPEYRNullable).NotNull().WithErrorCode(RuleNames.FD_TYPEYR_MA);
            RuleFor(he => he.MODESTUDNullable).NotNull().WithErrorCode(RuleNames.FD_MODESTUD_MA);
            RuleFor(he => he.FUNDLEVNullable).NotNull().WithErrorCode(RuleNames.FD_FUNDLEV_MA);
            RuleFor(he => he.FUNDCOMPNullable).NotNull().WithErrorCode(RuleNames.FD_FUNDCOMP_MA);
            RuleFor(he => he.YEARSTUNullable).NotNull().WithErrorCode(RuleNames.FD_YEARSTU_MA);
            RuleFor(he => he.MSTUFEENullable).NotNull().WithErrorCode(RuleNames.FD_MSTUFEE_MA);
            RuleFor(he => he.SPECFEENullable).NotNull().WithErrorCode(RuleNames.FD_SPECFEE_MA);
        }
    }
}
