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
    public class ProviderSpecDeliveryMonitoringMapperTests : AbstractMapperTests<Loose.MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring, MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring>
    {
        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_ProvSpecDelMonOccur()
        {
            TestMapperProperty(NewMapper(), m => m.ProvSpecDelMonOccur, TestString, m => m.ProvSpecDelMonOccur, TestString);
            TestMapperProperty(NewMapper(), m => m.ProvSpecDelMonOccur, TestStringLeadingAndTrailingWhiteSpace, m => m.ProvSpecDelMonOccur, TestString);
        }

        [Fact]
        public void Map_ProvSpecDelMon()
        {
            TestMapperProperty(NewMapper(), m => m.ProvSpecDelMon, TestString, m => m.ProvSpecDelMon, TestString);
            TestMapperProperty(NewMapper(), m => m.ProvSpecDelMon, TestStringLeadingAndTrailingWhiteSpace, m => m.ProvSpecDelMon, TestString);
        }

        private ProviderSpecLearningDeliveryMonitoringMapper NewMapper()
        {
            return new ProviderSpecLearningDeliveryMonitoringMapper();
        }
    }
}
