using System.IO;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.FileService.Interface;

namespace ESFA.DC.FileService
{
    public class FileSystemFileService : IFileService
    {
        public Task<string> ReadStringAsync(string fileReference, string container = null, Encoding encoding = null)
        {
            var filePath = container != null ? Path.Combine(container, fileReference) : fileReference;

            var fileContent = encoding != null ? File.ReadAllText(filePath, encoding) : File.ReadAllText(filePath);

            return Task.FromResult(fileContent);
        }

        public Task<Stream> OpenStreamAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task WriteStringAsync(string content, string fileReference, string container = null, Encoding encoding = null)
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

        public Task WriteToStreamAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
