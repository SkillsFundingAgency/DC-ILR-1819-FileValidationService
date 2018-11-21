using System.Linq;
using ESFA.DC.ILR.Model.Mapper.Interface;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Service.Tests
{
    public class LooseToTightSchemaMapperTests
    {
        [Fact]
        public void Map()
        {
            var loose = new Model.Loose.Message();

            var tight = new Model.Message();

            var messageMapperMock = new Mock<IModelMapper<Model.Loose.Message, Model.Message>>();
            
            messageMapperMock.Setup(m => m.Map(loose)).Returns(tight).Verifiable();

            var service = new LooseToTightSchemaMapper(messageMapperMock.Object);

            service.MapTo(loose).Should().BeSameAs(tight);
        }
    }
}
