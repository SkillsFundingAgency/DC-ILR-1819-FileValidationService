﻿using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.FileService.Interface
{
    public interface IFileService
    {
        Task<string> ReadStringAsync(string fileReference, string container, CancellationToken cancellationToken, Encoding encoding = null);

        Task<Stream> OpenReadStreamAsync(string fileReference, string container, CancellationToken cancellationToken, Encoding encoding = null);

        Task<Stream> OpenWriteStreamAsync(string fileReference, string container, CancellationToken cancellationToken, Encoding encoding = null);

        Task WriteStringAsync(string content, string fileReference, string container, CancellationToken cancellationToken, Encoding encoding = null);

        Task WriteFromStreamAsync(Stream stream, string fileReference, string container, CancellationToken cancellationToken, Encoding encoding = null);
    }
}
