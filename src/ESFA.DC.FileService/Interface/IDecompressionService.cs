using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.FileService.Interface
{
    public interface IDecompressionService
    {
        IEnumerable<string> GetZipArchiveEntryFileNames(Stream inputStream);

        Task DecompressAsync(Stream inputStream, Stream outputStream, string fileIdentifier, CancellationToken cancellationToken);
    }
}
