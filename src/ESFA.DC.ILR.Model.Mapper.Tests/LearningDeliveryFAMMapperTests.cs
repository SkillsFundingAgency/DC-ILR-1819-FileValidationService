using ESFA.DC.ILR.Model.Mapper.Tests.Abstract;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class LearningDeliveryFAMMapperTests : AbstractMapperTests<Loose.MessageLearnerLearningDeliveryLearningDeliveryFAM, MessageLearnerLearningDeliveryLearningDeliveryFAM>
    {
        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_LearnDelFAMCode()
        {
            TestMapperProperty(NewMapper(), m => m.LearnDelFAMCode, TestString, m => m.LearnDelFAMCode, TestString);
            TestMapperProperty(NewMapper(), m => m.LearnDelFAMCode, TestStringLeadingAndTrailingWhiteSpace, m => m.LearnDelFAMCode, TestString);
        }

        [Fact]
        public void Map_LearnDelFAMDateFrom()
        {
            TestMapperProperty(NewMapper(), m => m.LearnDelFAMDateFrom, TestDateTime, m => m.LearnDelFAMDateFrom, TestDateTime);
        }

        [Fact]
        public void Map_LearnDelFAMDateFromSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.LearnDelFAMDateFromSpecified, TestBool, m => m.LearnDelFAMDateFromSpecified, TestBool);
        }

        [Fact]
        public void Map_LearnDelFAMDateTo()
        {
            TestMapperProperty(NewMapper(), m => m.LearnDelFAMDateTo, TestDateTime, m => m.LearnDelFAMDateTo, TestDateTime);
        }

        [Fact]
        public void Map_LearnDelFAMDateToSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.LearnDelFAMDateToSpecified, TestBool, m => m.LearnDelFAMDateToSpecified, TestBool);
        }

        [Fact]
        public void Map_LearnDelFAMType()
        {
            TestMapperProperty(NewMapper(), m => m.LearnDelFAMType, TestString, m => m.LearnDelFAMType, TestString);
        }

        private LearningDeliveryFAMMapper NewMapper()
        {
            return new LearningDeliveryFAMMapper();
        }
    }
}
