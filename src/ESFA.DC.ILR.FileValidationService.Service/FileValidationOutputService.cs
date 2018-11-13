﻿using System.Collections.Generic;
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

        public FileValidationOutputService(IXmlSerializationService xmlSerializationService, IFileService fileService, IStronglyTypedKeyValuePersistenceService stronglyTypedKeyValuePersistenceService)
        {
            _xmlSerializationService = xmlSerializationService;
            _fileService = fileService;
            _stronglyTypedKeyValuePersistenceService = stronglyTypedKeyValuePersistenceService;
        }

        public async Task OutputAsync(IFileValidationContext fileValidationContext, Message message, IEnumerable<IValidationError> validationErrors, CancellationToken cancellationToken)
        {
            var outputFileReference = BuildOutputFileReference(fileValidationContext.FileReference);

            using (var fileStream = await _fileService.OpenWriteStreamAsync(outputFileReference, fileValidationContext.Container, cancellationToken))
            {
                _xmlSerializationService.Serialize(message, fileStream);
            }

            fileValidationContext.FileReference = outputFileReference;

            await _stronglyTypedKeyValuePersistenceService.SaveAsync(fileValidationContext.ValidationErrorsKey, validationErrors, cancellationToken);
        }

        public async Task OutputFileValidationFailureAsync(IFileValidationContext fileValidationContext, IEnumerable<IValidationError> validationErrors, CancellationToken cancellationToken)
        {
            await _stronglyTypedKeyValuePersistenceService.SaveAsync(fileValidationContext.ValidationErrorsKey, validationErrors, cancellationToken);
        }

        public string BuildOutputFileReference(string fileReference)
        {
            return fileReference.Insert(fileReference.Length - 4, "-Tight");
        }
    }
}
