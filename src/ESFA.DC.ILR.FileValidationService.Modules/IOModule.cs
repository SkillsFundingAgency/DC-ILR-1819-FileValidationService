using Autofac;
using ESFA.DC.FileService;
using ESFA.DC.FileService.Config.Interface;
using ESFA.DC.FileService.Interface;
using ESFA.DC.ILR.FileValidationService.Service;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.IO.Dictionary;
using ESFA.DC.IO.Interfaces;

namespace ESFA.DC.ILR.FileValidationService.Modules
{
    public class IOModule : Module
    {
        private readonly IAzureStorageFileServiceConfiguration _azureStorageFileServiceConfig;

        public IOModule(IAzureStorageFileServiceConfiguration azureStorageFileServiceConfig)
        {
            _azureStorageFileServiceConfig = azureStorageFileServiceConfig;
        }

        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterInstance(_azureStorageFileServiceConfig).As<IAzureStorageFileServiceConfiguration>();

            containerBuilder.RegisterType<AzureStorageFileService>().As<IFileService>();
            containerBuilder.RegisterType<DecompressionService>().As<IDecompressionService>();
            containerBuilder.RegisterType<DictionaryKeyValuePersistenceService>().As<IKeyValuePersistenceService>();
            containerBuilder.RegisterType<StronglyTypedKeyValuePersistenceService>().As<IStronglyTypedKeyValuePersistenceService>();
        }
    }
}
