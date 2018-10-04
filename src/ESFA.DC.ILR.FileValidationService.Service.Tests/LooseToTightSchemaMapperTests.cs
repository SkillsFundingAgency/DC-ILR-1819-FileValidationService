using System.Linq;
using ESFA.DC.ILR.Model.Loose;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Service.Tests
{
    public class LooseToTightSchemaMapperTests
    {
        [Fact]
        public void Map()
        {
            var loose = new Model.Loose.Message()
            {
                Header = new MessageHeader()
                {
                    Source = new MessageHeaderSource()
                    {
                        ComponentSetVersion = "TestCompSetVersion",
                    }
                },
                Learner =  new []
                {
                    new MessageLearner()
                    {
                        ALSCost = 1,
                        ALSCostSpecified = false,
                        Accom = 1,
                        Email = "HELLO",
                    }
                }
            };

            var service = new LooseToTightSchemaMapper();

            var tight = service.Map(loose);

            tight.Header.Source.ComponentSetVersion.Should().Be("TestCompSetVersion");
            tight.Learner.Should().HaveCount(1);
            tight.Learner.First().Accom.Should().Be(1);
            tight.Learner.First().Email.Should().Be("HELLO");
        }
    }
}
