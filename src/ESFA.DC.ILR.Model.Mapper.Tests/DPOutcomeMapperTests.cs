using ESFA.DC.ILR.Model.Mapper.Tests.Abstract;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class DPOutcomeMapperTests : AbstractMapperTests<Loose.MessageLearnerDestinationandProgressionDPOutcome, MessageLearnerDestinationandProgressionDPOutcome>
    {
        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_OutCode()
        {
            TestMapperProperty(NewMapper(), m => m.OutCode, TestIntSizedLong, m => m.OutCode, TestInt);
        }

        [Fact]
        public void Map_OutCollDate()
        {
            TestMapperProperty(NewMapper(), m => m.OutCollDate, TestDateTime, m => m.OutCollDate, TestDateTime);
        }

        [Fact]
        public void Map_OutEndDate()
        {
            TestMapperProperty(NewMapper(), m => m.OutEndDate, TestDateTime, m => m.OutEndDate, TestDateTime);
        }

        [Fact]
        public void Map_OutEndDateSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.OutEndDateSpecified, TestBool, m => m.OutEndDateSpecified, TestBool);
        }

        [Fact]
        public void Map_OutStartDate()
        {
            TestMapperProperty(NewMapper(), m => m.OutStartDate, TestDateTime, m => m.OutStartDate, TestDateTime);
        }

        [Fact]
        public void Map_OutType()
        {
            TestMapperProperty(NewMapper(), m => m.OutType, TestString, m => m.OutType, TestString);
            TestMapperProperty(NewMapper(), m => m.OutType, TestStringLeadingAndTrailingWhiteSpace, m => m.OutType, TestString);
        }

        private DPOutcomeMapper NewMapper()
        {
            return new DPOutcomeMapper();
        }
    }
}
