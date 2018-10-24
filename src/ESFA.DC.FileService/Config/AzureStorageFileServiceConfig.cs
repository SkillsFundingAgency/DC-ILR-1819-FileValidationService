using ESFA.DC.FileService.Config.Interface;

namespace ESFA.DC.FileService.Config
{
    public class AzureStorageFileServiceConfig : IAzureStorageFileServiceConfig
    {
        public string ConnectionString { get; set; }
    }
}
