using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.FileService.Interface;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.Model;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class FileValidationOutputService : IFileValidationOutputService
    {
        private readonly IXmlSerializationService _xmlSerializationService;
        private readonly IFileService _fileService;
        private readonly IStronglyTypedKeyValuePersistenceService _stronglyTypedKeyValuePersistenceService;
        private readonly IFileValidationIOModelBuilder _fileValidationIoModelBuilder;

        public FileValidationOutputService(IXmlSerializationService xmlSerializationService, IFileService fileService, IStronglyTypedKeyValuePersistenceService stronglyTypedKeyValuePersistenceService, IFileValidationIOModelBuilder fileValidationIoModelBuilder)
        {
            _xmlSerializationService = xmlSerializationService;
            _fileService = fileService;
            _stronglyTypedKeyValuePersistenceService = stronglyTypedKeyValuePersistenceService;
            _fileValidationIoModelBuilder = fileValidationIoModelBuilder;
        }

        public async Task OutputAsync(IFileValidationContext fileValidationContext, Message message, IEnumerable<IValidationError> validationErrors, CancellationToken cancellationToken)
        {
            var outputFileReference = BuildOutputFileReference(fileValidationContext.FileReference);

            using (var fileStream = await _fileService.OpenWriteStreamAsync(outputFileReference, fileValidationContext.Container, cancellationToken))
            {
                _xmlSerializationService.Serialize(message, fileStream);
            }

            fileValidationContext.FileReference = outputFileReference;

            var ioValidationErrors = _fileValidationIoModelBuilder.BuildValidationErrors(validationErrors).ToList();

            await _stronglyTypedKeyValuePersistenceService.SaveAsync(fileValidationContext.ValidationErrorsKey, ioValidationErrors, cancellationToken);
        }

        public async Task OutputFileValidationFailureAsync(IFileValidationContext fileValidationContext, IEnumerable<IValidationError> validationErrors, CancellationToken cancellationToken)
        {
            var ioValidationErrors = _fileValidationIoModelBuilder.BuildValidationErrors(validationErrors).ToList();

            await _stronglyTypedKeyValuePersistenceService.SaveAsync(fileValidationContext.ValidationErrorsKey, ioValidationErrors, cancellationToken);
        }

        public string BuildOutputFileReference(string fileReference)
        {
            return fileReference.Insert(fileReference.Length - 4, "-Tight");
        }
    }
}
