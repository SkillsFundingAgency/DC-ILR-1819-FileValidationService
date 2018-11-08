using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Mapping.Interface;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class FileValidationOrchestrationService : IFileValidationOrchestrationService
    {
        private readonly ILooseMessageProvider _looseMessageProvider;
        private readonly IFileValidationRuleExecutionService _fileValidationRuleExecutionService;
        private readonly ITightSchemaValidMessageFilterService _tightSchemaValidMessageFilterService;
        private readonly IMapper<Model.Loose.Message, Model.Message> _mapper;
        private readonly IFileValidationOutputService _fileValidationOutputService;
        private readonly ILogger _logger;

        public FileValidationOrchestrationService(
            ILooseMessageProvider looseMessageProvider,
            IFileValidationRuleExecutionService fileValidationRuleExecutionService,
            ITightSchemaValidMessageFilterService tightSchemaValidMessageFilterService,
            IMapper<Model.Loose.Message, Model.Message> mapper,
            IFileValidationOutputService fileValidationOutputService,
            ILogger logger)
        {
            _looseMessageProvider = looseMessageProvider;
            _fileValidationRuleExecutionService = fileValidationRuleExecutionService;
            _tightSchemaValidMessageFilterService = tightSchemaValidMessageFilterService;
            _mapper = mapper;
            _fileValidationOutputService = fileValidationOutputService;
            _logger = logger;
        }

        public async Task Validate(IFileValidationContext fileValidationContext, CancellationToken cancellationToken)
        {
            // Get File
            _logger.LogInfo("Starting Loose Message Provide");
            var looseMessage = await _looseMessageProvider.ProvideAsync(fileValidationContext, cancellationToken);
            _logger.LogInfo("Finished Loose Message Provide");

            // Validation Rules
            _logger.LogInfo("Starting Message Validation");
            var validationErrors = _fileValidationRuleExecutionService.Execute(looseMessage);
            _logger.LogInfo("Finished Message Validation");

            // Filter
            _logger.LogInfo("Starting Valid Learner Filter");
            var validLooseMessage = _tightSchemaValidMessageFilterService.ApplyFilter(looseMessage, validationErrors);
            _logger.LogInfo("Finished Valid Learner Filter");

            // Map to Tight Schema
            _logger.LogInfo("Starting Map to Tight Schema");
            var tightMessage = _mapper.MapTo(validLooseMessage);
            _logger.LogInfo("Finished Map to Tight Schema");

            // Output Tight Xml File
            _logger.LogInfo("Starting Validation Output");
            await _fileValidationOutputService.OutputAsync(fileValidationContext, tightMessage, validationErrors, cancellationToken);
            _logger.LogInfo("Finished Validation Output");
        }
    }
}
