using ESFA.DC.ILR.Model.Mapper.Tests.Abstract;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class LearnerFAMMapperTests : AbstractMapperTests<Loose.MessageLearnerLearnerFAM, MessageLearnerLearnerFAM>
    {
        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_LearnFAMCode()
        {
            TestMapperProperty(NewMapper(), m => m.LearnFAMCode, TestIntSizedLong, m => m.LearnFAMCode, TestInt);
        }

        [Fact]
        public void Map_LearnFAMType()
        {
            TestMapperProperty(NewMapper(), m => m.LearnFAMType, TestString, m => m.LearnFAMType, TestString);
            TestMapperProperty(NewMapper(), m => m.LearnFAMType, TestStringLeadingAndTrailingWhiteSpace, m => m.LearnFAMType, TestString);
        }

        private LearnerFAMMapper NewMapper()
        {
            return new LearnerFAMMapper();
        }
    }
}
