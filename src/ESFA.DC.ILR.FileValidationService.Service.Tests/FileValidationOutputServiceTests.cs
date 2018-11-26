using System.Collections;
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
            var tightFileReference = @"UKPRN/OutputFileReference-Tight.xml";
            var container = "Container";
            var validationErrorsKey = "ValidationErrorsKey";

            var ilrFileContent = "IlrFileContent";

            var tightValidMessage = new Message();
            IEnumerable<IValidationError> validationErrors = new List<IValidationError>();
            IEnumerable<IO.Model.Validation.ValidationError> ioValidationErrors = new List<IO.Model.Validation.ValidationError>();
            Stream stream = new MemoryStream();

            var fileValidationContextMock = new Mock<IFileValidationContext>();
            var xmlSerializationServiceMock = new Mock<IXmlSerializationService>();
            var fileServiceMock = new Mock<IFileService>();
            var stronglyTypedKeyValuePersistenceService = new Mock<IStronglyTypedKeyValuePersistenceService>();
            var fileValidationIoModelBuilderMock = new Mock<IFileValidationIOModelBuilder>();

            fileServiceMock.Setup(s => s.OpenWriteStreamAsync(tightFileReference, container, cancellationToken)).Returns(Task.FromResult(stream)).Verifiable();

            fileValidationContextMock.SetupGet(c => c.FileReference).Returns(fileReference).Verifiable();
            fileValidationContextMock.SetupGet(c => c.Container).Returns(container);
            fileValidationContextMock.SetupGet(c => c.ValidationErrorsKey).Returns(validationErrorsKey);
            fileValidationContextMock.SetupSet(c => c.FileReference = tightFileReference).Verifiable();

            xmlSerializationServiceMock.Setup(s => s.Serialize(tightValidMessage, stream)).Verifiable();

            stronglyTypedKeyValuePersistenceService.Setup(ps => ps.SaveAsync(validationErrorsKey, ioValidationErrors, cancellationToken)).Returns(Task.CompletedTask).Verifiable();

            fileValidationIoModelBuilderMock.Setup(b => b.BuildValidationErrors(validationErrors)).Returns(ioValidationErrors);

            await NewService(xmlSerializationServiceMock.Object, fileServiceMock.Object, stronglyTypedKeyValuePersistenceService.Object, fileValidationIoModelBuilderMock.Object)
                .OutputAsync(fileValidationContextMock.Object, tightValidMessage, validationErrors, cancellationToken);

            xmlSerializationServiceMock.VerifyAll();
            fileServiceMock.VerifyAll();
            stronglyTypedKeyValuePersistenceService.VerifyAll();
        }

        [Fact]
        public async Task OutputFileValidationFailureAsync()
        {
            var cancellationToken = CancellationToken.None;

            var validationErrorsKey = "ValidationErrorsKey";
            
            IEnumerable<IValidationError> validationErrors = new List<IValidationError>();
            IEnumerable<IO.Model.Validation.ValidationError> ioValidationErrors = new List<IO.Model.Validation.ValidationError>();

            var fileValidationContextMock = new Mock<IFileValidationContext>();
            var stronglyTypedKeyValuePersistenceService = new Mock<IStronglyTypedKeyValuePersistenceService>();
            var fileValidationIoModelBuilder = new Mock<IFileValidationIOModelBuilder>();
            
            fileValidationContextMock.SetupGet(c => c.ValidationErrorsKey).Returns(validationErrorsKey);
            stronglyTypedKeyValuePersistenceService.Setup(ps => ps.SaveAsync(validationErrorsKey, ioValidationErrors, cancellationToken)).Returns(Task.CompletedTask).Verifiable();
            fileValidationIoModelBuilder.Setup(b => b.BuildValidationErrors(validationErrors)).Returns(ioValidationErrors);

            await NewService(stronglyTypedKeyValuePersistenceService: stronglyTypedKeyValuePersistenceService.Object, fileValidationIoModelBuilder: fileValidationIoModelBuilder.Object)
                .OutputFileValidationFailureAsync(fileValidationContextMock.Object, validationErrors, cancellationToken);

            stronglyTypedKeyValuePersistenceService.VerifyAll();
        }

        private FileValidationOutputService NewService(IXmlSerializationService xmlSerializationService = null, IFileService fileService = null, IStronglyTypedKeyValuePersistenceService stronglyTypedKeyValuePersistenceService = null, IFileValidationIOModelBuilder fileValidationIoModelBuilder = null)
        {
            return new FileValidationOutputService(xmlSerializationService, fileService, stronglyTypedKeyValuePersistenceService, fileValidationIoModelBuilder);
        }
    }
}
