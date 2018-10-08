using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.Model;
using ESFA.DC.Mapping.Interface;
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
            var looseMessageProviderMock = new Mock<ILooseMessageProvider>();
            var fileValidationRuleExecutionServiceMock = new Mock<IFileValidationRuleExecutionService>();
            var tightSchemaValidMessageFilterServiceMock = new Mock<ITightSchemaValidMessageFilterService>();
            var mapperMock = new Mock<IMapper<Model.Loose.Message, Message>>();
            var fileValidationOutputServiceMock = new Mock<IFileValidationOutputService>();

            var looseMessage = new Model.Loose.Message();
            var validationErrors = new List<IValidationError>();
            var validLooseMessage = new Model.Loose.Message();
            var tightMessage = new Message();

            looseMessageProviderMock.Setup(p => p.Provide(fileValidationContextMock.Object, cancellationToken)).Returns(Task.FromResult(looseMessage)).Verifiable();
            fileValidationRuleExecutionServiceMock.Setup(s => s.Execute(looseMessage)).Returns(validationErrors).Verifiable();
            tightSchemaValidMessageFilterServiceMock.Setup(s => s.ApplyFilter(looseMessage, validationErrors)).Returns(validLooseMessage).Verifiable();
            mapperMock.Setup(m => m.MapTo(validLooseMessage)).Returns(tightMessage).Verifiable();
            fileValidationOutputServiceMock.Setup(s => s.Output(fileValidationContextMock.Object, tightMessage, validationErrors, cancellationToken)).Returns(Task.CompletedTask).Verifiable();
            
            var service = NewService(looseMessageProviderMock.Object, fileValidationRuleExecutionServiceMock.Object, tightSchemaValidMessageFilterServiceMock.Object, mapperMock.Object, fileValidationOutputServiceMock.Object);

            await service.Validate(fileValidationContextMock.Object, cancellationToken);

            looseMessageProviderMock.VerifyAll();
            fileValidationRuleExecutionServiceMock.VerifyAll();
            tightSchemaValidMessageFilterServiceMock.VerifyAll();
            mapperMock.VerifyAll();
            fileValidationOutputServiceMock.VerifyAll();
        }

        private FileValidationOrchestrationService NewService(ILooseMessageProvider looseMessageProvider = null, IFileValidationRuleExecutionService fileValidationRuleExecutionService = null, ITightSchemaValidMessageFilterService tightSchemaValidMessageFilterService = null, IMapper<Model.Loose.Message, Message> mapper = null, IFileValidationOutputService fileValidationOutputService = null)
        {
            return new FileValidationOrchestrationService(looseMessageProvider, fileValidationRuleExecutionService, tightSchemaValidMessageFilterService, mapper, fileValidationOutputService);
        }
    }
}
