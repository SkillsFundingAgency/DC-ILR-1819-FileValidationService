using ESFA.DC.ILR.Model.Mapper.Tests.Abstract;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class ProviderSpecLearnerMonitoringMapperTests : AbstractMapperTests<Loose.MessageLearnerProviderSpecLearnerMonitoring, MessageLearnerProviderSpecLearnerMonitoring>
    {
        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_ProvSpecLearnMon()
        {
            TestMapperProperty(NewMapper(), m => m.ProvSpecLearnMon, TestString, m => m.ProvSpecLearnMon, TestString);
        }

        [Fact]
        public void Map_ProvSpecLearnMonOccur()
        {
            TestMapperProperty(NewMapper(), m => m.ProvSpecLearnMonOccur, TestString, m => m.ProvSpecLearnMonOccur, TestString);
        }
        
        private ProviderSpecLearnerMonitoringMapper NewMapper()
        {
            return new ProviderSpecLearnerMonitoringMapper();
        }
    }
}
