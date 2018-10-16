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
            TestRuleFor(he => he.NUMHUS, "FD_NUMHUS_AP", "NUMHUS", "`");
        }

        [Fact]
        public void FD_SSN_AP()
        {
            TestRuleFor(he => he.SSN, "FD_SSN_AP", "SSN", "`");
        }

        [Fact]
        public void FD_QUALENT3_AP()
        {
            TestRuleFor(he => he.QUALENT3, "FD_QUALENT3_AP", "QUALENT3", "`");
        }

        [Fact]
        public void FD_UCASAPPID_AP()
        {
            TestRuleFor(he => he.UCASAPPID, "FD_UCASAPPID_AP", "AB12", "!");
        }

        [Fact]
        public void FD_DOMICILE_AP()
        {
            TestRuleFor(he => he.DOMICILE, "FD_DOMICILE_AP", "DOMICILE", "`");
        }

        [Fact]
        public void FD_HEPostCode_AP()
        {
            TestRuleFor(he => he.HEPostCode, "FD_HEPostCode_AP", "HEPostCode_AP", "`");
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
    }
}
