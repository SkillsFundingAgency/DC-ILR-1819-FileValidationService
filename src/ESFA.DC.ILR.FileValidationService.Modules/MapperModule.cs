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
        }
    }
}
