using ESFA.DC.ILR.Model.Mapper.Interface;
using ESFA.DC.ILR.Model.Mapper.Tests.Abstract;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class LearningDeliveryHEMapperTests : AbstractMapperTests<Loose.MessageLearnerLearningDeliveryLearningDeliveryHE, MessageLearnerLearningDeliveryLearningDeliveryHE>
    {
        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_Domicile()
        {
            TestMapperProperty(NewMapper(), m => m.DOMICILE, TestString, m => m.DOMICILE, TestString);
            TestMapperProperty(NewMapper(), m => m.DOMICILE, TestStringLeadingAndTrailingWhiteSpace, m => m.DOMICILE, TestString);
        }

        [Fact]
        public void Map_ELQ()
        {
            TestMapperProperty(NewMapper(), m => m.ELQ, TestIntSizedLong, m => m.ELQ, TestInt);
        }

        [Fact]
        public void Map_ELQSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.ELQSpecified, TestBool, m => m.ELQSpecified, TestBool);
        }

        [Fact]
        public void Map_FUNDCOMP()
        {
            TestMapperProperty(NewMapper(), m => m.FUNDCOMP, TestIntSizedLong, m => m.FUNDCOMP, TestInt);
        }

        [Fact]
        public void Map_FUNDLEV()
        {
            TestMapperProperty(NewMapper(), m => m.FUNDLEV, TestIntSizedLong, m => m.FUNDLEV, TestInt);
        }

        [Fact]
        public void Map_GROSSFEE()
        {
            TestMapperProperty(NewMapper(), m => m.GROSSFEE, TestIntSizedLong, m => m.GROSSFEE, TestInt);
        }

        [Fact]
        public void Map_GROSSFEESpecified()
        {
            TestMapperProperty(NewMapper(), m => m.GROSSFEESpecified, TestBool, m => m.GROSSFEESpecified, TestBool);
        }

        [Fact]
        public void Map_HEPostCode()
        {
            TestMapperProperty(NewMapper(), m => m.HEPostCode, TestString, m => m.HEPostCode, TestString);
            TestMapperProperty(NewMapper(), m => m.HEPostCode, TestStringLeadingAndTrailingWhiteSpace, m => m.HEPostCode, TestString);
        }

        [Fact]
        public void Map_MODESTUD()
        {
            TestMapperProperty(NewMapper(), m => m.MODESTUD, TestIntSizedLong, m => m.MODESTUD, TestInt);
        }

        [Fact]
        public void Map_MSTUFEE()
        {
            TestMapperProperty(NewMapper(), m => m.MSTUFEE, TestIntSizedLong, m => m.MSTUFEE, TestInt);
        }

        [Fact]
        public void Map_NETFEE()
        {
            TestMapperProperty(NewMapper(), m => m.NETFEE, TestIntSizedLong, m => m.NETFEE, TestInt);
        }

        [Fact]
        public void Map_NETFEESpecified()
        {
            TestMapperProperty(NewMapper(), m => m.NETFEESpecified, TestBool, m => m.NETFEESpecified, TestBool);
        }

        [Fact]
        public void Map_NUMHUS()
        {
            TestMapperProperty(NewMapper(), m => m.NUMHUS, TestString, m => m.NUMHUS, TestString);
            TestMapperProperty(NewMapper(), m => m.NUMHUS, TestStringLeadingAndTrailingWhiteSpace, m => m.NUMHUS, TestString);
        }

        [Fact]
        public void Map_PCFLDCS()
        {
            TestMapperProperty(NewMapper(), m => m.PCFLDCS, TestDecimal, m => m.PCFLDCS, TestDecimal);
        }

        [Fact]
        public void Map_PCFLDCSSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.PCFLDCSSpecified, TestBool, m => m.PCFLDCSSpecified, TestBool);
        }

        [Fact]
        public void Map_PCOLAB()
        {
            TestMapperProperty(NewMapper(), m => m.PCOLAB, TestDecimal, m => m.PCOLAB, TestDecimal);
        }

        [Fact]
        public void Map_PCOLABSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.PCOLABSpecified, TestBool, m => m.PCOLABSpecified, TestBool);
        }

        [Fact]
        public void Map_PCSLDCS()
        {
            TestMapperProperty(NewMapper(), m => m.PCSLDCS, TestDecimal, m => m.PCSLDCS, TestDecimal);
        }

        [Fact]
        public void Map_PCSLDCSSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.PCSLDCSSpecified, TestBool, m => m.PCSLDCSSpecified, TestBool);
        }

        [Fact]
        public void Map_PCTLDCS()
        {
            TestMapperProperty(NewMapper(), m => m.PCTLDCS, TestDecimal, m => m.PCTLDCS, TestDecimal);
        }

        [Fact]
        public void Map_PCTLDCSSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.PCTLDCSSpecified, TestBool, m => m.PCTLDCSSpecified, TestBool);
        }

        [Fact]
        public void Map_QUALENT3()
        {
            TestMapperProperty(NewMapper(), m => m.QUALENT3, TestString, m => m.QUALENT3, TestString);
            TestMapperProperty(NewMapper(), m => m.QUALENT3, TestStringLeadingAndTrailingWhiteSpace, m => m.QUALENT3, TestString);
        }

        [Fact]
        public void Map_SEC()
        {
            TestMapperProperty(NewMapper(), m => m.SEC, TestIntSizedLong, m => m.SEC, TestInt);
        }

        [Fact]
        public void Map_SECSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.SECSpecified, TestBool, m => m.SECSpecified, TestBool);
        }

        [Fact]
        public void Map_SOC2000()
        {
            TestMapperProperty(NewMapper(), m => m.SOC2000, TestIntSizedLong, m => m.SOC2000, TestInt);
        }

        [Fact]
        public void Map_SOC2000Specified()
        {
            TestMapperProperty(NewMapper(), m => m.SOC2000Specified, TestBool, m => m.SOC2000Specified, TestBool);
        }

        [Fact]
        public void Map_SPECFEE()
        {
            TestMapperProperty(NewMapper(), m => m.SPECFEE, TestIntSizedLong, m => m.SPECFEE, TestInt);
        }

        [Fact]
        public void Map_SSN()
        {
            TestMapperProperty(NewMapper(), m => m.SSN, TestString, m => m.SSN, TestString);
            TestMapperProperty(NewMapper(), m => m.SSN, TestStringLeadingAndTrailingWhiteSpace, m => m.SSN, TestString);
        }

        [Fact]
        public void Map_STULOAD()
        {
            TestMapperProperty(NewMapper(), m => m.STULOAD, TestDecimal, m => m.STULOAD, TestDecimal);
        }

        [Fact]
        public void Map_STULOADSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.STULOADSpecified, TestBool, m => m.STULOADSpecified, TestBool);
        }

        [Fact]
        public void Map_TYPEYR()
        {
            TestMapperProperty(NewMapper(), m => m.TYPEYR, TestIntSizedLong, m => m.TYPEYR, TestInt);
        }

        [Fact]
        public void Map_UCASAPPID()
        {
            TestMapperProperty(NewMapper(), m => m.UCASAPPID, TestString, m => m.UCASAPPID, TestString);
            TestMapperProperty(NewMapper(), m => m.UCASAPPID, TestStringLeadingAndTrailingWhiteSpace, m => m.UCASAPPID, TestString);
        }

        [Fact]
        public void Map_YEARSTU()
        {
            TestMapperProperty(NewMapper(), m => m.YEARSTU, TestIntSizedLong, m => m.YEARSTU, TestInt);
        }
        
        private LearningDeliveryHEMapper NewMapper()
        {
            return new LearningDeliveryHEMapper();
        }
    }
}
