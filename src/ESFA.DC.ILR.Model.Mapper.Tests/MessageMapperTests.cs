using ESFA.DC.ILR.Model.Mapper.Interface;
using ESFA.DC.ILR.Model.Mapper.Tests.Abstract;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class MessageMapperTests : AbstractMapperTests<Loose.Message, Message>
    {
        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_Header()
        {
            var input = new Loose.MessageHeader();
            var output = new MessageHeader();

            var propertyMapper = NewMockedModelMapper(input, output);

            var mapper = NewMapper(propertyMapper);

            TestMapperProperty(mapper, m => m.Header, input, m => m.Header, output);
        }

        [Fact]
        public void Map_LearningProvider()
        {
            var input = new Loose.MessageLearningProvider();
            var output = new MessageLearningProvider();

            var propertyMapper = NewMockedModelMapper(input, output);

            var mapper = NewMapper(learningProviderMapper: propertyMapper);

            TestMapperProperty(mapper, m => m.LearningProvider, input, m => m.LearningProvider, output);
        }

        [Fact]
        public void Map_SourceFiles()
        {
            var inputCollection = NewArrayContaining<Loose.MessageSourceFile>();
            var outputCollection = NewArrayContaining<MessageSourceFile>();
            
            var propertyMapper = NewMockedModelCollectionMapper(inputCollection, outputCollection);

            var mapper = NewMapper(sourceFileMapper: propertyMapper);

            TestMapperCollectionProperty(mapper, m => m.SourceFiles, inputCollection, m => m.SourceFiles, outputCollection);
        }

        [Fact]
        public void Map_Learners()
        {
            var inputCollection = NewArrayContaining<Loose.MessageLearner>();
            var outputCollection = NewArrayContaining<MessageLearner>();

            var propertyMapper = NewMockedModelCollectionMapper(inputCollection, outputCollection);

            var mapper = NewMapper(learnerMapper: propertyMapper);

            TestMapperCollectionProperty(mapper, m => m.Learner, inputCollection, m => m.Learner, outputCollection);
        }

        [Fact]
        public void Map_LearnerDestinationAndProgressions()
        {
            var inputCollection = NewArrayContaining<Loose.MessageLearnerDestinationandProgression>();
            var outputCollection = NewArrayContaining<MessageLearnerDestinationandProgression>();

            var propertyMapper = NewMockedModelCollectionMapper(inputCollection, outputCollection);

            var mapper = NewMapper(destinationAndProgressionMapper: propertyMapper);

            TestMapperCollectionProperty(mapper, m => m.LearnerDestinationandProgression, inputCollection, m => m.LearnerDestinationandProgression, outputCollection);
        }
        
        private MessageMapper NewMapper(
            IModelMapper<Loose.MessageHeader, MessageHeader> headerMapper = null,
            IModelMapper<Loose.MessageLearningProvider, MessageLearningProvider> learningProviderMapper = null,
            IModelMapper<Loose.MessageSourceFile, MessageSourceFile> sourceFileMapper = null,
            IModelMapper<Loose.MessageLearner, MessageLearner> learnerMapper = null,
            IModelMapper<Loose.MessageLearnerDestinationandProgression, MessageLearnerDestinationandProgression> destinationAndProgressionMapper = null)
        {
            return new MessageMapper(
                headerMapper ?? Mock.Of<IModelMapper<Loose.MessageHeader, MessageHeader>>(),
                learningProviderMapper ?? Mock.Of<IModelMapper<Loose.MessageLearningProvider, MessageLearningProvider>>(),
                sourceFileMapper ?? Mock.Of<IModelMapper<Loose.MessageSourceFile, MessageSourceFile>>(),
                learnerMapper ?? Mock.Of<IModelMapper<Loose.MessageLearner, MessageLearner>>(),
                destinationAndProgressionMapper ?? Mock.Of<IModelMapper<Loose.MessageLearnerDestinationandProgression, MessageLearnerDestinationandProgression>>());
        }
    }
}
