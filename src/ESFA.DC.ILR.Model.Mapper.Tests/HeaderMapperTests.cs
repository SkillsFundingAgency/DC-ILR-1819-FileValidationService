using ESFA.DC.ILR.Model.Mapper.Interface;
using ESFA.DC.ILR.Model.Mapper.Tests.Abstract;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class HeaderMapperTests : AbstractMapperTests<Loose.MessageHeader, MessageHeader>
    {
        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_CollectionDetails()
        {
            var input = new Loose.MessageHeaderCollectionDetails();
            var output = new MessageHeaderCollectionDetails();

            var propertyMapper = NewMockedModelMapper(input, output);

            var mapper = NewMapper(propertyMapper);

            TestMapperProperty(mapper, m => m.CollectionDetails, input, m => m.CollectionDetails, output);
        }

        [Fact]
        public void Map_Source()
        {
            var input = new Loose.MessageHeaderSource();
            var output = new MessageHeaderSource();

            var propertyMapper = NewMockedModelMapper(input, output);

            var mapper = NewMapper(sourceMapper: propertyMapper);

            TestMapperProperty(mapper, m => m.Source, input, m => m.Source, output);
        }

        private HeaderMapper NewMapper(
            IModelMapper<Loose.MessageHeaderCollectionDetails, MessageHeaderCollectionDetails> collectionDetailsMapper = null,
            IModelMapper<Loose.MessageHeaderSource, MessageHeaderSource> sourceMapper = null)
        {
            return new HeaderMapper(
                collectionDetailsMapper ?? Mock.Of<IModelMapper<Loose.MessageHeaderCollectionDetails, MessageHeaderCollectionDetails>>(),
                sourceMapper ?? Mock.Of<IModelMapper<Loose.MessageHeaderSource, MessageHeaderSource>>());
        }

    }
}
