using ESFA.DC.ILR.Model.Mapper.Tests.Abstract;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class ContactPreferenceMapperTests : AbstractMapperTests<Loose.MessageLearnerContactPreference, MessageLearnerContactPreference>
    {
        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_ContPrefType()
        {
            TestMapperProperty(NewMapper(), m => m.ContPrefType, TestString, m => m.ContPrefType, TestString);
        }

        [Fact]
        public void Map_ContPrefCode()
        {
            TestMapperProperty(NewMapper(), m => m.ContPrefCode, TestIntSizedLong, m => m.ContPrefCode, TestInt);
        }

        private ContactPreferenceMapper NewMapper()
        {
            return new ContactPreferenceMapper();
        }
    }
}
