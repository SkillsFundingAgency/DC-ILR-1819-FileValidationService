using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.FileService.Interface;

namespace ESFA.DC.FileService
{
    public class DecompressionService : IDecompressionService
    {
        public IEnumerable<string> GetZipArchiveEntryFileNames(Stream inputStream)
        {
            using (var zipArchive = new ZipArchive(inputStream, ZipArchiveMode.Read, true))
            {
                return zipArchive.Entries.Select(e => e.Name);
            }
        }

        public async Task DecompressAsync(Stream inputStream, Stream outputStream, string fileIdentifier, CancellationToken cancellationToken)
        {
            using (var zipArchive = new ZipArchive(inputStream, ZipArchiveMode.Read, true))
            {
                var zipArchiveEntry = zipArchive.Entries.First(e => e.Name == fileIdentifier);

                using (var zipArchiveEntryStream = zipArchiveEntry.Open())
                {
                    await zipArchiveEntryStream.CopyToAsync(outputStream, 81920, cancellationToken);
                }
            }
        }
    }
}
