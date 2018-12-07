using ESFA.DC.ILR.Model.Mapper.Tests.Abstract;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class SourceFileMapperTests : AbstractMapperTests<Loose.MessageSourceFile, MessageSourceFile>
    {

        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_DateTime()
        {
            TestMapperProperty(NewMapper(), m => m.DateTime, TestDateTime, m => m.DateTime, TestDateTime);
        }

        [Fact]
        public void Map_DateTimeSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.DateTimeSpecified, TestBool, m => m.DateTimeSpecified, TestBool);
        }

        [Fact]
        public void Map_FilePreparationDate()
        {
            TestMapperProperty(NewMapper(), m => m.FilePreparationDate, TestDateTime, m => m.FilePreparationDate, TestDateTime);
        }

        [Fact]
        public void Map_Release()
        {
            TestMapperProperty(NewMapper(), m => m.Release, TestString, m => m.Release, TestString);
        }

        [Fact]
        public void Map_SerialNo()
        {
            TestMapperProperty(NewMapper(), m => m.SerialNo, TestString, m => m.SerialNo, TestString);
        }

        [Fact]
        public void Map_SoftwarePackage()
        {
            TestMapperProperty(NewMapper(), m => m.SoftwarePackage, TestString, m => m.SoftwarePackage, TestString);
        }

        [Fact]
        public void Map_SoftwareSupplier()
        {
            TestMapperProperty(NewMapper(), m => m.SoftwareSupplier, TestString, m => m.SoftwareSupplier, TestString);
        }

        [Fact]
        public void Map_SourceFileName()
        {
            TestMapperProperty(NewMapper(), m => m.SourceFileName, TestString, m => m.SourceFileName, TestString);
        }

        private SourceFileMapper NewMapper()
        {
            return new SourceFileMapper();
        }
    }
}
