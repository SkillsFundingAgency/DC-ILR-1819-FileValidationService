using ESFA.DC.ILR.Model.Mapper.Interface;
using ESFA.DC.ILR.Model.Mapper.Tests.Abstract;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class LearnerDestinationAndProgressionMapperTests : AbstractMapperTests<Loose.MessageLearnerDestinationandProgression, MessageLearnerDestinationandProgression>
    {
        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_DPOutcome()
        {
            var inputCollection = NewArrayContaining<Loose.MessageLearnerDestinationandProgressionDPOutcome>();
            var outputCollection = NewArrayContaining<MessageLearnerDestinationandProgressionDPOutcome>();

            var propertyMapper = NewMockedModelCollectionMapper(inputCollection, outputCollection);

            var mapper = NewMapper(propertyMapper);

            TestMapperCollectionProperty(mapper, m => m.DPOutcome, inputCollection, m => m.DPOutcome, outputCollection);
        }

        [Fact]
        public void Map_LearnRefNumber()
        {
            TestMapperProperty(NewMapper(), m => m.LearnRefNumber, TestString, m => m.LearnRefNumber, TestString);
        }

        [Fact]
        public void Map_ULN()
        {
            TestMapperProperty(NewMapper(), m => m.ULN, TestLong, m => m.ULN, TestLong);
        }
        
        private LearnerDestinationAndProgressionMapper NewMapper(IModelMapper<Loose.MessageLearnerDestinationandProgressionDPOutcome, MessageLearnerDestinationandProgressionDPOutcome> dpOutcomeMapper = null)
        {
            return new LearnerDestinationAndProgressionMapper(dpOutcomeMapper ?? Mock.Of<IModelMapper<Loose.MessageLearnerDestinationandProgressionDPOutcome, MessageLearnerDestinationandProgressionDPOutcome>>());
        }
    }
}
