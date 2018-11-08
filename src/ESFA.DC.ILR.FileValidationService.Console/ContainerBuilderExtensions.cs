using Autofac;
using ESFA.DC.FileService;
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
    }
}
