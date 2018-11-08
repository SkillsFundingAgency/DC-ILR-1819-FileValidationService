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

            var fileReference = @"UKPRN/OutputFileReference.xml";
            var tightFileReference = @"UKPRN/OutputFileReference_Tight.xml";
            var container = "Container";
            var validationErrorsKey = "ValidationErrorsKey";

            var ilrFileContent = "IlrFileContent";

            var tightValidMessage = new Message();
            IEnumerable<IValidationError> validationErrors = new List<IValidationError>();
            Stream stream = new MemoryStream();

            var fileValidationContextMock = new Mock<IFileValidationContext>();
            var xmlSerializationServiceMock = new Mock<IXmlSerializationService>();
            var fileServiceMock = new Mock<IFileService>();
            var stronglyTypedKeyValuePersistenceService = new Mock<IStronglyTypedKeyValuePersistenceService>();

            fileServiceMock.Setup(s => s.OpenWriteStreamAsync(tightFileReference, container, cancellationToken)).Returns(Task.FromResult(stream)).Verifiable();

            fileValidationContextMock.SetupGet(c => c.FileReference).Returns(fileReference).Verifiable();
            fileValidationContextMock.SetupGet(c => c.Container).Returns(container);
            fileValidationContextMock.SetupGet(c => c.ValidationErrorsKey).Returns(validationErrorsKey);
            fileValidationContextMock.SetupSet(c => c.FileReference = tightFileReference).Verifiable();

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
