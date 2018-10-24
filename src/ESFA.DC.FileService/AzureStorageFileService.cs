using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.FileService.Config.Interface;
using ESFA.DC.FileService.Interface;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.RetryPolicies;

namespace ESFA.DC.FileService
{
    public class AzureStorageFileService : IFileService
    {
        private readonly IAzureStorageFileServiceConfig _azureStorageFileServiceConfig;

        private readonly BlobRequestOptions _requestOptions = new BlobRequestOptions() { RetryPolicy = new LinearRetry(TimeSpan.FromSeconds(5), 3) };

        public AzureStorageFileService(IAzureStorageFileServiceConfig _azureStorageFileServiceConfig)
        {
            this._azureStorageFileServiceConfig = _azureStorageFileServiceConfig;
        }

        public async Task<Stream> OpenReadStreamAsync(string fileReference, string container, CancellationToken cancellationToken)
        {
            var cloudBlockBlob = await GetCloudBlockBlob(fileReference, container, cancellationToken);

            var stream = await cloudBlockBlob.OpenReadAsync(
                null,
                _requestOptions,
                null,
                cancellationToken);

            return stream;
        }

        public async Task<Stream> OpenWriteStreamAsync(string fileReference, string container, CancellationToken cancellationToken)
        {
            var cloudBlockBlob = await GetCloudBlockBlob(fileReference, container, cancellationToken);

            var stream = await cloudBlockBlob.OpenWriteAsync(
                null,
                _requestOptions,
                null,
                cancellationToken);

            return stream;
        }

        private async Task<CloudBlockBlob> GetCloudBlockBlob(string fileReference, string container, CancellationToken cancellationToken)
        {
            var cloudStorageAccount = CloudStorageAccount.Parse(_azureStorageFileServiceConfig.ConnectionString);
            var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            var cloudBlobContainer = cloudBlobClient.GetContainerReference(container);

            await cloudBlobContainer.CreateIfNotExistsAsync(BlobContainerPublicAccessType.Off, _requestOptions, null, cancellationToken);
            return cloudBlobContainer.GetBlockBlobReference(fileReference);
        }
    }
}
