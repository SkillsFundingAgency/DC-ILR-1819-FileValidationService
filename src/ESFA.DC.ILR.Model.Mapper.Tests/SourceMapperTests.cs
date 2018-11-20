using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.Model.Mapper.Tests.Abstract;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class SourceMapperTests : AbstractMapperTests<Loose.MessageHeaderSource, MessageHeaderSource>
    {
        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_ComponentSetVersion()
        {
            TestMapperProperty(NewMapper(), m => m.ComponentSetVersion, TestString, m => m.ComponentSetVersion, TestString);
        }

        [Fact]
        public void Map_DateTime()
        {
            TestMapperProperty(NewMapper(), m => m.DateTime, TestDateTime, m => m.DateTime, TestDateTime);
        }

        [Fact]
        public void Map_ProtectiveMarking()
        {
            TestMapperProperty(NewMapper(), m => m.ProtectiveMarking, Loose.MessageHeaderSourceProtectiveMarking.OFFICIALSENSITIVEPersonal, m => m.ProtectiveMarking, MessageHeaderSourceProtectiveMarking.OFFICIALSENSITIVEPersonal);
        }

        [Fact]
        public void Map_ReferenceData()
        {
            TestMapperProperty(NewMapper(), m => m.ReferenceData, TestString, m => m.ReferenceData, TestString);
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
        public void Map_UKPRN()
        {
            TestMapperProperty(NewMapper(), m => m.UKPRN, TestInt, m => m.UKPRN, TestInt);
        }

        private SourceMapper NewMapper()
        {
            return new SourceMapper();
        }
    }
}
