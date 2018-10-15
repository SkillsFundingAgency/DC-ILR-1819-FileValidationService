using System.Threading;
using ESFA.DC.FileService;
using ESFA.DC.FileService.Interface;
using ESFA.DC.ILR.FileValidationService.Rules;
using ESFA.DC.ILR.FileValidationService.Service;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Loose.Interface;
using ESFA.DC.Mapping.Interface;
using ESFA.DC.Serialization.Interfaces;
using ESFA.DC.Serialization.Xml;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IFileValidationContext fileValidationContext = new FileValidationContext()
            {
                FileReference = "ILR-99999999-1819-20180626-144401-01.xml",
                Container = "Files",
                OutputFileReference = "ILR-99999999-1819-20180626-144401-02.xml",
                OutputContainer = "Files"
            };

            IFileService fileService = new FileSystemFileService();
            IXmlSerializationService xmlSerializationService = new XmlSerializationService();
            
            IValidator<ILooseContactPreference> contactPreferenceValidator = new ContactPreferenceValidator();
            IValidator<ILooseLearnerFAM> learnerFamValidator = new LearnerFamValidator();
            IValidator<ILooseProviderSpecLearnerMonitoring> providerSpecLearnerMonitoringValidator = new ProviderSpecLearnerMonitoringValidator();
            IValidator<ILooseEmploymentStatusMonitoring> employmentStatusMonitoringValidator = new EmploymentStatusMonitoringValidator();
            IValidator<ILooseLearnerEmploymentStatus> learnerEmploymentStatusValidator = new LearnerEmploymentStatusValidator(employmentStatusMonitoringValidator);
            IValidator<ILooseLearnerHEFinancialSupport> learnerHEFinancialSupportValidator = new LearnerHEFinancialSupportValidator();
            IValidator<ILooseLearnerHE> learnerHeValidator = new LearnerHEValidator(learnerHEFinancialSupportValidator);
            IValidator<ILooseLLDDAndHealthProblem> llddAndHealthProblemValidator = new LLDDAndHealthProblemValidator();
            IValidator<ILooseLearner> learnerValidator = new LearnerValidator(contactPreferenceValidator, learnerFamValidator, providerSpecLearnerMonitoringValidator, learnerEmploymentStatusValidator, learnerHeValidator, llddAndHealthProblemValidator);

            IValidator<ILooseDPOutcome> dpOutcomeValidator = new DPOutcomeValidator();
            IValidator<ILooseLearnerDestinationAndProgression> learnerDestinationAndProgressionValidator = new LearnerDestinationAndProgressionValidator(dpOutcomeValidator);
            
            IValidator<ILooseLearningDeliveryFAM> learningDeliveryFAMValidator = new LearningDeliveryFAMValidator();
            IValidator<ILooseAppFinRecord> appFinRecordValidator = new AppFinRecordValidator();
            IValidator<ILooseProviderSpecDeliveryMonitoring> providerSpecDeliveryMonitoringValidator = new ProviderSpecDeliveryMonitoringValidator();
            IValidator<ILooseLearningDeliveryHE> learningDeliveryHEValidator = new LearningDeliveryHEValidator();
            IValidator<ILooseLearningDeliveryWorkPlacement> learningDeliveryWorkPlacementValidator = new LearningDeliveryWorkPlacementValidator();
            IValidator<ILooseLearningDelivery> learningDeliveryValidator = new LearningDeliveryValidator(learningDeliveryFAMValidator, appFinRecordValidator, providerSpecDeliveryMonitoringValidator, learningDeliveryHEValidator, learningDeliveryWorkPlacementValidator);

            ILooseMessageProvider looseMessageProvider = new LooseMessageProvider(fileService, xmlSerializationService);
            IFileValidationRuleExecutionService fileValidationRuleExecutionService = new FileValidationRuleExecutionService(learnerValidator, learningDeliveryValidator, learnerDestinationAndProgressionValidator);
            ITightSchemaValidMessageFilterService tightSchemaValidMessageFilterService = new TightSchemaValidMessageFilterService();
            IMapper<Model.Loose.Message, Message> mapper = new LooseToTightSchemaMapper();
            IFileValidationOutputService fileValidationOutputService = new FileValidationOutputService(xmlSerializationService, fileService);

            IFileValidationOrchestrationService fileValidationOrchestrationService = new FileValidationOrchestrationService(
                looseMessageProvider,
                fileValidationRuleExecutionService,
                tightSchemaValidMessageFilterService,
                mapper,
                fileValidationOutputService);

            fileValidationOrchestrationService.Validate(fileValidationContext, CancellationToken.None).Wait();
        }
    }
}
