using Autofac;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Mapper;
using ESFA.DC.ILR.Model.Mapper.Interface;

namespace ESFA.DC.ILR.FileValidationService.Modules
{
    public class MapperModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
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
            containerBuilder.RegisterType<EmploymentStatusMonitoringMapper>().As<IModelMapper<Model.Loose.MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring,MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring>>();
            containerBuilder.RegisterType<LearnerHEFinancialSupportMapper>().As<IModelMapper<Model.Loose.MessageLearnerLearnerHELearnerHEFinancialSupport, MessageLearnerLearnerHELearnerHEFinancialSupport>>();
            containerBuilder.RegisterType<AppFinRecordMapper>().As<IModelMapper<Model.Loose.MessageLearnerLearningDeliveryAppFinRecord, MessageLearnerLearningDeliveryAppFinRecord>>();
            containerBuilder.RegisterType<LearningDeliveryFAMMapper>().As<IModelMapper<Model.Loose.MessageLearnerLearningDeliveryLearningDeliveryFAM, MessageLearnerLearningDeliveryLearningDeliveryFAM>>();
            containerBuilder.RegisterType<LearningDeliveryHEMapper>().As<IModelMapper<Model.Loose.MessageLearnerLearningDeliveryLearningDeliveryHE, MessageLearnerLearningDeliveryLearningDeliveryHE>>();
            containerBuilder.RegisterType<LearningDeliveryWorkPlacementMapper>().As<IModelMapper<Model.Loose.MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement, MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement>>();
            containerBuilder.RegisterType<LearnerDestinationAndProgressionMapper>().As<IModelMapper<Model.Loose.MessageLearnerDestinationandProgression, MessageLearnerDestinationandProgression>>();
            containerBuilder.RegisterType<DPOutcomeMapper>().As<IModelMapper<Model.Loose.MessageLearnerDestinationandProgressionDPOutcome, MessageLearnerDestinationandProgressionDPOutcome>>();
        }
    }
}
