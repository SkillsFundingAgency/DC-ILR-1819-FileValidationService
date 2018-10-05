using System.Threading.Tasks;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.Mapping.Interface;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class FileValidationOrchestrationService : IFileValidationOrchestrationService
    {
        private readonly ILooseMessageProvider _looseMessageProvider;
        private readonly IFileValidationRuleExecutionService _fileValidationRuleExecutionService;
        private readonly ITightSchemaValidMessageProviderService _tightSchemaValidMessageProviderService;
        private readonly IMapper<Model.Loose.Message, Model.Message> _mapper;
        private readonly IFileValidationOutputService _fileValidationOutputService;

        public FileValidationOrchestrationService(
            ILooseMessageProvider looseMessageProvider,
            IFileValidationRuleExecutionService fileValidationRuleExecutionService,
            ITightSchemaValidMessageProviderService tightSchemaValidMessageProviderService,
            IMapper<Model.Loose.Message, Model.Message> mapper,
            IFileValidationOutputService fileValidationOutputService)
        {
            _looseMessageProvider = looseMessageProvider;
            _fileValidationRuleExecutionService = fileValidationRuleExecutionService;
            _tightSchemaValidMessageProviderService = tightSchemaValidMessageProviderService;
            _mapper = mapper;
            _fileValidationOutputService = fileValidationOutputService;
        }

        public async Task Validate(IFileValidationContext fileValidationContext)
        {
            // Get File
            var looseMessage = await _looseMessageProvider.Provide(fileValidationContext);
            
            // Validation Rules
            var validationErrors = _fileValidationRuleExecutionService.Execute(looseMessage);

            // Filter
            var validLooseMessage = _tightSchemaValidMessageProviderService.Provide(looseMessage, validationErrors);

            // Map to Tight Schema
            var tightMessage = _mapper.MapTo(looseMessage);
            
            // Output Tight Xml File
            await _fileValidationOutputService.Output(tightMessage, validationErrors);
        }
    }
}
