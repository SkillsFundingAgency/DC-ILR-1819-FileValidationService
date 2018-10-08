using ESFA.DC.FileService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.Model.Loose;
using ESFA.DC.Serialization.Interfaces;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Service.Tests
{
    public class LooseMessageProviderTests
    {
        [Fact]
        public async Task Provide()
        {
            var cancellationToken = CancellationToken.None;

            var fileReference = "FileReference";
            var container = "Container";

            var looseMessageContent = "Content";

            var looseMessage = new Message();

            var fileValidationContextMock = new Mock<IFileValidationContext>();
            var fileServiceMock = new Mock<IFileService>();
            var xmlSerializationServiceMock = new Mock<IXmlSerializationService>();

            fileValidationContextMock.SetupGet(c => c.FileReference).Returns(fileReference);
            fileValidationContextMock.SetupGet(c => c.Container).Returns(container);

            fileServiceMock.Setup(s => s.ReadStringAsync(fileReference, container, cancellationToken, null)).Returns(Task.FromResult(looseMessageContent)).Verifiable();
            xmlSerializationServiceMock.Setup(s => s.Deserialize<Message>(looseMessageContent)).Returns(looseMessage).Verifiable();

            var providedMessage = await NewProvider(fileServiceMock.Object, xmlSerializationServiceMock.Object).ProvideAsync(fileValidationContextMock.Object, cancellationToken);

            providedMessage.Should().Be(looseMessage);

            fileServiceMock.VerifyAll();
            xmlSerializationServiceMock.VerifyAll();
        }

        private LooseMessageProvider NewProvider(IFileService fileService = null, IXmlSerializationService xmlSerializationService = null)
        {
            return new LooseMessageProvider(fileService, xmlSerializationService);
        }
    }
}
