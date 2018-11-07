using ESFA.DC.FileService.Config.Interface;

namespace ESFA.DC.FileService.Config
{
    public class AzureStorageFileServiceConfiguration : IAzureStorageFileServiceConfiguration
    {
        public string ConnectionString { get; set; }
    }
}
