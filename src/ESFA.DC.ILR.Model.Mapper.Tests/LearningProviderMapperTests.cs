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
    public class LearningProviderMapperTests : AbstractMapperTests<Loose.MessageLearningProvider, MessageLearningProvider>
    {
        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_UKPRN()
        {
            TestMapperProperty(NewMapper(), m => m.UKPRN, TestInt, m => m.UKPRN, TestInt);
        }

        private LearningProviderMapper NewMapper()
        {
            return new LearningProviderMapper();
        }
    }
}
