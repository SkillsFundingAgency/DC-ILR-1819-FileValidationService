using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
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

        public FileValidationOrchestrationService(
            ILooseMessageProvider looseMessageProvider,
            IFileValidationRuleExecutionService fileValidationRuleExecutionService,
            ITightSchemaValidMessageFilterService tightSchemaValidMessageFilterService,
            IMapper<Model.Loose.Message, Model.Message> mapper,
            IFileValidationOutputService fileValidationOutputService)
        {
            _looseMessageProvider = looseMessageProvider;
            _fileValidationRuleExecutionService = fileValidationRuleExecutionService;
            _tightSchemaValidMessageFilterService = tightSchemaValidMessageFilterService;
            _mapper = mapper;
            _fileValidationOutputService = fileValidationOutputService;
        }

        public async Task Validate(IFileValidationContext fileValidationContext, CancellationToken cancellationToken)
        {
            // Get File
            var looseMessage = await _looseMessageProvider.Provide(fileValidationContext, cancellationToken);
            
            // Validation Rules
            var validationErrors = _fileValidationRuleExecutionService.Execute(looseMessage);

            // Filter
            var validLooseMessage = _tightSchemaValidMessageFilterService.ApplyFilter(looseMessage, validationErrors);

            // Map to Tight Schema
            var tightMessage = _mapper.MapTo(validLooseMessage);
            
            // Output Tight Xml File
            await _fileValidationOutputService.Output(fileValidationContext, tightMessage, validationErrors, cancellationToken);
        }
    }
}
