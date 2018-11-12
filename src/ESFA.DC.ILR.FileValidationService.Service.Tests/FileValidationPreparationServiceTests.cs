using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.FileService.Interface;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Service.Tests
{
    public class FileValidationPreparationServiceTests
    {
        [Theory]
        [InlineData("a.zip")]
        [InlineData(".zip")]
        [InlineData("a.ZIP")]
        [InlineData("a.Zip")]
        public void IsZip_True(string fileName)
        {
            NewService().IsZip(fileName).Should().BeTrue();
        }

        [Theory]
        [InlineData("a.xml")]
        [InlineData("")]
        public void IsZip_False(string fileName)
        {
            NewService().IsZip(fileName).Should().BeFalse();
        }

        [Fact]
        public void BuildIlrXmlFileReference()
        {
            NewService().BuildIlrXmlFileReference("a.zip").Should().Be("a.xml");
        }

        [Fact]
        public void BuildIlrXmlFileReference_FileNotZip()
        {
            Action action = () => NewService().BuildIlrXmlFileReference("a.xml");

            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void UpdateFileValidationContext()
        {
            var fileName = "FileName";
            var fileValidationContextMock = new Mock<IFileValidationContext>();

            fileValidationContextMock.SetupSet(c => c.FileReference = fileName).Verifiable();
            fileValidationContextMock.SetupSet(c => c.OriginalFileReference = fileName).Verifiable();

            NewService().UpdateFileValidationContext(fileValidationContextMock.Object, fileName);

            fileValidationContextMock.VerifyAll();
        }

        [Fact]
        public void ValidateXmlFileNames_Valid()
        {
            NewService().ValidateXmlFileNames(new[] { "a.xml" }).Should().BeTrue();
        }

        [Fact]
        public void ValidateXmlFileNames_Invalid_Empty()
        {
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();

            validationErrorHandlerMock.Setup(h => h.FileFailureErrorHandler("ZIP_EMPTY")).Verifiable();

            Action action = () => NewService(validationErrorHandler: validationErrorHandlerMock.Object).ValidateXmlFileNames(new string[] { });

            action.Should().Throw<FileLoadException>();

            validationErrorHandlerMock.Verify();
        }

        [Fact]
        public void ValidateXmlFileNames_Invalid_MoreThanOne()
        {
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();

            validationErrorHandlerMock.Setup(h => h.FileFailureErrorHandler("ZIP_TOO_MANY_FILES")).Verifiable();

            Action action = () => NewService(validationErrorHandler: validationErrorHandlerMock.Object).ValidateXmlFileNames(new string[] { "a.xml", "b.xml" });

            action.Should().Throw<FileLoadException>();
        }

        [Fact]
        public async Task Prepare()
        {
            var fileReference = "FileReference.zip";
            var outputFileReference = "FileReference.xml";
            var container = "Container";
            var xmlFileName = "a.xml";
            Stream inputStream = new MemoryStream();
            Stream outputStream = new MemoryStream();
            var xmlFileNames = new List<string>() { xmlFileName };

            var cancellationToken = CancellationToken.None;

            var fileValidationContextMock = new Mock<IFileValidationContext>();
            var fileServiceMock = new Mock<IFileService>();
            var decompressionServiceMock = new Mock<IDecompressionService>();

            fileValidationContextMock.SetupGet(c => c.FileReference).Returns(fileReference).Verifiable();
            fileValidationContextMock.SetupGet(c => c.Container).Returns(container).Verifiable();
            fileServiceMock.Setup(fs => fs.OpenReadStreamAsync(fileReference, container, cancellationToken)).Returns(Task.FromResult(inputStream)).Verifiable();
            decompressionServiceMock.Setup(ds => ds.GetZipArchiveEntryFileNames(inputStream)).Returns(xmlFileNames).Verifiable();
            fileServiceMock.Setup(fs => fs.OpenWriteStreamAsync(outputFileReference, container, cancellationToken)).Returns(Task.FromResult(outputStream)).Verifiable();
            decompressionServiceMock.Setup(ds => ds.DecompressAsync(inputStream, outputStream, xmlFileName, cancellationToken)).Returns(Task.CompletedTask).Verifiable();
            fileValidationContextMock.SetupSet(c => c.FileReference = outputFileReference).Verifiable();
            fileValidationContextMock.SetupSet(c => c.OriginalFileReference = outputFileReference).Verifiable();

            await NewService(fileServiceMock.Object, decompressionServiceMock.Object).Prepare(fileValidationContextMock.Object, cancellationToken);

            fileServiceMock.VerifyAll();
            decompressionServiceMock.VerifyAll();
            fileValidationContextMock.VerifyAll();
        }

        private FileValidationPreparationService NewService(IFileService fileService = null, IDecompressionService decompressionService = null, IValidationErrorHandler validationErrorHandler = null)
        {
            return new FileValidationPreparationService(fileService, decompressionService, validationErrorHandler);
        }
    }
}
