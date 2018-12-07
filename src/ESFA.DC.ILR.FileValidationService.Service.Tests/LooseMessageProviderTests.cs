using System.IO;
using ESFA.DC.FileService.Interface;
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

            Stream stream = new MemoryStream();

            var looseMessage = new Message();

            var fileValidationContextMock = new Mock<IFileValidationContext>();
            var fileServiceMock = new Mock<IFileService>();
            var xsdValidationServiceMock = new Mock<IXsdValidationService>();
            var xmlSerializationServiceMock = new Mock<IXmlSerializationService>();

            fileValidationContextMock.SetupGet(c => c.FileReference).Returns(fileReference);
            fileValidationContextMock.SetupGet(c => c.Container).Returns(container);

            fileServiceMock.Setup(s => s.OpenReadStreamAsync(fileReference, container, cancellationToken)).Returns(Task.FromResult(stream)).Verifiable();
            xsdValidationServiceMock.Setup(s => s.Validate(stream)).Verifiable();
            xmlSerializationServiceMock.Setup(s => s.Deserialize<Message>(stream)).Returns(looseMessage).Verifiable();

            var providedMessage = await NewProvider(fileServiceMock.Object, xmlSerializationServiceMock.Object, xsdValidationServiceMock.Object).ProvideAsync(fileValidationContextMock.Object, cancellationToken);

            providedMessage.Should().Be(looseMessage);
            
            fileServiceMock.VerifyAll();
            xsdValidationServiceMock.VerifyAll();
            xmlSerializationServiceMock.VerifyAll();

            //using (var stream = await _fileService.OpenReadStreamAsync(fileValidationContext.FileReference, fileValidationContext.Container, cancellationToken))
            //{
            //    _xsdValidationService.Validate(stream);

            //    stream.Position = 0;

            //    return _xmlSerializationService.Deserialize<Message>(stream);
            //}
        }

        private LooseMessageProvider NewProvider(IFileService fileService = null, IXmlSerializationService xmlSerializationService = null, IXsdValidationService xsdValidationService = null)
        {
            return new LooseMessageProvider(fileService, xmlSerializationService, xsdValidationService);
        }
    }
}
