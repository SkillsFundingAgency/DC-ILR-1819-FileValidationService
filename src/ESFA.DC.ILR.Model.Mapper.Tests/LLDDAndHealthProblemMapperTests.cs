using ESFA.DC.ILR.Model.Mapper.Tests.Abstract;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class LLDDAndHealthProblemMapperTests : AbstractMapperTests<Loose.MessageLearnerLLDDandHealthProblem,
        MessageLearnerLLDDandHealthProblem>
    {
        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_LLDDCat()
        {
            TestMapperProperty(NewMapper(), m => m.LLDDCat, TestIntSizedLong, m => m.LLDDCat, TestInt);
        }

        [Fact]
        public void Map_PrimaryLLDD()
        {
            TestMapperProperty(NewMapper(), m => m.PrimaryLLDD, TestIntSizedLong, m => m.PrimaryLLDD, TestInt);
        }


        [Fact]
        public void Map_PrimaryLLDDSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.PrimaryLLDDSpecified, TestBool, m => m.PrimaryLLDDSpecified, TestBool);
        }
        
        private LLDDAndHealthProblemMapper NewMapper()
        {
            return new LLDDAndHealthProblemMapper();
        }
    }

}
