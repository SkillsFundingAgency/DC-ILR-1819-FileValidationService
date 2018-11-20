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
        }
    }
}
