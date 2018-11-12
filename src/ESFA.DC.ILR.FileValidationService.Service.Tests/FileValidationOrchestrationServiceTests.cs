using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.FileValidationService.Service.Interface.Exception;
using ESFA.DC.ILR.Model;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Mapping.Interface;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Service.Tests
{
    public class FileValidationOrchestrationServiceTests
    {
        [Fact]
        public async Task Validate()
        {
            var cancellationToken = CancellationToken.None;

            var fileValidationContextMock = new Mock<IFileValidationContext>();

            var fileValidationPreparationServiceMock = new Mock<IFileValidationPreparationService>();
            var looseMessageProviderMock = new Mock<ILooseMessageProvider>();
            var fileValidationRuleExecutionServiceMock = new Mock<IFileValidationRuleExecutionService>();
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            var tightSchemaValidMessageFilterServiceMock = new Mock<ITightSchemaValidMessageFilterService>();
            var mapperMock = new Mock<IMapper<Model.Loose.Message, Message>>();
            var fileValidationOutputServiceMock = new Mock<IFileValidationOutputService>();
            var loggerMock = new Mock<ILogger>();

            var looseMessage = new Model.Loose.Message();
            var validationErrors = new List<IValidationError>();
            var validLooseMessage = new Model.Loose.Message();
            var tightMessage = new Message();

            fileValidationPreparationServiceMock.Setup(s => s.Prepare(fileValidationContextMock.Object, cancellationToken)).Returns(Task.CompletedTask);
            looseMessageProviderMock.Setup(p => p.ProvideAsync(fileValidationContextMock.Object, cancellationToken)).Returns(Task.FromResult(looseMessage)).Verifiable();
            fileValidationRuleExecutionServiceMock.Setup(s => s.Execute(looseMessage)).Returns(validationErrors).Verifiable();
            validationErrorHandlerMock.SetupGet(h => h.ValidationErrors).Returns(validationErrors);
            tightSchemaValidMessageFilterServiceMock.Setup(s => s.ApplyFilter(looseMessage, validationErrors)).Returns(validLooseMessage).Verifiable();
            mapperMock.Setup(m => m.MapTo(validLooseMessage)).Returns(tightMessage).Verifiable();
            fileValidationOutputServiceMock.Setup(s => s.OutputAsync(fileValidationContextMock.Object, tightMessage, validationErrors, cancellationToken)).Returns(Task.CompletedTask).Verifiable();
            
            var service = NewService(fileValidationPreparationServiceMock.Object, looseMessageProviderMock.Object, fileValidationRuleExecutionServiceMock.Object, tightSchemaValidMessageFilterServiceMock.Object, mapperMock.Object, fileValidationOutputServiceMock.Object, validationErrorHandlerMock.Object, loggerMock.Object);

            await service.Validate(fileValidationContextMock.Object, cancellationToken);

            looseMessageProviderMock.VerifyAll();
            fileValidationRuleExecutionServiceMock.VerifyAll();
            tightSchemaValidMessageFilterServiceMock.VerifyAll();
            mapperMock.VerifyAll();
            fileValidationOutputServiceMock.VerifyAll();
        }

        [Fact]
        public async Task Validate_XmlSchemaException()
        {
            var cancellationToken = CancellationToken.None;

            var fileValidationContextMock = new Mock<IFileValidationContext>();

            var fileValidationPreparationServiceMock = new Mock<IFileValidationPreparationService>();
            var looseMessageProviderMock = new Mock<ILooseMessageProvider>();
            var fileValidationOutputServiceMock = new Mock<IFileValidationOutputService>();
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            var loggerMock = new Mock<ILogger>();

            var validationErrors = new List<IValidationError>();

            fileValidationPreparationServiceMock.Setup(s => s.Prepare(fileValidationContextMock.Object, cancellationToken)).Returns(Task.CompletedTask);
            looseMessageProviderMock.Setup(p => p.ProvideAsync(fileValidationContextMock.Object, cancellationToken)).Throws<XmlSchemaException>();

            fileValidationOutputServiceMock.Setup(s => s.OutputFileValidationFailureAsync(fileValidationContextMock.Object, validationErrors, cancellationToken)).Returns(Task.CompletedTask).Verifiable();
            validationErrorHandlerMock.SetupGet(h => h.ValidationErrors).Returns(validationErrors);

            var service = NewService(fileValidationPreparationServiceMock.Object, looseMessageProviderMock.Object, fileValidationOutputService: fileValidationOutputServiceMock.Object, validationErrorHandler: validationErrorHandlerMock.Object, logger: loggerMock.Object);

            var exception = Record.ExceptionAsync(() => service.Validate(fileValidationContextMock.Object, cancellationToken));

            exception.Result.Should().BeOfType<FileValidationServiceFileFailureException>();

            fileValidationPreparationServiceMock.VerifyAll();
            looseMessageProviderMock.VerifyAll();
            fileValidationOutputServiceMock.VerifyAll();
        }

        [Fact]
        public async Task Validate_FileLoadException()
        {
            var cancellationToken = CancellationToken.None;

            var fileValidationContextMock = new Mock<IFileValidationContext>();

            var fileValidationPreparationServiceMock = new Mock<IFileValidationPreparationService>();
            var fileValidationOutputServiceMock = new Mock<IFileValidationOutputService>();
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            var loggerMock = new Mock<ILogger>();

            var validationErrors = new List<IValidationError>();

            fileValidationPreparationServiceMock.Setup(s => s.Prepare(fileValidationContextMock.Object, cancellationToken)).Throws<FileLoadException>();

            fileValidationOutputServiceMock.Setup(s => s.OutputFileValidationFailureAsync(fileValidationContextMock.Object, validationErrors, cancellationToken)).Returns(Task.CompletedTask).Verifiable();
            validationErrorHandlerMock.SetupGet(h => h.ValidationErrors).Returns(validationErrors);

            var service = NewService(fileValidationPreparationServiceMock.Object, fileValidationOutputService: fileValidationOutputServiceMock.Object, validationErrorHandler: validationErrorHandlerMock.Object, logger: loggerMock.Object);

            var exception = Record.ExceptionAsync(() => service.Validate(fileValidationContextMock.Object, cancellationToken));

            exception.Result.Should().BeOfType<FileValidationServiceFileFailureException>();

            fileValidationPreparationServiceMock.VerifyAll();
            fileValidationOutputServiceMock.VerifyAll();
        }

        private FileValidationOrchestrationService NewService(IFileValidationPreparationService fileValidationPreparationService = null, ILooseMessageProvider looseMessageProvider = null, IFileValidationRuleExecutionService fileValidationRuleExecutionService = null, ITightSchemaValidMessageFilterService tightSchemaValidMessageFilterService = null, IMapper<Model.Loose.Message, Message> mapper = null, IFileValidationOutputService fileValidationOutputService = null, IValidationErrorHandler validationErrorHandler = null, ILogger logger = null)
        {
            return new FileValidationOrchestrationService(fileValidationPreparationService, looseMessageProvider, fileValidationRuleExecutionService, tightSchemaValidMessageFilterService, mapper, fileValidationOutputService, validationErrorHandler, logger);
        }
    }
}
