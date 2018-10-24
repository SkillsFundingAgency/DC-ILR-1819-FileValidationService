using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.FileService.Interface;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.Model;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class FileValidationOutputService : IFileValidationOutputService
    {
        private readonly IXmlSerializationService _xmlSerializationService;
        private readonly IFileService _fileService;
        private readonly IStronglyTypedKeyValuePersistenceService _stronglyTypedKeyValuePersistenceService;

        public FileValidationOutputService(IXmlSerializationService xmlSerializationService, IFileService fileService, IStronglyTypedKeyValuePersistenceService stronglyTypedKeyValuePersistenceService)
        {
            _xmlSerializationService = xmlSerializationService;
            _fileService = fileService;
            _stronglyTypedKeyValuePersistenceService = stronglyTypedKeyValuePersistenceService;
        }

        public async Task OutputAsync(IFileValidationContext fileValidationContext, Message message, IEnumerable<IValidationError> validationErrors, CancellationToken cancellationToken)
        {
            using (var fileStream = await _fileService.OpenWriteStreamAsync(fileValidationContext.OutputFileReference, fileValidationContext.OutputContainer, cancellationToken))
            {
                _xmlSerializationService.Serialize(message, fileStream);
            }

            await _stronglyTypedKeyValuePersistenceService.SaveAsync(fileValidationContext.ValidationErrorsKey, validationErrors, cancellationToken);
        }
    }
}
