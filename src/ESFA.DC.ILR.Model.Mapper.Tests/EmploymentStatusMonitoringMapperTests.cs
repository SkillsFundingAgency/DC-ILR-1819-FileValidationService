using ESFA.DC.ILR.Model.Mapper.Tests.Abstract;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class EmploymentStatusMonitoringMapperTests : AbstractMapperTests<Loose.MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring, MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring>
    {
        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_ESMCode()
        {
            TestMapperProperty(NewMapper(), m => m.ESMCode, TestIntSizedLong, m => m.ESMCode, TestInt);
        }

        [Fact]
        public void Map_ESMType()
        {
            TestMapperProperty(NewMapper(), m => m.ESMType, TestString, m => m.ESMType, TestString);
        }

        private EmploymentStatusMonitoringMapper NewMapper()
        {
            return new EmploymentStatusMonitoringMapper();
        }
    }
}
