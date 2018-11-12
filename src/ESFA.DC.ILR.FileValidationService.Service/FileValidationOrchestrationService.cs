using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.FileValidationService.Service.Interface.Exception;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Mapping.Interface;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class FileValidationOrchestrationService : IFileValidationOrchestrationService
    {
        private readonly IFileValidationPreparationService _fileValidationPreparationService;
        private readonly ILooseMessageProvider _looseMessageProvider;
        private readonly IFileValidationRuleExecutionService _fileValidationRuleExecutionService;
        private readonly ITightSchemaValidMessageFilterService _tightSchemaValidMessageFilterService;
        private readonly IMapper<Model.Loose.Message, Model.Message> _mapper;
        private readonly IFileValidationOutputService _fileValidationOutputService;
        private readonly IValidationErrorHandler _validationErrorHandler;
        private readonly ILogger _logger;

        public FileValidationOrchestrationService(
            IFileValidationPreparationService fileValidationPreparationService,
            ILooseMessageProvider looseMessageProvider,
            IFileValidationRuleExecutionService fileValidationRuleExecutionService,
            ITightSchemaValidMessageFilterService tightSchemaValidMessageFilterService,
            IMapper<Model.Loose.Message, Model.Message> mapper,
            IFileValidationOutputService fileValidationOutputService,
            IValidationErrorHandler validationErrorHandler,
            ILogger logger)
        {
            _fileValidationPreparationService = fileValidationPreparationService;
            _looseMessageProvider = looseMessageProvider;
            _fileValidationRuleExecutionService = fileValidationRuleExecutionService;
            _tightSchemaValidMessageFilterService = tightSchemaValidMessageFilterService;
            _mapper = mapper;
            _fileValidationOutputService = fileValidationOutputService;
            _validationErrorHandler = validationErrorHandler;
            _logger = logger;
        }
        
        public async Task Validate(IFileValidationContext fileValidationContext, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInfo("Starting File Validation Preparation Service");
                await _fileValidationPreparationService.Prepare(fileValidationContext, cancellationToken);
                _logger.LogInfo("Finished File Validation Preparation Service");

                // Get File
                _logger.LogInfo("Starting Loose Message Provide");
                var looseMessage = await _looseMessageProvider.ProvideAsync(fileValidationContext, cancellationToken);
                _logger.LogInfo("Finished Loose Message Provide");

                // Validation Rules
                _logger.LogInfo("Starting Message Validation");
                _fileValidationRuleExecutionService.Execute(looseMessage);
                _logger.LogInfo("Finished Message Validation");

                var validationErrors = _validationErrorHandler.ValidationErrors.ToList();

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
            catch (Exception exception) when (exception is FileLoadException || exception is XmlSchemaException)
            {
                _logger.LogError("File Validation Failure Output", exception);
                await _fileValidationOutputService.OutputFileValidationFailureAsync(fileValidationContext, _validationErrorHandler.ValidationErrors, cancellationToken);
                throw new FileValidationServiceFileFailureException("File Validation Service File Failure", exception);
            }
        }
    }
}
