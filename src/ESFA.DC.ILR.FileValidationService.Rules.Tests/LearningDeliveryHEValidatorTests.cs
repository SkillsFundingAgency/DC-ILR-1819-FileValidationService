using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class LearningDeliveryHEValidatorTests : AbstractValidatorTests<ILooseLearningDeliveryHE>
    {
        public LearningDeliveryHEValidatorTests()
            : base(new LearningDeliveryHEValidator())
        {
        }

        [Fact]
        public void FD_NUMHUS_AP()
        {
            TestRegexRuleFor(he => he.NUMHUS, "FD_NUMHUS_AP", "NUMHUS", "`");
        }

        [Fact]
        public void FD_SSN_AP()
        {
            TestRegexRuleFor(he => he.SSN, "FD_SSN_AP", "SSN", "`");
        }

        [Fact]
        public void FD_QUALENT3_AP()
        {
            TestRegexRuleFor(he => he.QUALENT3, "FD_QUALENT3_AP", "QUALENT3", "`");
        }

        [Fact]
        public void FD_UCASAPPID_AP()
        {
            TestRegexRuleFor(he => he.UCASAPPID, "FD_UCASAPPID_AP", "AB12", "!");
        }

        [Fact]
        public void FD_DOMICILE_AP()
        {
            TestRegexRuleFor(he => he.DOMICILE, "FD_DOMICILE_AP", "DOMICILE", "`");
        }

        [Fact]
        public void FD_HEPostCode_AP()
        {
            TestRegexRuleFor(he => he.HEPostCode, "FD_HEPostCode_AP", "HEPostCode_AP", "`");
        }

        [Fact]
        public void FD_TYPEYR_MA()
        {
            TestMandatoryLongAttributeRuleFor(fd => fd.TYPEYRNullable, "FD_TYPEYR_MA");
        }

        [Fact]
        public void FD_MODESTUD_MA()
        {
            TestMandatoryLongAttributeRuleFor(fd => fd.MODESTUDNullable, "FD_MODESTUD_MA");
        }

        [Fact]
        public void FD_FUNDLEV_MA()
        {
            TestMandatoryLongAttributeRuleFor(fd => fd.FUNDLEVNullable, "FD_FUNDLEV_MA");
        }

        [Fact]
        public void FD_FUNDCOMP_MA()
        {
            TestMandatoryLongAttributeRuleFor(fd => fd.FUNDCOMPNullable, "FD_FUNDCOMP_MA");
        }

        [Fact]
        public void FD_YEARSTU_MA()
        {
            TestMandatoryLongAttributeRuleFor(fd => fd.YEARSTUNullable, "FD_YEARSTU_MA");
        }

        [Fact]
        public void FD_MSTUFEE_MA()
        {
            TestMandatoryLongAttributeRuleFor(fd => fd.MSTUFEENullable, "FD_MSTUFEE_MA");
        }

        [Fact]
        public void FD_SPECFEE_MA()
        {
            TestMandatoryLongAttributeRuleFor(fd => fd.SPECFEENullable, "FD_SPECFEE_MA");
        }

        [Fact]
        public void FD_NUMHUS_AL()
        {
            TestLengthStringRuleFor(fd => fd.NUMHUS, "FD_NUMHUS_AL", "NUMHUS", 1, 20);
        }

        [Fact]
        public void FD_SSN_AL()
        {
            TestLengthStringRuleFor(fd => fd.SSN, "FD_SSN_AL", "SSN", 1, 13);
        }

        [Fact]
        public void FD_QUALENT3_AL()
        {
            TestLengthStringRuleFor(fd => fd.QUALENT3, "FD_QUALENT3_AL", "QUALENT3", 1, 3);
        }

        [Fact]
        public void FD_SOC2000_AL()
        {
            TestLengthLongRuleFor(fd => fd.SOC2000Nullable, "FD_SOC2000_AL", "SOC2000", 1, 4);
        }

        [Fact]
        public void FD_SEC_AL()
        {
            TestLengthLongRuleFor(fd => fd.SECNullable, "FD_SEC_AL", "SEC", 1, 1);
        }

        [Fact]
        public void FD_UCASAPPID_AL()
        {
            TestLengthStringRuleFor(fd => fd.UCASAPPID, "FD_UCASAPPID_AL", "UCASAPPID", 1, 9);
        }

        [Fact]
        public void FD_TYPEYR_AL()
        {
            TestLengthLongRuleFor(fd => fd.TYPEYRNullable, "FD_TYPEYR_AL", "TYPEYR", 1, 1);
        }

        [Fact]
        public void FD_MODESTUD_AL()
        {
            TestLengthLongRuleFor(fd => fd.MODESTUDNullable, "FD_MODESTUD_AL", "MODESTUD", 1, 2);
        }

        [Fact]
        public void FD_FUNDLEV_AL()
        {
            TestLengthLongRuleFor(fd => fd.FUNDLEVNullable, "FD_FUNDLEV_AL", "FUNDLEV", 1, 2);
        }

        [Fact]
        public void FD_FUNDCOMP_AL()
        {
            TestLengthLongRuleFor(fd => fd.FUNDCOMPNullable, "FD_FUNDCOMP_AL", "FUNDCOMP", 1, 1);
        }

        [Fact]
        public void FD_STULOAD_AL()
        {
            TestLengthDecimalRuleFor(fd => fd.STULOADNullable, "FD_STULOAD_AL", "STULOAD", 4, 1);
        }

        [Fact]
        public void FD_YEARSTU_AL()
        {
            TestLengthLongRuleFor(fd => fd.YEARSTUNullable, "FD_YEARSTU_AL", "YEARSTU", 1, 2);
        }

        [Fact]
        public void FD_MSTUFEE_AL()
        {
            TestLengthLongRuleFor(fd => fd.MSTUFEENullable, "FD_MSTUFEE_AL", "MSTUFEE", 1, 2);
        }

        [Fact]
        public void FD_PCOLAB_AL()
        {
            TestLengthDecimalRuleFor(fd => fd.PCOLABNullable, "FD_PCOLAB_AL", "PCOLAB", 4, 1);
        }

        [Fact]
        public void FD_PCFLDCS_AL()
        {
            TestLengthDecimalRuleFor(fd => fd.PCFLDCSNullable, "FD_PCFLDCS_AL", "PCFLDCS", 4, 1);
        }

        [Fact]
        public void FD_PCSLDCS_AL()
        {
            TestLengthDecimalRuleFor(fd => fd.PCSLDCSNullable, "FD_PCSLDCS_AL", "PCSLDCS", 4, 1);
        }

        [Fact]
        public void FD_PCTLDCS_AL()
        {
            TestLengthDecimalRuleFor(fd => fd.PCTLDCSNullable, "FD_PCTLDCS_AL", "PCTLDCS", 4, 1);
        }

        [Fact]
        public void FD_SPECFEE_AL()
        {
            TestLengthLongRuleFor(he => he.SPECFEENullable, "FD_SPECFEE_AL", "SPECFEE", 1, 1);
        }

        [Fact]
        public void FD_NETFEE_AL()
        {
            TestLengthLongRuleFor(he => he.NETFEENullable, "FD_NETFEE_AL", "NETFEE", 1, 6);
        }

        [Fact]
        public void FD_GROSSFEE_AL()
        {
            TestLengthLongRuleFor(he => he.GROSSFEENullable, "FD_GROSSFEE_AL", "GROSSFEE", 1, 6);
        }

        [Fact]
        public void FD_DOMICILE_AL()
        {
            TestLengthStringRuleFor(he => he.DOMICILE, "FD_DOMICILE_AL", "DOMICILE", 1, 2);
        }

        [Fact]
        public void FD_ELQ_AL()
        {
            TestLengthLongRuleFor(he => he.ELQNullable, "FD_ELQ_AL", "ELQ", 1, 1);
        }

        [Fact]
        public void FD_HEPostCode_AL()
        {
            TestLengthStringRuleFor(he => he.HEPostCode, "FD_HEPostCode_AL", "HEPostCode", 1, 8);
        }

        [Fact]
        public void FD_STULOAD_AR()
        {
            TestRangeFor(he => he.STULOADNullable, "FD_STULOAD_AR", "STULOAD", 0.1m, 300.0m);
        }

        [Fact]
        public void FD_YEARSTU_AR()
        {
            TestRangeFor(he => he.YEARSTUNullable, "FD_YEARSTU_AR", "YEARSTU", 1, 98);
        }

        [Fact]
        public void FD_PCOLAB_AR()
        {
            TestRangeFor(he => he.PCOLABNullable, "FD_PCOLAB_AR", "PCOLAB", 0.1m, 100.0m);
        }

        [Fact]
        public void FD_PCFLDCS_AR()
        {
            TestRangeFor(he => he.PCFLDCSNullable, "FD_PCFLDCS_AR", "PCFLDCS", 0m, 100.0m);
        }

        [Fact]
        public void FD_PCSLDCS_AR()
        {
            TestRangeFor(he => he.PCSLDCSNullable, "FD_PCSLDCS_AR", "PCSLDCS", 0m, 100.0m);
        }

        [Fact]
        public void FD_PCTLDCS_AR()
        {
            TestRangeFor(he => he.PCTLDCSNullable, "FD_PCTLDCS_AR", "PCTLDCS", 0m, 100.0m);
        }

        [Fact]
        public void FD_NETFEE_AR()
        {
            TestRangeFor(he => he.NETFEENullable, "FD_NETFEE_AR", "NETFEE", 0, 999999);
        }

        [Fact]
        public void FD_GROSSFEE_AR()
        {
            TestRangeFor(he => he.GROSSFEENullable, "FD_GROSSFEE_AR", "GROSSFEE", 0, 999999);
        }
    }
}
