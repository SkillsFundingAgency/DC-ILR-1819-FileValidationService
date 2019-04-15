using ESFA.DC.ILR.Model.Mapper.Tests.Abstract;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class AppFinRecordMapperTests : AbstractMapperTests<Loose.MessageLearnerLearningDeliveryAppFinRecord, MessageLearnerLearningDeliveryAppFinRecord>
    {
        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_AFinAmount()
        {
            TestMapperProperty(NewMapper(), m => m.AFinAmount, TestIntSizedLong, m => m.AFinAmount, TestInt);
        }

        [Fact]
        public void Map_AFinCode()
        {
            TestMapperProperty(NewMapper(), m => m.AFinCode, TestIntSizedLong, m => m.AFinCode, TestInt);
        }

        [Fact]
        public void Map_AFinDate()
        {
            TestMapperProperty(NewMapper(), m => m.AFinDate, TestDateTime, m => m.AFinDate, TestDateTime);
        }

        [Fact]
        public void Map_AFinType()
        {
            TestMapperProperty(NewMapper(), m => m.AFinType, TestString, m => m.AFinType, TestString);
            TestMapperProperty(NewMapper(), m => m.AFinType, TestStringLeadingAndTrailingWhiteSpace, m => m.AFinType, TestString);
        }
        
        private AppFinRecordMapper NewMapper()
        {
            return new AppFinRecordMapper();
        }
    }

}
