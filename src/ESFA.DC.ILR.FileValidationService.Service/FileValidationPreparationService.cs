using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.FileService.Interface;
using ESFA.DC.ILR.FileValidationService.Service.Interface;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class FileValidationPreparationService : IFileValidationPreparationService
    {
        private const string XmlExtension = ".XML";
        private const string ZipExtension = ".ZIP";
        private const string ZipEmptyRuleName = "ZIP_EMPTY";
        private const string ZipTooManyFilesRuleName = "ZIP_TOO_MANY_FILES";

        private readonly IFileService _fileService;
        private readonly IDecompressionService _decompressionService;
        private readonly IValidationErrorHandler _validationErrorHandler;

        public FileValidationPreparationService(IFileService fileService, IDecompressionService decompressionService, IValidationErrorHandler validationErrorHandler)
        {
            _fileService = fileService;
            _decompressionService = decompressionService;
            _validationErrorHandler = validationErrorHandler;
        }

        public async Task Prepare(IFileValidationContext fileValidationContext, CancellationToken cancellationToken)
        {
            if (IsZip(fileValidationContext.FileReference))
            {
                using (var inputStream = await _fileService.OpenReadStreamAsync(fileValidationContext.FileReference, fileValidationContext.Container, cancellationToken))
                {
                    var archiveEntryFileNames = _decompressionService.GetZipArchiveEntryFileNames(inputStream).ToList();
                    
                    var archiveEntryXmlFileNames = archiveEntryFileNames.Where(n => n.IndexOf(XmlExtension, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

                    ValidateXmlFileNames(archiveEntryXmlFileNames);

                    var archiveEntryIlrXmlFileName = archiveEntryXmlFileNames.First();

                    var outputFileReference = BuildIlrXmlFileReference(fileValidationContext.FileReference);

                    using (var outputStream = await _fileService.OpenWriteStreamAsync(outputFileReference, fileValidationContext.Container, cancellationToken))
                    {
                        await _decompressionService.DecompressAsync(inputStream, outputStream, archiveEntryIlrXmlFileName, cancellationToken);
                    }

                    UpdateFileValidationContext(fileValidationContext, outputFileReference);
                }
            }
        }

        public bool ValidateXmlFileNames(IEnumerable<string> xmlFileNames)
        {
            if (!xmlFileNames.Any())
            {
                _validationErrorHandler.FileFailureErrorHandler(ZipEmptyRuleName);
                throw new FileLoadException("Zip File contains no Xml File.");
            }

            if (xmlFileNames.Count() > 1)
            {
                _validationErrorHandler.FileFailureErrorHandler(ZipTooManyFilesRuleName);
                throw new FileLoadException("Zip File contains more than one Xml File.");
            }

            return true;
        }

        public bool IsZip(string fileReference)
        {
            return fileReference.EndsWith(ZipExtension, StringComparison.OrdinalIgnoreCase);
        }

        public string BuildIlrXmlFileReference(string zipFile)
        {
            if (!IsZip(zipFile))
            {
                throw new ArgumentException("File is not a Zip File.");
            }

            var zipIndex = zipFile.IndexOf(ZipExtension, StringComparison.OrdinalIgnoreCase);

            return zipFile.Remove(zipIndex) + XmlExtension;
        }

        public void UpdateFileValidationContext(IFileValidationContext fileValidationContext, string outputFileReference)
        {
            fileValidationContext.FileReference = outputFileReference;
            fileValidationContext.OriginalFileReference = outputFileReference;
        }
    }
}
