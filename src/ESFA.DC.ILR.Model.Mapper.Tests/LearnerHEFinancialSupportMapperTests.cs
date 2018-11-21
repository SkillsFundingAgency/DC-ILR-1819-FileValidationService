using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.Model.Mapper.Tests.Abstract;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class LearnerHEFinancialSupportMapperTests : AbstractMapperTests<Loose.MessageLearnerLearnerHELearnerHEFinancialSupport, MessageLearnerLearnerHELearnerHEFinancialSupport>
    {
        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_FINAMOUNT()
        {
            TestMapperProperty(NewMapper(), m => m.FINAMOUNT, TestIntSizedLong, m => m.FINAMOUNT, TestInt);
        }

        [Fact]
        public void Map_FINTYPE()
        {
            TestMapperProperty(NewMapper(), m => m.FINTYPE, TestIntSizedLong, m => m.FINTYPE, TestInt);
        }

        private LearnerHEFinancialSupportMapper NewMapper()
        {
            return new LearnerHEFinancialSupportMapper();
        }
    }
}
