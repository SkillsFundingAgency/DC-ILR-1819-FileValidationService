using ESFA.DC.ILR.Model.Mapper.Interface;
using ESFA.DC.ILR.Model.Mapper.Tests.Abstract;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class LearnerHEMapperTests : AbstractMapperTests<Loose.MessageLearnerLearnerHE, MessageLearnerLearnerHE>
    {
        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_LearnerHEFinancialSupport()
        {
            var inputCollection = NewArrayContaining<Loose.MessageLearnerLearnerHELearnerHEFinancialSupport>();
            var outputCollection = NewArrayContaining<MessageLearnerLearnerHELearnerHEFinancialSupport>();

            var propertyMapper = NewMockedModelCollectionMapper(inputCollection, outputCollection);

            var mapper = NewMapper(propertyMapper);

            TestMapperCollectionProperty(mapper, m => m.LearnerHEFinancialSupport, inputCollection, m => m.LearnerHEFinancialSupport, outputCollection);
        }

        [Fact]
        public void Map_TTACOM()
        {
            TestMapperProperty(NewMapper(), m => m.TTACCOM, TestIntSizedLong, m => m.TTACCOM, TestInt);
        }

        [Fact]
        public void Map_TTACOMSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.TTACCOMSpecified, TestBool, m => m.TTACCOMSpecified, TestBool);
        }

        [Fact]
        public void Map_UCASPERID()
        {
            TestMapperProperty(NewMapper(), m => m.UCASPERID, TestString, m => m.UCASPERID, TestString);
        }
        
        private LearnerHEMapper NewMapper(IModelMapper<Loose.MessageLearnerLearnerHELearnerHEFinancialSupport, MessageLearnerLearnerHELearnerHEFinancialSupport> learnerHEFinancialSupportMapper = null)
        {
            return new LearnerHEMapper(learnerHEFinancialSupportMapper ?? Mock.Of<IModelMapper<Loose.MessageLearnerLearnerHELearnerHEFinancialSupport, MessageLearnerLearnerHELearnerHEFinancialSupport>>());
        }
    }
}
