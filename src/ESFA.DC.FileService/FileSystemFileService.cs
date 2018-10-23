using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.FileService.Interface;

namespace ESFA.DC.FileService
{
    public class FileSystemFileService : IFileService
    {
        public Task<string> ReadStringAsync(string fileReference, string container, CancellationToken cancellationToken, Encoding encoding = null)
        {
            var filePath = container != null ? Path.Combine(container, fileReference) : fileReference;

            var fileContent = encoding != null ? File.ReadAllText(filePath, encoding) : File.ReadAllText(filePath);

            return Task.FromResult(fileContent);
        }

        public Task<Stream> OpenReadStreamAsync(string fileReference, string container, CancellationToken cancellationToken, Encoding encoding = null)
        {
            var filePath = container != null ? Path.Combine(container, fileReference) : fileReference;
            
            return Task.FromResult(File.OpenRead(filePath) as Stream);
        }

        public Task<Stream> OpenWriteStreamAsync(string fileReference, string container, CancellationToken cancellationToken, Encoding encoding = null)
        {
            var filePath = container != null ? Path.Combine(container, fileReference) : fileReference;

            return Task.FromResult(File.OpenWrite(filePath) as Stream);
        }

        public Task WriteStringAsync(string content, string fileReference, string container, CancellationToken cancellationToken, Encoding encoding = null)
        {
            var filePath = container != null ? Path.Combine(container, fileReference) : fileReference;

            if (encoding != null)
            {
                File.WriteAllText(filePath, content, encoding);
            }
            else
            {
                File.WriteAllText(filePath, content);
            }

            return Task.CompletedTask;
        }

        public Task WriteFromStreamAsync(Stream stream, string fileReference, string container, CancellationToken cancellationToken, Encoding encoding = null)
        {
            var filePath = container != null ? Path.Combine(container, fileReference) : fileReference;

            using (var outputStream = File.OpenWrite(filePath))
            {
                return stream.CopyToAsync(outputStream);
            }
        }
    }
}
