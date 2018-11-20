using ESFA.DC.ILR.Model.Mapper.Interface;
using ESFA.DC.ILR.Model.Mapper.Tests.Abstract;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class CollectionDetailsMapperTests : AbstractMapperTests<Loose.MessageHeaderCollectionDetails, MessageHeaderCollectionDetails>
    {

        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_Collection()
        {
            TestMapperProperty(NewMapper(), m => m.Collection, Loose.MessageHeaderCollectionDetailsCollection.ILR, m => m.Collection, MessageHeaderCollectionDetailsCollection.ILR);
        }

        [Fact]
        public void Map_FilePreparationDate()
        {
            TestMapperProperty(NewMapper(), m => m.FilePreparationDate, TestDateTime,  m => m.FilePreparationDate, TestDateTime);
        }

        [Fact]
        public void Map_Year()
        {
            TestMapperProperty(NewMapper(), m => m.Year, Loose.MessageHeaderCollectionDetailsYear.Item1819, m => m.Year, MessageHeaderCollectionDetailsYear.Item1819);
        }

        private CollectionDetailsMapper NewMapper()
        {
            return new CollectionDetailsMapper();
        }
    }
}
