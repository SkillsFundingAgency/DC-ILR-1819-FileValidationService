using System;
using System.Diagnostics;
using System.Threading;
using System.Xml.Schema;
using ESFA.DC.FileService;
using ESFA.DC.FileService.Config;
using ESFA.DC.FileService.Config.Interface;
using ESFA.DC.FileService.Interface;
using ESFA.DC.ILR.FileValidationService.Rules;
using ESFA.DC.ILR.FileValidationService.Service;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Loose.Interface;
using ESFA.DC.ILR.Model.Loose.Schema;
using ESFA.DC.ILR.Model.Loose.Schema.Interface;
using ESFA.DC.IO.Dictionary;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Mapping.Interface;
using ESFA.DC.Serialization.Interfaces;
using ESFA.DC.Serialization.Json;
using ESFA.DC.Serialization.Xml;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            IFileValidationContext fileValidationContext = new FileValidationContext()
            {
                FileReference = "ILR-99999999-1819-20180626-144401-01.xml",
                Container = "Files",
                OutputFileReference = "ILR-99999999-1819-20180626-144401-02.xml",
                OutputContainer = "Files",
                ValidationErrorsKey = "ValidationErrors"
            };

            //IFileValidationContext fileValidationContext = new FileValidationContext()
            //{
            //    FileReference = @"10003231/ILR-10003231-1819-20181012-100001-01.xml",
            //    Container = "ilr-files",
            //    OutputFileReference = @"10003231/ILR-10003231-1819-20181012-100001-02.xml",
            //    OutputContainer = "ilr-files"
            //};

            //IAzureStorageFileServiceConfig azureStorageFileServiceConfig = new AzureStorageFileServiceConfig()
            //{
            //    ConnectionString = ""
            //};
            //IFileService fileService = new AzureStorageFileService(azureStorageFileServiceConfig);

            IFileService fileService = new FileSystemFileService();

            IValidationErrorHandler validationErrorHandler = new ValidationErrorHandler();
            IIlrLooseXmlSchemaProvider xmlSchemaProvider = new IlrLooseXmlSchemaProvider();
            IValidationErrorMetadataService validationErrorMetadataService = new ValidationErrorMetadataService();
            IXsdValidationService xsdValidationService = new XsdValidationService(xmlSchemaProvider, validationErrorHandler, validationErrorMetadataService);
            
            IXmlSerializationService xmlSerializationService = new XmlSerializationService();
            IJsonSerializationService jsonSerializationService = new JsonSerializationService();

            IKeyValuePersistenceService keyValuePersistenceService = new DictionaryKeyValuePersistenceService();

            IStronglyTypedKeyValuePersistenceService stronglyTypedKeyValuePersistenceService = new StronglyTypedKeyValuePersistenceService(jsonSerializationService, keyValuePersistenceService);

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

            ILooseMessageProvider looseMessageProvider = new LooseMessageProvider(fileService, xmlSerializationService, xsdValidationService);
            IFileValidationRuleExecutionService fileValidationRuleExecutionService = new FileValidationRuleExecutionService(learnerValidator, learningDeliveryValidator, learnerDestinationAndProgressionValidator);
            ITightSchemaValidMessageFilterService tightSchemaValidMessageFilterService = new TightSchemaValidMessageFilterService();
            IMapper<Model.Loose.Message, Message> mapper = new LooseToTightSchemaMapper();
            IFileValidationOutputService fileValidationOutputService = new FileValidationOutputService(xmlSerializationService, fileService, stronglyTypedKeyValuePersistenceService);

            IFileValidationOrchestrationService fileValidationOrchestrationService = new FileValidationOrchestrationService(
                looseMessageProvider,
                fileValidationRuleExecutionService,
                tightSchemaValidMessageFilterService,
                mapper,
                fileValidationOutputService);

            try
            {
                fileValidationOrchestrationService.Validate(fileValidationContext, CancellationToken.None).Wait();

                System.Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
                System.Console.Read();
            }
            catch (AggregateException aggregateException) when (aggregateException.InnerException is XmlSchemaException)
            {
                // Error Handle. Abort Job, go do XSD Validation Report.
            }
            catch(Exception exception)
            {
                // Job Failed
            }
        }
    }
}
