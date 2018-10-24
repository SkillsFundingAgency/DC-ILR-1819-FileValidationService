using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.FileService.Interface
{
    public interface IFileService
    {
        Task<Stream> OpenReadStreamAsync(string fileReference, string container, CancellationToken cancellationToken);

        Task<Stream> OpenWriteStreamAsync(string fileReference, string container, CancellationToken cancellationToken);
    }
}
