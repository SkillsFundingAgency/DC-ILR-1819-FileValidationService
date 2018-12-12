using Autofac;
using ESFA.DC.FileService;
using ESFA.DC.FileService.Interface;
using ESFA.DC.ILR.FileValidationService.Console.Stubs;
using ESFA.DC.ILR.FileValidationService.Rules;
using ESFA.DC.ILR.FileValidationService.Service;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Loose.Interface;
using ESFA.DC.ILR.Model.Loose.Schema;
using ESFA.DC.ILR.Model.Loose.Schema.Interface;
using ESFA.DC.ILR.Model.Mapper;
using ESFA.DC.ILR.Model.Mapper.Interface;
using ESFA.DC.IO.Dictionary;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Mapping.Interface;
using ESFA.DC.Serialization.Interfaces;
using ESFA.DC.Serialization.Json;
using ESFA.DC.Serialization.Xml;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Console
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder RegisterValidators(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ContactPreferenceValidator>().As<IValidator<ILooseContactPreference>>();
            containerBuilder.RegisterType<LearnerFamValidator>().As<IValidator<ILooseLearnerFAM>>();
            containerBuilder.RegisterType<ProviderSpecLearnerMonitoringValidator>().As<IValidator<ILooseProviderSpecLearnerMonitoring>>();
            containerBuilder.RegisterType<EmploymentStatusMonitoringValidator>().As<IValidator<ILooseEmploymentStatusMonitoring>>();
            containerBuilder.RegisterType<LearnerEmploymentStatusValidator>().As<IValidator<ILooseLearnerEmploymentStatus>>();
            containerBuilder.RegisterType<LearnerHEFinancialSupportValidator>().As<IValidator<ILooseLearnerHEFinancialSupport>>();
            containerBuilder.RegisterType<LearnerHEValidator>().As<IValidator<ILooseLearnerHE>>();
            containerBuilder.RegisterType<LLDDAndHealthProblemValidator>().As<IValidator<ILooseLLDDAndHealthProblem>>();
            containerBuilder.RegisterType<LearnerValidator>().As<IValidator<ILooseLearner>>();
            containerBuilder.RegisterType<DPOutcomeValidator>().As<IValidator<ILooseDPOutcome>>();
            containerBuilder.RegisterType<LearnerDestinationAndProgressionValidator>().As<IValidator<ILooseLearnerDestinationAndProgression>>();
            containerBuilder.RegisterType<LearningDeliveryFAMValidator>().As<IValidator<ILooseLearningDeliveryFAM>>();
            containerBuilder.RegisterType<AppFinRecordValidator>().As<IValidator<ILooseAppFinRecord>>();
            containerBuilder.RegisterType<ProviderSpecDeliveryMonitoringValidator>().As<IValidator<ILooseProviderSpecDeliveryMonitoring>>();
            containerBuilder.RegisterType<LearningDeliveryHEValidator>().As<IValidator<ILooseLearningDeliveryHE>>();
            containerBuilder.RegisterType<LearningDeliveryWorkPlacementValidator>().As<IValidator<ILooseLearningDeliveryWorkPlacement>>();
            containerBuilder.RegisterType<LearningDeliveryValidator>().As<IValidator<ILooseLearningDelivery>>();

            return containerBuilder;
        }

        public static ContainerBuilder RegisterSerializers(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<XmlSerializationService>().As<IXmlSerializationService>();
            containerBuilder.RegisterType<JsonSerializationService>().As<IJsonSerializationService>().As<ISerializationService>();

            return containerBuilder;
        }

        public static ContainerBuilder RegisterIoServices(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<FileSystemFileService>().As<IFileService>();
            containerBuilder.RegisterType<DictionaryKeyValuePersistenceService>().As<IKeyValuePersistenceService>();
            containerBuilder.RegisterType<StronglyTypedKeyValuePersistenceService>().As<IStronglyTypedKeyValuePersistenceService>();
            containerBuilder.RegisterType<FileValidationPreparationServiceStub>().As<IFileValidationPreparationService>();
            containerBuilder.RegisterType<FileValidationIOModelBuilder>().As<IFileValidationIOModelBuilder>();

            return containerBuilder;
        }

        public static ContainerBuilder RegisterValidationServices(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ValidationErrorHandler>().As<IValidationErrorHandler>();
            containerBuilder.RegisterType<IlrLooseXmlSchemaProvider>().As<IIlrLooseXmlSchemaProvider>();
            containerBuilder.RegisterType<ValidationErrorMetadataService>().As<IValidationErrorMetadataService>();
            containerBuilder.RegisterType<XsdValidationService>().As<IXsdValidationService>();
            containerBuilder.RegisterType<LooseMessageProvider>().As<ILooseMessageProvider>();
            containerBuilder.RegisterType<FileValidationRuleExecutionService>().As<IFileValidationRuleExecutionService>();
            containerBuilder.RegisterType<TightSchemaValidMessageFilterService>().As<ITightSchemaValidMessageFilterService>();
            containerBuilder.RegisterType<LooseToTightSchemaMapper>().As<IMapper<Model.Loose.Message, Message>>();
            containerBuilder.RegisterType<FileValidationOutputService>().As<IFileValidationOutputService>();
            containerBuilder.RegisterType<FileValidationOrchestrationService>().As<IFileValidationOrchestrationService>();

            return containerBuilder;
        }

        public static ContainerBuilder RegisterMappers(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<MessageMapper>().As<IModelMapper<Model.Loose.Message, Message>>();
            containerBuilder.RegisterType<HeaderMapper>().As<IModelMapper<Model.Loose.MessageHeader, MessageHeader>>();
            containerBuilder.RegisterType<CollectionDetailsMapper>().As<IModelMapper<Model.Loose.MessageHeaderCollectionDetails, MessageHeaderCollectionDetails>>();
            containerBuilder.RegisterType<SourceMapper>().As<IModelMapper<Model.Loose.MessageHeaderSource, MessageHeaderSource>>();
            containerBuilder.RegisterType<LearningProviderMapper>().As<IModelMapper<Model.Loose.MessageLearningProvider, MessageLearningProvider>>();
            containerBuilder.RegisterType<SourceFileMapper>().As<IModelMapper<Model.Loose.MessageSourceFile, MessageSourceFile>>();
            containerBuilder.RegisterType<LearnerMapper>().As<IModelMapper<Model.Loose.MessageLearner, MessageLearner>>();
            containerBuilder.RegisterType<ContactPreferenceMapper>().As<IModelMapper<Model.Loose.MessageLearnerContactPreference, MessageLearnerContactPreference>>();
            containerBuilder.RegisterType<LLDDAndHealthProblemMapper>().As<IModelMapper<Model.Loose.MessageLearnerLLDDandHealthProblem, MessageLearnerLLDDandHealthProblem>>();
            containerBuilder.RegisterType<LearnerEmploymentStatusMapper>().As<IModelMapper<Model.Loose.MessageLearnerLearnerEmploymentStatus, MessageLearnerLearnerEmploymentStatus>>();
            containerBuilder.RegisterType<LearnerFAMMapper>().As<IModelMapper<Model.Loose.MessageLearnerLearnerFAM, MessageLearnerLearnerFAM>>();
            containerBuilder.RegisterType<LearnerHEMapper>().As<IModelMapper<Model.Loose.MessageLearnerLearnerHE, MessageLearnerLearnerHE>>();
            containerBuilder.RegisterType<ProviderSpecLearnerMonitoringMapper>().As<IModelMapper<Model.Loose.MessageLearnerProviderSpecLearnerMonitoring, MessageLearnerProviderSpecLearnerMonitoring>>();
            containerBuilder.RegisterType<LearningDeliveryMapper>().As<IModelMapper<Model.Loose.MessageLearnerLearningDelivery, MessageLearnerLearningDelivery>>();
            containerBuilder.RegisterType<EmploymentStatusMonitoringMapper>().As<IModelMapper<Model.Loose.MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring, MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring>>();
            containerBuilder.RegisterType<LearnerHEFinancialSupportMapper>().As<IModelMapper<Model.Loose.MessageLearnerLearnerHELearnerHEFinancialSupport, MessageLearnerLearnerHELearnerHEFinancialSupport>>();
            containerBuilder.RegisterType<AppFinRecordMapper>().As<IModelMapper<Model.Loose.MessageLearnerLearningDeliveryAppFinRecord, MessageLearnerLearningDeliveryAppFinRecord>>();
            containerBuilder.RegisterType<LearningDeliveryFAMMapper>().As<IModelMapper<Model.Loose.MessageLearnerLearningDeliveryLearningDeliveryFAM, MessageLearnerLearningDeliveryLearningDeliveryFAM>>();
            containerBuilder.RegisterType<LearningDeliveryHEMapper>().As<IModelMapper<Model.Loose.MessageLearnerLearningDeliveryLearningDeliveryHE, MessageLearnerLearningDeliveryLearningDeliveryHE>>();
            containerBuilder.RegisterType<LearningDeliveryWorkPlacementMapper>().As<IModelMapper<Model.Loose.MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement, MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement>>();
            containerBuilder.RegisterType<ProviderSpecLearningDeliveryMonitoringMapper>().As<IModelMapper<Model.Loose.MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring, MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring>>();
            containerBuilder.RegisterType<LearnerDestinationAndProgressionMapper>().As<IModelMapper<Model.Loose.MessageLearnerDestinationandProgression, MessageLearnerDestinationandProgression>>();
            containerBuilder.RegisterType<DPOutcomeMapper>().As<IModelMapper<Model.Loose.MessageLearnerDestinationandProgressionDPOutcome, MessageLearnerDestinationandProgressionDPOutcome>>();

            return containerBuilder;
        }

        public static ContainerBuilder RegisterLogger(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<LoggerStub>().As<ILogger>();

            return containerBuilder;
        }
    }
}
