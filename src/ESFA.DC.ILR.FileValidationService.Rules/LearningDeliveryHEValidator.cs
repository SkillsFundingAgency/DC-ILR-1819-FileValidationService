using ESFA.DC.ILR.FileValidationService.Rules.Abstract;
using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearningDeliveryHEValidator : AbstractFileValidationValidator<ILooseLearningDeliveryHE>
    {
        public override void RegexRules()
        {
            RuleFor(he => he.NUMHUS).MatchesRestrictedString().WithErrorCode(RuleNames.FD_NUMHUS_AP);
            RuleFor(he => he.SSN).MatchesRestrictedString().WithErrorCode(RuleNames.FD_SSN_AP);
            RuleFor(he => he.QUALENT3).MatchesRestrictedString().WithErrorCode(RuleNames.FD_QUALENT3_AP);
            RuleFor(he => he.UCASAPPID).MatchesRegex(Regexes.UcasAppId).WithErrorCode(RuleNames.FD_UCASAPPID_AP);
            RuleFor(he => he.DOMICILE).MatchesRestrictedString().WithErrorCode(RuleNames.FD_DOMICILE_AP);
            RuleFor(he => he.HEPostCode).MatchesRestrictedString().WithErrorCode(RuleNames.FD_HEPostCode_AP);
        }

        public override void MandatoryAttributeRules()
        { 
            RuleFor(he => he.TYPEYRNullable).NotNull().WithErrorCode(RuleNames.FD_TYPEYR_MA);
            RuleFor(he => he.MODESTUDNullable).NotNull().WithErrorCode(RuleNames.FD_MODESTUD_MA);
            RuleFor(he => he.FUNDLEVNullable).NotNull().WithErrorCode(RuleNames.FD_FUNDLEV_MA);
            RuleFor(he => he.FUNDCOMPNullable).NotNull().WithErrorCode(RuleNames.FD_FUNDCOMP_MA);
            RuleFor(he => he.YEARSTUNullable).NotNull().WithErrorCode(RuleNames.FD_YEARSTU_MA);
            RuleFor(he => he.MSTUFEENullable).NotNull().WithErrorCode(RuleNames.FD_MSTUFEE_MA);
            RuleFor(he => he.SPECFEENullable).NotNull().WithErrorCode(RuleNames.FD_SPECFEE_MA);
        }

        public override void LengthRules()
        {
            RuleFor(he => he.NUMHUS).Length(1, 20).WithLengthError(RuleNames.FD_NUMHUS_AL);
            RuleFor(he => he.SSN).Length(1, 13).WithLengthError(RuleNames.FD_SSN_AL);
            RuleFor(he => he.QUALENT3).Length(1, 3).WithLengthError(RuleNames.FD_QUALENT3_AL);
            RuleFor(he => he.SOC2000Nullable).Length(1, 4).WithLengthError(RuleNames.FD_SOC2000_AL);
            RuleFor(he => he.SECNullable).Length(1, 1).WithLengthError(RuleNames.FD_SEC_AL);
            RuleFor(he => he.UCASAPPID).Length(1, 9).WithLengthError(RuleNames.FD_UCASAPPID_AL);
            RuleFor(he => he.TYPEYRNullable).Length(1, 1).WithLengthError(RuleNames.FD_TYPEYR_AL);
            RuleFor(he => he.MODESTUDNullable).Length(1, 2).WithLengthError(RuleNames.FD_MODESTUD_AL);
            RuleFor(he => he.FUNDLEVNullable).Length(1, 2).WithLengthError(RuleNames.FD_FUNDLEV_AL);
            RuleFor(he => he.FUNDCOMPNullable).Length(1, 1).WithLengthError(RuleNames.FD_FUNDCOMP_AL);
            RuleFor(he => he.STULOADNullable).DecimalLength(4, 1).WithLengthError(RuleNames.FD_STULOAD_AL);
            RuleFor(he => he.YEARSTUNullable).Length(1, 2).WithLengthError(RuleNames.FD_YEARSTU_AL);
            RuleFor(he => he.MSTUFEENullable).Length(1, 2).WithLengthError(RuleNames.FD_MSTUFEE_AL);
            RuleFor(he => he.PCOLABNullable).DecimalLength(4, 1).WithLengthError(RuleNames.FD_PCOLAB_AL);
            RuleFor(he => he.PCFLDCSNullable).DecimalLength(4, 1).WithLengthError(RuleNames.FD_PCFLDCS_AL);
            RuleFor(he => he.PCSLDCSNullable).DecimalLength(4, 1).WithLengthError(RuleNames.FD_PCSLDCS_AL);
            RuleFor(he => he.PCTLDCSNullable).DecimalLength(4, 1).WithLengthError(RuleNames.FD_PCTLDCS_AL);
            RuleFor(he => he.SPECFEENullable).Length(1, 1).WithLengthError(RuleNames.FD_SPECFEE_AL);
            RuleFor(he => he.NETFEENullable).Length(1, 6).WithLengthError(RuleNames.FD_NETFEE_AL);
            RuleFor(he => he.GROSSFEENullable).Length(1, 6).WithLengthError(RuleNames.FD_GROSSFEE_AL);
            RuleFor(he => he.DOMICILE).Length(1, 2).WithLengthError(RuleNames.FD_DOMICILE_AL);
            RuleFor(he => he.ELQNullable).Length(1, 1).WithLengthError(RuleNames.FD_ELQ_AL);
            RuleFor(he => he.HEPostCode).Length(1, 8).WithLengthError(RuleNames.FD_HEPostCode_AL);
        }
    }
}
