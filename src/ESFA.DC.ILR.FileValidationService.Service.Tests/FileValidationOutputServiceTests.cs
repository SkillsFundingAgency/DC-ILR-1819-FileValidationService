using System.Collections.Generic;
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
            var outputFileReference = "OutputFileReference";
            var outputContainer = "OutputContainer";

            var ilrFileContent = "IlrFileContent";

            var tightValidMessage = new Message();
            var validationErrors = new List<IValidationError>();

            var fileValidationContextMock = new Mock<IFileValidationContext>();
            var xmlSerializationServiceMock = new Mock<IXmlSerializationService>();
            var fileServiceMock = new Mock<IFileService>();

            fileValidationContextMock.SetupGet(c => c.OutputFileReference).Returns(outputFileReference);
            fileValidationContextMock.SetupGet(c => c.OutputContainer).Returns(outputContainer);

            xmlSerializationServiceMock.Setup(s => s.Serialize(tightValidMessage)).Returns(ilrFileContent).Verifiable();
            fileServiceMock.Setup(s => s.WriteStringAsync(ilrFileContent, outputFileReference, outputContainer, null)).Returns(Task.CompletedTask).Verifiable();

            await NewService(xmlSerializationServiceMock.Object, fileServiceMock.Object).Output(fileValidationContextMock.Object, tightValidMessage, validationErrors);

            xmlSerializationServiceMock.VerifyAll();
            fileServiceMock.VerifyAll();
        }

        private FileValidationOutputService NewService(IXmlSerializationService xmlSerializationService = null, IFileService fileService = null)
        {
            return new FileValidationOutputService(xmlSerializationService, fileService);
        }
    }
}
