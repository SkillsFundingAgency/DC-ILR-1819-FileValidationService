using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.FileService.Interface;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.Model;
using ESFA.DC.Serialization.Interfaces;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Service.Tests
{
    public class FileValidationOutputServiceTests
    {
        [Fact]
        public async Task Output()
        {
            var cancellationToken = CancellationToken.None;

            var outputFileReference = "OutputFileReference";
            var outputContainer = "OutputContainer";
            var validationErrorsKey = "ValidationErrorsKey";

            var ilrFileContent = "IlrFileContent";

            var tightValidMessage = new Message();
            IEnumerable<IValidationError> validationErrors = new List<IValidationError>();
            Stream stream = new MemoryStream();

            var fileValidationContextMock = new Mock<IFileValidationContext>();
            var xmlSerializationServiceMock = new Mock<IXmlSerializationService>();
            var fileServiceMock = new Mock<IFileService>();
            var stronglyTypedKeyValuePersistenceService = new Mock<IStronglyTypedKeyValuePersistenceService>();

            fileServiceMock.Setup(s => s.OpenWriteStreamAsync(outputFileReference, outputContainer, cancellationToken)).Returns(Task.FromResult(stream)).Verifiable();

            fileValidationContextMock.SetupGet(c => c.OutputFileReference).Returns(outputFileReference);
            fileValidationContextMock.SetupGet(c => c.OutputContainer).Returns(outputContainer);
            fileValidationContextMock.SetupGet(c => c.ValidationErrorsKey).Returns(validationErrorsKey);

            xmlSerializationServiceMock.Setup(s => s.Serialize(tightValidMessage, stream)).Verifiable();

            stronglyTypedKeyValuePersistenceService.Setup(ps => ps.SaveAsync(validationErrorsKey, validationErrors, cancellationToken)).Returns(Task.CompletedTask).Verifiable();

            await NewService(xmlSerializationServiceMock.Object, fileServiceMock.Object, stronglyTypedKeyValuePersistenceService.Object)
                .OutputAsync(fileValidationContextMock.Object, tightValidMessage, validationErrors, cancellationToken);

            xmlSerializationServiceMock.VerifyAll();
            fileServiceMock.VerifyAll();
            stronglyTypedKeyValuePersistenceService.VerifyAll();
        }

        private FileValidationOutputService NewService(IXmlSerializationService xmlSerializationService = null, IFileService fileService = null, IStronglyTypedKeyValuePersistenceService stronglyTypedKeyValuePersistenceService = null)
        {
            return new FileValidationOutputService(xmlSerializationService, fileService, stronglyTypedKeyValuePersistenceService);
        }
    }
}
