using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.FileService.Interface;

namespace ESFA.DC.FileService
{
    public class FileSystemFileService : IFileService
    {
        public Task<Stream> OpenReadStreamAsync(string fileReference, string container, CancellationToken cancellationToken)
        {
            var filePath = container != null ? Path.Combine(container, fileReference) : fileReference;
            
            return Task.FromResult(File.OpenRead(filePath) as Stream);
        }

        public Task<Stream> OpenWriteStreamAsync(string fileReference, string container, CancellationToken cancellationToken)
        {
            var filePath = container != null ? Path.Combine(container, fileReference) : fileReference;

            return Task.FromResult(File.OpenWrite(filePath) as Stream);
        }
    }
}
